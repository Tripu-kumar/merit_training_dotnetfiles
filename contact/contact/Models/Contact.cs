using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace contact.Models
{
    public class Contact
    {
        [Key]
        public int contact_id {get;set;}
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string name { get; set; }
        [EmailAddress]
        [Required]
        public string emailid { get; set; }
        [StringLength(60)]
        [Required]
        public string message { get; set; }
    }
}
