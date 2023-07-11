using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDAbstractionLayer
{
    public interface IRFIDWriter
    {
        bool WriteEPC(uint accessPassword, string currentEPC, string newEPC);
        bool WriteEPC(string currentEPC, string newEPC);

        bool WriteEPC(uint accessPassword, byte[] currentEpc, byte[] newEpc);
        bool WriteEPC(uint accessPassword, string currentEpc, byte[] newEpc);
    }
}
