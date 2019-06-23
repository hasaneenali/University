using System.Threading.Tasks;
using Xamarin.Forms;

namespace UniversityXamarin.Services
{
   public class DialogService
    {

        public async Task<string> ShowImageOptions()
        {
            return await Application.Current.MainPage.DisplayActionSheet(
                "هل تريد اظهار الصور?",
                "الغاء",
                null,
                "من معرض الصور",
                "من الكاميرا");
        }
    }
}

