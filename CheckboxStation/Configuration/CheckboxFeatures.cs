using Caretag.Contracts.Models.v1.Settings;
using DevExpress.CodeParser;
using Org.BouncyCastle.Bcpg.Sig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckboxStation.Configuration
{
    public class CheckboxFeatures
    {
        public bool OperationsEnabled { get; set; }
        public bool ServiceDemandEnabled { get; set; }
        public bool ScanTabEnabled { get; set; }
        public bool VerificationEnabled { get; set; }
        public bool CheckInEnabled { get; set; }
        public bool CheckOutEnabled { get; set; }
    }


    public static class CheckboxFeaturesExtensions
    {
        public static CheckboxFeatures LoadFromAppInstance(this CheckboxFeatures features, AppInstanceResponse appInstance)
        {
            if (appInstance?.Settings?.CheckboxSetting?.Feature != null)
            {
                var appInstanceFeatures = appInstance?.Settings?.CheckboxSetting?.Feature;

                features = new CheckboxFeatures
                {
                    OperationsEnabled = appInstanceFeatures.OperationsEnabled,
                    ServiceDemandEnabled = appInstanceFeatures.ServiceDemandEnabled,
                    ScanTabEnabled = appInstanceFeatures.ScanTabEnabled,
                    VerificationEnabled = appInstanceFeatures.VerificationEnabled,
                    CheckInEnabled = appInstanceFeatures.CheckInEnabled,
                    CheckOutEnabled = appInstanceFeatures.CheckOutEnabled
                };
            }

            return features;
        }
    }

}
