using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caretag_Class.Model;
using DevExpress.Xpo;
using Main.Util;

namespace AdminStation.ViewModels.DataTypeViewModels
{
    public class CostTypeViewModel : DataTypeViewModel<long, Cost_Type>
    {
        public CostTypeViewModel()
        {

        }
        
        public CostTypeViewModel(Cost_Type dbItem)
        {
            //assign corresponding fields from dbItem to this object
            this.Pkid = dbItem.Index_ID;
            this.Change_Date = dbItem.Change_Date;
            this.Cost_Type = dbItem.Cost_Type1;
            this.Cost_Price = dbItem.Cost_Price;
        }

        private string _cost_type;
        [DisplayName("Cost Type")]
        public string Cost_Type
        {
            get => _cost_type;
            set
            {
                _cost_type = value;
                OnPropertyChanged("Cost_Type");
            }
        }

        private decimal? _cost_price;
        [DisplayName("Cost Price")]
        public decimal? Cost_Price
        {
            get => _cost_price;
            set
            {
                _cost_price = value;
                OnPropertyChanged("Cost_Price");
            }
        }

        private DateTime? _change_date;
        [DisplayName("Change Date")]
        public DateTime? Change_Date
        {
            get => _change_date;
            set
            {
                _change_date = value;
                OnPropertyChanged("Change_Date");
            }
        }

        [DisplayName("Primary Key Id")]
        public override long Pkid { get; set; }
        public override void UpdateToDbItem(Cost_Type dbItem)
        {
            this._change_date = DateTime.Now;
            //assign corresponding fields from this object to dbItem
            dbItem.Index_ID = this.Pkid;
            dbItem.Change_Date = this.Change_Date;
            dbItem.Cost_Type1 = this.Cost_Type;
            dbItem.Cost_Price = this.Cost_Price;
        }

        public override void UpdateFromDbItem(Cost_Type dbItem)
        {
            //assign corresponding fields from dbItem to this object
            this.Pkid = dbItem.Index_ID;
            this.Change_Date = dbItem.Change_Date;
            this.Cost_Type = dbItem.Cost_Type1;
            this.Cost_Price = dbItem.Cost_Price;
        }
    }
}
