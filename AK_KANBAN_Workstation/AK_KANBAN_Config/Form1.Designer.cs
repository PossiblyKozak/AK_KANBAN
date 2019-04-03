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
            this.btnBegin = new System.Windows.Forms.Button();
            this.cbWorkers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblWorkstationID = new System.Windows.Forms.Label();
            this.lblTimeBeforeRefresh = new System.Windows.Forms.Label();
            this.lblLampsMade = new System.Windows.Forms.Label();
            this.cbWorkstation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnBegin
            // 
            this.btnBegin.Location = new System.Drawing.Point(302, 25);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(75, 23);
            this.btnBegin.TabIndex = 0;
            this.btnBegin.Text = "Begin";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // cbWorkers
            // 
            this.cbWorkers.FormattingEnabled = true;
            this.cbWorkers.Location = new System.Drawing.Point(12, 27);
            this.cbWorkers.Margin = new System.Windows.Forms.Padding(2);
            this.cbWorkers.Name = "cbWorkers";
            this.cbWorkers.Size = new System.Drawing.Size(92, 21);
            this.cbWorkers.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose Speed";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(221, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Pause";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblWorkstationID
            // 
            this.lblWorkstationID.AutoSize = true;
            this.lblWorkstationID.Location = new System.Drawing.Point(105, 11);
            this.lblWorkstationID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWorkstationID.Name = "lblWorkstationID";
            this.lblWorkstationID.Size = new System.Drawing.Size(64, 13);
            this.lblWorkstationID.TabIndex = 5;
            this.lblWorkstationID.Text = "Workstation";
            // 
            // lblTimeBeforeRefresh
            // 
            this.lblTimeBeforeRefresh.AutoSize = true;
            this.lblTimeBeforeRefresh.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeBeforeRefresh.Location = new System.Drawing.Point(12, 50);
            this.lblTimeBeforeRefresh.Name = "lblTimeBeforeRefresh";
            this.lblTimeBeforeRefresh.Size = new System.Drawing.Size(0, 28);
            this.lblTimeBeforeRefresh.TabIndex = 6;
            // 
            // lblLampsMade
            // 
            this.lblLampsMade.AutoSize = true;
            this.lblLampsMade.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLampsMade.Location = new System.Drawing.Point(291, 62);
            this.lblLampsMade.Name = "lblLampsMade";
            this.lblLampsMade.Size = new System.Drawing.Size(86, 16);
            this.lblLampsMade.TabIndex = 7;
            this.lblLampsMade.Text = "0 Lamps Made";
            this.lblLampsMade.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbWorkstation
            // 
            this.cbWorkstation.FormattingEnabled = true;
            this.cbWorkstation.Location = new System.Drawing.Point(108, 27);
            this.cbWorkstation.Margin = new System.Windows.Forms.Padding(2);
            this.cbWorkstation.Name = "cbWorkstation";
            this.cbWorkstation.Size = new System.Drawing.Size(92, 21);
            this.cbWorkstation.TabIndex = 8;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 82);
            this.Controls.Add(this.cbWorkstation);
            this.Controls.Add(this.lblLampsMade);
            this.Controls.Add(this.lblTimeBeforeRefresh);
            this.Controls.Add(this.lblWorkstationID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbWorkers);
            this.Controls.Add(this.btnBegin);
            this.Name = "frmMain";
            this.Text = "AK_KANBAN Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.ComboBox cbWorkers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblWorkstationID;
        private System.Windows.Forms.Label lblTimeBeforeRefresh;
        private System.Windows.Forms.Label lblLampsMade;
        private System.Windows.Forms.ComboBox cbWorkstation;
    }
}

