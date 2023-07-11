namespace Caretag_Class.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class View_Reader_Log_Error
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ErrorLog_ID { get; set; }

        public string Error_Description { get; set; }

        public DateTime? ChangeDate { get; set; }

        [StringLength(50)]
        public string Area_Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Reader_Name { get; set; }

        public string Reader_Description { get; set; }

        [StringLength(50)]
        public string IP_Address { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Reader_ID { get; set; }

        public int? Department_ID { get; set; }
    }
}
