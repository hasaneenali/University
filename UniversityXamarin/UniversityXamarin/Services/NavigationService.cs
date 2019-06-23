using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityXamarin.Views;

namespace UniversityXamarin.Services
{
  public  class NavigationService
    {

        public async  Task NavigateOnMaster( string pageName)
        {
           

            switch (pageName)
            {
                case "CollegesView":
                    await App.Navigator.PushAsync(
                        new Colleges());
                    break;
            }
        }
    }
}
