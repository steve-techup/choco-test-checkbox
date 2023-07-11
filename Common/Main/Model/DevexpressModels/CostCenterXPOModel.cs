using Caretag_Class.Model;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Model.DevexpressModels
{
    [Persistent("Cost_Center")]
    public class CostCenterXPOModel : XPLiteObject
    {
        public CostCenterXPOModel(Session session) : base(session)
        {
        }

        [Key]
        [DisplayName("Index ID")]
        public long Index_ID
        {
            get => _index_ID;
            set => SetPropertyValue(nameof(_index_ID), ref _index_ID, value);
        }
        private long _index_ID;

        [DisplayName("Cost Center Name")]
        public string Cost_Center_Name
        {
            get => _cost_Center_Name;
            set => SetPropertyValue(nameof(_cost_Center_Name), ref _cost_Center_Name, value);
        }
        private string _cost_Center_Name;

        [DisplayName("Cost Center Code")]
        public string Cost_Center_Code
        {
            get => _cost_Center_Code;
            set => SetPropertyValue(nameof(_cost_Center_Code), ref _cost_Center_Code, value);
        }
        private string _cost_Center_Code;

        [DisplayName("Hidden Center")]
        public bool? Hidden_Center
        {
            get => _hidden_Center;
            set => SetPropertyValue(nameof(_hidden_Center), ref _hidden_Center, value);
        }
        private bool? _hidden_Center;

        [DisplayName("Change Date")]
        public DateTime? Change_Date
        {
            get => _change_Date;
            set => SetPropertyValue(nameof(_change_Date), ref _change_Date, value);
        }
        private DateTime? _change_Date;

        [DisplayName("Note")]
        public string? Extra_Text
        {
            get => _extra_Text;
            set => SetPropertyValue(nameof(_extra_Text), ref _extra_Text, value);
        }
        private string? _extra_Text;

        [DisplayName("Default Always")]
        public bool? Default_Always
        {
            get => _default_Always;
            set => SetPropertyValue(nameof(_default_Always), ref _default_Always, value);
        }
        private bool? _default_Always;
    }
}
