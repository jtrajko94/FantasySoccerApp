using FantasySoccerApp.AppLayout.Models;
using FantasySoccerApp.AppLayout.Views;
using FantasySoccerApp.ViewModels.Teams;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FantasySoccerApp.Views.Teams
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutView
    {
        private AboutViewModel ViewModel
        {
            get { return (AboutViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        public AboutView()
        {
            InitializeComponent();

            ViewModel = new AboutViewModel();
            BindingContext = ViewModel;
        }

        private async void competition_ItemTapped(System.Object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            Template template = new Template();
            template.Name = "League";
            template.PageName = "Views.Leagues.LeaguePage";
            await Application.Current.MainPage.Navigation.PushAsync(new TemplateHostPage(template));
        }
    }
}