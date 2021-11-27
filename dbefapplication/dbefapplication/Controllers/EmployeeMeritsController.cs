using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dbefapplication.Models;
using Microsoft.Data.SqlClient;

namespace dbefapplication.Controllers
{
    public class EmployeeMeritsController : Controller
    {
        private readonly meritemployeeContext _context;

       

        public EmployeeMeritsController(meritemployeeContext context)
        {
            _context = context;
        }

        // GET: EmployeeMerits
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeMerits.ToListAsync());
        }

        // GET: EmployeeMerits/Details/5
        public  ViewResult Details(int? id)
        {
            /*if (id == null)
            {
                return NotFound();
            }

            var employeeMerit = await _context.EmployeeMerits
            .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeMerit == null)
            {
                return NotFound();
            }*/
          
            var employeemerit =  _context.EmployeeMerits
            .FromSqlRaw<EmployeeMerit>("spgetemployeebyid {0}", id)
            .ToList()
            .FirstOrDefault();
           

            return View(employeemerit);
           

        }

        

        // GET: EmployeeMerits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeMerits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Employeename,EmployeeSal,EmployeeDept")] EmployeeMerit employeeMerit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeMerit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeMerit);
        }

        // GET: EmployeeMerits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMerit = await _context.EmployeeMerits.FindAsync(id);
            if (employeeMerit == null)
            {
                return NotFound();
            }
            return View(employeeMerit);
        }

        // POST: EmployeeMerits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Employeename,EmployeeSal,EmployeeDept")] EmployeeMerit employeeMerit)
        {
            if (id != employeeMerit.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeMerit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeMeritExists(employeeMerit.EmployeeId))
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
            return View(employeeMerit);
        }

        // GET: EmployeeMerits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMerit = await _context.EmployeeMerits
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeMerit == null)
            {
                return NotFound();
            }

            return View(employeeMerit);
        }

        // POST: EmployeeMerits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeMerit = await _context.EmployeeMerits.FindAsync(id);
            _context.EmployeeMerits.Remove(employeeMerit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeMeritExists(int id)
        {
            return _context.EmployeeMerits.Any(e => e.EmployeeId == id);
        }
    }
}
