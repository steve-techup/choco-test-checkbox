﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFLocalizeExtension.Engine;

namespace RFIDAbstractionLayer.Simulator.Resources
{
    public class LocalizedStrings
    {
        public LocalizedStrings()
        {
            
        }

        public static LocalizedStrings Instance { get; } = new LocalizedStrings();

        public void SetCulture(string cultureCode)
        {
            var newCulture = new CultureInfo(cultureCode);
            LocalizeDictionary.Instance.Culture = newCulture;
        }

        public string this[string key]
        {
            get
            {
                var result =
                    LocalizeDictionary.Instance.GetLocalizedObject("RFIDAbstractionLayer.Simulator", "Strings", key,
                        LocalizeDictionary.Instance.Culture);
                return result as string;
            }
        }
    }
}
