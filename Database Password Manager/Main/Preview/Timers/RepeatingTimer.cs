using System;
using System.Timers;

namespace DatabasePasswordManager.Main.Preview.Timers
{
    internal sealed class RepeatingTimer : IDisposable
    {
        #region GLOBAL_VARIABLES
        private Timer repeatingTimer;
        private int tickCounter;

        public int TickInterval { get { return ((int)repeatingTimer.Interval); } set { repeatingTimer.Interval = value; } }

        private int repeatingTimes;
        public int RepeatingTimes
        {
            get { return repeatingTimes; }
            set
            {
                if (!repeatingTimer.Enabled)
                {
                    int repeatingTimes = value;

                    if (repeatingTimes > 0)
                    {
                        this.repeatingTimes = repeatingTimes;
                    }
                    else
                    {
                        throw (new ArgumentException("Value must be greater than 0.", "RepeatingTimes"));
                    }
                }
                else
                {
                    throw (new InvalidOperationException("Cannot change RepeatingTimes value while timer is enabled."));
                }
            }
        }

        public event TickEventHandler Tick;
        public event ElapsedEventHandler Elapsed;
        #endregion

        #region CONSTRUCTORS
        public RepeatingTimer()
        {
            Startup();

            RepeatingTimes = 1;
        }

        public RepeatingTimer(int tickInterval, int repeatingTimes)
        {
            Startup();

            TickInterval = tickInterval;
            RepeatingTimes = repeatingTimes;
        }
        #endregion

        #region STARTUP
        private void Startup()
        {
            repeatingTimer = new Timer();
            repeatingTimer.Elapsed += Timer_Elapsed;
            tickCounter = 0;
        }
        #endregion

        #region TIMER_MANAGER
        public void Start()
        {
            if (!repeatingTimer.Enabled)
            {
                RepeatingTimes = repeatingTimes;

                repeatingTimer.Start();
            }
        }

        public void StopAndReset()
        {
            if (repeatingTimer.Enabled)
            {
                repeatingTimer.Stop();

                tickCounter = 0;
            }
        }
        #endregion

        #region TIMER_EVENT
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (tickCounter != (RepeatingTimes - 1))
            {
                tickCounter++;

                Tick?.Invoke(this, new TickEventArgs((RepeatingTimes - tickCounter)));
            }
            else
            {
                StopAndReset();

                Elapsed?.Invoke(this, new EventArgs());
            }
        }
        #endregion

        #region DISPOSE
        private bool disposedValue = false;

        public void Dispose()
        {
            if (!disposedValue)
            {
                disposedValue = true;

                StopAndReset();
                repeatingTimer.Dispose();
            }
        }
        #endregion
    }
}
