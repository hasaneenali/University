

using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows.Input;
using UniversityXamarin.ViewModels;
using UniversityXamarin.Views;
using Xamarin.Forms;

namespace UniversityXamarin.Models
{
    public class University
    {
       
        public int UniversityId { get; set; }

       
        public string Name { get; set; }

       
        public string ImageUrl { get; set; }

        public  List<College> Colleges { get; set; }



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


        public ICommand SelectCategoryCommand
        {
            get
            {
                return new RelayCommand(SelectCategory);
            }
        }

        async void SelectCategory()
        {
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Colleges = new CollegesViewModel(Colleges);                                 
            await Application.Current.MainPage.Navigation.PushAsync(new Colleges());

        }

       

    }
}
