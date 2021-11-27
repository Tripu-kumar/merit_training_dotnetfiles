using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jobmvc.Models
{
    public class jobdata
    {
        public int JobDetailsId { get; set; }
        public string Companyname { get; set; }
        public string JobCategory { get; set; }
        public string Requiredskills { get; set; }
        public string Experience { get; set; }
        public int NoOfVacancies { get; set; }
        public double Salary { get; set; }
        public DateTime EndDate { get; set; }
        public string Email { get; set; }
        public string JobLocation { get; set; }
        public double PhNo { get; set; }
        public string CompanyAddress { get; set; }
        public string JobDescription { get; set; }
        public string JobType { get; set; }
    }
}
