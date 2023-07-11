using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Model;

namespace RFIDAbstractionLayer.Simulator.Model
{
    public class SimulatorItem
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string EPC { get; set; }
        public SimulatorItemType ItemType { get; set; }

        public SimulatorItem(Instrument_RFID instrument)
        {
            Id = instrument.Description_ID;
            Description = instrument.getDescription();
            EPC = instrument.EPC_Nr;
            ItemType = SimulatorItemType.Instrument;
        }

        public SimulatorItem(Tray_RFID tray)
        {
            Id = tray.Description_ID.ToString();
            Description = tray.Description_Text;
            EPC = tray.EPC_Nr;
            ItemType = SimulatorItemType.Tray;
        }
        /*
        public SimulatorItem(RFIDUserCard card)
        {
            Id = card.ID;
            Description = card.UserName;
            EPC = card.EPC;
            ItemType = SimulatorItemType.CardID;
        }*/

        public SimulatorItem(string idEpcDescItemType)
        {
            string[] list = idEpcDescItemType.Split("|");
            Id = list[0];
            EPC = list[1];
            Description = list[2];
            if (Enum.TryParse(list[3], out SimulatorItemType sit))
                ItemType = sit;
        }

        public SimulatorItem(string id, string epc, string description, SimulatorItemType type)
        {
            Id = id;
            EPC = epc;
            Description = description;
            ItemType = type;
        }

        public SimulatorItem(Container_RFID container)
        {
            Id = container.Description_ID.ToString();
            EPC = container.EPC_Nr;
            Description = container.Special_Text;
            ItemType = SimulatorItemType.Container;
        }
    }
}
