using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Extensions
{
    public static class ControlExtensions
    {
        public static IList<T> GetAllControlsRecusrvive<T>(Control control) where T : Control
        {
            var rtn = new List<T>();
            foreach (Control item in control.Controls)
            {
                var ctr = item as T;
                if (ctr != null)
                {
                    rtn.Add(ctr);
                }
                else
                {
                    rtn.AddRange(GetAllControlsRecusrvive<T>(item));
                }

            }
            return rtn;
        }
    }
}
