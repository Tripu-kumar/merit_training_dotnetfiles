using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace contactMVC.Models
{
    public class ContactData
    {
        [Key]
        public int contact_id { get; set; }
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
