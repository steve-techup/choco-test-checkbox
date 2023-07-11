using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;

namespace Main.Model.DevexpressModels
{
    [Persistent("Cost_Item")]
    public class CostItemXPOModel : XPLiteObject
    {
        public CostItemXPOModel(Session session)
            : base(session)
        {
        }

        private long _index_ID;
        [Key, DisplayName("ID")]
        public long Index_ID
        {
            get => _index_ID;
            set => SetPropertyValue(nameof(Index_ID), ref _index_ID, value);
        }

        private long _cost_center;
        [DisplayName("Cost Center")]
        public long Cost_Center
        {
            get => _cost_center;
            set => SetPropertyValue(nameof(Cost_Center), ref _cost_center, value);
        }

        private DateTime? _change_date;
        [DisplayName("Change Date")]
        public DateTime? Change_Date
        {
            get => _change_date;
            set => SetPropertyValue(nameof(Change_Date), ref _change_date, value);
        }

        private long? _cost_type_id;
        [DisplayName("Cost Type ID")]
        public long? Cost_Type_ID
        {
            get => _cost_type_id;
            set => SetPropertyValue(nameof(Cost_Type_ID), ref _cost_type_id, value);
        }

        private bool? _default_cost;
        [DisplayName("Default Cost")]
        public bool? Default_Cost
        {
            get => _default_cost;
            set => SetPropertyValue(nameof(Default_Cost), ref _default_cost, value);
        }

        [Association, DisplayName("Cost Log Lines")]
        public XPCollection<CostLogXPOModel> CostLogLines => GetCollection<CostLogXPOModel>(nameof(CostLogLines));
    }
}