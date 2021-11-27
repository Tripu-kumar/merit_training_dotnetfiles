using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> emplist;
        public MockEmployeeRepository()
        {
            emplist = new List<Employee>()
            {
               new Employee(){id=1,Name="tripu",Department="HR",Email="tripu@anc.com"},
               new Employee(){id=2,Name="kalai",Department="Payroll",Email="kalai@anc.com"},
              new  Employee(){id=3,Name="Santhi",Department="IT",Email="santhi@anc.com"},
              new Employee(){id=4,Name="agila",Department="IT",Email="agila@anc.com"},
             };
        }
        public Employee GetEmployee(int id)
        {
            return emplist.FirstOrDefault(e => e.id == id);
        }
        public IEnumerable<Employee> Getallemployees()
        {
            return emplist;
        }
    }
}
