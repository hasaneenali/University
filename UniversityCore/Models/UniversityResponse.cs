using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityCore.Models
{
    public class UniversityResponse
    {
        public int UniversityId { get; set; }


        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public List<CollegeResponse>  colleges { get; set; }
    }
}
