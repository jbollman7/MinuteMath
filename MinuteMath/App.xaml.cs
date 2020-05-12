using MinuteMath.Pages;
using Xamarin.Forms;

namespace MinuteMath
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new StartPage();
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