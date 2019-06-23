using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityCore.Entities
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }


        [Required]
        [MaxLength(20,ErrorMessage ="20 حرف")]

        public string FirstArticle { get; set; }
        public int Firstdegree { get; set; }

        public string SecondeArticle { get; set; }
        public int SecondeDegree { get; set; }

        public string ThirdArticle { get; set; }

        public int ThirdDegree { get; set; }

        public string FourArticle { get; set; }
        public int FourDegree { get; set; }


       
        public decimal Avarge { get; set; }

        public int StudentId { get; set; }
        public virtual Student student { get; set; }

    }
}
