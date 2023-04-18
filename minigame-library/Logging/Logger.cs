namespace minigame_library.Logging
{
    public class Logger
    {
        private static Logger? _instance;
        private int _id = 0;

        private readonly TraceSource ts;
        private readonly TraceListener listener;

        private Logger()
        {
            throw new InvalidOperationException("Use the Logger.CreateInstance() method instead.");
        }

        private Logger(string logFile, SourceLevels loggingLevel)
        {
            LogFile = logFile;

            ts = new("Debugger")
            {
                Switch = new("User Switch") { Level = loggingLevel }
            };

            listener = new Debugger(new StreamWriter(logFile) { AutoFlush = true });
            ts.Listeners.Add(listener);
        }

        /// <summary>
        /// Gets file path specified used for the log file
        /// </summary>
        public string LogFile { get; }

        #region Singleton Methods
        /// <summary>
        /// Return an instance of the Logger class. Logger instance must be created first before calling this method.
        /// To create a Logger instance, use the CreateInstance() method. All classes depend on the Logger class.
        /// </summary>
        /// <returns>Returns instance of the logger</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static Logger GetInstance()
        {
            return _instance ?? throw new InvalidOperationException("Object not created. Logger instance must be created with Logger.CreateInstance() before using it.");
        }

        /// <summary>
        ///  Creates a singleton instance of the Logger class. Log file path can be specified. Logging level is set to
        ///  log all event by default.
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="loggingLevel"></param>
        /// <returns>The instance of the logger</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static Logger CreateInstance(string logFile)
        {
            if (_instance != null)
            {
                throw new InvalidOperationException("Object already created");
            }

            _instance = new Logger(logFile, (SourceLevels)Config.LoggingLevel);
            _instance.Log(TraceEventType.Information, "Logger created");
            return _instance;
        }
        #endregion

        /// <summary>
        /// Logs an event to the specified log file. The id is automatically generated.
        /// </summary>
        /// <param name="evenetLevel"></param>
        /// <param name="message"></param>
        public void Log(TraceEventType evenetLevel, string message)
        {
            ts.TraceEvent(evenetLevel, _id++, message);
        }

        /// <summary>
        /// Logs an event to the specified log file. The id can be specified.
        /// </summary>
        /// <param name="evenetLevel"></param>
        /// <param name="id"></param>
        /// <param name="message"></param>
        public void Log(TraceEventType evenetLevel, int id, string message)
        {
            ts.TraceEvent(evenetLevel, id, message);
        }
    }
}
