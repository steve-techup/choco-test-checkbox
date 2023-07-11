namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cart_Description
    {
        [Key]
        public int Description_ID { get; set; }

        [StringLength(50)]
        public string Cart_Name { get; set; }

        [Column("Cart_Description")]
        public string Cart_Description1 { get; set; }

        public bool? Cart_Lock { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
