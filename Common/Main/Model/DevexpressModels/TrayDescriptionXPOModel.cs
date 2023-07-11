using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Main.Model.DevexpressModels
{
    [Persistent("Tray_Description")]
    public class TrayDescriptionXPOModel : XPLiteObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public TrayDescriptionXPOModel(Session session)
            : base(session)
        {

        }
        private int _descriptionId;
        [Key]
        [DisplayName("Description Id")]
        public int Description_ID
        {
            get => _descriptionId;
            set => SetPropertyValue(nameof(_descriptionId), ref _descriptionId, value);
        }

        private string _tray_Name;
        [DisplayName("Name")]
        public string Tray_Name
        {
            get => _tray_Name;
            set => SetPropertyValue(nameof(_tray_Name), ref _tray_Name, value);
        }

        private string _tray_Description;

        [Persistent("Tray_Description")]
        [DisplayName("Description")]
        public string Tray_Description1
        {
            get => _tray_Description;
            set => SetPropertyValue(nameof(_tray_Description), ref _tray_Description, value);
        }

        private bool? _tray_Lock;
        [DisplayName("Locked")]
        public bool? Tray_Lock
        {
            get => _tray_Lock;
            set => SetPropertyValue(nameof(_tray_Lock), ref _tray_Lock, value);
        }

        private DateTime? _date_Changed;
        [DisplayName("Date Changed")]
        public DateTime? Date_Changed
        {
            get => _date_Changed;
            set => SetPropertyValue(nameof(_date_Changed), ref _date_Changed, value);
        }

        private bool? _hide_Tray;
        [DisplayName("Hidden")]
        public bool? Hide_Tray
        {
            get => _hide_Tray;
            set => SetPropertyValue(nameof(Hide_Tray), ref _hide_Tray, value);
        }

        
        private bool? _deleted_Tray;
        [DisplayName("Deleted")]
        public bool? Deleted_Tray
        {
            get => _deleted_Tray;
            set => SetPropertyValue(nameof(Deleted_Tray), ref _deleted_Tray, value);
        }

        private int _cost_ID;
        public int Cost_ID
        {
            get => _cost_ID;
            set => SetPropertyValue(nameof(Cost_ID), ref _cost_ID, value);
        }

        private string _special_Text;

        [DisplayName("Note")]
        public string Special_Text
        {
            get => _special_Text;
            set => SetPropertyValue(nameof(Special_Text), ref _special_Text, value);
        }

        [Association]
        public XPCollection<PackingLogXPOModel> PackingLogs => GetCollection<PackingLogXPOModel>(nameof(PackingLogs));

        [Association]
        public XPCollection<CostLogXPOModel> CostLogLines => GetCollection<CostLogXPOModel>(nameof(CostLogLines));

        public override string ToString()
        {
            return $"{Tray_Name} {Tray_Description1}";
        }
        [Association]
        [System.ComponentModel.Browsable(false)]
        public XPCollection<TrayImageXPOModel> Images => GetCollection<TrayImageXPOModel>(nameof(Images));

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
                Images.Add(new TrayImageXPOModel(Session) { Image = value });

                OnChanged(nameof(Images));
            }
        }

    }
}