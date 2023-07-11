namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Storage_Station
    {
        [Key]
        public long Storage_ID { get; set; }

        public long? Reestablish_ID { get; set; }

        [StringLength(50)]
        public string Station_Name { get; set; }

        public long? Reader_ID { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
