using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretag_Class.Model
{
    public class AssetId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string EPC { get; set; }
        public bool WrittenToTag { get; set; }
    }
}
