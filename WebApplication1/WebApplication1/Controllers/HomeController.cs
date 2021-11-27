using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    
    public class HomeController : Controller
    {
        private IEmployeeRepository emprepo;
        public HomeController(IEmployeeRepository emprep)
    {
        emprepo = emprep;
    }
    public ViewResult Index()
    {
           var model = emprepo.Getallemployees();
            ViewBag.PageTitle = "HOME PAGE";
            return View(model);
       
    }

  
    public ViewResult Details(int id)
    {

            HomeDetailsViewModel hme = new HomeDetailsViewModel()
            {
                employee = emprepo.GetEmployee(id),
                pagetitle = "Employee Details"
            };
           /* Employee model = emprepo.GetEmployee(2);
 
            ViewBag.PageTitle = "Employee Details";
            ViewBag.Employee = model;*/
            return View(hme);
       
        //return View(model);//strongly typed view
    }
}
}
