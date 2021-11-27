using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace contactmvc.Models
{
    public class Contactdata
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string Name { get; set; }
        public string Emailid { get; set; }
        public string Message { get; set; }
    }
}
