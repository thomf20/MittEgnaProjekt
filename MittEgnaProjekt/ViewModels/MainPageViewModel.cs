using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittEgnaProjekt.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        public MainPageViewModel()
        {
            NavigateToStartPage();
        }

        public void NavigateToStartPage()
        {
            var mainPage = new MainPage();
            mainPage.BindingContext = new MainPageViewModel();

            Application.Current.MainPage = new NavigationPage(mainPage);
        }
    }
}
