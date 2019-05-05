using DatabaseCoreLogic.Account;
using DatabasePasswordManager.Main.Preview.Timers;
using System;
using System.Windows.Forms;

namespace DatabasePasswordManager.Main.Preview
{
    public partial class PreviewEmailAccount : UserControl
    {
        #region GLOBAL_VARIABLES
        private RepeatingTimer repeatingTimer;

        private EmailAccount emailAccount;
        #endregion

        #region FORM_EVENTS
        public PreviewEmailAccount(EmailAccount emailAccount)
        {
            InitializeComponent();

            repeatingTimer = new RepeatingTimer(PreviewUtilities.TimerTickInterval, PreviewUtilities.TimerRepeatingTimes);

            this.emailAccount = emailAccount;
        }

        private void PreviewEmailAccount_Load(object sender, EventArgs e)
        {
            repeatingTimer.Tick += RepeatingTimer_Tick;
            repeatingTimer.Elapsed += RepeatingTimer_Elapsed;

            textBoxName.Text = emailAccount.Name;
            textBoxEmail.Text = emailAccount.Email;
            textBoxPassword.Text = emailAccount.Password;
        }
        #endregion

        #region BUTTON_EVENT
        private void buttonShowHide_Click(object sender, EventArgs e)
        {
            if (buttonShowHide.Text == PreviewUtilities.ShowText)
            {
                buttonShowHide.Text = PreviewUtilities.TimerRepeatingTimes.ToString();

                repeatingTimer.Start();
            }
            else
            {
                buttonShowHide.Text = PreviewUtilities.ShowText;

                repeatingTimer.StopAndReset();
            }

            textBoxPassword.UseSystemPasswordChar = (!textBoxPassword.UseSystemPasswordChar);
        }
        #endregion

        #region BUTTON_STATUS
        private void SetButtonShowHideText(string text)
        {
            if (buttonShowHide.InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    SetButtonShowHideText(text);
                });
            }
            else
            {
                buttonShowHide.Text = text;
            }
        }
        #endregion

        #region TEXTBOX_STATUS
        private void SetTextBoxPasswordStatus()
        {
            if (textBoxPassword.InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    SetTextBoxPasswordStatus();
                });
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = (!textBoxPassword.UseSystemPasswordChar);
            }
        }
        #endregion

        #region TIMER_EVENTS
        private void RepeatingTimer_Tick(object sender, TickEventArgs e)
        {
            SetButtonShowHideText(e.RemainingTicks.ToString());
        }

        private void RepeatingTimer_Elapsed(object sender, EventArgs e)
        {
            SetButtonShowHideText(PreviewUtilities.ShowText);

            SetTextBoxPasswordStatus();
        }
        #endregion
    }
}
