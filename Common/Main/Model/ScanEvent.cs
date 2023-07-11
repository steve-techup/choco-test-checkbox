using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caretag_Class.Model
{
    [Table("ScanEvent")]
    public class ScanEvent
    {
        [Key]
        public int ID { get; set; }
        [StringLength(200)]
        public string EPC { get; set; }
        public DateTime Time_stamp { get; set; }
        [StringLength(200)]
        public string Scan_location { get; set; }
        public string DisplayText => $"{Time_stamp.ToString("dd/MM HH:mm")} {Scan_location}";
    }
}
