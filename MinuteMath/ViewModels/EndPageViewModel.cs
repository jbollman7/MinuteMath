using System.ComponentModel;
using MinuteMath.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MinuteMath.ViewModels
{
    public class EndPageViewModel : INotifyPropertyChanged
    {
        public EndPageViewModel()
        {
            LaunchGamePlayCommand = new Command(() =>
            {
                Application.Current.MainPage = new NavigationPage(new GamePlay());
            });
        }


        public Command LaunchGamePlayCommand { get; }


        public int HighScore
        {
            get => Preferences.Get(nameof(HighScore), 0);
            set
            {
                Preferences.Set(nameof(HighScore), value);
                var args = new PropertyChangedEventArgs(nameof(HighScore));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public int Score => Preferences.Get(nameof(Score), 0);

        public event PropertyChangedEventHandler PropertyChanged;
    }
}