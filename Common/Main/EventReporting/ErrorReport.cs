using System;

namespace Caretag_Class.EventReporting
{
    public class ErrorReport
    {
        public string UserErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public string LogMessage { get; set; }
        public ReportLevel ReportLevel { get; set; }
        public bool AddContactMessage { get; set; }
        public bool AddRestartMessage { get; set; }
        public Exception? Exception { get; set; }
    }
}
