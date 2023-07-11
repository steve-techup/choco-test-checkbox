using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using DevExpress.Xpo;
using DynamicData;

namespace Main.Model.DevexpressModels
{
    [Persistent("Instrument_Description")]
    public class InstrumentDescriptionXPOModel : XPLiteObject
    {
        protected override void OnSaving()
        {
            Date_Changed = DateTime.Now;

            var vendorName = Session.ExecuteQuery("SELECT Vendor_Name FROM Instrument_Vendor WHERE Vendor_ID = @id", new[] { "id" }, new object[] { Vendor_ID })
                .ResultSet.FirstOrDefault()?.Rows.FirstOrDefault()?.Values.FirstOrDefault()?.ToString();
            if (vendorName != null)
                Instrument_Company = vendorName;
        }

        public InstrumentDescriptionXPOModel(Session session) : base(session)
        {
        }

        [Key]
        [DevExpress.Xpo.DisplayName("Description ID")]
        public string Description_ID
        {
            get => _description_ID;
            set => SetPropertyValue(nameof(_description_ID), ref _description_ID, value);
        }
        private string _description_ID;

        [DevExpress.Xpo.DisplayName("Instrument Company")]
        public string Instrument_Company
        {
            get => _instrument_Company;
            set => SetPropertyValue(nameof(_instrument_Company), ref _instrument_Company, value);
        }
        private string _instrument_Company;

        [DevExpress.Xpo.DisplayName("Description Name")]
        public string Description_Name
        {
            get => _description_Name;
            set => SetPropertyValue(nameof(_description_Name), ref _description_Name, value);
        }
        private string _description_Name;

        private string _d;
        public string D
        {
            get => _d;
            set => SetPropertyValue(nameof(_d), ref _d, value);
        }

        private string _e;
        public string E
        {
            get => _e;
            set => SetPropertyValue(nameof(_e), ref _e, value);
        }

        [DevExpress.Xpo.DisplayName("Date Changed")]
        private DateTime? _date_Changed;
        public DateTime? Date_Changed
        {
            get => _date_Changed;
            set => SetPropertyValue(nameof(_date_Changed), ref _date_Changed, value);
        }
        private int _vendor_ID;
        public int Vendor_ID
        {
            get => _vendor_ID;
            set => SetPropertyValue(nameof(_vendor_ID), ref _vendor_ID, value);
        }

        public override string ToString()
        {
            return GetFullDescription();
        }

        public string GetFullDescription()
        {
            return $"{Description_Name} {D} {E}";
        }

        [DevExpress.Xpo.DisplayName("RFID Untaggable")]
        private bool _rfidUntaggable;
        public bool RfidUntaggable
        {
            get => _rfidUntaggable;
            set => SetPropertyValue(nameof(_rfidUntaggable), ref _rfidUntaggable, value);
        }

        private List<TrayDescriptionXPOModel> _trays;

        [Association("Tray_PackList", typeof(TrayDescriptionXPOModel), UseAssociationNameAsIntermediateTableName = true)]
        public List<TrayDescriptionXPOModel> Trays
        {
            get => _trays;
            set => SetPropertyValue(nameof(TrayDescriptionXPOModel), ref _trays, value);
        }

        [Association]
        public XPCollection<PackingLogLineXPOModel> PackingLogLines => GetCollection<PackingLogLineXPOModel>(nameof(PackingLogLines));

        [Association]
        [Browsable(false)]
        public XPCollection<ImageXPOModel> Images => GetCollection<ImageXPOModel>(nameof(Images));

        [NonPersistent]
        public Image Image
        {
            get
            {
                if (!Images.IsLoaded)
                    Images.Load();

                if (Images == null || !Images.IsLoaded)
                    return null;

                return Images.FirstOrDefault()?.Image;
            }
            set
            {
                while (Images.Count > 0)
                {
                    Images.Remove(Images[0]);
                }
                Images.Add(new ImageXPOModel(Session) { Image = value });

                OnChanged(nameof(Images));
            }
        }

    }
}
