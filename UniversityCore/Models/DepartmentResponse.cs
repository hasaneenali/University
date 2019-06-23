using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityCore.Entities;

namespace UniversityCore.Models
{
    public class DepartmentResponse
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int UniversityId { get; set; }
        public int CollegeId { get; set; }

       
    }
}
