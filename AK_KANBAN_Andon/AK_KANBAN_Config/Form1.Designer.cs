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
            this.dgvConfig = new System.Windows.Forms.DataGridView();
            this.cbWorkstation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAutoRefresh = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(311, 306);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // dgvConfig
            // 
            this.dgvConfig.AllowUserToAddRows = false;
            this.dgvConfig.AllowUserToDeleteRows = false;
            this.dgvConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfig.Location = new System.Drawing.Point(12, 50);
            this.dgvConfig.Name = "dgvConfig";
            this.dgvConfig.ReadOnly = true;
            this.dgvConfig.Size = new System.Drawing.Size(374, 250);
            this.dgvConfig.TabIndex = 4;
            // 
            // cbWorkstation
            // 
            this.cbWorkstation.FormattingEnabled = true;
            this.cbWorkstation.Location = new System.Drawing.Point(11, 24);
            this.cbWorkstation.Margin = new System.Windows.Forms.Padding(2);
            this.cbWorkstation.Name = "cbWorkstation";
            this.cbWorkstation.Size = new System.Drawing.Size(92, 21);
            this.cbWorkstation.TabIndex = 9;
            this.cbWorkstation.SelectedValueChanged += new System.EventHandler(this.CbWorkstation_SelectedValueChanged);
            this.cbWorkstation.Click += new System.EventHandler(this.CbWorkstation_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Workstation";
            // 
            // cbAutoRefresh
            // 
            this.cbAutoRefresh.AutoSize = true;
            this.cbAutoRefresh.Enabled = false;
            this.cbAutoRefresh.Location = new System.Drawing.Point(11, 312);
            this.cbAutoRefresh.Name = "cbAutoRefresh";
            this.cbAutoRefresh.Size = new System.Drawing.Size(86, 17);
            this.cbAutoRefresh.TabIndex = 11;
            this.cbAutoRefresh.Text = "Auto-Update";
            this.cbAutoRefresh.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 339);
            this.Controls.Add(this.cbAutoRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbWorkstation);
            this.Controls.Add(this.dgvConfig);
            this.Controls.Add(this.btnConnect);
            this.Name = "frmMain";
            this.Text = "AK_KANBAN Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.DataGridView dgvConfig;
        private System.Windows.Forms.ComboBox cbWorkstation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbAutoRefresh;
    }
}

