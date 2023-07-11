using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretag_Class.Model
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string OperationId { get; set; }
        public string OperatingRoom { get; set; }
        [StringLength(50)]
        public string State { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public ICollection<OperationInstrument> OperationInstruments { get; set; }
    }
}
