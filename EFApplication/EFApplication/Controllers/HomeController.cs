using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EFApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


namespace EFApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeDbContext _context;

        public HomeController(ILogger<HomeController> logger,EmployeeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /*public IActionResult Index()
        {
            return View(_context.Employees.ToList());
           
        }*/
        public Employee Index(int id)
        {
            return _context.Employees
            .FromSqlRaw<Employee>("spgetemployeebyid {0}", id)
            .ToList()
            .FirstOrDefault();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
