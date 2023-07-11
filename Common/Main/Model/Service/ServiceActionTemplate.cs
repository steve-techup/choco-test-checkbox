using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretag_Class.Model.Service
{
    public class ServiceActionTemplate
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartStates { get; set; }
        [StringLength(50)]
        public string EndState { get; set; }
    }
}
