using Egor92.MvvmNavigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp.Constants;

using WpfApp.Core;
using WpfApp.View.Pages;
using WpfLibrary.Contexts;

namespace WpfApp.ViewModel
{
    internal class EndGamePageViewModel : BaseViewModel
    {
        private NavigationManager _navigationManager;
        public EndGamePageViewModel(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            closePageAfterTime();
        }
        private async void closePageAfterTime()
        {
            await Task.Run(asyncSleep3Sec);
            ApplicationContext.SetWindwoSize(600, 600);
            _navigationManager.Navigate(NavigationKeys.StartPage, new StartPage());
        }
        private async Task asyncSleep3Sec()
        {
            Thread.Sleep(3000);  
        }

        public string WinnerText
        {
            get { return ApplicationContext.WinnerText; }
        }
    }
}
