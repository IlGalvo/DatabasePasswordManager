using System.Windows.Forms;
using DatabaseCoreLogic.Account;
using DatabaseCoreLogic;
using System;
using DatabasePasswordManager.Main.Manager;

namespace DatabasePasswordManager.Main.Preview
{
    public partial class PreviewUserControl : UserControl
    {
        #region GLOBAL_VARIABLES        
        private AccountType accountType;
        private IAccount iAccount;
        private CoreLogic coreLogic;
        #endregion

        #region CONSTRUCTORS
        public PreviewUserControl(AccountType accountType, IAccount iAccount, CoreLogic coreLogic)
        {
            InitializeComponent();

            this.accountType = accountType;
            this.iAccount = iAccount;
            this.coreLogic = coreLogic;

            switch(accountType)
            {
                case AccountType.GeneralAccount:
                    panelContainer.Controls.Add(new PreviewGeneralAccount(((GeneralAccount)iAccount)));
                    break;
                case AccountType.EmailAccount:
                    panelContainer.Controls.Add(new PreviewEmailAccount(((EmailAccount)iAccount)));
                    break;
            }
        }
        #endregion

        #region BUTTONUPDATE_EVENT
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ManagerForm.UpdateRow(accountType, iAccount, coreLogic);
        }
        #endregion

        #region BUTTON_INFORMATION
        private void roundedButtonInformation_MouseHover(object sender, EventArgs e)
        {
            string text = ("Creation Date: " + iAccount.CreationDate.ToString() + "\nLast Update: " + iAccount.LastUpdate.ToString());

            toolTipInformation.Show(text, roundedButtonInformation);
        }
        #endregion

        #region BUTTONDELETE_EVENT
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you really sure?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    coreLogic.DeleteSelectedAccountData(accountType, iAccount.ID);
                }
                catch (CoreLogicException coreLogicException)
                {
                    MessageBox.Show(coreLogicException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
