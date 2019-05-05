namespace DatabasePasswordManager.Main
{
    partial class MainForm
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
            speechRecognizer.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControlAccount = new System.Windows.Forms.TabControl();
            this.tabPageGeneralAccount = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelGeneralAccount = new System.Windows.Forms.TableLayoutPanel();
            this.optimizedFlowLayoutPanelGeneralAccount = new CustomControlCollection.OptimizedFlowLayoutPanel();
            this.tabPageEmailAccount = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelEmailAccount = new System.Windows.Forms.TableLayoutPanel();
            this.optimizedFlowLayoutPanelEmailAccount = new CustomControlCollection.OptimizedFlowLayoutPanel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chekUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonMicrophoneSearch = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.labelAutoLock = new System.Windows.Forms.Label();
            this.timerAutoLock = new System.Windows.Forms.Timer(this.components);
            this.placeholderRichTextBoxGeneralAccount = new CustomControlCollection.RichTextBoxes.PlaceholderRichTextBox();
            this.placeholderRichTextBoxEmailAccount = new CustomControlCollection.RichTextBoxes.PlaceholderRichTextBox();
            this.tabControlAccount.SuspendLayout();
            this.tabPageGeneralAccount.SuspendLayout();
            this.tableLayoutPanelGeneralAccount.SuspendLayout();
            this.tabPageEmailAccount.SuspendLayout();
            this.tableLayoutPanelEmailAccount.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAccount
            // 
            this.tabControlAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAccount.Controls.Add(this.tabPageGeneralAccount);
            this.tabControlAccount.Controls.Add(this.tabPageEmailAccount);
            this.tabControlAccount.Location = new System.Drawing.Point(12, 59);
            this.tabControlAccount.Name = "tabControlAccount";
            this.tabControlAccount.SelectedIndex = 0;
            this.tabControlAccount.Size = new System.Drawing.Size(673, 451);
            this.tabControlAccount.TabIndex = 0;
            this.tabControlAccount.SelectedIndexChanged += new System.EventHandler(this.tabControlAccount_SelectedIndexChanged);
            // 
            // tabPageGeneralAccount
            // 
            this.tabPageGeneralAccount.Controls.Add(this.tableLayoutPanelGeneralAccount);
            this.tabPageGeneralAccount.Location = new System.Drawing.Point(4, 27);
            this.tabPageGeneralAccount.Name = "tabPageGeneralAccount";
            this.tabPageGeneralAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneralAccount.Size = new System.Drawing.Size(665, 420);
            this.tabPageGeneralAccount.TabIndex = 0;
            this.tabPageGeneralAccount.Text = "General Account";
            this.tabPageGeneralAccount.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelGeneralAccount
            // 
            this.tableLayoutPanelGeneralAccount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanelGeneralAccount.ColumnCount = 3;
            this.tableLayoutPanelGeneralAccount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.1F));
            this.tableLayoutPanelGeneralAccount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.8F));
            this.tableLayoutPanelGeneralAccount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.1F));
            this.tableLayoutPanelGeneralAccount.Controls.Add(this.optimizedFlowLayoutPanelGeneralAccount, 1, 0);
            this.tableLayoutPanelGeneralAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGeneralAccount.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelGeneralAccount.Name = "tableLayoutPanelGeneralAccount";
            this.tableLayoutPanelGeneralAccount.RowCount = 1;
            this.tableLayoutPanelGeneralAccount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGeneralAccount.Size = new System.Drawing.Size(659, 414);
            this.tableLayoutPanelGeneralAccount.TabIndex = 0;
            this.tableLayoutPanelGeneralAccount.Click += new System.EventHandler(this.MainForm_Click);
            // 
            // optimizedFlowLayoutPanelGeneralAccount
            // 
            this.optimizedFlowLayoutPanelGeneralAccount.AutoScroll = true;
            this.optimizedFlowLayoutPanelGeneralAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optimizedFlowLayoutPanelGeneralAccount.Location = new System.Drawing.Point(62, 3);
            this.optimizedFlowLayoutPanelGeneralAccount.Name = "optimizedFlowLayoutPanelGeneralAccount";
            this.optimizedFlowLayoutPanelGeneralAccount.Size = new System.Drawing.Size(533, 408);
            this.optimizedFlowLayoutPanelGeneralAccount.TabIndex = 0;
            this.optimizedFlowLayoutPanelGeneralAccount.Click += new System.EventHandler(this.MainForm_Click);
            this.optimizedFlowLayoutPanelGeneralAccount.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelAccounts_ControlRemoved);
            // 
            // tabPageEmailAccount
            // 
            this.tabPageEmailAccount.Controls.Add(this.tableLayoutPanelEmailAccount);
            this.tabPageEmailAccount.Location = new System.Drawing.Point(4, 27);
            this.tabPageEmailAccount.Name = "tabPageEmailAccount";
            this.tabPageEmailAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEmailAccount.Size = new System.Drawing.Size(665, 420);
            this.tabPageEmailAccount.TabIndex = 1;
            this.tabPageEmailAccount.Text = "Email Account";
            this.tabPageEmailAccount.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelEmailAccount
            // 
            this.tableLayoutPanelEmailAccount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanelEmailAccount.ColumnCount = 3;
            this.tableLayoutPanelEmailAccount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.1F));
            this.tableLayoutPanelEmailAccount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.8F));
            this.tableLayoutPanelEmailAccount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.1F));
            this.tableLayoutPanelEmailAccount.Controls.Add(this.optimizedFlowLayoutPanelEmailAccount, 1, 0);
            this.tableLayoutPanelEmailAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelEmailAccount.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelEmailAccount.Name = "tableLayoutPanelEmailAccount";
            this.tableLayoutPanelEmailAccount.RowCount = 1;
            this.tableLayoutPanelEmailAccount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEmailAccount.Size = new System.Drawing.Size(659, 414);
            this.tableLayoutPanelEmailAccount.TabIndex = 0;
            this.tableLayoutPanelEmailAccount.Click += new System.EventHandler(this.MainForm_Click);
            // 
            // optimizedFlowLayoutPanelEmailAccount
            // 
            this.optimizedFlowLayoutPanelEmailAccount.AutoScroll = true;
            this.optimizedFlowLayoutPanelEmailAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optimizedFlowLayoutPanelEmailAccount.Location = new System.Drawing.Point(62, 3);
            this.optimizedFlowLayoutPanelEmailAccount.Name = "optimizedFlowLayoutPanelEmailAccount";
            this.optimizedFlowLayoutPanelEmailAccount.Size = new System.Drawing.Size(533, 408);
            this.optimizedFlowLayoutPanelEmailAccount.TabIndex = 0;
            this.optimizedFlowLayoutPanelEmailAccount.Click += new System.EventHandler(this.MainForm_Click);
            this.optimizedFlowLayoutPanelEmailAccount.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelAccounts_ControlRemoved);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.lockToolStripMenuItem,
            this.addAccountToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(697, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.Click += new System.EventHandler(this.MainForm_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.createBackupToolStripMenuItem,
            this.chekUpdatesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // createBackupToolStripMenuItem
            // 
            this.createBackupToolStripMenuItem.Name = "createBackupToolStripMenuItem";
            this.createBackupToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.createBackupToolStripMenuItem.Text = "Create Backup";
            this.createBackupToolStripMenuItem.Click += new System.EventHandler(this.createBackupToolStripMenuItem_Click);
            // 
            // chekUpdatesToolStripMenuItem
            // 
            this.chekUpdatesToolStripMenuItem.Name = "chekUpdatesToolStripMenuItem";
            this.chekUpdatesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.chekUpdatesToolStripMenuItem.Text = "Chek Updates";
            this.chekUpdatesToolStripMenuItem.Click += new System.EventHandler(this.chekUpdatesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.lockToolStripMenuItem.Text = "Lock";
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
            // 
            // addAccountToolStripMenuItem
            // 
            this.addAccountToolStripMenuItem.Name = "addAccountToolStripMenuItem";
            this.addAccountToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.addAccountToolStripMenuItem.Text = "Add Account";
            this.addAccountToolStripMenuItem.Click += new System.EventHandler(this.addAccountToolStripMenuItem_Click);
            // 
            // buttonMicrophoneSearch
            // 
            this.buttonMicrophoneSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMicrophoneSearch.BackColor = System.Drawing.Color.White;
            this.buttonMicrophoneSearch.BackgroundImage = global::DatabasePasswordManager.Properties.Resources.Microphone;
            this.buttonMicrophoneSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMicrophoneSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMicrophoneSearch.Location = new System.Drawing.Point(239, 26);
            this.buttonMicrophoneSearch.Name = "buttonMicrophoneSearch";
            this.buttonMicrophoneSearch.Size = new System.Drawing.Size(29, 26);
            this.buttonMicrophoneSearch.TabIndex = 2;
            this.buttonMicrophoneSearch.UseVisualStyleBackColor = false;
            this.buttonMicrophoneSearch.Click += new System.EventHandler(this.buttonMicrophoneSearch_ClickAsync);
            this.buttonMicrophoneSearch.MouseEnter += new System.EventHandler(this.buttonMicrophoneSearch_MouseEnter);
            this.buttonMicrophoneSearch.MouseLeave += new System.EventHandler(this.buttonMicrophoneSearch_MouseLeave);
            // 
            // labelError
            // 
            this.labelError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(274, 30);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(46, 18);
            this.labelError.TabIndex = 3;
            this.labelError.Text = "Error:";
            this.labelError.Click += new System.EventHandler(this.labelError_Click);
            // 
            // labelAutoLock
            // 
            this.labelAutoLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelAutoLock.AutoSize = true;
            this.labelAutoLock.Location = new System.Drawing.Point(9, 513);
            this.labelAutoLock.Name = "labelAutoLock";
            this.labelAutoLock.Size = new System.Drawing.Size(94, 18);
            this.labelAutoLock.TabIndex = 4;
            this.labelAutoLock.Text = "Auto Lock in:";
            // 
            // timerAutoLock
            // 
            this.timerAutoLock.Interval = 1000;
            this.timerAutoLock.Tick += new System.EventHandler(this.timerAutoLock_Tick);
            // 
            // placeholderRichTextBoxGeneralAccount
            // 
            this.placeholderRichTextBoxGeneralAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.placeholderRichTextBoxGeneralAccount.AutoWordSelection = true;
            this.placeholderRichTextBoxGeneralAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeholderRichTextBoxGeneralAccount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.placeholderRichTextBoxGeneralAccount.Location = new System.Drawing.Point(12, 26);
            this.placeholderRichTextBoxGeneralAccount.MaxLength = 32;
            this.placeholderRichTextBoxGeneralAccount.Multiline = false;
            this.placeholderRichTextBoxGeneralAccount.Name = "placeholderRichTextBoxGeneralAccount";
            this.placeholderRichTextBoxGeneralAccount.PlaceholderText = "Search...";
            this.placeholderRichTextBoxGeneralAccount.PlaceholerFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeholderRichTextBoxGeneralAccount.Size = new System.Drawing.Size(228, 27);
            this.placeholderRichTextBoxGeneralAccount.TabIndex = 1;
            this.placeholderRichTextBoxGeneralAccount.Text = "";
            this.placeholderRichTextBoxGeneralAccount.TextChanged += new System.EventHandler(this.textBoxPlaceholder_TextChanged);
            // 
            // placeholderRichTextBoxEmailAccount
            // 
            this.placeholderRichTextBoxEmailAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.placeholderRichTextBoxEmailAccount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.placeholderRichTextBoxEmailAccount.Location = new System.Drawing.Point(12, 29);
            this.placeholderRichTextBoxEmailAccount.MaxLength = 32;
            this.placeholderRichTextBoxEmailAccount.Name = "placeholderRichTextBoxEmailAccount";
            this.placeholderRichTextBoxEmailAccount.PlaceholderText = "Search...";
            this.placeholderRichTextBoxEmailAccount.PlaceholerFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeholderRichTextBoxEmailAccount.Size = new System.Drawing.Size(228, 24);
            this.placeholderRichTextBoxEmailAccount.TabIndex = 1;
            this.placeholderRichTextBoxEmailAccount.Text = "";
            this.placeholderRichTextBoxEmailAccount.Visible = false;
            this.placeholderRichTextBoxEmailAccount.TextChanged += new System.EventHandler(this.textBoxPlaceholder_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(697, 538);
            this.Controls.Add(this.buttonMicrophoneSearch);
            this.Controls.Add(this.placeholderRichTextBoxGeneralAccount);
            this.Controls.Add(this.labelAutoLock);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.placeholderRichTextBoxEmailAccount);
            this.Controls.Add(this.tabControlAccount);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::DatabasePasswordManager.Properties.Resources.Icon;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Password Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.tabControlAccount.ResumeLayout(false);
            this.tabPageGeneralAccount.ResumeLayout(false);
            this.tableLayoutPanelGeneralAccount.ResumeLayout(false);
            this.tabPageEmailAccount.ResumeLayout(false);
            this.tableLayoutPanelEmailAccount.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControlAccount;
        private System.Windows.Forms.TabPage tabPageGeneralAccount;
        private System.Windows.Forms.TabPage tabPageEmailAccount;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
        private CustomControlCollection.RichTextBoxes.PlaceholderRichTextBox placeholderRichTextBoxEmailAccount;
        private System.Windows.Forms.Button buttonMicrophoneSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGeneralAccount;
        private CustomControlCollection.OptimizedFlowLayoutPanel optimizedFlowLayoutPanelGeneralAccount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEmailAccount;
        private CustomControlCollection.OptimizedFlowLayoutPanel optimizedFlowLayoutPanelEmailAccount;
        private System.Windows.Forms.ToolStripMenuItem chekUpdatesToolStripMenuItem;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelAutoLock;
        private System.Windows.Forms.Timer timerAutoLock;
        private CustomControlCollection.RichTextBoxes.PlaceholderRichTextBox placeholderRichTextBoxGeneralAccount;
    }
}

