namespace DatabasePasswordManager.Startup
{
    partial class StartupCreate
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
            this.textBoxPasswordConfirm = new System.Windows.Forms.TextBox();
            this.textBoxPasswordEntered = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelConfirm = new System.Windows.Forms.Label();
            this.buttonShowInsert = new System.Windows.Forms.Button();
            this.buttonShowRepeat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPasswordConfirm
            // 
            this.textBoxPasswordConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPasswordConfirm.Location = new System.Drawing.Point(6, 93);
            this.textBoxPasswordConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPasswordConfirm.MaxLength = 32;
            this.textBoxPasswordConfirm.Name = "textBoxPasswordConfirm";
            this.textBoxPasswordConfirm.Size = new System.Drawing.Size(271, 24);
            this.textBoxPasswordConfirm.TabIndex = 2;
            this.textBoxPasswordConfirm.UseSystemPasswordChar = true;
            this.textBoxPasswordConfirm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxesPasswords_KeyPress);
            // 
            // textBoxPasswordEntered
            // 
            this.textBoxPasswordEntered.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPasswordEntered.Location = new System.Drawing.Point(6, 31);
            this.textBoxPasswordEntered.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPasswordEntered.MaxLength = 32;
            this.textBoxPasswordEntered.Name = "textBoxPasswordEntered";
            this.textBoxPasswordEntered.Size = new System.Drawing.Size(271, 24);
            this.textBoxPasswordEntered.TabIndex = 0;
            this.textBoxPasswordEntered.UseSystemPasswordChar = true;
            this.textBoxPasswordEntered.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxesPasswords_KeyPress);
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(99, 9);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(119, 18);
            this.labelPassword.TabIndex = 4;
            this.labelPassword.Text = "Insert Password:";
            // 
            // labelConfirm
            // 
            this.labelConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelConfirm.AutoSize = true;
            this.labelConfirm.Location = new System.Drawing.Point(99, 71);
            this.labelConfirm.Name = "labelConfirm";
            this.labelConfirm.Size = new System.Drawing.Size(130, 18);
            this.labelConfirm.TabIndex = 5;
            this.labelConfirm.Text = "Repeat Password:";
            // 
            // buttonShowInsert
            // 
            this.buttonShowInsert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowInsert.BackColor = System.Drawing.Color.White;
            this.buttonShowInsert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonShowInsert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowInsert.Location = new System.Drawing.Point(272, 31);
            this.buttonShowInsert.Name = "buttonShowInsert";
            this.buttonShowInsert.Size = new System.Drawing.Size(44, 24);
            this.buttonShowInsert.TabIndex = 1;
            this.buttonShowInsert.Text = "Show";
            this.buttonShowInsert.UseVisualStyleBackColor = false;
            this.buttonShowInsert.Click += new System.EventHandler(this.buttonShow_Click);
            this.buttonShowInsert.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonShow_KeyUp);
            this.buttonShowInsert.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonShow_MouseDownAndUp);
            this.buttonShowInsert.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonShow_MouseDownAndUp);
            // 
            // buttonShowRepeat
            // 
            this.buttonShowRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowRepeat.BackColor = System.Drawing.Color.White;
            this.buttonShowRepeat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonShowRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowRepeat.Location = new System.Drawing.Point(272, 93);
            this.buttonShowRepeat.Name = "buttonShowRepeat";
            this.buttonShowRepeat.Size = new System.Drawing.Size(44, 24);
            this.buttonShowRepeat.TabIndex = 3;
            this.buttonShowRepeat.Text = "Show";
            this.buttonShowRepeat.UseVisualStyleBackColor = false;
            this.buttonShowRepeat.Click += new System.EventHandler(this.buttonShow_Click);
            this.buttonShowRepeat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonShow_KeyUp);
            this.buttonShowRepeat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonShow_MouseDownAndUp);
            this.buttonShowRepeat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonShow_MouseDownAndUp);
            // 
            // StartupCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.buttonShowRepeat);
            this.Controls.Add(this.buttonShowInsert);
            this.Controls.Add(this.labelConfirm);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxPasswordConfirm);
            this.Controls.Add(this.textBoxPasswordEntered);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StartupCreate";
            this.Size = new System.Drawing.Size(319, 121);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPasswordConfirm;
        private System.Windows.Forms.TextBox textBoxPasswordEntered;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelConfirm;
        private System.Windows.Forms.Button buttonShowInsert;
        private System.Windows.Forms.Button buttonShowRepeat;
    }
}
