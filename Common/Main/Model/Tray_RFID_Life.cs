namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tray_RFID_Life
    {
        [Key]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }

        public DateTime Date_Birth { get; set; }

        public DateTime? Date_End { get; set; }

        public DateTime? Last_Service { get; set; }

        public DateTime? Return_Service { get; set; }

        public int? Number_Service { get; set; }

        public int? Wash_Counter { get; set; }

        public DateTime? Steri_In { get; set; }

        public DateTime? Steri_Out { get; set; }

        [StringLength(255)]
        public string Steri_Name { get; set; }

        public DateTime? OR_In { get; set; }

        public DateTime? OR_Out { get; set; }

        [StringLength(255)]
        public string OR_Name { get; set; }

        public int? Used_In_OR { get; set; }

        public int? Passed_Steri { get; set; }

        public DateTime? Last_Change { get; set; }
    }
}
