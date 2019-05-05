using System;
using System.Windows.Forms;

namespace DatabasePasswordManager.Startup
{
    public partial class StartupCreate : UserControl, IStartup
    {
        #region GLOBAL_VARIABLE
        private Action<object, EventArgs> actionToPerform;
        #endregion

        #region CONSTRUCTOR
        public StartupCreate(Action<object, EventArgs> actionToPerform)
        {
            InitializeComponent();

            this.actionToPerform = actionToPerform;
        }
        #endregion

        #region BUTTON_EVENTS
        private void buttonShow_Click(object sender, EventArgs e)
        {
            bool manage = (textBoxPasswordEntered.UseSystemPasswordChar && textBoxPasswordConfirm.UseSystemPasswordChar);

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
            if ((button == buttonShowInsert) && (manage))
            {
                textBoxPasswordEntered.UseSystemPasswordChar = (!textBoxPasswordEntered.UseSystemPasswordChar);
            }
            else if (manage)
            {
                textBoxPasswordConfirm.UseSystemPasswordChar = (!textBoxPasswordConfirm.UseSystemPasswordChar);
            }
        }
        #endregion

        #region TEXTBOX_EVENT
        private void textBoxesPasswords_KeyPress(object sender, KeyPressEventArgs e)
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
            if (textBoxPasswordEntered.Text != textBoxPasswordConfirm.Text)
            {
                throw (new ArgumentException("Passwords don't match."));
            }

            return textBoxPasswordEntered.Text;
        }
        #endregion
    }
}
