using System;
namespace MinuteMath.Models
{
    public enum ColorTheme
    {
        Red,
        Orange,
        Green,
        Blue,
        Purple
    }

    public class Color
    {
        public Color()
        {
        }
        //TODO add color selection here
        // TODO add color themes here
        //Call color methods from ViewModels.


        public ColorTheme ChooseBackgroundColor()
        {
            var colorValues = Enum.GetValues(typeof(ColorTheme));
            var random = new Random();
            var randomBackgroundColor = (ColorTheme)colorValues.GetValue(random.Next(colorValues.Length));
            //return randomBackgroundColor.ToString();
            return randomBackgroundColor;
        }
    }
}
