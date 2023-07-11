namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EPC_Number_Serie
    {
        [Key]
        [Column(Order = 0)]
        public string Owner_Ship { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Owner_Serie { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string Customer_Number { get; set; }

        [StringLength(10)]
        public string Special_Number { get; set; }

        public int? Max_Number { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Start_EPC { get; set; }

        public string New_EPC { get; set; }

        public bool? Confirm_To_GS1 { get; set; }

        public string Last_Used_EPC { get; set; }

        public DateTime? Last_Used_Date { get; set; }
    }
}
