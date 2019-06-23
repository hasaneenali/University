using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using UniversityCore.Entities;

namespace UniversityCore.Models
{
    public class CollegeViewModel:College
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
