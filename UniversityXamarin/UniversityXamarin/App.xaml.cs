using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UniversityXamarin.Views;
using UniversityXamarin.Services;

namespace UniversityXamarin
{
    public partial class App : Application
    {
        NavigationService navigationService;
        ApiService apiService;
        public static NavigationPage Navigator
        {
            get;
            internal set;
        }
       

        public App()
        {
            InitializeComponent();
            
            //MainPage = new AppShell();
            MainPage = new NavigationPage(new SearchColleges());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
