using Caretag_Class.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;
using Main.Util;
using System.IO;

namespace AdminStation.ViewModels.DataTypeViewModels
{
    public class TrayViewModel : DataTypeViewModel<int, Tray_Description>
    {
        private string _tray_name;
        [DisplayName("Tray Name")]
        public string Tray_Name
        {
            get => _tray_name;
            set
            {
                _tray_name = value;
                OnPropertyChanged("Tray_Name");
            }
        }

        private string _tray_description;
        [DisplayName("Tray Description")]
        public string Tray_Description
        {
            get => _tray_description;
            set
            {
                _tray_description = value;
                OnPropertyChanged("Tray_Description");
            }
        }

        private bool? _tray_Lock;
        [DisplayName("Tray Lock")]
        public bool? Tray_Lock
        {
            get => _tray_Lock;
            set
            {
                _tray_Lock = value;
                OnPropertyChanged("Tray_Lock");
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

        private bool? _hide_tray;
        [DisplayName("Hide Tray")]
        public bool? Hide_Tray
        {
            get => _hide_tray;
            set
            {
                _hide_tray = value;
                OnPropertyChanged("Hide_Tray");
            }
        }

        private bool? _deleted_tray;
        [DisplayName("Deleted Tray")]
        public bool? Deleted_Tray
        {
            get => _deleted_tray;
            set
            {
                _deleted_tray = value;
                OnPropertyChanged("Deleted_Tray");
            }
        }

        private Cost_Item? _costItem;
        [DisplayName("Cost Item")]
        public Cost_Item? CostItem
        {
            get => _costItem;
            set
            {
                _costItem = value;
                OnPropertyChanged("CostItem");
            }
        }

        private string _special_text;
        [DisplayName("Note")]
        public string Special_Text
        {
            get => _special_text;
            set
            {
                _special_text = value;
                OnPropertyChanged("Special_Text");
            }
        }

        bool imageChanged = false;
        public Image? _image;
        public Image? Image
        {
            get => _image;
            set
            {
                if (_image != value)
                    imageChanged = true;
                _image = value;
                OnPropertyChanged("Image");
            }
        }

        public TrayViewModel()
        {

        }

        public TrayViewModel(Tray_Description tray)
        {
            UpdateFromDbItem(tray);
        }

        public override int Pkid { get; set; }
        public override void UpdateToDbItem(Tray_Description dbItem)
        {
            dbItem.Tray_Name = Tray_Name;
            dbItem.Tray_Description1 = Tray_Description;
            dbItem.Tray_Lock = Tray_Lock;
            dbItem.Date_Changed = Date_Changed;
            dbItem.Hide_Tray = Hide_Tray;
            dbItem.Deleted_Tray = Deleted_Tray;
            dbItem.CostItem = CostItem;
            dbItem.Special_Text = Special_Text;
            dbItem.Description_ID = Pkid;
            dbItem.Images.Clear();
            if (Image != null && imageChanged)
            {
                using var ms = new MemoryStream();
                Image.Save(ms, Image.RawFormat);

                dbItem.Images.Add(new Tray_Image()
                {
                    TheImage = ms.ToArray()
                });
            }
        }

        public override void UpdateFromDbItem(Tray_Description dbItem)
        {
            this.Pkid = dbItem.Description_ID;
            this.Tray_Name = dbItem.Tray_Name;
            this.Tray_Description = dbItem.Tray_Description1;
            this.Tray_Lock = dbItem.Tray_Lock;
            this.Date_Changed = dbItem.Date_Changed;
            this.Hide_Tray = dbItem.Hide_Tray;
            this.Deleted_Tray = dbItem.Deleted_Tray;
            this.CostItem = dbItem.CostItem;
            this.Special_Text = dbItem.Special_Text;
            if (dbItem.Images?.Count > 0)
                this.Image = Image.FromStream(new MemoryStream(dbItem.Images.First().TheImage));
        }
    }
}
