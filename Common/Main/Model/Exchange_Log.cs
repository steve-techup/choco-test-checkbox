namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exchange_Log
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Employee_ID { get; set; }

        public DateTime? Exchange_Date { get; set; }

        public DateTime? Exchange_Return_Date { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Exchange_Number { get; set; }

        public long? Exchange_ID { get; set; }
    }
}
