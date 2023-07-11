using System;
using Caretag_Class.Model;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Xpo;
using Main.Util;

namespace AdminStation.ViewModels.DataTypeViewModels
{
    public class CostItemViewModel : DataTypeViewModel<long, Cost_Item>
    {
        public CostItemViewModel()
        {

        }

        public CostItemViewModel(Cost_Item costItem)
        {
            // Assign relevant fields from costItem
            this.Pkid = costItem.Index_ID;
            this.ChangeDate = costItem.Change_Date ?? DateTime.Now;
            this.CostType = costItem.CostType.Cost_Type1;
            this.DefaultCost = costItem.Default_Cost;
            this.Price = costItem.CostType.Cost_Price ?? 0;
        }

        [DisplayName("Change date")]
        public DateTime? ChangeDate { get; set; }
        private bool? _defaultCost;
        [DisplayName("Default cost")]
        public bool? DefaultCost
        {
            get => _defaultCost;
            set
            {
                _defaultCost = value;
                OnPropertyChanged("DefaultCost");
            }
        }
        [DisplayName("Cost Type")]
        public string CostType { get; set; }
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [DisplayName("Primary Key Id")]
        public override long Pkid { get; set; }
        public override void UpdateToDbItem(Cost_Item dbItem)
        {
            this.ChangeDate = DateTime.Now;
            // Assign relevant fields from this object to dbItem
            dbItem.Index_ID = this.Pkid;
            dbItem.Change_Date = this.ChangeDate;
            dbItem.Default_Cost = this.DefaultCost;
        }

        public override void UpdateFromDbItem(Cost_Item dbItem)
        {
            // Assign relevant fields from dbItem to this object
            this.Pkid = dbItem.Index_ID;
            this.ChangeDate = dbItem.Change_Date;
            this.CostType = dbItem.CostType.Cost_Type1;
            this.DefaultCost = dbItem.Default_Cost;
            this.Price = dbItem.CostType.Cost_Price ?? 0;
        }
    }
}
