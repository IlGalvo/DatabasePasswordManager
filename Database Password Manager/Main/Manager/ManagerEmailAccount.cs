using DatabaseCoreLogic.Account;
using System;
using System.Windows.Forms;

namespace DatabasePasswordManager.Main.Manager
{
    public partial class ManagerEmailAccount : UserControl, IManager<EmailAccount>
    {
        #region GLOBAL_VARIABLE
        private EmailAccount emailAccount;
        private Action<object, EventArgs> actionToPerform;
        #endregion

        #region FORM_EVENTS
        public ManagerEmailAccount(Action<object, EventArgs> actionToPerform)
        {
            InitializeComponent();

            emailAccount = new EmailAccount();
            this.actionToPerform = actionToPerform;
        }

        public ManagerEmailAccount(EmailAccount emailAccount, Action<object, EventArgs> actionToPerform)
        {
            InitializeComponent();

            this.emailAccount = emailAccount;
            this.actionToPerform = actionToPerform;
        }

        private void ManagerEmailAccount_Load(object sender, EventArgs e)
        {
            textBoxName.Text = emailAccount.Name;
            textBoxName.SelectionStart = textBoxName.TextLength;
            textBoxEmail.Text = emailAccount.Email;
            textBoxPassword.Text = emailAccount.Password;
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
        private void textBoxexInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;

                actionToPerform?.BeginInvoke(this, new EventArgs(), null, null);
            }
        }
        #endregion

        #region INTERFACE_METHOD
        public EmailAccount GetAccountRow()
        {
            emailAccount.Name = ((textBoxName.Text != string.Empty) ? textBoxName.Text : null);
            emailAccount.Email = ((textBoxEmail.Text != string.Empty) ? textBoxEmail.Text : null);
            emailAccount.Password = ((textBoxPassword.Text != string.Empty) ? textBoxPassword.Text : null);

            if (emailAccount == EmailAccount.Empty)
            {
                throw (new FormatException("The Row must not be empty."));
            }

            return emailAccount;
        }
        #endregion
    }
}
