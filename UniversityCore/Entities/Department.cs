using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityCore.Entities
{
    public partial class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int UniversityId { get; set; }
        public int CollegeId { get; set; }

        public virtual College College { get; set; }
        public virtual University University { get; set; }
    }
}
