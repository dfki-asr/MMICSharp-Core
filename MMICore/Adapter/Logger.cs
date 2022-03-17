// SPDX-License-Identifier: MIT
// The content of this file has been developed in the context of the MOSIM research project.
// Original author(s): Andreas Kaiser, Felix Gaisbauer

using System;

namespace MMICSharp
{
    /// <summary>
    /// Enum describes the log level utilized by the logger
    /// </summary>
    public enum Log_level
    {
        L_SILENT,
        L_ERROR,
		L_WARNING,
        L_INFO,
        L_DEBUG,
    };

    /// <summary>
    /// Class providing for logging 
    /// </summary>
    public class Logger 
    {
        /// <summary>
        /// Singleton instance
        /// </summary>
        public static Logger Instance
        {
            get;
            set;
        } = new Logger();
		
        /// <summary>
        /// The assigned log level
        /// </summary>
        public Log_level Level
        {
            get;
            set;
        } = Log_level.L_SILENT;
		
        public void CreateLog(Log_level logLevel, string text)
        {
            //Only log if the global log level allows it (e.g. if debug is desired -> all is logged)
            if (logLevel <= Level)
            {
                switch (logLevel)
                {
                    case Log_level.L_DEBUG:
                        CreateDebugLog(text);
                        break;

                    case Log_level.L_INFO:
                        CreateInfoLog(text);
                        break;

					case Log_level.L_WARNING:
						CreateWarningLog(text);
						break;

					case Log_level.L_ERROR:
                        CreateErrorLog(text);
                        break;
                }
            }
        }

		/// <summary>
		/// Method to log an error (must be overwritten by the child class)
		/// </summary>
		protected virtual void CreateErrorLog(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now} ----> {text}");
            Console.ForegroundColor = ConsoleColor.White;
		}

		/// <summary>
		/// Method to log warning messages (must be overwritten by the child class)
		/// </summary>
		protected virtual void CreateWarningLog(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{DateTime.Now} ----> {text}");
            Console.ForegroundColor = ConsoleColor.White;
        }

		/// <summary>
		/// Method to log info messages (must be overwritten by the child class)
		/// </summary>
		protected virtual void CreateInfoLog(string text)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"{DateTime.Now} ----> {text}");
			Console.ForegroundColor = ConsoleColor.White;
		}

        /// <summary>
        /// Method to log debug information (must be overwritten by the child class)
        /// </summary>
        /// <param name="text"></param>
        protected virtual void CreateDebugLog(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{DateTime.Now} ----> {text}");
            Console.ForegroundColor = ConsoleColor.White;
        }
		
        public static void Log(Log_level logLevel, string text)
        {
            //Call the assigned instance if defined
            Instance?.CreateLog(logLevel, text);
        }

		public static void LogError(string text)
		{
			Instance?.CreateLog(Log_level.L_ERROR, text);
		}

		public static void LogWarning(string text)
		{
			Instance?.CreateLog(Log_level.L_WARNING, text);
		}

		public static void LogDebug(string text)
		{
			Instance?.CreateLog(Log_level.L_DEBUG, text);
		}

		public static void LogInfo(string text)
		{
			Instance?.CreateLog(Log_level.L_INFO, text);
		}
	}
}
