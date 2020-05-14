using MinuteMath.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MinuteMath.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePlay : ContentPage
    {
        public GamePlay()
        {
            InitializeComponent();
            BindingContext = new GameLogicViewModel();
        }
    }
}