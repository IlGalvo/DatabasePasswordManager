using DatabaseCoreLogic.Account;
using System;
using System.Windows.Forms;

namespace DatabasePasswordManager.Main.Manager
{
    public partial class ManagerGeneralAccount : UserControl, IManager<GeneralAccount>
    {
        #region GLOBAL_VARIABLES
        private const string NONE = ("None");

        private GeneralAccount generalAccount;
        private EmailAccount[] emailAccountList;
        private Action<object, EventArgs> actionToPerform;
        #endregion

        #region FORM_EVENT
        public ManagerGeneralAccount(EmailAccount[] emailAccountList, Action<object, EventArgs> actionToPerform)
        {
            InitializeComponent();

            generalAccount = new GeneralAccount();
            this.emailAccountList = emailAccountList;
            this.actionToPerform = actionToPerform;
        }

        public ManagerGeneralAccount(GeneralAccount generalAccount, EmailAccount[] emailAccountList, Action<object, EventArgs> actionToPerform)
        {
            InitializeComponent();

            this.generalAccount = generalAccount;
            this.emailAccountList = emailAccountList;
            this.actionToPerform = actionToPerform;
        }

        private void ManagerGeneralAccount_Load(object sender, EventArgs e)
        {
            textBoxName.Text = generalAccount.Name;
            textBoxName.SelectionStart = textBoxName.TextLength;
            textBoxUsername.Text = generalAccount.Username;

            for (int i = 0; i != emailAccountList.Length; i++)
            {
                comboBoxEmail.Items.Add(emailAccountList[i].Email);
            }
            comboBoxEmail.Items.Add(NONE);
            comboBoxEmail.SelectedItem = ((!string.IsNullOrEmpty(generalAccount.Email)) ? generalAccount.Email : NONE);

            textBoxPassword.Text = generalAccount.Password;
            textBoxOther.Text = generalAccount.Other;
        }
        #endregion

        #region BUTTON_EVENTS
        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.UseSystemPasswordChar)
            {
                textBoxPassword.UseSystemPasswordChar = (!textBoxPassword.UseSystemPasswordChar);
            }
        }

        private void buttonShow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxPassword.UseSystemPasswordChar = (!textBoxPassword.UseSystemPasswordChar);
            }
        }

        private void buttonShow_MouseDownAndUp(object sender, MouseEventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = (!textBoxPassword.UseSystemPasswordChar);
        }
        #endregion

        #region TEXTBOX_EVENT
        private void textBoxesInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;

                actionToPerform?.BeginInvoke(this, new EventArgs(), null, null);
            }
        }
        #endregion

        #region INTERFACE_METHOD
        public GeneralAccount GetAccountRow()
        {
            generalAccount.Name = ((textBoxName.Text != string.Empty) ? textBoxName.Text : null);
            generalAccount.Username = textBoxUsername.Text;
            generalAccount.Password = ((textBoxPassword.Text != string.Empty) ? textBoxPassword.Text : null);
            generalAccount.Other = textBoxOther.Text;

            string emailID = null;
            if (comboBoxEmail.SelectedItem.ToString() != NONE)
            {
                for (int i = 0; i != emailAccountList.Length; i++)
                {
                    if (emailAccountList[i].Email == comboBoxEmail.SelectedItem.ToString())
                    {
                        emailID = emailAccountList[i].ID.ToString();
                        break;
                    }
                }
            }
            generalAccount.Email = emailID;

            if (generalAccount == GeneralAccount.Empty)
            {
                throw (new FormatException("The Row must not be empty."));
            }

            return generalAccount;
        }
        #endregion
    }
}
