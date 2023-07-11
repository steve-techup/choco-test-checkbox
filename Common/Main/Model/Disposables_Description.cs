namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Disposables_Description
    {
        [Key]
        public long Description_ID { get; set; }

        public string Description_Text { get; set; }

        [StringLength(250)]
        public string Manufactor { get; set; }

        public int? Numbers { get; set; }

        public decimal? Cost_Factor { get; set; }

        public DateTime? ChangeDate { get; set; }

        public string Disposables_External { get; set; }
    }
}
