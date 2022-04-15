using FantasySoccerApp.AppLayout;
using Foundation;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.SfCalendar.XForms.iOS;
using Syncfusion.SfChart.XForms.iOS.Renderers;
using Syncfusion.XForms.iOS.Border;
using Syncfusion.XForms.iOS.Buttons;
using Syncfusion.XForms.iOS.ComboBox;
using Syncfusion.XForms.iOS.Core;
using Syncfusion.XForms.iOS.Graphics;
using Syncfusion.XForms.iOS.TabView;
using UIKit;
using Xamarin.Forms;

namespace FantasySoccerApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Rg.Plugins.Popup.Popup.Init();
            Forms.SetFlags("CollectionView_Experimental");
            new SfComboBoxRenderer();
            global::Xamarin.Forms.Forms.Init();
            this.LoadApplication(new App());
            SfButtonRenderer.Init();
            SfCheckBoxRenderer.Init();
            SfBorderRenderer.Init();
            SfCalendarRenderer.Init();
            SfChartRenderer.Init();
            SfGradientViewRenderer.Init();
            SfComboBoxRenderer.Init();
            SfRadioButtonRenderer.Init();
            SfSegmentedControlRenderer.Init();
            SfComboBoxRenderer.Init();
            SfTabViewRenderer.Init();
            SfListViewRenderer.Init();

            Core.Init();
            var result = base.FinishedLaunching(app, options);

            var safeAreInset = UIApplication.SharedApplication.KeyWindow.SafeAreaInsets;

            if (safeAreInset.Top > 0)
            {
                AppSettings.Instance.IsSafeAreaEnabled = true;
                AppSettings.Instance.SafeAreaHeight = safeAreInset.Top;
            }

            return result;
        }
    }
}
