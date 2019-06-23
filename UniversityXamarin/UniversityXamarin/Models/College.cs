using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using UniversityXamarin.Views;
using Xamarin.Forms;

namespace UniversityXamarin.Models
{
   public class College
    {
        public int CollegeId { get; set; }
        public string Name { get; set; }
        
        public string ImageUrl { get; set; }
        public int UniversityId { get; set; }

        public University University { get; set; }

        public byte[] ImageArray { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImageUrl))
                {
                    return "noimage";
                }

                return string.Format(
                    "http://192.168.0.111:84/{0}",
                    ImageUrl.Substring(1));
            }
        }


       
    }
}
