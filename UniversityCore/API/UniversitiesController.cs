using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityCore.Models;



namespace UniversityCore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public UniversitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Universities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entities.University>>> GetUniversities()
        {
            var Universities = await _context.Universities.Include(g => g.Colleges).ToListAsync();
            var universitiesResponse = new List<UniversityResponse>();

            foreach (var university in Universities)
            {
                var collegeResponse = new List<CollegeResponse>();
                foreach (var college in university.Colleges)
                {
                    collegeResponse.Add(new CollegeResponse
                    {
                        Name = college.Name,
                        ImageUrl = college.ImageUrl,
                        UniversityId = college.UniversityId,
                        CollegeId = college.CollegeId,

                    });
                }

                universitiesResponse.Add(new UniversityResponse
                {
                    UniversityId = university.UniversityId,
                    ImageUrl = university.ImageUrl,
                    Name = university.Name,
                    colleges = collegeResponse,

                });
            }

            return Ok(universitiesResponse);

        }

        // GET: api/Universities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entities.University>> GetUniversity(int id)
        {
            var university = await _context.Universities.FindAsync(id);

            if (university == null)
            {
                return NotFound();
            }

            return university;
        }

        // PUT: api/Universities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversity(int id, Entities.University university)
        {
            if (id != university.UniversityId)
            {
                return BadRequest();
            }

            _context.Entry(university).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityExists(id))
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

        // POST: api/Universities
        [HttpPost]
        public async Task<ActionResult<Entities.University>> PostUniversity(Entities.University university)
        {
            _context.Universities.Add(university);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUniversity", new { id = university.UniversityId }, university);
        }

        // DELETE: api/Universities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entities.University>> DeleteUniversity(int id)
        {
            var university = await _context.Universities.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }

            _context.Universities.Remove(university);
            await _context.SaveChangesAsync();

            return university;
        }

        private bool UniversityExists(int id)
        {
            return _context.Universities.Any(e => e.UniversityId == id);
        }
    }
}
