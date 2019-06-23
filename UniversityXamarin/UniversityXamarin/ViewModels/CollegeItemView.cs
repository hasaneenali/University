using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using UniversityXamarin.Models;
using UniversityXamarin.Services;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Plugin.Media;
using Plugin.Media.Abstractions;
using UniversityXamarin.Helpers;
using UniversityXamarin.Views;
using Xamarin.Forms;

namespace UniversityXamarin.ViewModels
{
    public  class CollegeItemView: College, INotifyPropertyChanged
    {
       
        private ApiService apiService;
        private MediaFile file;
        private ImageSource imageSource;

        public ImageSource ImageSource
        {

            set
            {
                if (imageSource != value)
                {
                    imageSource = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImageSource"));
                }
            }

            get { return imageSource; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<UnivirsityItemViewModel> Departments { get; set; }


        public CollegeItemView()
        {
            Departments = new ObservableCollection<UnivirsityItemViewModel>();
            apiService=new ApiService();
           
           ImageSource = "noimage";
            LoadDepartments();
        }

        private async void LoadDepartments()
        {
            var departments = new List<University>();
            departments = await apiService.Get<University>("Universities");
            ReloadDeparments(departments);
        }

        private void ReloadDeparments(List<University> departments)
        {
            Departments.Clear();

            foreach (var department in departments.OrderBy(d => d.Name))
            {
                Departments.Add(new UnivirsityItemViewModel()
                {
                    Name = department.Name,
                    UniversityId = department.UniversityId
                });
            }
        }


        public ICommand NewCustomerCommand
        {
            get { return new RelayCommand(NewCustomer); }
        }

        private async void NewCustomer()
        {
            

            if (string.IsNullOrEmpty(Name))
            {
               
                await App.Current.MainPage.DisplayAlert("ادخل الرقم", "الادخال خطا", "نعم");
                return;
            }

          

            if (UniversityId == 0)
            {
                await App.Current.MainPage.DisplayAlert("ادخل الرقم", "الادخال خطا", "نعم");
                return;
               
            }




            byte[] imageArray = null;
            if (this.file != null)
            {
                imageArray = FilesHelper.ReadFully(this.file.GetStream());
            }


            var customer = new College
            {
               
                ImageArray = imageArray,
                Name = Name,
                UniversityId = UniversityId,


            };

            var response = await apiService.NewCustomer(customer);
            await App.Current.MainPage.DisplayAlert("تمت الاضافه بنجاح", "الادخال ", "نعم");
            await Application.Current.MainPage.Navigation.PushAsync(new Colleges());




        }


        public ICommand ChangeImageCommand => new RelayCommand(this.ChangeImage);

        private async void ChangeImage()
        {
            await CrossMedia.Current.Initialize();

            var source = await Application.Current.MainPage.DisplayActionSheet(
                "Where do you take the picture?",
                "Cancel",
                null,
                "From Gallery",
                "From Camera");

            if (source == "Cancel")
            {
                this.file = null;
                return;
            }

            if (source == "From Camera")
            {
                this.file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Pictures",
                        Name = "test.jpg",
                        PhotoSize = PhotoSize.Small,
                    }
                );
            }
            else
            {
                this.file = await CrossMedia.Current.PickPhotoAsync();
            }

            if (this.file != null)
            {
                this.ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
        }

    }
}
