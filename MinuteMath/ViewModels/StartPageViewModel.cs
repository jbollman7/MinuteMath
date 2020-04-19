using Xamarin.Forms;
using MinuteMath.Pages;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MinuteMath.ViewModels
{
    public enum GetColor
    {
        Red,
        Orange,
        Gold,
        Blue,
        Green,
        Violet,
        Pink,
        Plum
    }
    public class StartPageViewModel : INotifyPropertyChanged
    {
        public StartPageViewModel()
        {
           
            //myColorChooser();
            ColorChoice = ChooseBackgroundColor();
             LaunchGamePlayCommand = new Command(() =>
            {
                App.Current.MainPage = new NavigationPage(new GamePlay());
            });
            
        }

        public ICommand LaunchGamePlayCommand { get; }

        /*
        public GetColor ChooseBackgroundColor()
        {
            var colorValues = Enum.GetValues(typeof(GetColor));
            var random = new Random();
            var randomBackgroundColor = (GetColor)colorValues.GetValue(random.Next(colorValues.Length));
            return randomBackgroundColor;
        }
        */
        public string ChooseBackgroundColor()
        {
            var colorValues = Enum.GetValues(typeof(GetColor));
            var random = new Random();
            var randomBackgroundColor = (GetColor)colorValues.GetValue(random.Next(colorValues.Length));
            return randomBackgroundColor.ToString();
        }
        
        private string _colorChoice;

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


        /*(
        public void myColorChooser()
         {
             var rndColor = ChooseBackgroundColor();
            switch (rndColor)
            {
                case GetColor.Red:
                    ColorChoice = "Red";
                    break;
                case GetColor.Orange:
                    ColorChoice = "Orange";
                    break;
                case GetColor.Gold:
                    ColorChoice = "Gold";
                    break;
                case GetColor.Green:
                    ColorChoice = "Green";
                    break;
                case GetColor.Blue:
                    ColorChoice = "Blue";
                    break;
                case GetColor.Violet:
                    ColorChoice = "Violet";
                    break;

            } //switch

        } //method
*/

    }
}
