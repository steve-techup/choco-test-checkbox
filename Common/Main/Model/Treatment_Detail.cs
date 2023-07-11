namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Treatment_Detail
    {
        [Key]
        public long Detail_ID { get; set; }

        public long? Treatment_ID { get; set; }

        public short? The_Order { get; set; }

        public string Detail_Text { get; set; }

        public DateTime? Change_Date { get; set; }

        public long? Treatment_Type { get; set; }

        [StringLength(50)]
        public string Detail_Name { get; set; }
    }
}
