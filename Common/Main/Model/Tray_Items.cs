namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tray_Items
    {
        [Key]
        public long Description_ID { get; set; }

        public long Tray_ID { get; set; }

        public long Disposable_ID { get; set; }

        public string Item_Description { get; set; }

        public bool? Item_Mandatory { get; set; }

        public bool? Hide_Item { get; set; }

        public bool? Deleted_Item { get; set; }

        public int? Cost_ID { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
