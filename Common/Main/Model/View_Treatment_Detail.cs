namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Treatment_Detail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Detail_ID { get; set; }

        public short? The_Order { get; set; }

        public string Detail_Text { get; set; }

        public DateTime? Change_Date { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Treatment_Description { get; set; }

        public string Description_Text { get; set; }

        public long? Treatment_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string Description_ID { get; set; }

        public long? Treatment_Type { get; set; }

        [StringLength(10)]
        public string Description_Type { get; set; }
    }
}
