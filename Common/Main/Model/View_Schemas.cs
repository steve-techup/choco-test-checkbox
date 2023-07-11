namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Schemas
    {
        [StringLength(128)]
        public string schema { get; set; }

        [Key]
        public string name { get; set; }
    }
}
