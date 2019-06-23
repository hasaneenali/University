

namespace UniversityCore.Entities
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    public partial class University
    {
        public University()
        {
            Colleges = new HashSet<College>();
            Departments = new HashSet<Department>();
        }

        public int UniversityId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }



        [JsonIgnore]
        public ICollection<College> Colleges { get; set; }
        [JsonIgnore]
        public virtual ICollection<Department> Departments { get; set; }

    }
}
