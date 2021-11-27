using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFApplication.Models
{
    [Table("EmployeeMerit")]
    public class Employee
    {
        [Key]
        [Column("employeeID")]
        public int empid { get; set; }
        [Column("employeename")]
        public string empname { get; set; }
        [Column("employee_sal")]
        public int salary { get; set; }
        [Column("employee_dept")]
        public string department { get; set; }
    }
}
