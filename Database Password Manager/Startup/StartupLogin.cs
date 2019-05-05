using System;
using System.Windows.Forms;

namespace DatabasePasswordManager.Startup
{
    public partial class StartupLogin : UserControl, IStartup
    {
        #region GLOBAL_VARIABLE
        private Action<object, EventArgs> actionToPerform;
        #endregion

        #region CONSTRUCTOR
        public StartupLogin(Action<object, EventArgs> actionToPerform)
        {
            InitializeComponent();

            this.actionToPerform = actionToPerform;
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
        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
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
            return textBoxPassword.Text;
        }
        #endregion
    }
}
