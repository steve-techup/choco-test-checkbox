namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exchange_Table
    {
        [Key]
        [Column(Order = 0)]
        public long Exchange_ID { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        public int? Employee_ID { get; set; }

        public DateTime? Exchange_Date { get; set; }

        public DateTime? Exchange_Return_Date { get; set; }

        public long? Exchange_Place_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Exchange_Number { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Is_Missing { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Change_Date { get; set; }
    }
}
