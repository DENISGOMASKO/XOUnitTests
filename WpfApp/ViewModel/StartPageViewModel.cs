using Egor92.MvvmNavigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Constants;

using WpfApp.Core;
using WpfApp.View.Pages;
using WpfLibrary.Contexts;
using WpfLibrary.Core;

namespace WpfApp.ViewModel
{
    internal class StartPageViewModel : BaseViewModel
    {
        private static NavigationManager _navigationManager;
        public StartPageViewModel(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        private void startGame(PlayingFieldStatus playingFieldStatus)
        {
            ApplicationContext.ChangedXO = playingFieldStatus;
            ApplicationContext.SetWindwoSize(800, 600);
            _navigationManager.Navigate(NavigationKeys.GamePage, new GamePage());
        }

        public ActionCommand StartGameAsX
        {
            get
            {
                return new ActionCommand(() =>
                {
                    startGame(PlayingFieldStatus.X);
                });
            }
        }
        public ActionCommand StartGameAsO
        {
            get
            {
                return new ActionCommand(() =>
                {
                    startGame(PlayingFieldStatus.O);
                });
            }
        }
    }
}
