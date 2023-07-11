namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Treatment_Type
    {
        [Key]
        [Column(Order = 0)]
        public long Index_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string Description_Type { get; set; }

        public string Server_Path { get; set; }

        public DateTime? Change_Date { get; set; }
    }
}
