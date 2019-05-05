using System;

namespace DatabasePasswordManager.Main.Preview.Timers
{
    internal sealed class TickEventArgs : EventArgs
    {
        #region GLOBAL_VARIABLES
        private int remainingTicks;
        public int RemainingTicks { get { return remainingTicks; } }
        #endregion

        #region CONSTRUCTOR
        public TickEventArgs(int remainingTicks)
        {
            this.remainingTicks = remainingTicks;
        }
        #endregion
    }
}
