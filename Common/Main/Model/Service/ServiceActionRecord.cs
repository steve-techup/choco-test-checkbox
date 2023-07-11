using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretag_Class.Model.Service
{
    public class ServiceActionRecord
    {
        [Key]
        public int Id { get; set; }
        public int ServiceActionTemplateId { get; set; }
        public int ServiceRequestId { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        [StringLength(100)]
        public string Location { get; set; }
    }
}
