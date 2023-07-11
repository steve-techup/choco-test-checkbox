using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDAbstractionLayer.Simulator.Model
{
    public enum SimulatorItemType
    {
        Unknown,
        CardID,
        Instrument,
        Tray,
        Barcode,
        Container,
        Recent,
        Search
    }
}
