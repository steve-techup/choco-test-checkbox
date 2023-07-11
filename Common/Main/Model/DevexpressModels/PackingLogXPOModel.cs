using System;
using System.ComponentModel;
using Caretag_Class.Model;
using DevExpress.Xpo;
using Main.Annotations;

namespace Main.Model.DevexpressModels
{
    [Persistent("PackingLogs")]
    public class PackingLogXPOModel : XPLiteObject
    {
        public PackingLogXPOModel(Session session) : base(session)
        {
        }

        private int _id;
        
        [Key]
        public int Id
        {
            get => _id;
            set => SetPropertyValue(nameof(_id), ref _id, value);
        }


        private string _sterilizationIndicatorLotNumber;
        public string SterilizationIndicatorLotNumber
        {
            get => _sterilizationIndicatorLotNumber;
            set => SetPropertyValue(nameof(_sterilizationIndicatorLotNumber), ref _sterilizationIndicatorLotNumber, value);
        }

        private bool _packedLocked;
        public bool PackedLocked
        {
            get => _packedLocked;
            set => SetPropertyValue(nameof(_packedLocked), ref _packedLocked, value);
        }

        private int _totalInstruments;
        public int TotalInstruments
        {
            get => _totalInstruments;
            set => SetPropertyValue(nameof(_totalInstruments), ref _totalInstruments, value);
        }

        private int _totalInstrumentTypes;
        public int TotalInstrumentTypes
        {
            get => _totalInstrumentTypes;
            set => SetPropertyValue(nameof(_totalInstrumentTypes), ref _totalInstrumentTypes, value);
        }

        private int _totalPackedManually;
        public int TotalPackedManually
        {
            get => _totalPackedManually;
            set => SetPropertyValue(nameof(_totalPackedManually), ref _totalPackedManually, value);
        }

        private UserXPOModel _packedByUserId;
        [Association]
        [DevExpress.Xpo.DisplayName("Packed By")]
        public UserXPOModel PackedByUserId
        {
            get => _packedByUserId;
            set => SetPropertyValue(nameof(_packedByUserId), ref _packedByUserId, value);
        }
        
        private DateTime _timestamp;
        public DateTime Timestamp
        {
            get => _timestamp;
            set => SetPropertyValue(nameof(_timestamp), ref _timestamp, value);
        }
        
        private CostLogXPOModel _costLogId;
        [Association]
        [Browsable(false)]

        [System.ComponentModel.DataAnnotations.Display(AutoGenerateField = false, Description = "This column isn't created")]
        public CostLogXPOModel CostLogId
        {
            get => _costLogId;
            set => SetPropertyValue(nameof(_costLogId), ref _costLogId, value);
        }
        
        private TrayDescriptionXPOModel _trayDescription;
        [Association]
        [DevExpress.Xpo.DisplayName("Tray Description")]
        public TrayDescriptionXPOModel TrayTypeId
        {
            get { return _trayDescription; }
            set { SetPropertyValue(nameof(Tray_Description), ref _trayDescription, value); }
        }
        
        [Association]
        public XPCollection<PackingLogLineXPOModel> PackingLogLines => GetCollection<PackingLogLineXPOModel>(nameof(PackingLogLines));
        
    }
}
