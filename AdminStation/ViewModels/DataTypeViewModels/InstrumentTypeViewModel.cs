using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Model;
using DevExpress.Xpo;
using Main.Util;

namespace AdminStation.ViewModels.DataTypeViewModels
{
    public class InstrumentTypeViewModel : DataTypeViewModel<string, Instrument_Description>
    {
        public override string Pkid { get; set; }
        
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private DateTime? _date_changed;
        [DisplayName("Date Changed")]
        public DateTime? Date_Changed
        {
            get => _date_changed;
            set
            {
                _date_changed = value;
                OnPropertyChanged("Date_Changed");
            }
        }

        private int _vendor_id;
        [DisplayName("Vendor ID")]
        public int Vendor_ID
        {
            get => _vendor_id;
            set
            {
                _vendor_id = value;
                OnPropertyChanged("Vendor_ID");
            }
        }

        private bool _rfidUntaggable;
        [DisplayName("RFID Untaggable")]
        public bool RfidUntaggable
        {
            get => _rfidUntaggable;
            set
            {
                _rfidUntaggable = value;
                OnPropertyChanged("RfidUntaggable");
            }
        }
        
        public override void UpdateToDbItem(Instrument_Description dbItem)
        {
            throw new NotImplementedException();
        }

        public override void UpdateFromDbItem(Instrument_Description dbItem)
        {
            throw new NotImplementedException();
        }
    }
}
