namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Container_Description
    {
        [Key]
        public int Description_ID { get; set; }

        [StringLength(50)]
        public string Container_Name { get; set; }

        [Column("Container_Description")]
        public string Container_Description1 { get; set; }

        public bool Container_Lock { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
