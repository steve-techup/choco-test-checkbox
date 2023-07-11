namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Demand_Service_Log
    {
        [Key]
        public long Demand_Service_ID { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        [StringLength(255)]
        public string Description_ID { get; set; }

        public string Rules_ID_String { get; set; }

        [StringLength(50)]
        public string Insert_Place { get; set; }

        public DateTime? ChangeDate { get; set; }

        public long? Demand_Text_ID { get; set; }
    }
}
