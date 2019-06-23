using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UniversityCore.Entities;

namespace UniversityCore.Models
{
    public class StudentViewModel:Student
    {

        [Display(Name="Image")]

        public IFormFile ImageFile { get; set; }
    }
}
