namespace DemandasApp
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblHost = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblDbName = new System.Windows.Forms.Label();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblTableName = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCookie = new System.Windows.Forms.Label();
            this.txtCookie = new System.Windows.Forms.TextBox();
            this.chkUpdateOnlyOpen = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(12, 15);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(35, 15);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Host:";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(110, 12);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(262, 23);
            this.txtHost.TabIndex = 1;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 44);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 15);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Porta:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(110, 41);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(262, 23);
            this.txtPort.TabIndex = 3;
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(12, 73);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(90, 15);
            this.lblDbName.TabIndex = 4;
            this.lblDbName.Text = "Nome do Baco:";
            // 
            // txtDbName
            // 
            this.txtDbName.Location = new System.Drawing.Point(110, 70);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(262, 23);
            this.txtDbName.TabIndex = 5;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 102);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(50, 15);
            this.lblUser.TabIndex = 6;
            this.lblUser.Text = "Usuário:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(110, 99);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(262, 23);
            this.txtUser.TabIndex = 7;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 131);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(42, 15);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Senha:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(110, 128);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(262, 23);
            this.txtPassword.TabIndex = 9;
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(12, 160);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(94, 15);
            this.lblTableName.TabIndex = 10;
            this.lblTableName.Text = "Nome da Tabela:";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(110, 157);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(262, 23);
            this.txtTableName.TabIndex = 11;
            // 
            // lblCookie
            // 
            this.lblCookie.AutoSize = true;
            this.lblCookie.Location = new System.Drawing.Point(12, 189);
            this.lblCookie.Name = "lblCookie";
            this.lblCookie.Size = new System.Drawing.Size(48, 15);
            this.lblCookie.TabIndex = 12;
            this.lblCookie.Text = "Cookie:";
            // 
            // txtCookie
            // 
            this.txtCookie.Location = new System.Drawing.Point(110, 186);
            this.txtCookie.Name = "txtCookie";
            this.txtCookie.Size = new System.Drawing.Size(262, 23);
            this.txtCookie.TabIndex = 13;
            // 
            // chkUpdateOnlyOpen
            // 
            this.chkUpdateOnlyOpen.AutoSize = true;
            this.chkUpdateOnlyOpen.Location = new System.Drawing.Point(15, 227);
            this.chkUpdateOnlyOpen.Name = "chkUpdateOnlyOpen";
            this.chkUpdateOnlyOpen.Size = new System.Drawing.Size(296, 19);
            this.chkUpdateOnlyOpen.TabIndex = 14;
            this.chkUpdateOnlyOpen.Text = "Atualizar somente registros com status 'Aberto' ou 'Em andamento'";
            this.chkUpdateOnlyOpen.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(297, 256);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(216, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 291);
            this.Controls.Add(this.chkUpdateOnlyOpen);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCookie);
            this.Controls.Add(this.lblCookie);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.lblTableName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtDbName);
            this.Controls.Add(this.lblDbName);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lblHost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurações";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.TextBox txtDbName;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCookie;
        private System.Windows.Forms.TextBox txtCookie;
        private System.Windows.Forms.CheckBox chkUpdateOnlyOpen;
    }
}
