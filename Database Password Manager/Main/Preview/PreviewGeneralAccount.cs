using DatabaseCoreLogic.Account;
using DatabasePasswordManager.Main.Preview.Timers;
using System;
using System.Windows.Forms;

namespace DatabasePasswordManager.Main.Preview
{
    public partial class PreviewGeneralAccount : UserControl
    {
        #region GLOBAL_VARIABLES
        private RepeatingTimer repeatingTimer;

        private GeneralAccount generalAccount;
        #endregion

        #region FORM_EVENTS
        public PreviewGeneralAccount(GeneralAccount generalAccount)
        {
            InitializeComponent();

            repeatingTimer = new RepeatingTimer(PreviewUtilities.TimerTickInterval, PreviewUtilities.TimerRepeatingTimes);

            this.generalAccount = generalAccount;
        }

        private void PreviewGeneralAccount_Load(object sender, EventArgs e)
        {
            repeatingTimer.Tick += RepeatingTimer_Tick;
            repeatingTimer.Elapsed += RepeatingTimer_Elapsed;

            textBoxName.Text = generalAccount.Name;
            textBoxUsername.Text = generalAccount.Username;
            textBoxEmail.Text = generalAccount.Email;
            textBoxPassword.Text = generalAccount.Password;
            textBoxOther.Text = generalAccount.Other;
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
