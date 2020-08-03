using System;
using NLog;

namespace BLL.utilities.logger
{
    public class MyLogger : ILogger
    {

        //Singleton
        private static MyLogger _instance;
        private static Logger _logger;

        private MyLogger()
        {
            
        }

        public static MyLogger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MyLogger();
            }

            return _instance;
        }

        private Logger GetLogger(string theLogger)
        {
            if (MyLogger._logger == null)
            {
                MyLogger._logger = LogManager.GetLogger(theLogger);
            }

            return MyLogger._logger;
        }

        public void Debug(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("MusicCollLoggerRule").Debug(message);
            }
            else
            {
                GetLogger("MusicCollLoggerRule").Debug(message, arg);
            }
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("MusicCollLoggerRule").Info(message);
            }
            else
            {
                GetLogger("MusicCollLoggerRule").Info(message, arg);
            }
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("MusicCollLoggerRule").Warn(message);
            }
            else
            {
                GetLogger("MusicCollLoggerRule").Warn(message, arg);
            }
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("MusicCollLoggerRule").Error(message);
            }
            else
            {
                GetLogger("MusicCollLoggerRule").Error(message, arg);
            }
        }
    }
}
