using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace dbefapplication.Models
{
    public partial class EmployeeMerit
    {
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        public string Employeename { get; set; }
        [Required]
        [Range(0, 50000, ErrorMessage = "salary range should be less than 50000.")]
        public int EmployeeSal { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
        public string EmployeeDept { get; set; }

        internal static object FromSqlRaw<T>(string v, int? id)
        {
            throw new NotImplementedException();
        }
    }
}
