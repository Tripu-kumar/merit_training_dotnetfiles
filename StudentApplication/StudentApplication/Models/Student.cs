using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace StudentApplication.Models
{
    public class Student
    {
        [Key]
        public int stuid { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [StringLength(10)]
        public string name { get; set; }
        
        [Required(ErrorMessage = "Please enter branch")]
      
        public Branch branch { get; set; }
       
        [Required(ErrorMessage = "Please enter section")]
        [StringLength(10)]
        public string section { get; set; }

        [Required(ErrorMessage = "Please enter gender")]
        public Gender gender { get; set; }

        public IEnumerable<Gender> AllGenders{ get; set; }

    }
}
