using System;
using System.ComponentModel;
using System.Windows.Input;
using MinuteMath.Pages;
using Xamarin.Forms;

namespace MinuteMath.ViewModels
{
    public enum GetColor
    {
        Aqua,
        Aquamarine,
        Blue,
        MediumSlateBlue,
        LightCoral,
        Coral,
        CornflowerBlue,
        Crimson,
        Gold,
        Green,
        Orange,
        Pink,
        Plum,
        Red,
        Violet
    }

    public class StartPageViewModel : INotifyPropertyChanged
    {
        private string _colorChoice;

        public StartPageViewModel()
        {
            //myColorChooser();
            ColorChoice = ChooseBackgroundColor();
            LaunchGamePlayCommand = new Command(() =>
            {
                Application.Current.MainPage = new NavigationPage(new GamePlay());
            });
        }

        public ICommand LaunchGamePlayCommand { get; }

        public string ColorChoice
        {
            get => _colorChoice;
            set
            {
                _colorChoice = value;
                var args = new PropertyChangedEventArgs(nameof(ColorChoice));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ChooseBackgroundColor()
        {
            var colorValues = Enum.GetValues(typeof(GetColor));
            var random = new Random();
            var randomBackgroundColor = (GetColor) colorValues.GetValue(random.Next(colorValues.Length));
            return randomBackgroundColor.ToString();
        }
    }
}