using NLog.Config;
using NLog.Targets;
using NLog;

namespace TestEmails
{
	public class FileLogger
	{
		private static readonly ILogger logger;

		static FileLogger()
		{
			var config = new LoggingConfiguration();

			// Targets where to log to: File

			var fileTarget = new FileTarget("file")
			{
				FileName = "log.txt",
				Layout = "${longdate} ${level} ${message} ${exception:format=tostring}"
			};

			config.AddTarget(fileTarget);

			// Rules for mapping loggers to targets

			var rule = new LoggingRule("*", LogLevel.Trace, fileTarget);
			config.LoggingRules.Add(rule);

			// Apply config

			LogManager.Configuration = config;

			logger = LogManager.GetCurrentClassLogger();
		}

		public void LogInfo(string message)
		{
			logger.Info(message);
		}

		public void LogWarning(string message)
		{
			logger.Warn(message);
		}

		public void LogError(string message)
		{
			logger.Error(message);
		}

		public void LogException(string message, System.Exception exception)
		{
			logger.Error(exception, message);
		}
	}
}