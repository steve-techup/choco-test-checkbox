using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretag_Class.Model.Service
{
    public class ServiceActionRecordLine
    {
        [Key]
        public int Id { get; set; }
        public int ServiceActionRecordId { get; set; }
        public int ServiceActionTemplateLineId { get; set; }
        public bool Checked { get; set; }
    }
}
