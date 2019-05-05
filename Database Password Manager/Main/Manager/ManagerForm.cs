using DatabaseCoreLogic.Account;
using System;
using System.Windows.Forms;
using DatabaseCoreLogic;

namespace DatabasePasswordManager.Main.Manager
{
    public partial class ManagerForm : Form
    {
        #region GLOBAL_VARIABLES
        private enum UserAction
        {
            Add,
            Update
        }

        private AccountType accountType;
        private UserAction userAction;
        private CoreLogic coreLogic;
        private UserControl userControl;
        #endregion

        #region FORM_ACTIONS
        public static DialogResult AddRow(AccountType accountType, CoreLogic coreLogic)
        {
            return ExecuteAction(accountType, UserAction.Add, null, coreLogic);
        }

        public static DialogResult UpdateRow(AccountType accountType, IAccount iAccount, CoreLogic coreLogic)
        {
            return ExecuteAction(accountType, UserAction.Update, iAccount, coreLogic);
        }

        private static DialogResult ExecuteAction(AccountType accountType, UserAction userAction, IAccount iAccount, CoreLogic coreLogic)
        {
            ManagerForm managerForm = new ManagerForm(accountType, userAction, iAccount, coreLogic);
            DialogResult dialogResult = managerForm.ShowDialog();
            managerForm.Dispose();

            return dialogResult;
        }
        #endregion

        #region FORM_EVENTS
        private ManagerForm(AccountType accountType, UserAction userAction, IAccount iAccount, CoreLogic coreLogic)
        {
            InitializeComponent();

            this.accountType = accountType;
            this.userAction = userAction;
            this.coreLogic = coreLogic;

            Action<object, EventArgs> actionToPerform = buttonAction_Click;

            switch (accountType)
            {
                case AccountType.EmailAccount:
                    switch (userAction)
                    {
                        case UserAction.Add:
                            userControl = new ManagerEmailAccount(actionToPerform);
                            break;
                        case UserAction.Update:
                            userControl = new ManagerEmailAccount(((EmailAccount)iAccount), actionToPerform);
                            break;
                    }
                    break;
                case AccountType.GeneralAccount:
                    try
                    {
                        EmailAccount[] emailAccountList = coreLogic.QuerySearchEmailAccountData();

                        switch (userAction)
                        {
                            case UserAction.Add:
                                userControl = new ManagerGeneralAccount(emailAccountList, actionToPerform);
                                break;
                            case UserAction.Update:
                                userControl = new ManagerGeneralAccount(((GeneralAccount)iAccount), emailAccountList, actionToPerform);
                                break;
                        }
                    }
                    catch (CoreLogicException coreLogicException)
                    {
                        MessageBox.Show(coreLogicException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }

            panelContainer.Controls.Add(userControl);
        }

        private void FormManager_Load(object sender, EventArgs e)
        {
            buttonAction.Text = userAction.ToString();
        }
        #endregion

        #region BUTTON_EVENT
        private void buttonAction_Click(object sender, EventArgs e)
        {
            if (buttonAction.InvokeRequired)
            {
                buttonAction.BeginInvoke((MethodInvoker)delegate
                {
                    buttonAction_Click(sender, e);
                });
            }
            else
            {
                try
                {
                    switch (accountType)
                    {
                        case AccountType.EmailAccount:
                            EmailAccount emailAccount = ((ManagerEmailAccount)userControl).GetAccountRow();

                            switch (userAction)
                            {
                                case UserAction.Add:
                                    coreLogic.InsertEmailAccountData(emailAccount.Name, emailAccount.Email, emailAccount.Password);
                                    break;
                                case UserAction.Update:
                                    coreLogic.UpdateEmailAccountData(emailAccount.Name, emailAccount.Email, emailAccount.Password, emailAccount.ID);
                                    break;
                            }
                            break;

                        case AccountType.GeneralAccount:
                            GeneralAccount generalAccount = ((ManagerGeneralAccount)userControl).GetAccountRow();

                            uint? emailID = ((!string.IsNullOrEmpty(generalAccount.Email)) ? uint.Parse(generalAccount.Email) : ((uint?)null));

                            switch (userAction)
                            {
                                case UserAction.Add:
                                    coreLogic.InsertGeneralAccountData(generalAccount.Name, generalAccount.Username, generalAccount.Password,
                                        generalAccount.Other, emailID);
                                    break;
                                case UserAction.Update:
                                    coreLogic.UpdateGeneralAccountData(generalAccount.Name, generalAccount.Username, generalAccount.Password,
                                        generalAccount.Other, emailID, generalAccount.ID);
                                    break;
                            }
                            break;
                    }

                    panelContainer.Controls.Remove(userControl);
                    userControl.Dispose();

                    DialogResult = DialogResult.OK;
                    Close();
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
