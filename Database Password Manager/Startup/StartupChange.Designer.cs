namespace DatabasePasswordManager.Startup
{
    partial class StartupChange
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.labeCurrentPassword = new System.Windows.Forms.Label();
            this.textBoxCurrentPassword = new System.Windows.Forms.TextBox();
            this.buttonShowOldInsert = new System.Windows.Forms.Button();
            this.buttonShowNewInsert = new System.Windows.Forms.Button();
            this.buttonShowNewRepeat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(6, 152);
            this.textBoxConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxConfirmPassword.MaxLength = 32;
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(271, 24);
            this.textBoxConfirmPassword.TabIndex = 4;
            this.textBoxConfirmPassword.UseSystemPasswordChar = true;
            this.textBoxConfirmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUserControl_KeyPress);
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewPassword.Location = new System.Drawing.Point(6, 90);
            this.textBoxNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNewPassword.MaxLength = 32;
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(271, 24);
            this.textBoxNewPassword.TabIndex = 2;
            this.textBoxNewPassword.UseSystemPasswordChar = true;
            this.textBoxNewPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUserControl_KeyPress);
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Location = new System.Drawing.Point(67, 68);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(153, 18);
            this.labelNewPassword.TabIndex = 7;
            this.labelNewPassword.Text = "Insert New Password:";
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Location = new System.Drawing.Point(67, 130);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(164, 18);
            this.labelConfirmPassword.TabIndex = 8;
            this.labelConfirmPassword.Text = "Repeat New Password:";
            // 
            // labeCurrentPassword
            // 
            this.labeCurrentPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labeCurrentPassword.AutoSize = true;
            this.labeCurrentPassword.Location = new System.Drawing.Point(67, 10);
            this.labeCurrentPassword.Name = "labeCurrentPassword";
            this.labeCurrentPassword.Size = new System.Drawing.Size(172, 18);
            this.labeCurrentPassword.TabIndex = 6;
            this.labeCurrentPassword.Text = "Insert Current Password:";
            // 
            // textBoxCurrentPassword
            // 
            this.textBoxCurrentPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCurrentPassword.Location = new System.Drawing.Point(6, 32);
            this.textBoxCurrentPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxCurrentPassword.MaxLength = 32;
            this.textBoxCurrentPassword.Name = "textBoxCurrentPassword";
            this.textBoxCurrentPassword.Size = new System.Drawing.Size(271, 24);
            this.textBoxCurrentPassword.TabIndex = 0;
            this.textBoxCurrentPassword.UseSystemPasswordChar = true;
            this.textBoxCurrentPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxUserControl_KeyPress);
            // 
            // buttonShowOldInsert
            // 
            this.buttonShowOldInsert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowOldInsert.BackColor = System.Drawing.Color.White;
            this.buttonShowOldInsert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonShowOldInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowOldInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowOldInsert.Location = new System.Drawing.Point(272, 32);
            this.buttonShowOldInsert.Name = "buttonShowOldInsert";
            this.buttonShowOldInsert.Size = new System.Drawing.Size(44, 24);
            this.buttonShowOldInsert.TabIndex = 1;
            this.buttonShowOldInsert.Text = "Show";
            this.buttonShowOldInsert.UseVisualStyleBackColor = false;
            this.buttonShowOldInsert.Click += new System.EventHandler(this.buttonShow_Click);
            this.buttonShowOldInsert.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonShow_KeyUp);
            this.buttonShowOldInsert.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonShow_MouseDownAndUp);
            this.buttonShowOldInsert.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonShow_MouseDownAndUp);
            // 
            // buttonShowNewInsert
            // 
            this.buttonShowNewInsert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowNewInsert.BackColor = System.Drawing.Color.White;
            this.buttonShowNewInsert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonShowNewInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowNewInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowNewInsert.Location = new System.Drawing.Point(272, 90);
            this.buttonShowNewInsert.Name = "buttonShowNewInsert";
            this.buttonShowNewInsert.Size = new System.Drawing.Size(44, 24);
            this.buttonShowNewInsert.TabIndex = 3;
            this.buttonShowNewInsert.Text = "Show";
            this.buttonShowNewInsert.UseVisualStyleBackColor = false;
            this.buttonShowNewInsert.Click += new System.EventHandler(this.buttonShow_Click);
            this.buttonShowNewInsert.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonShow_KeyUp);
            this.buttonShowNewInsert.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonShow_MouseDownAndUp);
            this.buttonShowNewInsert.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonShow_MouseDownAndUp);
            // 
            // buttonShowNewRepeat
            // 
            this.buttonShowNewRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowNewRepeat.BackColor = System.Drawing.Color.White;
            this.buttonShowNewRepeat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonShowNewRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowNewRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowNewRepeat.Location = new System.Drawing.Point(272, 152);
            this.buttonShowNewRepeat.Name = "buttonShowNewRepeat";
            this.buttonShowNewRepeat.Size = new System.Drawing.Size(44, 24);
            this.buttonShowNewRepeat.TabIndex = 5;
            this.buttonShowNewRepeat.Text = "Show";
            this.buttonShowNewRepeat.UseVisualStyleBackColor = false;
            this.buttonShowNewRepeat.Click += new System.EventHandler(this.buttonShow_Click);
            this.buttonShowNewRepeat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonShow_KeyUp);
            this.buttonShowNewRepeat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonShow_MouseDownAndUp);
            this.buttonShowNewRepeat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonShow_MouseDownAndUp);
            // 
            // StartupChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.buttonShowNewRepeat);
            this.Controls.Add(this.buttonShowNewInsert);
            this.Controls.Add(this.buttonShowOldInsert);
            this.Controls.Add(this.textBoxCurrentPassword);
            this.Controls.Add(this.labeCurrentPassword);
            this.Controls.Add(this.labelConfirmPassword);
            this.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.textBoxConfirmPassword);
            this.Controls.Add(this.textBoxNewPassword);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StartupChange";
            this.Size = new System.Drawing.Size(319, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.Label labeCurrentPassword;
        private System.Windows.Forms.TextBox textBoxCurrentPassword;
        private System.Windows.Forms.Button buttonShowOldInsert;
        private System.Windows.Forms.Button buttonShowNewInsert;
        private System.Windows.Forms.Button buttonShowNewRepeat;
    }
}
