using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caretag_Class.Exceptions
{
    public class CaretagApplicationException : ApplicationException
    {
        public CaretagApplicationException(string message) : base(message)
        {

        }
    }
}
