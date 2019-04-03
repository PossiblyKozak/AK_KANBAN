USE [AK_KANBAN]
GO

--Below is the procedure for returning the first open order ID to the user
CREATE PROCEDURE GetOpenOrder
AS
	SELECT TOP 1 [ID], [ReqLamp] FROM tblOrders
	WHERE [CompLamps] < [ReqLamp];
GO

--BELOW IS THE PROCEDURE TO GET THE SIMULATION SPEED
CREATE PROCEDURE GetSimSpeed
AS
	SELECT [Value] FROM tblConfig
	WHERE [Option] = 'SimulationSpeed';
GO

--BELOW IS THE PROCEDURE TO GET THE GET SECODNS PER LAMP
CREATE PROCEDURE GetSecondsPerLamp
AS
	SELECT [Value] FROM tblConfig
	WHERE [Option] = 'SecondsPerLamp';
GO

--BELOW IS THE PROCEDURE TO CREATE A NEW WORKSTATION
CREATE PROCEDURE CreateNewWorkStation @skillID int
AS
	DECLARE @workerID INT
	DECLARE @workstationID INT
	DECLARE @harnessBinSize INT
	DECLARE @reflectorBinSize INT
	DECLARE @housingBinSize INT
	DECLARE @lensBinSize INT
	DECLARE @bulbBinSize INT
	DECLARE @bezelBinSize INT

	SET @harnessBinSize = (SELECT [Value] FROM tblConfig WHERE [Option]= 'HarnessBinSize');
	SET @reflectorBinSize = (SELECT [Value] FROM tblConfig WHERE [Option]= 'ReflectorBinSize');
	SET @housingBinSize = (SELECT [Value] FROM tblConfig WHERE [Option]= 'HousingBinSize');
	SET @lensBinSize = (SELECT [Value] FROM tblConfig WHERE [Option]= 'LensBinSize');
	SET @bulbBinSize = (SELECT [Value] FROM tblConfig WHERE [Option]= 'BulbBinSize');
	SET @bezelBinSize = (SELECT [Value] FROM tblConfig WHERE [Option]= 'BezelBinSize');

	INSERT INTO tblWorkers ([SkillLevel]) VALUES (@skillID);
	SET @workerID = (SELECT TOP 1 ID FROM tblWorkers ORDER BY ID DESC);

	INSERT INTO tblWorkStations ([WorkerID]) VALUES (@workerID);
	SET @workstationID = (SELECT TOP 1 ID FROM tblWorkStations ORDER BY ID DESC);

	INSERT INTO tblPartBins ([PartName], [BinSize], [BinLevel], [WorkStationID]) VALUES ('Harness', @harnessBinSize, @harnessBinSize, @workstationID );
	INSERT INTO tblPartBins ([PartName], [BinSize], [BinLevel], [WorkStationID]) VALUES ('Reflector', @reflectorBinSize, @reflectorBinSize, @workstationID );
	INSERT INTO tblPartBins ([PartName], [BinSize], [BinLevel], [WorkStationID]) VALUES ('Housing', @housingBinSize, @housingBinSize, @workstationID );
	INSERT INTO tblPartBins ([PartName], [BinSize], [BinLevel], [WorkStationID]) VALUES ('Lens', @lensBinSize, @lensBinSize, @workstationID );
	INSERT INTO tblPartBins ([PartName], [BinSize], [BinLevel], [WorkStationID]) VALUES ('Bulb', @bulbBinSize, @bulbBinSize, @workstationID );
	INSERT INTO tblPartBins ([PartName], [BinSize], [BinLevel], [WorkStationID]) VALUES ('Bezel', @bezelBinSize, @bezelBinSize, @workstationID );

	SELECT TOP 1 ID FROM tblWorkStations ORDER BY ID DESC;
GO

--BELOW IS THE PROCEDURE TO FILL ALL OF THE BINS IF THEY'RE BELOW A CERTAIN POINT
CREATE PROCEDURE FillBins 
AS
	UPDATE tblPartBins
	SET BinLevel = BinLevel + BinSize
	WHERE BinLevel <= (SELECT [Value] FROM tblConfig WHERE [Option] = 'AlertLevel')
	SELECT count(*) FROM tblLamps
GO

--BELOW IS THE PROCEDURE TO CREATE A TEST TRAY
CREATE PROCEDURE CreateTestTray
AS
	DECLARE @testTraySize INT
	DECLARE @testTrayID INT

	SET @testTraySize =  (SELECT [Value] FROM tblConfig WHERE [Option] = 'TestTraySize');
	INSERT INTO tblTestTray ([MaxLamps], [TestUnitNumber]) VALUES (@testTraySize, 0);
GO

--BELOW IS THE PROCEDURE TO GET THE TEST TRAY ID
CREATE PROCEDURE GetTestTrayID 
AS
	DECLARE @oneid INT -- or the appropriate type
	DECLARE the_cursor CURSOR FAST_FORWARD

	FOR SELECT ID FROM tblTestTray WHERE Tested = 0
		OPEN the_cursor
		FETCH NEXT FROM the_cursor INTO @oneid
		WHILE @@FETCH_STATUS = 0
		BEGIN
			EXEC TestTheTray @oneid
			FETCH NEXT FROM the_cursor INTO @oneid
		END
		CLOSE the_cursor
		DEALLOCATE the_cursor

	DECLARE @testTrayID INT
	DECLARE @lampNum INT
	SET @testTrayID = (SELECT ID FROM tblTestTray WHERE [MaxLamps] > (SELECT COUNT (ID) FROM tblLamps WHERE TestTrayID = tblTestTray.ID));

	IF @testTrayID IS NULL
		EXEC CreateTestTray;
		SET @testTrayID = (SELECT ID FROM tblTestTray WHERE [MaxLamps] > (SELECT COUNT (ID) FROM tblLamps WHERE TestTrayID = tblTestTray.ID));
	SET @lampNum = (SELECT COUNT (ID) FROM tblLamps WHERE TestTrayID = @testTrayID);
	SELECT @testTrayID, @lampNum;
GO

--BELOW IS THE PROCEDURE TO CREATE A SINGLE LAMP
CREATE PROCEDURE CreateLamp @workStationID INT, @orderID INT, @testTrayID INT, @fogLampID INT
AS
	DECLARE @hasParts INT

	IF ((SELECT COUNT (ID) FROM tblPartBins WHERE WorkStationID = @workstationID AND BinLevel = 0) <= 0)
		BEGIN;

			UPDATE tblPartBins
			SET BinLevel = BinLevel - 1
			WHERE WorkStationID = @workstationID;

			DECLARE @workerID INT
			SET @workerID = (SELECT TOP 1 [workerID] FROM tblWorkStations WHERE ID = @workStationID);
			INSERT INTO tblLamps ([TestTrayID], [FogLampID], [OrderID], [WorkerID]) VALUES (@testTrayID, @fogLampID, @orderID, @workerID);
		END;
	ELSE
		SELECT 1;
GO

--BELOW IS THE PROCEDURE TO ITERATE OVER ALL LAMP ID'S AND TEST THEM
CREATE PROCEDURE TestTheTray @testTrayID INT
AS
	DECLARE @oid int
	DECLARE tt_Cursor CURSOR FAST_FORWARD
	
	FOR SELECT ID FROM tblLamps WHERE TestTrayID = @testTrayID
		OPEN tt_Cursor
		FETCH NEXT FROM tt_Cursor INTO @oid
		WHILE @@FETCH_STATUS = 0
		BEGIN
			EXEC TestTheLamp @oid
			FETCH NEXT FROM tt_Cursor INTO @oid
		END
	CLOSE tt_Cursor
	DEALLOCATE tt_Cursor
GO

--BELOW IS THE PROCEDURE TO TEST A SINGLE LAMP
CREATE PROCEDURE TestTheLamp @lampID INT
AS
	DECLARE @odds INT
	SET @odds = (SELECT FailRate FROM tblSkillLevels JOIN tblLamps ON tblLamps.ID = @lampID JOIN tblWorkers ON tblWorkers.ID = tblLamps.WorkerID WHERE tblWorkers.SkillLevel = tblSkillLevels.ID)

	DECLARE @orderID INT
	SET @orderID = (SELECT OrderID FROM tblLamps WHERE ID = @lampID)

	DECLARE @rand INT
	SET @rand = RAND()*100

	IF (@rand > @odds)
	BEGIN;
		UPDATE tblLamps
		SET TestPassed = 1
		WHERE ID = @lampID

		UPDATE tblOrders
		SET CompLamps = CompLamps + 1
		WHERE ID = @orderID
	END;
	ELSE
		UPDATE tblLamps
		SET TestPassed = 0
		WHERE ID = @lampID
GO

--BELOW IS THE PROCEDURE TO ADD A NEW ORDER WITH A GIVEN SIZE
CREATE PROCEDURE AddNewOrder @size INT
AS
	INSERT INTO tblOrders ([ReqLamp], [CompLamps]) VALUES (@size, 0);
GO