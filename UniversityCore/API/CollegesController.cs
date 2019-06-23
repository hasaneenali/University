using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using University.Helpers;
using UniversityCore.Entities;
using UniversityCore.Models;

namespace UniversityCore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegesController : ControllerBase
    {
        private readonly DataContext _context;
        //private readonly ICollegeRepository _repo;
        //private readonly IMapper _mapper;

        public CollegesController(DataContext context)
        {
            //_repo = repo;
            //_mapper = mapper;
            _context = context;
        }

        // GET: api/Colleges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<College>>> GetColleges()
        {
            var Colleges = await _context.Colleges.Include(u => u.University).Include(d => d.Departments).ToListAsync();
            var collegeResponse = new List<CollegeResponse>();

            foreach (var collge in Colleges)
            {
                var departmentResponse = new List<DepartmentResponse>();
                foreach (var depatemnt in collge.Departments)
                {
                    departmentResponse.Add(new DepartmentResponse
                    {
                        UniversityId = depatemnt.UniversityId,
                        DepartmentId = depatemnt.DepartmentId,
                        Name = depatemnt.Name,
                        ImageUrl = depatemnt.ImageUrl,
                        CollegeId = depatemnt.CollegeId,

                    });
                }

                collegeResponse.Add(new CollegeResponse
                {
                    UniversityId = collge.UniversityId,
                    ImageUrl = collge.ImageUrl,
                    CollegeId = collge.CollegeId,
                    University=collge.University,
                    Name = collge.Name,
                    departments = departmentResponse,

                });
            }

            return Ok(collegeResponse);
        }

        // GET: api/Colleges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<College>> GetCollege(int id)
        {
            var college = await _context.Colleges.FindAsync(id);

            if (college == null)
            {
                return NotFound();
            }

            return college;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<College>>> GetColleges2()
        //{
        //    var college=  await _context.Colleges.Include(u=>u.University).ToListAsync();
        //    return college;
        //}

        // PUT: api/Colleges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollege(int id, College college)
        {
            if (id != college.CollegeId)
            {
                return BadRequest();
            }

            _context.Entry(college).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // POST: api/Colleges
        [HttpPost]
        public async Task<ActionResult<College>> PostCollege(College college)
        {
            var imageUrl = string.Empty;
            if (college.ImageArray != null && college.ImageArray.Length > 0)
            {
                var stream = new MemoryStream(college.ImageArray);
                var guid = Guid.NewGuid().ToString();
                var file = $"{guid}.jpg";
                var folder = "wwwroot\\images\\College";
                var fullPath = $"~/images/College/{file}";
                var response = FilesHelper.UploadPhoto(stream, folder, file);

                if (response)
                {
                  imageUrl = fullPath;
                }
            }
            var entityProduct = new College
            {
                Name =college.Name,
                UniversityId = college.UniversityId,
                ImageUrl =imageUrl, 
            };
            
           _context.Colleges.Add(entityProduct);
            await _context.SaveChangesAsync();

           return CreatedAtAction("GetCollege", new { id = college.CollegeId }, college);
        }

        // DELETE: api/Colleges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<College>> DeleteCollege(int id)
        {
            var college = await _context.Colleges.FindAsync(id);
            if (college == null)
            {
                return NotFound();
            }

            _context.Colleges.Remove(college);
            await _context.SaveChangesAsync();

            return college;
        }

        private bool CollegeExists(int id)
        {
            return _context.Colleges.Any(e => e.CollegeId == id);
        }

        [HttpGet]
        [Route("Search/{SearchName}")]
        public IActionResult Search(string SearchName)
        {
            var result = _context.Colleges.Include(u=>u.University).Where(a => a.Name.Contains(SearchName));
            return Ok(result);
        }


    }
}
