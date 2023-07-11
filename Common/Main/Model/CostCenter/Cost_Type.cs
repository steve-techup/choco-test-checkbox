namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cost_Type
    {
        [Key]
        public long Index_ID { get; set; }

        [Column("Cost_Type")]
        public string Cost_Type1 { get; set; }

        public decimal? Cost_Price { get; set; }

        public DateTime? Change_Date { get; set; }

        public override string ToString()
        {
            return $"{Cost_Type1} [{Cost_Price}]";
        }
    }
}
