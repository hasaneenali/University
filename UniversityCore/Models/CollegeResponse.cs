using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityCore.Entities;

namespace UniversityCore.Models
{
    public class CollegeResponse
    {
        public int CollegeId { get; set; }

        public int UniversityId { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

       public  Entities.University University { get; set; }

        public List<DepartmentResponse> departments { get; set; }
    }
}
