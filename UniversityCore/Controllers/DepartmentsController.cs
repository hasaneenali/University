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
    public class DepartmentsController : Controller
    {
        private readonly DataContext _context;

        public DepartmentsController(DataContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Departments.Include(d => d.College).Include(d => d.University);
            return View(await dataContext.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.College)
                .Include(d => d.University)
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "CollegeId", "Name");
            ViewData["UniversityId"] = new SelectList(_context.Universities, "UniversityId", "Name");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;
                if (departmentViewModel.ImageFile != null && departmentViewModel.ImageFile.Length > 0)
                {

                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";


                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Department", file);



                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await departmentViewModel.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Department/{file}";
                }

                var department = this.todepartment(departmentViewModel, path);
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "CollegeId", "Name", departmentViewModel.CollegeId);
            ViewData["UniversityId"] = new SelectList(_context.Universities, "UniversityId", "Name", departmentViewModel.UniversityId);
            return View(departmentViewModel);
        }

        private Department todepartment(DepartmentViewModel departmentViewModel, string path)
        {
            return new Department()
            {
                DepartmentId = departmentViewModel.DepartmentId,
                CollegeId = departmentViewModel.CollegeId,
                UniversityId= departmentViewModel.UniversityId,
                ImageUrl = path,
                Name = departmentViewModel.Name,
                University = departmentViewModel.University,
                College= departmentViewModel.College,

            };
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "CollegeId", "Name", department.CollegeId);
            ViewData["UniversityId"] = new SelectList(_context.Universities, "UniversityId", "Name", department.UniversityId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,Name,ImageUrl,UniversityId,CollegeId")] Department department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.DepartmentId))
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
            ViewData["CollegeId"] = new SelectList(_context.Colleges, "CollegeId", "Name", department.CollegeId);
            ViewData["UniversityId"] = new SelectList(_context.Universities, "UniversityId", "Name", department.UniversityId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.College)
                .Include(d => d.University)
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }
    }
}
