using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDAbstractionLayer
{
    public interface IPortCache
    {
        public void SavePorts(List<string> ports);
        public List<string>  LoadPorts();

    }
}
