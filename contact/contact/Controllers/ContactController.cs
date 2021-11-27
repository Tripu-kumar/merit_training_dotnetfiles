using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using contact.Models;

namespace contact.Controllers
{
    public class ContactController : Controller
    {
        private ContactDbContext con;
        public ContactController(ContactDbContext context)
        {
            con = context;
        }
        [HttpGet]
        public List<Contact> Get()
        {
            return con.Contacts.ToList();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
