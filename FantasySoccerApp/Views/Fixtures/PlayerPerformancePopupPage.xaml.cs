using System;
using FantasySoccerApp.ViewModels.Fixtures;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Xaml;

namespace FantasySoccerApp.Views.Fixtures
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPerformancePopupPage
    {
        private PlayerStatisticsViewModel ViewModel
        {
            get { return (PlayerStatisticsViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        public PlayerPerformancePopupPage()
        {
            InitializeComponent();

            ViewModel = new PlayerStatisticsViewModel();
            BindingContext = ViewModel;
        }
    }
}
