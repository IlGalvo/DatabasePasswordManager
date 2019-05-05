using DatabaseCoreLogic;
using System;
using System.Windows.Forms;

namespace DatabasePasswordManager.Startup
{
    public partial class StartupForm : Form
    {
        #region GLOBAL_VARIABLES
        private enum StartupAction
        {
            Create,
            Login,
            Change,
            Backup
        }

        private UserControl userControl;

        private StartupAction startupAction;
        private CoreLogic coreLogic;
        #endregion

        #region FORM_ACTIONS
        public static DialogResult StartupDatabase(CoreLogic coreLogic)
        {
            return ExecuteAction(((coreLogic.DatabaseExists()) ? StartupAction.Login : StartupAction.Create), coreLogic);
        }

        public static DialogResult ChangeDatabasePassword(CoreLogic coreLogic)
        {
            return ExecuteAction(StartupAction.Change, coreLogic);
        }

        public static DialogResult BackupDatabase(CoreLogic coreLogic)
        {
            return ExecuteAction(StartupAction.Backup, coreLogic);
        }

        private static DialogResult ExecuteAction(StartupAction startupAction, CoreLogic coreLogic)
        {
            StartupForm startupForm = new StartupForm(startupAction, coreLogic);
            DialogResult dialogResult = startupForm.ShowDialog();
            startupForm.Dispose();

            return dialogResult;
        }
        #endregion

        #region FORM_EVENTS
        private StartupForm(StartupAction startupAction, CoreLogic coreLogic)
        {
            InitializeComponent();

            this.startupAction = startupAction;
            this.coreLogic = coreLogic;

            Action<object, EventArgs> actionToPerform = buttonAction_Click;

            switch (startupAction)
            {
                case StartupAction.Create:
                    userControl = new StartupCreate(actionToPerform);
                    break;
                case StartupAction.Login:
                case StartupAction.Backup:
                    userControl = new StartupLogin(actionToPerform);
                    break;
                case StartupAction.Change:
                    userControl = new StartupChange(actionToPerform);
                    break;
            }

            panelContainer.Controls.Add(userControl);
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
            buttonAction.Text = startupAction.ToString();
        }
        #endregion

        #region BUTTON_ACTION
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
                    switch (startupAction)
                    {
                        case StartupAction.Create:
                            coreLogic.CreateDatabase(((StartupCreate)userControl).GetPassword());
                            break;
                        case StartupAction.Login:
                        case StartupAction.Backup:
                            string plainTextPassword = ((StartupLogin)userControl).GetPassword();

                            coreLogic.CloseDatabaseConnection();
                            coreLogic.LoginDatabase(plainTextPassword);

                            if (startupAction == StartupAction.Backup)
                            {
                                coreLogic.BackupDatabase(plainTextPassword);
                            }
                            break;
                        case StartupAction.Change:
                            StartupChange startupChange = ((StartupChange)userControl);

                            string[] plainTextPasswords = startupChange.GetPassword()
                                .Split(new string[] { StartupChange.PasswordsSeparator }, StringSplitOptions.RemoveEmptyEntries);

                            coreLogic.CloseDatabaseConnection();
                            coreLogic.LoginDatabase(plainTextPasswords[0]);

                            coreLogic.ChangeDatabasePassword(plainTextPasswords[1]);
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
    }
    #endregion
}
