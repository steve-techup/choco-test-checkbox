using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caretag_Class.Util
{
    public static class FormUtil
    {
        public static void InvokeIfRequired<T>(this T control, MethodInvoker action) where T: Control
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
}
