namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Storage_Item
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        public long? Storage_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Is_Checked_OUT { get; set; }

        public long? Tray_ID { get; set; }

        public long? Container_ID { get; set; }

        public long? Cart_ID { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
