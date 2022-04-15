using FantasySoccerApp.ViewModels.Fixtures;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FantasySoccerApp.Views.Fixtures
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OddsView
    {
        private OddsViewModel ViewModel
        {
            get { return (OddsViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OddsView" /> class.
        /// </summary>
        public OddsView()
        {
            InitializeComponent();

            ViewModel = new OddsViewModel();
            BindingContext = ViewModel;
        }
    }
}
