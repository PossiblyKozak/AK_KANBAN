USE [AK_KANBAN]
GO
/****** Object:  StoredProcedure [dbo].[TestTheTray]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP PROCEDURE [dbo].[TestTheTray]
GO
/****** Object:  StoredProcedure [dbo].[TestTheLamp]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP PROCEDURE [dbo].[TestTheLamp]
GO
/****** Object:  StoredProcedure [dbo].[GetTestTrayID]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP PROCEDURE [dbo].[GetTestTrayID]
GO
/****** Object:  StoredProcedure [dbo].[GetSimSpeed]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP PROCEDURE [dbo].[GetSimSpeed]
GO
/****** Object:  StoredProcedure [dbo].[GetSecondsPerLamp]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP PROCEDURE [dbo].[GetSecondsPerLamp]
GO
/****** Object:  StoredProcedure [dbo].[GetOpenOrder]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP PROCEDURE [dbo].[GetOpenOrder]
GO
/****** Object:  StoredProcedure [dbo].[FillBins]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP PROCEDURE [dbo].[FillBins]
GO
/****** Object:  StoredProcedure [dbo].[CreateTestTray]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP PROCEDURE [dbo].[CreateTestTray]
GO
/****** Object:  StoredProcedure [dbo].[CreateNewWorkStation]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP PROCEDURE [dbo].[CreateNewWorkStation]
GO
/****** Object:  StoredProcedure [dbo].[CreateLamp]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP PROCEDURE [dbo].[CreateLamp]
GO
ALTER TABLE [dbo].[tblWorkStations] DROP CONSTRAINT [FK_tblWorkStations_tblWorkers]
GO
ALTER TABLE [dbo].[tblWorkers] DROP CONSTRAINT [FK_tblWorkers_tblSkillLevels]
GO
ALTER TABLE [dbo].[tblPartBins] DROP CONSTRAINT [FK_tblPartBins_tblWorkStations]
GO
ALTER TABLE [dbo].[tblLamps] DROP CONSTRAINT [FK_tblLamps_tblWorkers]
GO
ALTER TABLE [dbo].[tblLamps] DROP CONSTRAINT [FK_tblLamps_tblTestTray]
GO
ALTER TABLE [dbo].[tblLamps] DROP CONSTRAINT [FK_tblLamps_tblOrders]
GO
ALTER TABLE [dbo].[tblWorkStations] DROP CONSTRAINT [DF_tblWorkStations_IsActive]
GO
ALTER TABLE [dbo].[tblTestTray] DROP CONSTRAINT [DF_tblTestTray_Tested]
GO
ALTER TABLE [dbo].[tblOrders] DROP CONSTRAINT [DF__tblOrders__Order__72C60C4A]
GO
/****** Object:  Table [dbo].[tblWorkStations]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP TABLE [dbo].[tblWorkStations]
GO
/****** Object:  Table [dbo].[tblWorkers]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP TABLE [dbo].[tblWorkers]
GO
/****** Object:  Table [dbo].[tblTestTray]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP TABLE [dbo].[tblTestTray]
GO
/****** Object:  Table [dbo].[tblSkillLevels]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP TABLE [dbo].[tblSkillLevels]
GO
/****** Object:  Table [dbo].[tblPartBins]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP TABLE [dbo].[tblPartBins]
GO
/****** Object:  Table [dbo].[tblOrders]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP TABLE [dbo].[tblOrders]
GO
/****** Object:  Table [dbo].[tblLamps]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP TABLE [dbo].[tblLamps]
GO
/****** Object:  Table [dbo].[tblConfig]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP TABLE [dbo].[tblConfig]
GO
USE [master]
GO
/****** Object:  Database [AK_KANBAN]    Script Date: 4/2/2019 9:59:51 PM ******/
DROP DATABASE [AK_KANBAN]
GO
/****** Object:  Database [AK_KANBAN]    Script Date: 4/2/2019 9:59:51 PM ******/
CREATE DATABASE [AK_KANBAN]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AK_KANBAN', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\AK_KANBAN.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AK_KANBAN_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\AK_KANBAN_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AK_KANBAN] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AK_KANBAN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AK_KANBAN] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AK_KANBAN] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AK_KANBAN] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AK_KANBAN] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AK_KANBAN] SET ARITHABORT OFF 
GO
ALTER DATABASE [AK_KANBAN] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AK_KANBAN] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AK_KANBAN] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AK_KANBAN] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AK_KANBAN] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AK_KANBAN] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AK_KANBAN] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AK_KANBAN] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AK_KANBAN] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AK_KANBAN] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AK_KANBAN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AK_KANBAN] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AK_KANBAN] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AK_KANBAN] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AK_KANBAN] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AK_KANBAN] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AK_KANBAN] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AK_KANBAN] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AK_KANBAN] SET  MULTI_USER 
GO
ALTER DATABASE [AK_KANBAN] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AK_KANBAN] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AK_KANBAN] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AK_KANBAN] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AK_KANBAN] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AK_KANBAN', N'ON'
GO
ALTER DATABASE [AK_KANBAN] SET QUERY_STORE = OFF
GO
USE [AK_KANBAN]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [AK_KANBAN]
GO
/****** Object:  Table [dbo].[tblConfig]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblConfig](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Option] [varchar](50) NOT NULL,
	[Value] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblConfig] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLamps]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLamps](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TestTrayID] [int] NOT NULL,
	[FogLampID] [int] NOT NULL,
	[TestPassed] [bit] NULL,
	[OrderID] [int] NOT NULL,
	[WorkerID] [int] NOT NULL,
 CONSTRAINT [PK_tblLamps] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblOrders]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReqLamp] [int] NOT NULL,
	[CompLamps] [int] NOT NULL,
	[OrderDate] [datetime] NULL,
 CONSTRAINT [PK_tblOrders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPartBins]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPartBins](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PartName] [nchar](25) NULL,
	[BinSize] [int] NOT NULL,
	[BinLevel] [int] NOT NULL,
	[WorkStationID] [int] NOT NULL,
 CONSTRAINT [PK_tblPartBins] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSkillLevels]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSkillLevels](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeCategory] [varchar](50) NULL,
	[WorkSpeed] [real] NOT NULL,
	[FailRate] [real] NOT NULL,
 CONSTRAINT [PK_tblSkills] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTestTray]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTestTray](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaxLamps] [int] NOT NULL,
	[TestUnitNumber] [nchar](25) NOT NULL,
	[Tested] [bit] NOT NULL,
 CONSTRAINT [PK_tblTestTray] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblWorkers]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblWorkers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SkillLevel] [int] NOT NULL,
 CONSTRAINT [PK_tblWorkers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblWorkStations]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblWorkStations](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[WorkerID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_tblWorkStations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblConfig] ON 

INSERT [dbo].[tblConfig] ([ID], [Option], [Value]) VALUES (1, N'AlertLevel', N'5')
INSERT [dbo].[tblConfig] ([ID], [Option], [Value]) VALUES (2, N'MinutesPerRefill', N'5')
INSERT [dbo].[tblConfig] ([ID], [Option], [Value]) VALUES (3, N'SimulationSpeed', N'60')
INSERT [dbo].[tblConfig] ([ID], [Option], [Value]) VALUES (4, N'SecondsPerLamp', N'60')
INSERT [dbo].[tblConfig] ([ID], [Option], [Value]) VALUES (5, N'TestTraySize', N'60')
INSERT [dbo].[tblConfig] ([ID], [Option], [Value]) VALUES (6, N'HarnessBinSize', N'55')
INSERT [dbo].[tblConfig] ([ID], [Option], [Value]) VALUES (7, N'ReflectorBinSize', N'35')
INSERT [dbo].[tblConfig] ([ID], [Option], [Value]) VALUES (8, N'HousingBinSize', N'24')
INSERT [dbo].[tblConfig] ([ID], [Option], [Value]) VALUES (9, N'LensBinSize', N'40')
INSERT [dbo].[tblConfig] ([ID], [Option], [Value]) VALUES (10, N'BulbBinSize', N'60')
INSERT [dbo].[tblConfig] ([ID], [Option], [Value]) VALUES (11, N'BezelBinSize', N'75')
SET IDENTITY_INSERT [dbo].[tblConfig] OFF
SET IDENTITY_INSERT [dbo].[tblSkillLevels] ON 

INSERT [dbo].[tblSkillLevels] ([ID], [EmployeeCategory], [WorkSpeed], [FailRate]) VALUES (1, N'Skilled', 0.85, 0.15)
INSERT [dbo].[tblSkillLevels] ([ID], [EmployeeCategory], [WorkSpeed], [FailRate]) VALUES (2, N'Average', 1, 0.5)
INSERT [dbo].[tblSkillLevels] ([ID], [EmployeeCategory], [WorkSpeed], [FailRate]) VALUES (3, N'Rookie', 1.5, 0.15)
SET IDENTITY_INSERT [dbo].[tblSkillLevels] OFF
ALTER TABLE [dbo].[tblOrders] ADD  CONSTRAINT [DF__tblOrders__Order__72C60C4A]  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[tblTestTray] ADD  CONSTRAINT [DF_tblTestTray_Tested]  DEFAULT ((0)) FOR [Tested]
GO
ALTER TABLE [dbo].[tblWorkStations] ADD  CONSTRAINT [DF_tblWorkStations_IsActive]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tblLamps]  WITH CHECK ADD  CONSTRAINT [FK_tblLamps_tblOrders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[tblOrders] ([ID])
GO
ALTER TABLE [dbo].[tblLamps] CHECK CONSTRAINT [FK_tblLamps_tblOrders]
GO
ALTER TABLE [dbo].[tblLamps]  WITH CHECK ADD  CONSTRAINT [FK_tblLamps_tblTestTray] FOREIGN KEY([TestTrayID])
REFERENCES [dbo].[tblTestTray] ([ID])
GO
ALTER TABLE [dbo].[tblLamps] CHECK CONSTRAINT [FK_tblLamps_tblTestTray]
GO
ALTER TABLE [dbo].[tblLamps]  WITH CHECK ADD  CONSTRAINT [FK_tblLamps_tblWorkers] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[tblWorkers] ([ID])
GO
ALTER TABLE [dbo].[tblLamps] CHECK CONSTRAINT [FK_tblLamps_tblWorkers]
GO
ALTER TABLE [dbo].[tblPartBins]  WITH CHECK ADD  CONSTRAINT [FK_tblPartBins_tblWorkStations] FOREIGN KEY([WorkStationID])
REFERENCES [dbo].[tblWorkStations] ([ID])
GO
ALTER TABLE [dbo].[tblPartBins] CHECK CONSTRAINT [FK_tblPartBins_tblWorkStations]
GO
ALTER TABLE [dbo].[tblWorkers]  WITH CHECK ADD  CONSTRAINT [FK_tblWorkers_tblSkillLevels] FOREIGN KEY([SkillLevel])
REFERENCES [dbo].[tblSkillLevels] ([ID])
GO
ALTER TABLE [dbo].[tblWorkers] CHECK CONSTRAINT [FK_tblWorkers_tblSkillLevels]
GO
ALTER TABLE [dbo].[tblWorkStations]  WITH CHECK ADD  CONSTRAINT [FK_tblWorkStations_tblWorkers] FOREIGN KEY([WorkerID])
REFERENCES [dbo].[tblWorkers] ([ID])
GO
ALTER TABLE [dbo].[tblWorkStations] CHECK CONSTRAINT [FK_tblWorkStations_tblWorkers]
GO
/****** Object:  StoredProcedure [dbo].[CreateLamp]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateLamp] @workStationID INT, @orderID INT, @testTrayID INT, @fogLampID INT
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

		UPDATE tblOrders
		SET CompLamps = CompLamps + 1
		WHERE ID = @orderID;
	END;
ELSE
	SELECT 1;
GO
/****** Object:  StoredProcedure [dbo].[CreateNewWorkStation]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--BELOW IS THE PROCEDURE TO CREATE A NEW WORKSTATION
CREATE PROCEDURE [dbo].[CreateNewWorkStation] @skillID int
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
/****** Object:  StoredProcedure [dbo].[CreateTestTray]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--BELOW IS THE PROCEDURE TO CREATE A TEST TRAY
CREATE PROCEDURE [dbo].[CreateTestTray]
AS
DECLARE @testTraySize INT
DECLARE @testTrayID INT

SET @testTraySize =  (SELECT [Value] FROM tblConfig WHERE [Option] = 'TestTraySize');
INSERT INTO tblTestTray ([MaxLamps], [TestUnitNumber]) VALUES (@testTraySize, 0);
GO
/****** Object:  StoredProcedure [dbo].[FillBins]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FillBins] 
AS
UPDATE tblPartBins
SET BinLevel = BinLevel + BinSize
WHERE BinLevel <= (SELECT [Value] FROM tblConfig WHERE [Option] = 'AlertLevel')
SELECT count(*) FROM tblLamps
GO
/****** Object:  StoredProcedure [dbo].[GetOpenOrder]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Below is the procedure for returning the first open order ID to the user
CREATE PROCEDURE [dbo].[GetOpenOrder]
AS
SELECT TOP 1 [ID], [ReqLamp] FROM tblOrders
WHERE [CompLamps] < [ReqLamp];
GO
/****** Object:  StoredProcedure [dbo].[GetSecondsPerLamp]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--BELOW IS THE PROCEDURE TO GET THE GET SECODNS PER LAMP
CREATE PROCEDURE [dbo].[GetSecondsPerLamp]
AS
SELECT [Value] FROM tblConfig
WHERE [Option] = 'SecondsPerLamp';
GO
/****** Object:  StoredProcedure [dbo].[GetSimSpeed]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--BELOW IS THE PROCEDURE TO GET THE SIMULATION SPEED
CREATE PROCEDURE [dbo].[GetSimSpeed]
AS
SELECT [Value] FROM tblConfig
WHERE [Option] = 'SimulationSpeed';
GO
/****** Object:  StoredProcedure [dbo].[GetTestTrayID]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTestTrayID] 
AS
	DECLARE @oneid int -- or the appropriate type
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
/****** Object:  StoredProcedure [dbo].[TestTheLamp]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[TestTheLamp] @lampID INT
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
/****** Object:  StoredProcedure [dbo].[TestTheTray]    Script Date: 4/2/2019 9:59:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TestTheTray] @testTrayID INT
AS
	DECLARE @oid int -- or the appropriate type
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
USE [master]
GO
ALTER DATABASE [AK_KANBAN] SET  READ_WRITE 
GO
