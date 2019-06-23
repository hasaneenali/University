using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityCore.Entities;
using UniversityCore.Models;


namespace UniversityCore.Controllers
{
    public class CollegesController : Controller
    {
        private readonly DataContext _context;

        public CollegesController(DataContext context)
        {
            _context = context;
        }

        // GET: Colleges
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Colleges.Include(c => c.University);
            return View(await dataContext.ToListAsync());
        }

        // GET: Colleges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var college = await _context.Colleges
                .Include(c => c.University)
                .FirstOrDefaultAsync(m => m.CollegeId == id);
            if (college == null)
            {
                return NotFound();
            }

            return View(college);
        }

        // GET: Colleges/Create
        public IActionResult Create()
        {
            ViewData["UniversityId"] = new SelectList(_context.Universities, "UniversityId", "Name");
            return View();
        }

        // POST: Colleges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CollegeViewModel collegeViewModel)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;
                if (collegeViewModel.ImageFile != null && collegeViewModel.ImageFile.Length > 0)
                {
                   
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                   
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\College", file);


                   
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await collegeViewModel.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/College/{file}";
                }

                var college = this.tocollege(collegeViewModel, path);
                _context.Add(college);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            ViewData["UniversityId"] = new SelectList(_context.Universities, "UniversityId", "Name", collegeViewModel.UniversityId);
            return View(collegeViewModel);
        }

        private College tocollege(CollegeViewModel collegeViewModel, string path)
        {
            return new College()
            {
              CollegeId=collegeViewModel.CollegeId,
              Name=collegeViewModel.Name,
              ImageUrl=path,
              UniversityId=collegeViewModel.UniversityId,
              University=collegeViewModel.University
            };
        }

        // GET: Colleges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var college = await _context.Colleges.FindAsync(id);
            if (college == null)
            {
                return NotFound();
            }
            ViewData["UniversityId"] = new SelectList(_context.Universities, "UniversityId", "Name", college.UniversityId);
            return View(college);
        }

        // POST: Colleges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  College college)
        {
            if (id != college.CollegeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(college);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollegeExists(college.CollegeId))
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
            ViewData["UniversityId"] = new SelectList(_context.Universities, "UniversityId", "Name", college.UniversityId);
            return View(college);
        }

        // GET: Colleges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var college = await _context.Colleges
                .Include(c => c.University)
                .FirstOrDefaultAsync(m => m.CollegeId == id);
            if (college == null)
            {
                return NotFound();
            }

            return View(college);
        }

        // POST: Colleges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var college = await _context.Colleges.FindAsync(id);
            _context.Colleges.Remove(college);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollegeExists(int id)
        {
            return _context.Colleges.Any(e => e.CollegeId == id);
        }
    }
}
