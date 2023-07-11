using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caretag_Class.Model.Service
{
    public class ServiceActionTemplateLine
    {
        [Key]
        public int Id { get; set; }
        public int ServiceActionTemplateId { get; set; }
        public string LineContents { get; set; }
    }
}
