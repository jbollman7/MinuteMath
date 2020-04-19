using System.ComponentModel;
using System.Windows.Input;
using MinuteMath.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MinuteMath.ViewModels
{
    public class EndPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        
        
      
        public Command LaunchGamePlayCommand { get; }

        public EndPageViewModel()
        {

            LaunchGamePlayCommand = new Command(() =>
            {
                App.Current.MainPage = new NavigationPage(new GamePlay());
            });
        }


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
        public int Score
        {
            get => Preferences.Get(nameof(Score), 0);
        }

    }
}
    
    
