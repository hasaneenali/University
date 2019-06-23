using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UniversityXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversityXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchColleges : ContentPage
    {
        public SearchColleges()
        {
            InitializeComponent();
          GetColleges();
        }

        private async void GetColleges()
        {
           HttpClient client=new HttpClient();
           var response = await client.GetStringAsync("http://192.168.0.111:84/api/Colleges");
           var products = JsonConvert.DeserializeObject<List<College>>(response);
           ListViewColleges.ItemsSource = products;
        }

       

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://192.168.0.111:84/api/Colleges/Search/"+EntrySearch.Text);
            var products = JsonConvert.DeserializeObject<List<College>>(response);
            ListViewColleges.ItemsSource = products;

        }
    }
}