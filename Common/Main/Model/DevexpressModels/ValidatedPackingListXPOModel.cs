using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Annotations;
using static Main.Model.PackingList.Validation.ValidatedPackingList;

namespace Main.Model.DevexpressModels
{
    [Persistent("ValidatedPackingLists")]
    public class ValidatedPackingListXPOModel : XPLiteObject
    {
        public ValidatedPackingListXPOModel(Session session)
            : base(session)
        {

        }

        private int _id;

        [Key]
        public int Id
        {
            get => _id;
            set => SetPropertyValue(nameof(_id), ref _id, value);
        }

        private DateTime _timestamp;

        public DateTime Timestamp
        {
            get => _timestamp;
            set => SetPropertyValue(nameof(_timestamp), ref _timestamp, value);
        }

        private string _location;

        public string Location
        {
            get => _location;
            set => SetPropertyValue(nameof(_location), ref _location, value);
        }

        private PackingListState _result;

        public PackingListState Result
        {
            get => _result;
            set => SetPropertyValue(nameof(_result), ref _result, value);
        }

        public string PrettyResult => Result switch
        {
            PackingListState.MoreThanOneTray => "More than one tray",
            PackingListState.NoTray          => "No tray",
            PackingListState.NotOk           => "Not OK",
            PackingListState.Ok              => "OK"
        };

        private string _trayEPC;
        public string TrayEPC
        {
            get => _trayEPC;
            set => SetPropertyValue(nameof(_trayEPC), ref _trayEPC, value);
        }

        private int _trayId;
        public int TrayId
        {
            get => _trayId;
            set => SetPropertyValue(nameof(_trayId), ref _trayId, value);
        }

        public string TrayName =>
            TrayId > 0 ? Session.GetObjectByKey<TrayDescriptionXPOModel>(TrayId).Tray_Name : "No Tray";

        public string TotalPacked =>
            Session.ExecuteQuery(
                "SELECT sum(Actual) FROM ValidatedPackingListLineItems where ValidatedPackingList_Id = @id", new[] {"id"},
                new object[] { Id }).ResultSet.FirstOrDefault()?.Rows.FirstOrDefault()?.Values.FirstOrDefault()?.ToString() ?? "-";
        public string TotalExpected 
        {
            get
            {
                var expected = int.Parse(Session.ExecuteQuery(
                    "SELECT sum(Expected) FROM ValidatedPackingListLineItems where ValidatedPackingList_Id = @id", new[] { "id" },
                        new object[] { Id
                        }).ResultSet.FirstOrDefault()?.Rows.FirstOrDefault()?.Values.FirstOrDefault()?.ToString() ?? "0");
                return expected > 0 ? expected.ToString() : "-";
            }
        }
    }
}
