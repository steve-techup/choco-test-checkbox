namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OR_Procedure
    {
        [Key]
        public long Index_ID { get; set; }

        public string Cost_Center { get; set; }

        public string Procedure_ID { get; set; }

        public string Procedure_Name { get; set; }

        public long? Cost_Center_ID { get; set; }

        public bool? Hidden { get; set; }

        public string External_ID { get; set; }

        public string Note { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
