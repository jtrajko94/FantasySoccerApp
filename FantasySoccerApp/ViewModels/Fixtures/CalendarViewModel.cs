using System;
using System.Windows.Input;
using FantasySoccerApp.AppLayout.Models;
using FantasySoccerApp.AppLayout.Views;
using FantasySoccerApp.Views.Fixtures;
using Syncfusion.SfCalendar.XForms;
using Xamarin.Forms;

namespace FantasySoccerApp.ViewModels.Fixtures
{
    public class CalendarViewModel : BaseViewModel
    {
        public DateTime MinDate { get; set; } = DateTime.Now.AddYears(-10);
        public DateTime MaxDate { get; set; } = DateTime.Now.AddYears(1);

        private string commandText;

        public string CommandText
        {
            get { return commandText; }
            set { commandText = value; }
        }

        public ICommand CalendarCellTapped { get; set; }

        public CalendarViewModel()
        {
            CalendarCellTapped = new Command<CalendarTappedEventArgs>(CellTapped);
        }

        private async void CellTapped(CalendarTappedEventArgs obj)
        {
            var date = obj.DateTime.ToString("dd/MM/yyyy");

            await Application.Current.MainPage.Navigation.PushAsync(new FixturesPage());
        }
    }
}
