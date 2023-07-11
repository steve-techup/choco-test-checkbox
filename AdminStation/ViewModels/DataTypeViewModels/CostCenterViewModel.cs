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
    public class CostCenterViewModel : DataTypeViewModel<long, Cost_Center>
    {
        public CostCenterViewModel()
        {

        }

        public CostCenterViewModel(Cost_Center dbItem)
        {
            //assign corresponding fields from dbItem to this object
            this.Pkid = dbItem.Index_ID;
            this.Change_Date = dbItem.Change_Date;
            this.Cost_Center_Name = dbItem.Cost_Center_Name;
            this.Cost_Center_Code = dbItem.Cost_Center_Code;
            this.Hidden_Center = dbItem.Hidden_Center;
            this.Default_Always = dbItem.Default_Always;
        }

        private string _cost_center_name;
        [DisplayName("Cost Center Name")]
        public string Cost_Center_Name
        {
            get => _cost_center_name;
            set
            {
                _cost_center_name = value;
                OnPropertyChanged("Cost_Center_Name");
            }
        }

        private string _cost_center_code;
        [DisplayName("Cost Center Code")]
        public string Cost_Center_Code
        {
            get => _cost_center_code;
            set
            {
                _cost_center_code = value;
                OnPropertyChanged("Cost_Center_Code");
            }
        }

        private bool? _hidden_center;
        [DisplayName("Hidden")]
        public bool? Hidden_Center
        {
            get => _hidden_center;
            set
            {
                _hidden_center = value;
                OnPropertyChanged("Hidden_Center");
            }
        }

        private bool? _default_always;
        [DisplayName("Default Always")]
        public bool? Default_Always
        {
            get => _default_always;
            set
            {
                _default_always = value;
                OnPropertyChanged("Default_Always");
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

        private string _extra_text;
        [DisplayName("Note")]
        public string Extra_Text
        {
            get => _extra_text;
            set
            {
                _extra_text = value;
                OnPropertyChanged("Extra_Text");
            }
        }

        [DisplayName("Primary Key Id")]
        public override long Pkid { get; set; }
        public override void UpdateToDbItem(Cost_Center dbItem)
        {
            this._change_date = DateTime.Now;
            //assign corresponding fields from this object to dbItem
            dbItem.Index_ID = this.Pkid;
            dbItem.Change_Date = this.Change_Date;
            dbItem.Cost_Center_Name = this.Cost_Center_Name;
            dbItem.Cost_Center_Code = this.Cost_Center_Code;
            dbItem.Hidden_Center = this.Hidden_Center;
            dbItem.Default_Always = this.Default_Always;
        }

        public override void UpdateFromDbItem(Cost_Center dbItem)
        {
            //assign corresponding fields from dbItem to this object
            this.Pkid = dbItem.Index_ID;
            this.Change_Date = dbItem.Change_Date;
            this.Cost_Center_Name = dbItem.Cost_Center_Name;
            this.Cost_Center_Code = dbItem.Cost_Center_Code;
            this.Hidden_Center = dbItem.Hidden_Center;
            this.Default_Always = dbItem.Default_Always;
        }
    }
}
