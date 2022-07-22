using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;
using NLog.Targets.Wrappers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MMICSharp.MMICSharp_Core.MMICore.Common.Tools
{
    public class TimeProfiler
    {
        private static Dictionary<string, TimeProfiler> profilersMap;

        private NLog.Logger csvLogger;
        private Dictionary<string, Stopwatch> stopwatchesMap;

        private const string LogsPathEnVar = "MOSIM_LOGS_PATH";

        private const string ExecTimeMsProperty = "ExecTimeMs";
        private const string ExecTimeTicksProperty = "ExecTimeTicks";
        private const string FrameProperty = "Frame";

        static TimeProfiler()
        {
            profilersMap = new Dictionary<string, TimeProfiler>();
            LogManager.Configuration = new LoggingConfiguration();
        }

        /// <summary>
        /// Create a profiler with a certain output folder and a specified prefix,
        /// or retrieve existing one with matching parameters
        /// </summary>
        /// <param name="logPrefix">
        /// The unique prefix of the output .csv files' names within the process. Default value - "log".
        /// The prefix "log" will produce a log file with the following format: log_dd-MM-yyyy_HH-mm-ss.csv.
        /// </param>
        /// <param name="logFilesFolder">
        /// The folder path that will contain the output .csv files.
        /// If none passed, tries to retrieve <see cref="MOSIM_LOGS_PATH"/> from user variables and use it as log files' location if <paramref name="useEnVar"/> is set to true.
        /// If no variable found and <paramref name="useEnVar"/> is set to false, uses an executable directory by default.
        /// </param>
        /// <param name="useEnVar">
        /// The flag indicating if using <see cref="MOSIM_LOGS_PATH"/> from user variables is necessary.
        /// If <paramref name="logFilesFolder"/> is an absolute path, <see cref="MOSIM_LOGS_PATH"/> will be ignored
        /// </param>
        public static TimeProfiler GetProfiler(string logPrefix, string logFilesFolder, bool useEnVar = true)
        {
            if (string.IsNullOrWhiteSpace(logPrefix))
                logPrefix = "log";

            if (useEnVar)
            {
                string enVarPath = Environment.GetEnvironmentVariable(LogsPathEnVar);
                if (!string.IsNullOrWhiteSpace(enVarPath))
                {
                    if (string.IsNullOrWhiteSpace(logFilesFolder))
                        logFilesFolder = enVarPath;
                    else if (!Path.IsPathRooted(logFilesFolder))
                        logFilesFolder = Path.Combine(enVarPath, logFilesFolder);
                }
            }

            if (string.IsNullOrWhiteSpace(logFilesFolder))
            {
                logFilesFolder = Directory.GetCurrentDirectory() + "\\";
            }
            
            string loggerUnqKey = logFilesFolder + "+" + logPrefix;

            TimeProfiler profiler;
            if (!profilersMap.TryGetValue(loggerUnqKey, out profiler))
            {
                // Setup logger for .csv file output
                FileTarget csvLogFile = new FileTarget(logPrefix + "File")
                {
                    DeleteOldFileOnStartup = true, // comment if old entries need to be saved
                    FileName = Path.Combine(logFilesFolder, logPrefix + "_${date:cached=True:format=dd-MM-yyyy_HH-mm-ss}.csv"),
                    Layout = new CsvLayout
                    {
                        WithHeader = true,
                        Columns =
                        {
                            new CsvColumn("Date", "${longdate}"),
                            new CsvColumn("ID", "${counter:Increment=1}"),
                            new CsvColumn("Code Section", "${message}"),
                            new CsvColumn("Execution Time (in ms)", "${event-properties:item=" + ExecTimeMsProperty + "}"),
                            new CsvColumn("Execution Time (in ticks)", "${event-properties:item=" + ExecTimeTicksProperty + "}"),
                            new CsvColumn("Frame", "${event-properties:item=" + FrameProperty + "}")
                        }
                    }
                };

                // Rules for mapping loggers to targets
                LogManager.Configuration.AddRuleForAllLevels(
                    new AsyncTargetWrapper { WrappedTarget = csvLogFile }, csvLogFile.Name);
                LogManager.ReconfigExistingLoggers();

                var csvLogger = LogManager.GetLogger(csvLogFile.Name);

                csvLogger.Properties.Add(ExecTimeMsProperty, 0);
                csvLogger.Properties.Add(ExecTimeTicksProperty, 0);
                csvLogger.Properties.Add(FrameProperty, -1);

                profiler = new TimeProfiler(csvLogger);

                profilersMap.Add(loggerUnqKey, profiler);
            }
            return profiler;
        }

        /// <summary>
        /// Optinally call when closing the process to flush the pending messages in asynchronous queue and free the files.
        /// No more log messages will be printed after the invocation of this method.
        /// </summary>
        public static void CloseLoggers()
        {
            LogManager.Flush();
            LogManager.Shutdown();
        }

        /// <summary>
        /// Sealed constructor for time profiler
        /// </summary>
        /// <param name="logger">Associated logger</param>
        private TimeProfiler(NLog.Logger logger)
        {
            csvLogger = logger;
            stopwatchesMap = new Dictionary<string, Stopwatch>();
        }

        /// <summary>
        /// Start time measurement for scattered code.
        /// For trivial cases use <see cref="StartWatch"/> or <see cref="WatchCodeSnippet"/>.
        /// </summary>
        /// <param name="codeSectionID">Unique description for code section to print in .csv file in "Code Section" column</param>
        public void StartWatchScattered(string codeSectionID)
        {
            if (stopwatchesMap.TryGetValue(codeSectionID, out Stopwatch stopwatch))
                stopwatch.Restart();
            else
            {
                Stopwatch newStopwatch = new Stopwatch();
                stopwatchesMap.Add(codeSectionID, newStopwatch);
                newStopwatch.Start();
            }
        }

        /// <summary>
        /// Stop stopwatch for specified scattered code and log the measurement
        /// </summary>
        /// <param name="codeSectionID">Unique description for code section to print in .csv file in "Code Section" column</param>
        /// <param name="frame">Optional frame index</param>
        public void StopWatchScattered(string codeSectionID, long frame = -1)
        {
            if (stopwatchesMap.TryGetValue(codeSectionID, out Stopwatch stopwatch))
            {
                stopwatch.Stop();
                logEntry(codeSectionID, stopwatch, frame);
            }
        }

        /// <summary>
        /// Start time measurement for blocked code section without memory allocation for <see cref="Stopwatch"/>.
        /// </summary>
        public Stopwatch StartWatch()
        {
            return Stopwatch.StartNew();
        }

        /// <summary>
        /// Stop stopwatch for blocked code section without memory allocation for <see cref="Stopwatch"/> and log the measurement
        /// </summary>
        /// <param name="codeSectionID">Unique description for code section to print in .csv file in "Code Section" column</param>
        /// <param name="stopwatch">The stopwatch started with <see cref="StartWatch"/></param>
        /// <param name="frame">Optional frame index</param>
        public void StopWatch(string codeSectionID, Stopwatch stopwatch, long frame = -1)
        {
            stopwatch.Stop();
            logEntry(codeSectionID, stopwatch, frame);
        }

        /// <summary>
        /// Start time measurement for short atomic code section without memory allocation for <see cref="Stopwatch"/>.
        /// For long or scattered cases use <see cref="StartWatch"/> and <see cref="StartWatchScattered"/> respectively.
        /// </summary>
        /// <param name="codeSectionID">Unique description for code section to print in .csv file in "Code Section" column</param>
        /// <param name="codeSnippet">Code snippet delegate</param>
        /// <param name="frame">Optional frame index</param>
        public void WatchCodeSnippet(string codeSectionID, Action codeSnippet, long frame = -1)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            codeSnippet();
            stopwatch.Stop();
            logEntry(codeSectionID, stopwatch, frame);
        }

        /// <summary>
        /// Add log message in asynchronous queue
        /// </summary>
        /// <param name="codeSectionID">The message to write in "Code Section" column</param>
        /// <param name="stopwatch">The stopwatch to provide info for "Execution Time (in ms)" and "Execution Time (in ticks)" column</param>
        /// <param name="frame">The frame index to write in "Frame" column</param>
        private void logEntry(string codeSectionID, Stopwatch stopwatch, long frame = -1)
        {
            csvLogger.Properties[ExecTimeMsProperty] = stopwatch.ElapsedMilliseconds;
            csvLogger.Properties[ExecTimeTicksProperty] = stopwatch.ElapsedTicks;
            if (frame != -1)
                csvLogger.Properties[FrameProperty] = frame;

            csvLogger.Info(codeSectionID);
        }
    }
}
