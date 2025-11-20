namespace DemandasApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnExportFullTable = new System.Windows.Forms.Button();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.lblProgressPercentage = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblErrors = new System.Windows.Forms.Label();
            this.lblUpdated = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.groupBoxStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(12, 578);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(175, 50);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "▶ INICIAR";
            this.btnStart.UseVisualStyleBackColor = false;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(193, 578);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(175, 50);
            this.btnStop.TabIndex = 2;
            this.btnStop.Enabled = false;
            this.btnStop.Text = "⏹ PARAR";
            this.btnStop.UseVisualStyleBackColor = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.Location = new System.Drawing.Point(12, 646);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 15);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            // 
            // btnExportFullTable
            // 
            this.btnExportFullTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportFullTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnExportFullTable.FlatAppearance.BorderSize = 0;
            this.btnExportFullTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportFullTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportFullTable.ForeColor = System.Drawing.Color.White;
            this.btnExportFullTable.Location = new System.Drawing.Point(12, 12);
            this.btnExportFullTable.Name = "btnExportFullTable";
            this.btnExportFullTable.Size = new System.Drawing.Size(140, 30);
            this.btnExportFullTable.TabIndex = 6;
            this.btnExportFullTable.Text = "Exportar (xlsx/csv)";
            this.btnExportFullTable.UseVisualStyleBackColor = false;
            this.btnExportFullTable.Click += new System.EventHandler(this.btnExportFullTable_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSettings.ForeColor = System.Drawing.Color.Black;
            this.btnSettings.Location = new System.Drawing.Point(238, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(130, 30);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.Text = "⚙ AJUSTES";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.groupBoxStats.Controls.Add(this.lblTimeRemaining);
            this.groupBoxStats.Controls.Add(this.lblProgressPercentage);
            this.groupBoxStats.Controls.Add(this.progressBar);
            this.groupBoxStats.Controls.Add(this.lblErrors);
            this.groupBoxStats.Controls.Add(this.lblUpdated);
            this.groupBoxStats.Controls.Add(this.lblTotal);
            this.groupBoxStats.Location = new System.Drawing.Point(12, 52);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(356, 509);
            this.groupBoxStats.TabIndex = 7;
            this.groupBoxStats.TabStop = false;
            // 
            // lblProgressPercentage
            // 
            this.lblProgressPercentage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblProgressPercentage.AutoSize = true;
            this.lblProgressPercentage.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProgressPercentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblProgressPercentage.Location = new System.Drawing.Point(137, 203);
            this.lblProgressPercentage.Name = "lblProgressPercentage";
            this.lblProgressPercentage.Size = new System.Drawing.Size(71, 45);
            this.lblProgressPercentage.TabIndex = 4;
            this.lblProgressPercentage.Text = "0%";
            this.lblProgressPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(20, 464);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(316, 23);
            this.progressBar.TabIndex = 3;
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblErrors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblErrors.Location = new System.Drawing.Point(20, 100);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(84, 30);
            this.lblErrors.TabIndex = 2;
            this.lblErrors.Text = "Erros: 0";
            // 
            // lblUpdated
            // 
            this.lblUpdated.AutoSize = true;
            this.lblUpdated.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUpdated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblUpdated.Location = new System.Drawing.Point(20, 60);
            this.lblUpdated.Name = "lblUpdated";
            this.lblUpdated.Size = new System.Drawing.Size(150, 30);
            this.lblUpdated.TabIndex = 1;
            this.lblUpdated.Text = "Atualizados: 0";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.Location = new System.Drawing.Point(20, 20);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(202, 30);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total a processar: 0";
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTimeRemaining.AutoSize = true;
            this.lblTimeRemaining.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTimeRemaining.ForeColor = System.Drawing.Color.Gray;
            this.lblTimeRemaining.Location = new System.Drawing.Point(20, 434);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(112, 17);
            this.lblTimeRemaining.TabIndex = 5;
            this.lblTimeRemaining.Text = "Tempo estimado: -";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(380, 670);
            this.Controls.Add(this.groupBoxStats);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnExportFullTable);
            this.Controls.Add(this.btnSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1746 Extractor";
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnExportFullTable;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.Label lblUpdated;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgressPercentage;
        private System.Windows.Forms.Label lblTimeRemaining;
    }
}
