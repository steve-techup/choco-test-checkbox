using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDAbstractionLayer
{
    public class PortCacheAllAvailableComPorts : IPortCache
    {
        public PortCacheAllAvailableComPorts()
        {
        }

        public void SavePorts(List<string> ports)
        {
            // do nothing
        }

        public List<string> LoadPorts()
        {
            return new List<string>();
        }
    }
}
