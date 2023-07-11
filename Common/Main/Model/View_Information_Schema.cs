namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Information_Schema
    {
        [Key]
        [Column(Order = 0)]
        public string TABLE_NAME { get; set; }

        [StringLength(128)]
        public string TABLE_CATALOG { get; set; }

        [StringLength(128)]
        public string TABLE_SCHEMA { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime modify_date { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long row_count { get; set; }
    }
}
