using Caretag_Class.Configuration;
using CheckboxStation.Configuration;
using CheckboxStation.Reporting;
using CsvHelper;
using DynamicData;
using DynamicData.Kernel;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CheckboxStation.Services
{
    public class ReportingService
    {
        private readonly CheckboxStationAppSettings _checkboxSettings;
        private readonly AppSettingsBase _appSettings;
        private readonly ILogger _logger;
        private int? _currentSessionNumber = null;
        private CsvHelper.Configuration.CsvConfiguration _csvConfiguration;
        public ReportingService(CheckboxStationAppSettings checkboxSettings, AppSettingsBase appSettings, ILogger logger)
        {
            _checkboxSettings = checkboxSettings;
            _appSettings = appSettings;
            _logger = logger;
            _csvConfiguration = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "\t",
                HasHeaderRecord = true
            };
        }
        private SmtpClient SetupEmailClient()
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "email-smtp.eu-central-1.amazonaws.com";
            client.EnableSsl = true;
            client.Timeout = 600000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("AKIATGR3EMCCTJPNTYTX", "BHAFQvWIOn3HBKya3gWs4CMiY0gSCUM0zHeQlgqUDv4U");
            return client;
        }

        public async Task GenerateVerificationCsv(List<VerificationReportItem> verificationReportItems, bool incrementSessionNumber = true)
        {
            if (!string.IsNullOrEmpty(_checkboxSettings.VerificationReportFilePath))
            {
                var fileExists = File.Exists(_checkboxSettings.VerificationReportFilePath);
                var existingItems = new List<VerificationReportItem>();

                if (fileExists)
                {
                    using (var streamReader = new StreamReader(_checkboxSettings.VerificationReportFilePath))
                    {
                        using (var csvFile = new CsvReader(streamReader, _csvConfiguration))
                        {
                            try
                            {
                                existingItems = csvFile.GetRecords<VerificationReportItem>().ToList();

                                if (_currentSessionNumber == null)
                                    _currentSessionNumber = existingItems?.Max(vi => vi.SessionCount);
                            }
                            catch (Exception ex)
                            {
                                _logger.Error(ex, "Error while reading CSV verification report");
                            }
                        }
                    }
                }
                else
                {
                    _currentSessionNumber = 0;
                }

                if (incrementSessionNumber)
                    _currentSessionNumber++;

                var existingSessionItems = existingItems.Where(i => i.SessionCount == _currentSessionNumber).ToList();

                if (existingItems.Any())
                    existingItems = existingItems.Except(existingSessionItems).ToList();

                verificationReportItems.ForEach(vi => vi.SessionCount = _currentSessionNumber != null ? (int)_currentSessionNumber : 1);
                existingItems.AddRange(verificationReportItems);

                if (!fileExists)
                {
                    var directory = Path.GetDirectoryName(_checkboxSettings.VerificationReportFilePath);

                    if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                        Directory.CreateDirectory(directory);
                }

                using (var streamWriter = new StreamWriter(_checkboxSettings.VerificationReportFilePath))
                {
                    using (var csvWriter = new CsvWriter(streamWriter, _csvConfiguration))
                    {
                        try
                        {
                            await csvWriter.WriteRecordsAsync(existingItems);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(ex, "Error while writing CSV verification report");
                        }
                    }
                }

            }
        }

        public async Task SendVerificationReportEmail(List<VerificationReportItem> verificationReportItems)
        {
            if (!string.IsNullOrEmpty(_checkboxSettings.VerificationReportFilePath) && !string.IsNullOrEmpty(_checkboxSettings.ReportingInVerificationMode))
            {
                string trayName = "-";
                string trayUdi = "-";
                int expectedCount = 0;
                int scannedCount = 0;
                string sessionNumber = "-";

                if (verificationReportItems.Any())
                {
                    trayName = verificationReportItems.Select(vi => vi.TrayName).First();
                    trayUdi = verificationReportItems.Select(vi => vi.TrayUDI).First();
                    expectedCount = verificationReportItems.Sum(vi => vi.Expected);
                    scannedCount = verificationReportItems.Sum(vi => vi.Quantity);
                    sessionNumber = verificationReportItems.Select(vi => vi.SessionCount.ToString()).First();
                }

                var emailBody = new StringBuilder();
                emailBody.AppendLine("Please find below the details of the Checkbox scanning session.</br></br>");
                emailBody.AppendLine();
                emailBody.AppendLine($"-\t<b>Session:</b>  {sessionNumber} from {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}</br>");
                emailBody.AppendLine($"-\t<b>Packing Set details:</b> {trayName} ({expectedCount} surgical instruments)</br>");
                emailBody.AppendLine($"-\t<b>Tray UDI:</b> {trayUdi}</br>");
                emailBody.AppendLine($"-\t<b>Scanned:</b> {scannedCount} instruments</br>");
                emailBody.AppendLine($"-\t<b>Checkbox: {_appSettings.StationUniqueID}</b></br></br>");
                emailBody.AppendLine();
                emailBody.AppendLine("<b>Find below the details of all surgical instruments </b>(scanned, or part of the packing set definition). All the earlier scanning sessions are attached in a CSV file (Tab delimited).</br></br>");


                emailBody.AppendLine(@"<table border=""1"" style=""border-collapse: collapse;"" cellspacing=""10"" cellpadding=""6"">
                                <thead>
                                    <tr>
                                        <th>Brand</th>
                                        <th>Article SKU</th>
                                        <th>Name</th>
                                        <th>EPC / UDI</th>
                                        <th>Scanned</th>
                                        <th>Expected</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    @@rows@@
                                </tbody>
                            </table>");

                var rows = new StringBuilder();

                if (verificationReportItems != null)
                {

                    foreach (var item in verificationReportItems)
                    {
                        rows.AppendLine(@$"<tr>
                                        <td>{item.Brand}</td>
                                        <td align=""center"">{item.ArticleSku}</td>
                                        <td>{item.ArticleName}</td>
                                        <td align=""center"">{item.ArticleUDI}</td>
                                        <td align=""center"">{item.Quantity}</td>
                                        <td align=""center"">{item.Expected}</td>
                                        <td>{item.FoundStatus}</td>
                                    </tr>");
                    }

                }

                emailBody.AppendLine();
                emailBody.AppendLine("</br></br><span style=\"color:gray\">Email generated automatically, once the user finished a scanning session and clicked on email (in verification mode).</span>");

                using (var smptClient = SetupEmailClient())
                {
                    var recipients = !string.IsNullOrEmpty(_checkboxSettings.ReportingInVerificationMode) ? _checkboxSettings.ReportingInVerificationMode.Split(';') : new string[0];
                    using (MailMessage message = new MailMessage())
                    {
                        try
                        {
                            message.Attachments.Add(new Attachment(_checkboxSettings.VerificationReportFilePath));
                            message.From = new MailAddress("petru.faurescu@caretag.eu", "Caretag Checkbox Station");
                            message.To.AddRange(recipients.Select(r => new MailAddress(r)));
                            message.IsBodyHtml = true;
                            message.Body = emailBody.ToString().Replace("@@rows@@", rows.ToString());
                            message.Subject = "Checkbox station report";
                            await smptClient.SendMailAsync(message);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(ex, "Error while sending verification report email");
                        }
                    }
                }

            }
        }
        public async Task<Tuple<string, string>> GenerateHtmlReport(List<VerificationReportItem> verificationReportItems)
        {
            var path = !string.IsNullOrEmpty(_checkboxSettings.VerificationReportFilePath) ? Path.GetDirectoryName(_checkboxSettings.VerificationReportFilePath) : @"Report";

            string trayName = "-";
            string trayUdi = "-";
            int expectedCount = 0;
            int scannedCount = 0;
            string sessionNumber = "-";

            if (verificationReportItems.Any())
            {
                trayName = verificationReportItems.Select(vi => vi.TrayName).First();
                trayUdi = verificationReportItems.Select(vi => vi.TrayUDI).First();
                expectedCount = verificationReportItems.Sum(vi => vi.Expected);
                scannedCount = verificationReportItems.Sum(vi => vi.Quantity);
                sessionNumber = verificationReportItems.Select(vi => vi.SessionCount.ToString("D2")).First();
            }

            var emailBody = new StringBuilder();
            emailBody.AppendLine("<body>");
            emailBody.AppendLine(@"<head>
                                    <style>
                                        body {
                                            font-family: sans-serif;
                                            padding: 16px;
                                        }

                                        .styled-table {
                                            border-collapse: collapse;
                                            margin: 25px 0;
                                            font-size: 0.9em;
                                            min-width: 400px;
                                            box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
                                        }

                                        .styled-table thead tr {
                                            background-color: #38485F;
                                            color: #ffffff;
                                            text-align: left;
                                        }

                                        .styled-table th,
                                        .styled-table td {
                                            padding: 12px 15px;
                                        }

                                        .styled-table tbody tr {
                                            border-bottom: 1px solid #dddddd;
                                        }

                                        .styled-table tbody tr:nth-of-type(even) {
                                            background-color: #f3f3f3;
                                        }

                                        .styled-table tbody tr:last-of-type {
                                            border-bottom: 2px solid #38485F;
                                        }

                                        .styled-table tbody tr.active-row {
                                            font-weight: bold;
                                            color: #38485F;
                                        }

                                        .info {
                                            margin: 8px;
                                        }

                                        p {
                                            color: #38485F;
                                        }
                                    </style>
                                </head>");
            emailBody.AppendLine("<p>Please find below the details of the Checkbox scanning session.</br></br></p>");
            emailBody.AppendLine();
            emailBody.AppendLine($"<p class=\"info\">-\t<b>Session:</b>  {sessionNumber} from {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")}</p>");
            emailBody.AppendLine($"<p class=\"info\">-\t<b>Packing Set details:</b> {trayName} ({expectedCount} surgical instruments)</p>");
            emailBody.AppendLine($"<p class=\"info\">-\t<b>Tray UDI:</b> {trayUdi}</p>");
            emailBody.AppendLine($"<p class=\"info\">-\t<b>Scanned:</b> {scannedCount} instruments</p>");
            emailBody.AppendLine($"<p class=\"info\">-\t<b>Checkbox: {_appSettings.StationUniqueID}</b></br></br></p>");
            emailBody.AppendLine();
            emailBody.AppendLine("<p><b>Find below the details of all surgical instruments </b>(scanned, or part of the packing set definition). All the earlier scanning sessions are attached in a CSV file (Tab delimited).</p>");


            emailBody.AppendLine(@"<table class=""styled-table"">
                                <thead>
                                    <tr>
                                        <th>Brand</th>
                                        <th>Article SKU</th>
                                        <th>Name</th>
                                        <th>EPC / UDI</th>
                                        <th>Scanned</th>
                                        <th>Expected</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    @@rows@@
                                </tbody>
                            </table>");

            emailBody.AppendLine("</body>");
            var rows = new StringBuilder();

            if (verificationReportItems != null)
            {

                foreach (var item in verificationReportItems)
                {
                    rows.AppendLine(@$"<tr>
                                        <td>{item.Brand}</td>
                                        <td align=""center"">{item.ArticleSku}</td>
                                        <td>{item.ArticleName}</td>
                                        <td align=""center"">{item.ArticleUDI}</td>
                                        <td align=""center"">{item.Quantity}</td>
                                        <td align=""center"">{item.Expected}</td>
                                        <td>{item.FoundStatus}</td>
                                    </tr>");
                }

            }

            emailBody.AppendLine();
            emailBody.AppendLine("</br><span style=\"color:gray; font-weight: normal;\">Email generated automatically, once the user finished a scanning session and clicked\r\n    on email (in verification mode).</span>");
            emailBody = emailBody.Replace("@@rows@@", rows.ToString());

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filePath = Path.Combine(path, $"{_appSettings.StationUniqueID} {DateTime.Now.ToString("yyyy.MM.dd")} - {sessionNumber}.html");

            try
            {
                File.WriteAllText(filePath, emailBody.ToString());
                return new Tuple<string, string>(sessionNumber, path);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error while generating verification HTMLreport");
                throw ex;
            }
        }
    }
}
