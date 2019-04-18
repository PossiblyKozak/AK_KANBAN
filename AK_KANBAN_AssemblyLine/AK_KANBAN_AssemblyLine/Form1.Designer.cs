namespace AK_KANBAN_Config
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblTimeBeforeRefresh = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lblNumIterations = new System.Windows.Forms.Label();
            this.chartLamps = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartOrder = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblActiveWorkstations = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartLamps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 40);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblTimeBeforeRefresh
            // 
            this.lblTimeBeforeRefresh.AutoSize = true;
            this.lblTimeBeforeRefresh.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeBeforeRefresh.Location = new System.Drawing.Point(7, 9);
            this.lblTimeBeforeRefresh.Name = "lblTimeBeforeRefresh";
            this.lblTimeBeforeRefresh.Size = new System.Drawing.Size(75, 28);
            this.lblTimeBeforeRefresh.TabIndex = 5;
            this.lblTimeBeforeRefresh.Text = "label1";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(309, 37);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 6;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // lblNumIterations
            // 
            this.lblNumIterations.AutoSize = true;
            this.lblNumIterations.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumIterations.Location = new System.Drawing.Point(346, 6);
            this.lblNumIterations.Name = "lblNumIterations";
            this.lblNumIterations.Size = new System.Drawing.Size(38, 28);
            this.lblNumIterations.TabIndex = 7;
            this.lblNumIterations.Text = "00";
            this.lblNumIterations.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chartLamps
            // 
            chartArea3.Name = "ChartArea1";
            this.chartLamps.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartLamps.Legends.Add(legend3);
            this.chartLamps.Location = new System.Drawing.Point(12, 70);
            this.chartLamps.Name = "chartLamps";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartLamps.Series.Add(series3);
            this.chartLamps.Size = new System.Drawing.Size(372, 180);
            this.chartLamps.TabIndex = 8;
            this.chartLamps.Text = "chart1";
            // 
            // chartOrder
            // 
            chartArea4.Name = "ChartArea1";
            this.chartOrder.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartOrder.Legends.Add(legend4);
            this.chartOrder.Location = new System.Drawing.Point(12, 256);
            this.chartOrder.Name = "chartOrder";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartOrder.Series.Add(series4);
            this.chartOrder.Size = new System.Drawing.Size(372, 180);
            this.chartOrder.TabIndex = 9;
            this.chartOrder.Text = "chart1";
            // 
            // lblActiveWorkstations
            // 
            this.lblActiveWorkstations.AutoSize = true;
            this.lblActiveWorkstations.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveWorkstations.Location = new System.Drawing.Point(12, 439);
            this.lblActiveWorkstations.Name = "lblActiveWorkstations";
            this.lblActiveWorkstations.Size = new System.Drawing.Size(0, 28);
            this.lblActiveWorkstations.TabIndex = 10;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 468);
            this.Controls.Add(this.lblActiveWorkstations);
            this.Controls.Add(this.chartOrder);
            this.Controls.Add(this.chartLamps);
            this.Controls.Add(this.lblNumIterations);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.lblTimeBeforeRefresh);
            this.Controls.Add(this.btnConnect);
            this.Name = "frmMain";
            this.Text = "AK_KANBAN Assembly Line";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.chartLamps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblTimeBeforeRefresh;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblNumIterations;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLamps;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOrder;
        private System.Windows.Forms.Label lblActiveWorkstations;
    }
}

