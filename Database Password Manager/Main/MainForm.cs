using CustomControlCollection;
using CustomControlCollection.RichTextBoxes;
using DatabaseCoreLogic;
using DatabaseCoreLogic.Account;
using DatabasePasswordManager.Main.Manager;
using DatabasePasswordManager.Main.Preview;
using DatabasePasswordManager.Startup;
using Microsoft.CognitiveServices.Speech;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DatabasePasswordManager.Main
{
    public partial class MainForm : Form
    {
        #region GLOBAL_VARIABLES
        private AccountType accountType;
        private SpeechRecognizer speechRecognizer;    
        
        private CoreLogic coreLogic;
        #endregion

        #region FORM_EVENTS
        public MainForm(CoreLogic coreLogic)
        {
            InitializeComponent();

            SpeechConfig speechConfig = SpeechConfig.FromSubscription("fdd7b2c3aea843e5847487bc264219bb", "westeurope");
            speechConfig.SpeechRecognitionLanguage = "it-IT";
            
            accountType = AccountType.GeneralAccount;
            speechRecognizer = new SpeechRecognizer(speechConfig);

            this.coreLogic = coreLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            coreLogic.GeneralAccountChanges += CoreLogic_GeneralAccountChanges;
            coreLogic.EmailAccountChanges += CoreLogic_EmailAccountChanges;

            speechRecognizer.Recognizing += SpeechRecognizer_Recognizing;

            labelError.Text = string.Empty;
            labelAutoLock.Text = string.Empty;

            CoreLogic_GeneralAccountChanges(this, new EventArgs());
            accountType = AccountType.EmailAccount;

            CoreLogic_EmailAccountChanges(this, new EventArgs());
            accountType = AccountType.GeneralAccount;

            EnableTimerAndSession(true);
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            switch (accountType)
            {
                case AccountType.GeneralAccount:
                    tabPageGeneralAccount.Focus();
                    break;
                case AccountType.EmailAccount:
                    tabPageEmailAccount.Focus();
                    break;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            EnableTimerAndSession(false);

            coreLogic.CloseDatabaseConnection();
        }
        #endregion

        #region FORM_STATUS
        private void EnableTimerAndSession(bool enable)
        {
            if (enable)
            {
                timerAutoLock.Start();

                SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            }
            else
            {
                timerAutoLock.Stop();

                SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;
            }
        }
        #endregion

        #region SYSTEM_EVENT
        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if ((e.Reason == SessionSwitchReason.SessionLock) ||
                (e.Reason == SessionSwitchReason.ConsoleDisconnect) ||
                (e.Reason == SessionSwitchReason.SessionRemoteControl))
            {
                lockToolStripMenuItem_Click(this, new EventArgs());
            }
        }
        #endregion

        #region TIMER_EVENT
        private void timerAutoLock_Tick(object sender, EventArgs e)
        {
            uint lastInputTime = SafeNativeMethods.GetLastInputTime();
            uint lockCountdown = (MainUtilities.MaxIdleTimeLock - lastInputTime);

            if (lastInputTime >= MainUtilities.MaxIdleTimeNotify)
            {
                SetLabelAutoLockText(string.Format(MainUtilities.LockNotificationText, lockCountdown));

                if (lockCountdown == 0)
                {
                    SetLabelAutoLockText(string.Empty);

                    lockToolStripMenuItem_Click(this, new EventArgs());
                }
            }
            else if ((lastInputTime == 0) && (labelAutoLock.Text != string.Empty))
            {
                SetLabelAutoLockText(string.Empty);
            }
        }
        #endregion

        #region TOOLSTRIPMENU_EVENTS
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StartupForm.ChangeDatabasePassword(coreLogic) == DialogResult.OK)
            {
                MessageBox.Show("Passowrd changed with success.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!coreLogic.IsDatabaseConnectionOpened())
            {
                Application.Restart();
            }
        }

        private void createBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StartupForm.BackupDatabase(coreLogic) == DialogResult.OK)
            {
                MessageBox.Show("Backup created successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!coreLogic.IsDatabaseConnectionOpened())
            {
                Application.Restart();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerForm.AddRow(accountType, coreLogic);
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    lockToolStripMenuItem_Click(sender, e);
                });
            }
            else
            {
                EnableTimerAndSession(false);
                coreLogic.CloseDatabaseConnection();

                Hide();

                if (StartupForm.StartupDatabase(coreLogic) == DialogResult.OK)
                {
                    Show();

                    EnableTimerAndSession(true);
                }
                else
                {
                    Close();
                }
            }
        }
        #endregion

        #region TEXTBOX_EVENT
        private void textBoxPlaceholder_TextChanged(object sender, EventArgs e)
        {
            switch (accountType)
            {
                case AccountType.GeneralAccount:
                    CoreLogic_GeneralAccountChanges(this, new EventArgs());
                    break;
                case AccountType.EmailAccount:
                    CoreLogic_EmailAccountChanges(this, new EventArgs());
                    break;
            }
        }
        #endregion

        #region TEXTBOX_STATUS
        private void SetPlaceholderRichTextBoxText(string text)
        {
            PlaceholderRichTextBox placeholderRichTextBox = null;

            switch (accountType)
            {
                case AccountType.GeneralAccount:
                    placeholderRichTextBox = placeholderRichTextBoxGeneralAccount;
                    break;
                case AccountType.EmailAccount:
                    placeholderRichTextBox = placeholderRichTextBoxEmailAccount;
                    break;
            }

            if (placeholderRichTextBox.InvokeRequired)
            {
                placeholderRichTextBox.BeginInvoke((MethodInvoker)delegate
                {
                    SetPlaceholderRichTextBoxText(text);
                });
            }
            else
            {
                placeholderRichTextBox.Text = text;
            }
        }
        #endregion

        #region BUTTON_EVENTS
        private async void buttonMicrophoneSearch_ClickAsync(object sender, EventArgs e)
        {
            if (SafeNativeMethods.IsInternetAvailable())
            {
                EnableMicrophoneSearchButton(false);
                Console.Beep(MainUtilities.BeepFrequency, MainUtilities.BeepDuration);

                SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeOnceAsync();

                if (speechRecognitionResult.Reason == ResultReason.RecognizedSpeech)
                {
                    SetPlaceholderRichTextBoxText(speechRecognitionResult.Text.Remove(speechRecognitionResult.Text.Length - 1));
                }
                else if (speechRecognitionResult.Reason == ResultReason.NoMatch)
                {
                    SetPlaceholderRichTextBoxText(MainUtilities.NoResultsText);
                }
                else if (speechRecognitionResult.Reason == ResultReason.Canceled)
                {
                    CancellationDetails cancellationDetails = CancellationDetails.FromResult(speechRecognitionResult);

                    if (cancellationDetails.Reason == CancellationReason.Error)
                    {
                        SetLabelErrorText(("Error: " + cancellationDetails.ErrorDetails + " (" + cancellationDetails.ErrorCode + ")."));
                    }
                }

                Console.Beep(MainUtilities.BeepFrequency, MainUtilities.BeepDuration);
                EnableMicrophoneSearchButton(true);
            }
            else
            {
                SetLabelErrorText("Error: No internet Connection.");
            }
        }

        private void buttonMicrophoneSearch_MouseEnter(object sender, EventArgs e)
        {
            buttonMicrophoneSearch.BackColor = Color.Gainsboro;
        }

        private void buttonMicrophoneSearch_MouseLeave(object sender, EventArgs e)
        {
            buttonMicrophoneSearch.BackColor = Color.White;
        }
        #endregion

        #region BUTTON_STATUS
        private void EnableMicrophoneSearchButton(bool enable)
        {
            if (buttonMicrophoneSearch.InvokeRequired)
            {
                buttonMicrophoneSearch.BeginInvoke((MethodInvoker)delegate
                {
                    EnableMicrophoneSearchButton(enable);
                });
            }
            else
            {
                buttonMicrophoneSearch.Enabled = enable;
            }
        }
        #endregion

        #region SPEECHRECOGNIZER_EVENT
        private void SpeechRecognizer_Recognizing(object sender, SpeechRecognitionEventArgs e)
        {
            SetPlaceholderRichTextBoxText(e.Result.Text);
        }
        #endregion

        #region LABELERROR_EVENT
        private void labelError_Click(object sender, EventArgs e)
        {
            Process.Start((MainUtilities.QueryErrorSearch + labelError.Text.Remove(labelError.Text.Length - 1))).Dispose();
        }
        #endregion

        #region LABELERROR_STATUS
        private void SetLabelErrorText(string text)
        {
            if (labelError.InvokeRequired)
            {
                labelError.BeginInvoke((MethodInvoker)delegate
                {
                    SetLabelErrorText(text);
                });
            }
            else
            {
                if (labelError.Text == string.Empty)
                {
                    Timer timer = new Timer();
                    timer.Interval = MainUtilities.LongTimerDelay;

                    timer.Tick += delegate
                    {
                        labelError.Text = string.Empty;

                        timer.Stop();
                        timer.Dispose();
                    };

                    timer.Start();
                }

                labelError.Text = text;
            }
        }
        #endregion

        #region TABCONTROL_EVENT
        private void tabControlAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            accountType = (AccountType)Enum.Parse(typeof(AccountType), ((TabControl)sender).SelectedTab.Name.Remove(0, 7));

            placeholderRichTextBoxGeneralAccount.Visible = (!placeholderRichTextBoxGeneralAccount.Visible);
            placeholderRichTextBoxEmailAccount.Visible = (!placeholderRichTextBoxEmailAccount.Visible);
        }
        #endregion

        #region CORELOGIC_EVENTS
        private void CoreLogic_GeneralAccountChanges(object sender, EventArgs e)
        {
            try
            {
                GeneralAccount[] generalAccountList = coreLogic.QuerySearchGeneralAccountData(placeholderRichTextBoxGeneralAccount.Text);

                ManageFixedFlowLayoutPanelAccount(optimizedFlowLayoutPanelGeneralAccount, generalAccountList);
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

        private void CoreLogic_EmailAccountChanges(object sender, EventArgs e)
        {
            try
            {
                EmailAccount[] emailAccountList = coreLogic.QuerySearchEmailAccountData(placeholderRichTextBoxEmailAccount.Text);

                ManageFixedFlowLayoutPanelAccount(optimizedFlowLayoutPanelEmailAccount, emailAccountList);
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

        private void ManageFixedFlowLayoutPanelAccount(OptimizedFlowLayoutPanel fixedFlowLayoutPanelAccount, Array accountList)
        {
            PreviewUserControl[] previewUserControlList = new PreviewUserControl[accountList.Length];

            for (int i = 0; i != accountList.Length; i++)
            {
                previewUserControlList[i] = new PreviewUserControl(accountType, ((IAccount)accountList.GetValue(i)), coreLogic);
            }

            fixedFlowLayoutPanelAccount.Controls.Clear();
            fixedFlowLayoutPanelAccount.Controls.AddRange(previewUserControlList);
            fixedFlowLayoutPanelAccount.AutoScrollPosition = new Point(0, 0);
        }
        #endregion

        #region FLOWLAYOUTPANELACCOUNTS_EVENT
        private void flowLayoutPanelAccounts_ControlRemoved(object sender, ControlEventArgs e)
        {
            e.Control.Dispose();
        }
        #endregion

        #region LABELAUTOLOCK_STATUS
        private void SetLabelAutoLockText(string text)
        {
            if (labelAutoLock.InvokeRequired)
            {
                labelAutoLock.BeginInvoke((MethodInvoker)delegate
                {
                    SetLabelAutoLockText(text);
                });
            }
            else
            {
                labelAutoLock.Text = text;
            }
        }
        #endregion
    }
}
