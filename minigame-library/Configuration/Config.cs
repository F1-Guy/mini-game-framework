using System.Xml;

namespace minigame_library.Configuration
{
    public static class Config
    {
        private static XmlDocument _configDoc;

        static Config()
        {
            _configDoc = new XmlDocument();

            try
            {
                _configDoc.Load("../../../../minigame-library/Configuration/config.xml");
            }
            catch (XmlException ex)
            {
                Logger.GetInstance().Log(TraceEventType.Error, $"Error loading config file: {ex.Message}");
                throw ex;
            }

        }

        /// <summary>
        /// Gets the maximum X value of the map and provides a default value in case of an error
        /// </summary>
        public static int maxX => int.Parse(_configDoc.SelectSingleNode("/configuration/mapConfig/MaxX")?.InnerText ?? "10");

        /// <summary>
        /// Gets the maximum Y value of the map and provides a default value in case of an error
        /// </summary>
        public static int maxY => int.Parse(_configDoc.SelectSingleNode("/configuration/mapConfig/MaxY")?.InnerText ?? "10");

        /// <summary>
        /// Gets default logging level to be used in the logger and provides a default value in case of an error
        /// </summary>
        public static string DatetimeFormat => _configDoc.SelectSingleNode("/configuration/loggerConfig/dateTimeFormat")?.InnerText ?? "dd/MM/yy HH:mm:ss:fff";

        /// <summary>
        /// Gets logging level to be used in the logger and provides a default value in case of an error
        /// </summary>
        public static int LoggingLevel => int.Parse(_configDoc.SelectSingleNode("/configuration/loggerConfig/loggingLevel")?.InnerText ?? "-1");
    }
}
