namespace DatabasePasswordManager.Main.Preview
{
    partial class PreviewUserControl
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
            this.components = new System.ComponentModel.Container();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.toolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.roundedButtonInformation = new CustomControlCollection.Buttons.RoundedButton();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.AutoSize = true;
            this.panelContainer.BackColor = System.Drawing.Color.Gainsboro;
            this.panelContainer.Location = new System.Drawing.Point(3, 3);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(272, 116);
            this.panelContainer.TabIndex = 0;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.BackColor = System.Drawing.SystemColors.Control;
            this.buttonDelete.Location = new System.Drawing.Point(189, 125);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(80, 32);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.buttonUpdate.Location = new System.Drawing.Point(9, 125);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(80, 32);
            this.buttonUpdate.TabIndex = 1;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // roundedButtonInformation
            // 
            this.roundedButtonInformation.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.roundedButtonInformation.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedButtonInformation.BackgroundImage = global::DatabasePasswordManager.Properties.Resources.Information;
            this.roundedButtonInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.roundedButtonInformation.FlatAppearance.BorderSize = 0;
            this.roundedButtonInformation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.roundedButtonInformation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.roundedButtonInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonInformation.Location = new System.Drawing.Point(125, 125);
            this.roundedButtonInformation.Name = "roundedButtonInformation";
            this.roundedButtonInformation.Size = new System.Drawing.Size(33, 32);
            this.roundedButtonInformation.TabIndex = 3;
            this.roundedButtonInformation.TabStop = false;
            this.roundedButtonInformation.UseVisualStyleBackColor = false;
            this.roundedButtonInformation.MouseHover += new System.EventHandler(this.roundedButtonInformation_MouseHover);
            // 
            // PreviewUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.roundedButtonInformation);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.panelContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PreviewUserControl";
            this.Size = new System.Drawing.Size(279, 167);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ToolTip toolTipInformation;
        private CustomControlCollection.Buttons.RoundedButton roundedButtonInformation;
    }
}
