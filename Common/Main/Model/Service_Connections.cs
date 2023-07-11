namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Service_Connections
    {
        [Key]
        [Column(Order = 0)]
        public int Service_Connection_ID { get; set; }

        public int? ServiceVendor_ID { get; set; }

        public string Service_Connection { get; set; }

        public Guid? Connection_Code { get; set; }

        public string PassCode { get; set; }

        public DateTime? LastLogin { get; set; }

        public int? NumberLogins { get; set; }

        [Key]
        [Column(Order = 1)]
        public bool Connection_InUse { get; set; }

        public DateTime? ChangeDate { get; set; }
    }
}
