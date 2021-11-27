using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentApplication.Models;

namespace StudentApplication.Controllers
{
    public class HomeController : Controller
    {
      

        private List<Student> studentlist = new List<Student>();
        public HomeController()
        {
            studentlist = new List<Student>()
            {
                new Student()
                {
                    stuid=101,
                    name="tripu",
                    branch=Branch.CSE,
                    section="A",
                    gender=Gender.female
                },
            new Student()
            {
                stuid = 102,
                name = "kalai",
                branch = Branch.EEE,
                section = "B",
                gender = Gender.female
            },
             new Student()
            {
                stuid = 103,
                name = "agila",
                branch = Branch.IT,
                section = "B",
                gender = Gender.female
            }
            };
        }

        public ViewResult Index()
        {
            return View(studentlist);
        }

        public ViewResult Details(int id)
        {
            var studetails = studentlist.FirstOrDefault(std => std.stuid == id);
            return View(studetails);
        }
      [HttpGet]
      public ViewResult Create()
        {
            Student stud = new Student
            {
                AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList()
            };
            return View(stud);
        }
        [HttpPost]
        public ViewResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                
               

            }
            student.stuid = studentlist.Max(x => x.stuid) + 1;
            studentlist.Add(student);
            return View("Details", student);

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
