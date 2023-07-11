using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Configuration;
using Caretag_Class.Model;

namespace Caretag_Class
{
    public class CaretagModelFactory
    {
        private readonly AppSettingsBase _appSettingsBase;

        public CaretagModelFactory(AppSettingsBase appSettingsBase)
        {
            _appSettingsBase = appSettingsBase;
        }

        public CaretagModel Create()
        {
            return new CaretagModel(_appSettingsBase?.ConnectionStrings?.SQLServer);
        }

    }
}
