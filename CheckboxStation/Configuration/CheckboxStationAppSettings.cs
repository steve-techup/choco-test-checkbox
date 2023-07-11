namespace CheckboxStation.Configuration
{
    public class CheckboxStationAppSettings
    {
        public int ManualServiceRuleId { get; set; }
        public CheckboxFeatures Features { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public string ReportingInVerificationMode { get; set; }
        public string VerificationReportFilePath { get; set; }
    }
}
