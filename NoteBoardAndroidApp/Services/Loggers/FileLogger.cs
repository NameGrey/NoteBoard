using Android.Content;
using Android.Media;
using Android.Util;
using Java.IO;
using Java.Lang;
using Java.Text;
using Java.Util;

namespace NoteBoardAndroidApp.Services.Loggers
{
	/**
	  * A logger that uses the standard Android Log class to log exceptions, and also logs them to a 
	  * file on the device. Requires permission WRITE_EXTERNAL_STORAGE in AndroidManifest.xml.
	  * @author Cindy Potvin
	  */
	public class FileLogger
	{
		private static readonly Locale DEFAULT_LOCALE = Locale.Us;
		/**
		  * Sends an error message to LogCat and to a log file.
		  * @param context The context of the application.
		  * @param logMessageTag A tag identifying a group of log messages. Should be a constant in the 
		  *                      class calling the logger.
		  * @param logMessage The message to add to the log.
		  */
		public static void Error(Context context, string logMessageTag, string logMessage)
		{
			int logResult = Log.Error(logMessageTag, logMessage);
			if (logResult > 0)
				logToFile(context, logMessageTag, logMessage);
		}

		/**
		   * Sends an error message and the exception to LogCat and to a log file.
		   * @param context The context of the application.
		   * @param logMessageTag A tag identifying a group of log messages. Should be a constant in the 
		   *                      class calling the logger.
		   * @param logMessage The message to add to the log.
		   * @param throwableException An exception to log
		   */
		public static void Error (Context context, string logMessageTag, string logMessage, Throwable throwableException)
		{
			int logResult = Log.Error(logMessageTag, logMessage, throwableException);
			if (logResult > 0)
				logToFile(context, logMessageTag,
				logMessage + "\r\n" + Log.GetStackTraceString(throwableException));
		}

		// The i and w method for info and warning logs 
		// should be implemented in the same way as the e method for error logs.

		/**
		   * Sends a message to LogCat and to a log file.
		   * @param context The context of the application.
		   * @param logMessageTag A tag identifying a group of log messages. Should be a constant in the 
		   *                      class calling the logger.
		   * @param logMessage The message to add to the log.
		   */
		public static void Verbose(Context context, string logMessageTag, string logMessage)
		{
			int logResult = Log.Verbose(logMessageTag, logMessage);
			if (logResult > 0)
				logToFile(context, logMessageTag, logMessage);
		}

		/**
		   * Sends a message and the exception to LogCat and to a log file.
		   * @param logMessageTag A tag identifying a group of log messages. Should be a constant in the 
		   *                      class calling the logger.
		   * @param logMessage The message to add to the log.
		   * @param throwableException An exception to log
		   */
		public static void Verbose (Context context, string logMessageTag, string logMessage, Throwable throwableException)
		{
			int logResult = Log.Verbose(logMessageTag, logMessage, throwableException);
			if (logResult > 0)
				logToFile(context, logMessageTag,
				logMessage + "\r\n" + Log.GetStackTraceString(throwableException));
		}

		// The d method for debug logs should be implemented in the same way as the v method for verbose logs.

		/**
		  * Gets a stamp containing the current date and time to write to the log.
		  * @return The stamp for the current date and time.
		  */
		private static string getDateTimeStamp()
		{
			Date dateNow = Calendar.GetInstance(DEFAULT_LOCALE).Time;
			// My locale, so all the log files have the same date and time format
			return (DateFormat.GetDateTimeInstance
			(DateFormat.Short, DateFormat.Short, DEFAULT_LOCALE).Format(dateNow));
		}

		/**
		  * Writes a message to the log file on the device.
		  * @param logMessageTag A tag identifying a group of log messages.
		  * @param logMessage The message to add to the log.
		  */
		private static void logToFile(Context context, string logMessageTag, string logMessage)
		{
			try
			{
				// Gets the log file from the root of the primary storage. If it does 
				// not exist, the file is created.
				File logFile = new File(System.Environment.CurrentDirectory, "TestApplicationLog.txt");
				if (!logFile.Exists())
					logFile.CreateNewFile();
				// Write the message to the log with a timestamp
				BufferedWriter writer = new BufferedWriter(new FileWriter(logFile, true));
				writer.Write(string.Format("%1s [%2s]:%3s\r\n",
				getDateTimeStamp(), logMessageTag, logMessage));
				writer.Close();
				// Refresh the data so it can seen when the device is plugged in a 
				// computer. You may have to unplug and replug to see the latest 
				// changes
				MediaScannerConnection.ScanFile(context,
												new string[] { logFile.ToString() },
												null,
												null);
			}
			catch (IOException e)
			{
				Log.Error("com.cindypotvin.Logger", "Unable to log exception to file.");
			}
		}
	}
}