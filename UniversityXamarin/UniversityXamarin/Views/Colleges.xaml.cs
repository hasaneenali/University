using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversityXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Colleges : ContentPage
    {
        public Colleges()
        {
            InitializeComponent();
        }

        

        private async void Item2_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchColleges());
        }

        private async void Item1_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddColleges());
        }
    }
}