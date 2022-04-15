using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FantasySoccerApp.Views.Navigation
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BottomNavigationPage : TabbedPage
    {
        public BottomNavigationPage()
        {
            InitializeComponent();
        }
    }
}
