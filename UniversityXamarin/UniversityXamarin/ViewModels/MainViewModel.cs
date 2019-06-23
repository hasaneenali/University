using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using UniversityXamarin.Models;
using UniversityXamarin.Services;
using Xamarin.Forms;

namespace UniversityXamarin.ViewModels
{
    public class MainViewModel
    {
        public UnivirsityViewModel Universities
        {
            get;
            set;
        }

        public CollegeItemView NewCustomer { get; set; }



        public CollegesViewModel Colleges { get; set; }

        #region Sigleton
        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion

      
        public MainViewModel()
        {
            Universities = new UnivirsityViewModel();
            NewCustomer = new CollegeItemView();
            instance = this;
        }
        
    }
}
