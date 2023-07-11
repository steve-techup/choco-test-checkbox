namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_ReaderList
    {
        public string Reader_Description { get; set; }

        [StringLength(10)]
        public string R_In_Use { get; set; }

        public long? Area_ID { get; set; }

        public long? Antenna_Area_ID { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Reader_ID { get; set; }

        [StringLength(50)]
        public string Antenna_Name { get; set; }

        [StringLength(50)]
        public string Antenna_Type { get; set; }

        public string Antenna_Location { get; set; }

        [StringLength(10)]
        public string In_Use { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime Last_Edited { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime Start_Date { get; set; }

        [StringLength(50)]
        public string Area_Name { get; set; }

        public string Area_Description { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Reader_Name { get; set; }

        [StringLength(50)]
        public string IP_Address { get; set; }
    }
}
