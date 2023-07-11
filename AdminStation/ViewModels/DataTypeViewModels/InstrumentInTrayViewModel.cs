using Caretag_Class.Model;
using DevExpress.Xpo;

namespace AdminStation.ViewModels.DataTypeViewModels
{
    public class InstrumentInTrayViewModel
    {
        [DisplayName("Description Id")]
        public string DescriptionId { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Vendor Name")]
        public string Vendor { get; set; }
        [DisplayName("Amount")]
        public int Amount { get; set; }

        public InstrumentInTrayViewModel()
        {

        }

        public InstrumentInTrayViewModel(Tray_PackList trayPacklist)
        {
            DescriptionId = trayPacklist.InstrumentDescription.Description_ID;
            Description = trayPacklist.InstrumentDescription.GetFullDescription();
            Vendor = trayPacklist?.InstrumentDescription?.Instrument_Company ?? "-";
            Amount = (trayPacklist.Number ?? 1);
        }
    }
}
