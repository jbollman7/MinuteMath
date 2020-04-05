using System;
using MinuteMath.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinuteMath
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new GamePlay();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
