using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using UniversityXamarin.Models;
using UniversityXamarin.Services;
using System.Linq;

namespace UniversityXamarin.ViewModels
{
   public class CollegesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

          List<College> colleges;
        ObservableCollection<College> _colleges;
       

        public ObservableCollection<College> CollegesList
        {
            get
            {
                return _colleges;
            }
            set
            {
                if (_colleges != value)
                {
                    _colleges = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(CollegesList)));
                }
            }
        }

        public CollegesViewModel(List<College> colleges)
        {
           
            this.colleges = colleges;
            CollegesList = new ObservableCollection<College>(colleges.OrderBy(n=>n.Name));

            
        }

       

       



    }
}
