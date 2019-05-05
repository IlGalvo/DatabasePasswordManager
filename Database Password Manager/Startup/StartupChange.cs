using System;
using System.Windows.Forms;

namespace DatabasePasswordManager.Startup
{
    public partial class StartupChange : UserControl, IStartup
    {
        #region GLOBAL_VARIABLE
        public static string PasswordsSeparator = ("{[(" + Guid.NewGuid().ToString().Replace("-", "") + ")]}");

        private Action<object, EventArgs> actionToPerform;
        #endregion

        #region CONSTRUCTOR
        public StartupChange(Action<object, EventArgs> actionToPerform)
        {
            InitializeComponent();

            this.actionToPerform = actionToPerform;
        }
        #endregion

        #region BUTTON_EVENTS
        private void buttonShow_Click(object sender, EventArgs e)
        {
            bool manage = (textBoxCurrentPassword.UseSystemPasswordChar &&
                textBoxNewPassword.UseSystemPasswordChar &&
                textBoxConfirmPassword.UseSystemPasswordChar);

            ManageButtonEvents(((Button)sender), manage);
        }

        private void buttonShow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ManageButtonEvents(((Button)sender), true);
            }
        }

        private void buttonShow_MouseDownAndUp(object sender, MouseEventArgs e)
        {
            ManageButtonEvents(((Button)sender), true);
        }

        private void ManageButtonEvents(Button button, bool manage)
        {
            if ((button == buttonShowOldInsert) && (manage))
            {
                textBoxCurrentPassword.UseSystemPasswordChar = (!textBoxCurrentPassword.UseSystemPasswordChar);
            }
            else if ((button == buttonShowNewInsert) & (manage))
            {
                textBoxNewPassword.UseSystemPasswordChar = (!textBoxNewPassword.UseSystemPasswordChar);
            }
            else if (manage)
            {
                textBoxConfirmPassword.UseSystemPasswordChar = (!textBoxConfirmPassword.UseSystemPasswordChar);
            }
        }
        #endregion

        #region TEXTBOX_EVENT
        private void textBoxUserControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;

                actionToPerform?.BeginInvoke(this, new EventArgs(), null, null);
            }
        }
        #endregion

        #region INTERFACE_METHOD
        public string GetPassword()
        {
            if (textBoxCurrentPassword.Text == textBoxNewPassword.Text)
            {
                throw (new ArgumentException("New Password cannot be equal to the older."));
            }
            else if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
            {
                throw (new ArgumentException("New Passwords don't match."));
            }

            return (textBoxCurrentPassword.Text + PasswordsSeparator + textBoxNewPassword.Text);
        }
        #endregion
    }
}
