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
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblTimeBeforeRefresh = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lblNumIterations = new System.Windows.Forms.Label();
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 72);
            this.Controls.Add(this.lblNumIterations);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.lblTimeBeforeRefresh);
            this.Controls.Add(this.btnConnect);
            this.Name = "frmMain";
            this.Text = "AK_KANBAN Assembly Line";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblTimeBeforeRefresh;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblNumIterations;
    }
}

