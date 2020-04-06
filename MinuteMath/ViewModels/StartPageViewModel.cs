using System;
using MinuteMath.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using MinuteMath.Pages;
using System.Windows.Input;

namespace MinuteMath.ViewModels
{
    public class StartPageViewModel
    {
        public StartPageViewModel()
        {
          
            
            LaunchGamePlayCommand = new Command(() =>
            {
                
                App.Current.MainPage = new NavigationPage(new GamePlay());
            });
            
        }

        public ICommand LaunchGamePlayCommand { get; }



    }
}
