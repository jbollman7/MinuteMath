using System.ComponentModel;
using Xamarin.Essentials;

namespace MinuteMath.ViewModels
{
    public class EndPageViewModel : INotifyPropertyChanged
    {
                
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
    
    
