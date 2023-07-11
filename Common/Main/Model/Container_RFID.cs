namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Container_RFID
    {
        [Key]
        public long Container_ID { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(50)]
        public string SEQ_Nr { get; set; }

        public int? Description_ID { get; set; }

        public string Special_Text { get; set; }

        public int? Container_Contents { get; set; }

        [StringLength(50)]
        public string Container_LastSeen_Place { get; set; }

        public DateTime? Container_LastSeen_Date { get; set; }

        public bool? Container_InUse { get; set; }

        public DateTime? Container_Changed { get; set; }

        public long? Cart_ID { get; set; }

        public long? Tray_ID { get; set; }
    }
}
