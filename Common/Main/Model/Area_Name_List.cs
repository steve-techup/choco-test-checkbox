namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Area_Name_List
    {
        [Key]
        public long Area_ID { get; set; }

        [StringLength(50)]
        public string Area_Name { get; set; }

        public string Area_Description { get; set; }

        [StringLength(50)]
        public string Area_Map_Name { get; set; }

        public byte[] TheMap { get; set; }

        public DateTime? Date_Changed { get; set; }
    }
}
