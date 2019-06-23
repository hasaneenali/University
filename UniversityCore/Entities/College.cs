using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityCore.Entities
{
    public partial class College
    {
        public College()
        {
            Departments = new HashSet<Department>();
        }

        public int CollegeId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int UniversityId { get; set; }

        [NotMapped]
        public byte[] ImageArray { get; set; }

        //[JsonIgnore]
        public  University University { get; set; }
        [JsonIgnore]
        public  ICollection<Department> Departments { get; set; }
    }

}
