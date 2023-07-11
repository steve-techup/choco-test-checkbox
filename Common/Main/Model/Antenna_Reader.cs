namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Antenna_Reader
    {
        [Key]
        public int Antenna_ID { get; set; }

        public short Reader_ID { get; set; }

        public long? Antenna_Area_ID { get; set; }

        [StringLength(50)]
        public string Antenna_Name { get; set; }

        [StringLength(50)]
        public string Antenna_Type { get; set; }

        public string Antenna_Location { get; set; }

        public short? Antenna_Factor { get; set; }

        public string Antenna_Description { get; set; }

        [StringLength(10)]
        public string In_Use { get; set; }

        public DateTime? StartDate { get; set; }
    }
}
