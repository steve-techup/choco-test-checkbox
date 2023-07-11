namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Exchange_OverView
    {
        public string Description_Text { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }

        public DateTime? Instrument_LastSeen_Date { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(101)]
        public string Full_Name { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        public DateTime? Exchange_Date { get; set; }

        public DateTime? Exchange_Return_Date { get; set; }

        public int? Days { get; set; }

        [StringLength(50)]
        public string Instrument_LastSeen_Place { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Exchange_Number { get; set; }

        public int? Employee_ID { get; set; }
    }
}
