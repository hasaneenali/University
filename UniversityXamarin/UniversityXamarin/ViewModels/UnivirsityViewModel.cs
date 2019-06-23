using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using UniversityXamarin.Models;
using UniversityXamarin.Services;
using Xamarin.Forms;

namespace UniversityXamarin.ViewModels
{
    public class UnivirsityViewModel : INotifyPropertyChanged
    {
       
        ApiService apiService;

        bool _isRefreshing;
        public event PropertyChangedEventHandler PropertyChanged;

        List<University> categories;

        ObservableCollection<University> _universities;

        public ObservableCollection<University> UniversitiesList
        {
            get
            {
                return _universities;
            }
            set
            {
                if (_universities != value)
                {
                    _universities = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(UniversitiesList)));
                }
            }
        }

        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                if (_isRefreshing != value)
                {
                    _isRefreshing = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsRefreshing)));
                }
            }
        }

        public UnivirsityViewModel()
        {
            apiService = new ApiService();
            LoadUniversities();

        }

        private async void LoadUniversities()
        {

            var response = await apiService.GetList<University>(
               "http://192.168.0.111:84",
                "/api",
                "/Universities");

          var universities = (List<University>)response.Result;
            UniversitiesList = new ObservableCollection<University>(universities);

        }
    }
}
