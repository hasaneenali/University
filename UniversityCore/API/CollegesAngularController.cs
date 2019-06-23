using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityCore.Entities;
using UniversityCore.Models;
using System.Linq;

namespace UniversityCore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegesAngularController : ControllerBase
    {
        private readonly DataContext _context;

        public CollegesAngularController(DataContext context)
        {
            _context = context;
        }

        

        [HttpPost]
        public async Task<ActionResult<College>> PostCollege(College college)
        {

            _context.Colleges.Add(college);
            await _context.SaveChangesAsync();
            return Ok();


        }


        
    }
}