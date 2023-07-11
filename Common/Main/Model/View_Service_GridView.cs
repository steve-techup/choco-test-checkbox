namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Service_GridView
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Date_Birth { get; set; }

        public DateTime? Date_End { get; set; }

        public DateTime? Sent_Service { get; set; }

        public DateTime? Return_Service { get; set; }

        public int? Number_Service { get; set; }

        public DateTime? Last_Change { get; set; }

        [StringLength(765)]
        public string Full_Name { get; set; }

        public int? Service_Days { get; set; }

        public int? DaysInService { get; set; }

        public int? Passed_Steri { get; set; }

        public int? Used_In_OR { get; set; }
    }
}
