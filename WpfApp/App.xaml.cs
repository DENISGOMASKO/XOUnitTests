using Egor92.MvvmNavigation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using WpfApp.View.Pages;
using WpfApp.View.Windows;
using WpfApp.Constants;
using WpfApp.ViewModel;
using WpfLibrary.Contexts;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            ApplicationContext.MWindow = mainWindow;

            var navigationManager = new NavigationManager(mainWindow);
            navigationManager.Register<GamePage>(NavigationKeys.GamePage, () => new GamePageViewModel(navigationManager));
            navigationManager.Register<StartPage>(NavigationKeys.StartPage, () => new StartPageViewModel(navigationManager));
            navigationManager.Register<EndGamePage>(NavigationKeys.EndGamePage, () => new EndGamePageViewModel(navigationManager));

            mainWindow.Show();
            ApplicationContext.SetWindwoSize(600, 600);
            navigationManager.Navigate(NavigationKeys.StartPage, new StartPage());
        }
    }
}
