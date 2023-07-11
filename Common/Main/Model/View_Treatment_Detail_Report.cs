namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Treatment_Detail_Report
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Detail_ID { get; set; }

        public long? Treatment_ID { get; set; }

        public short? The_Order { get; set; }

        public string Detail_Text { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Treatment_Description { get; set; }

        [StringLength(1026)]
        public string Full_Name { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }
    }
}
