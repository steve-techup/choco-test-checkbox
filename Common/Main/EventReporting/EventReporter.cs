using Microsoft.Extensions.Logging;
using System;
using System.Resources;
using System.Windows.Forms;

namespace Caretag_Class.EventReporting
{
    /// <summary>
    /// Used for logging events in a standardized way with an error code, while alerting user at the same time in a message box. 
    /// </summary>
    public class EventReporter
    {
        private readonly ILogger<EventReporter> _logger;
        private readonly ResourceManager _resourceManager;

        private string getLocalized(string str)
        {
            var locstr = _resourceManager.GetString(str);

            return string.IsNullOrWhiteSpace(locstr) ? "[Missing localization] " + str : locstr;
        }

        public EventReporter(ILogger<EventReporter> logger, ResourceManager resourceManager)
        {
            _logger = logger;
            _resourceManager = resourceManager;
        }

        public void ReportError(Exception ex, string userErrorMessage, string logMessage, string errorCode, bool addRestartMessage = false, bool addContactMessage = false)
        {
            report((m, c) => _logger.LogError(ex, m, c), userErrorMessage, errorCode, logMessage, ReportLevel.Error, addContactMessage, addRestartMessage);
        }
        public void ReportError(string userErrorMessage, string logMessage, string errorCode, bool addRestartMessage = false, bool addContactMessage = false)
        {
            report((m, c) => _logger.LogError(m, c), userErrorMessage, errorCode, logMessage, ReportLevel.Error, addContactMessage, addRestartMessage);
        }

        public void ReportWarning(Exception ex, string userErrorMessage, string logMessage, string errorCode, bool addRestartMessage = false, bool addContactMessage = false)
        {
            report((m, c) => _logger.LogWarning(ex, m, c), userErrorMessage, errorCode, logMessage, ReportLevel.Warning, addContactMessage, addRestartMessage);
        }
        public void ReportWarning(string userErrorMessage, string logMessage, string errorCode, bool addRestartMessage = false, bool addContactMessage = false)
        {
            report((m, c) => _logger.LogWarning(m, c), userErrorMessage, errorCode, logMessage, ReportLevel.Warning, addContactMessage, addRestartMessage);
        }
        public void ReportFatal(Exception ex, string userErrorMessage, string logMessage, string errorCode, bool addRestartMessage = false, bool addContactMessage = false)
        {
            report((m, c) => _logger.LogCritical(ex, m, c), userErrorMessage, errorCode, logMessage, ReportLevel.Fatal, addContactMessage, addRestartMessage);
        }
        public void ReportFatal(string userErrorMessage, string logMessage, string errorCode, bool addRestartMessage = false, bool addContactMessage = false)
        {
            report((m, c) => _logger.LogCritical(m, c), userErrorMessage, errorCode, logMessage, ReportLevel.Fatal, addContactMessage, addRestartMessage);
        }
        public void ReportDebug(Exception ex, string userErrorMessage, string logMessage, string errorCode, bool addRestartMessage = false, bool addContactMessage = false)
        {
            report((m, c) => _logger.LogDebug(ex, m, c), userErrorMessage, errorCode, logMessage, ReportLevel.Debug, addContactMessage, addRestartMessage);
        }
        public void ReportDebug(string userErrorMessage, string logMessage, string errorCode, bool addRestartMessage = false, bool addContactMessage = false)
        {
            report((m, c) => _logger.LogDebug(m, c), userErrorMessage, errorCode, logMessage, ReportLevel.Debug, addContactMessage, addRestartMessage);
        }
        public void ReportInformation(Exception ex, string userErrorMessage, string logMessage, string errorCode, bool addRestartMessage = false, bool addContactMessage = false)
        {
            report((m, c) => _logger.LogInformation(ex, m, c), userErrorMessage, errorCode, logMessage, ReportLevel.Information, addContactMessage, addRestartMessage);
        }
        public void ReportInformation(string userErrorMessage, string logMessage, string errorCode, bool addRestartMessage = false, bool addContactMessage = false)
        {
            report((m, c) => _logger.LogInformation(m, c), userErrorMessage, errorCode, logMessage, ReportLevel.Information, addContactMessage, addRestartMessage);
        }

        private void report(Action<string, string> logAction, string userErrorMessage, string errorCode, string logMessage, ReportLevel reportLevel, bool addContactMessage, bool addRestartMessage)
        {
            logAction(getLocalized(logMessage) + ", " + getLocalized("error code:") + " {errorCode}", errorCode);

            userErrorMessage = getLocalized(userErrorMessage);

            if (addRestartMessage)
                userErrorMessage += "\n" + getLocalized("Please restart the application.");

            if (addContactMessage)
                userErrorMessage += "\n" + getLocalized(
                    "If this does not solve the problem, contact Caretag support and report the error code.");

            userErrorMessage += "\n" + getLocalized("Error code :") + errorCode;


            switch (reportLevel)
            {
                case ReportLevel.Error:
                case ReportLevel.Fatal:
                    MessageBox.Show(userErrorMessage, getLocalized("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case ReportLevel.Information:
                case ReportLevel.Debug:
                    MessageBox.Show(userErrorMessage, getLocalized("Information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case ReportLevel.Warning:
                    MessageBox.Show(userErrorMessage, getLocalized("Warning"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
    }
}
