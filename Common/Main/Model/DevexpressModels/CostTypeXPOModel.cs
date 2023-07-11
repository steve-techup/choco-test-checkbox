using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace Main.Model.DevexpressModels
{
    [Persistent("Cost_Type")]
    public class CostTypeXPOModel : XPLiteObject
    {
        public CostTypeXPOModel(Session session) : base(session)
        {
        }

        [Key]
        [DisplayName("Index ID")]
        public long Index_ID
        {
            get => _index_ID;
            set => SetPropertyValue(nameof(Index_ID), ref _index_ID, value);
        }
        private long _index_ID;

        [DisplayName("Cost Type")]
        public string Cost_Type
        {
            get => _cost_Type;
            set => SetPropertyValue(nameof(Cost_Type), ref _cost_Type, value);
        }
        private string _cost_Type;

        [DisplayName("Cost Price")]
        public decimal? Cost_Price
        {
            get => _cost_Price;
            set => SetPropertyValue(nameof(Cost_Price), ref _cost_Price, value);
        }
        private decimal? _cost_Price;

        [DisplayName("Change Date")]
        public DateTime? Change_Date
        {
            get => _change_Date;
            set => SetPropertyValue(nameof(Change_Date), ref _change_Date, value);
        }
        private DateTime? _change_Date;
    }
}