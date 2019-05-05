namespace DatabasePasswordManager.Main
{
    internal static class MainUtilities
    {
        #region GENERAL
        public static int LongTimerDelay { get { return 10000; } }

        public static string QueryErrorSearch { get { return ("https://www.google.com/search?q=" + "Microsoft Cognitive Service Speech To Text "); } }
        #endregion

        #region IDLE
        public static uint MaxIdleTimeNotify { get { return 30; } }

        public static uint MaxIdleTimeLock { get { return 60; } }

        public static string LockNotificationText { get { return ("Auto Lock in: {0}s."); } }
        #endregion

        #region MICROPHONERECOGNITIONCLIENT
        public static string AvailableCulture { get { return ("en-US"); } }

        public static string APIKey { get { return ("8c534f8ebdc34870b8177138d673cb74"); } }

        public static string NoResultsText { get { return ("No results available."); } }
        #endregion

        #region BEEP
        public static int BeepFrequency { get { return 850; } }

        public static int BeepDuration { get { return 115; } }
        #endregion
    }
}
