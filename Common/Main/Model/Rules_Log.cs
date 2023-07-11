namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rules_Log
    {
        [Key]
        [Column(Order = 0)]
        public long Rules_Log_ID { get; set; }

        public int? UserID { get; set; }

        [StringLength(50)]
        public string EPC_Nr { get; set; }

        public long? Rules_ID { get; set; }

        [StringLength(50)]
        public string Types_Service { get; set; }

        public int? ServiceVendor_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime ChangeDate { get; set; }
    }
}
