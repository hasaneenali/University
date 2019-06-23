using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityCore.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="الرجاء عدم ادخل اقل من 50 حرف")]
        public string Name { get; set; }


        [Display(Name="AgeStudent")]
        public int Age { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }

    }
}
