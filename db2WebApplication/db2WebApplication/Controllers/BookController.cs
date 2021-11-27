using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using db2WebApplication.Models;

namespace db2WebApplication.Controllers
{
    public class BookController : Controller
    {
        // GET: BookController
        private readonly BookDbContext _context;

        public BookController(BookDbContext con)
        {
            _context = con;
        }
        public IActionResult Index()
        {
            return View(_context.books.ToList());
        }



        // GET: BookController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var b = await _context.books.FirstOrDefaultAsync(m => m.bookid == id);
            if (b == null)
            {
                return NotFound();
            }

            return View(b);
        }

        // GET: BookController/Create
        public ActionResult Create()

        {

            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bookid,bookname")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: BookController/Edit/5
        /*public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var b = await _context.books.FindAsync(id);
            if (b == null)
            {
                return NotFound();
            }
            return View(b);
        }*/


        // POST: BookController/Edit/5
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
       /* public async Task<IActionResult> Edit(int id, [Bind("bookid","bookname")] Book books)
        {
            if (id != books.bookid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(books.bookid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(books);
        }*/

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
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
