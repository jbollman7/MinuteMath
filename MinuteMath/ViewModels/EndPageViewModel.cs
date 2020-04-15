using System.ComponentModel;
using Xamarin.Essentials;

namespace MinuteMath.ViewModels
{
    public class EndPageViewModel : INotifyPropertyChanged
    {
        
        private readonly int _score;

        public EndPageViewModel(int score)
        {
            this._score = score;
        }

        public void CompareScores()
        {
            if (_score > HighScore)
                HighScore = _score;
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
    
    
