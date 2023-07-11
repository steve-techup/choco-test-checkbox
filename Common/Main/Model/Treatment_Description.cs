namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Treatment_Description
    {
        [Key]
        [Column(Order = 0)]
        public long Treatment_ID { get; set; }

        [Key]
        [Column("Treatment_Description", Order = 1)]
        public string Treatment_Description1 { get; set; }

        public DateTime? Change_Date { get; set; }

        public string Treatment_Path { get; set; }
    }
}
