using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using db2WebApplication.Models;
using Microsoft.Data.SqlClient;

namespace db2WebApplication.Controllers
{
    public class AuthorController : Controller
    {
        // GET: AuthorController
        private readonly BookDbContext _context;

        public AuthorController(BookDbContext con)
        {
            _context = con;
        }
        [Route("Home/Index")]
        public ActionResult Index()
        {
            //var temp = _context.authors.Where(e => e.pubyear > 2018);
            //return View(_context.authors.ToList());
            var temp = from auth in _context.authors
                       
                       .Where(e=>e.pubyear>=2018)
                       select auth;
            return View(temp);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {

          
            return View();
        }
      

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("authorid,authorname,pubyear")] Author auth)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auth);
        }


        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
