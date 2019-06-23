using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityCore.Entities;
using UniversityCore.Models;

namespace UniversityCore.Controllers
{
    public class UniversitiesController : Controller
    {
        private readonly DataContext _context;

        public UniversitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: Universities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Universities.ToListAsync());
        }

        // GET: Universities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await _context.Universities
                .FirstOrDefaultAsync(m => m.UniversityId == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // GET: Universities/Create
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UniversityViewModel universityViewModel)
        {
            if (ModelState.IsValid)
            {
                string path = string.Empty;
                if (universityViewModel.ImageFile != null && universityViewModel.ImageFile.Length > 0)
                {
                   
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\University", file);


                   
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await universityViewModel.ImageFile.CopyToAsync(stream);
                    }

                   
                    path = $"~/images/University/{file}";
                }

                var university = this.toUniversity(universityViewModel, path);

                _context.Add(university);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(universityViewModel);
        }

        private Entities.University toUniversity(UniversityViewModel universityViewModel, string path)
        {
            return new Entities.University()
            {
                UniversityId = universityViewModel.UniversityId,
                Name = universityViewModel.Name,
                ImageUrl = path
            };
        }

        // GET: Universities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await _context.Universities.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }

            var universityViewModel = this.ToUniversityViewModel(university);

            return View(universityViewModel);
            //return View(university);
        }

        private UniversityViewModel ToUniversityViewModel(Entities.University university)
        {
            return new UniversityViewModel()
            {
                UniversityId = university.UniversityId,
                Name=university.Name,
                ImageUrl=university.ImageUrl,
            };
        }

        // POST: Universities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UniversityViewModel universityViewModel)
        {
            if (id != universityViewModel.UniversityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var path = universityViewModel.ImageUrl;

                    if (universityViewModel.ImageFile != null && universityViewModel.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";

                        path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\University", file);


                        using (var stream = new FileStream(path, FileMode.Create))
                        {

                            await universityViewModel.ImageFile.CopyToAsync(stream);

                        }

                        path = $"~/images/University/{file}";

                    }

                    var university = this.toUniversity(universityViewModel, path);
                    _context.Update(university);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityExists(universityViewModel.UniversityId))
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
            return View(universityViewModel);
        }

        // GET: Universities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await _context.Universities
                .FirstOrDefaultAsync(m => m.UniversityId == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // POST: Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var university = await _context.Universities.FindAsync(id);
            _context.Universities.Remove(university);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversityExists(int id)
        {
            return _context.Universities.Any(e => e.UniversityId == id);
        }

       
    }
}
