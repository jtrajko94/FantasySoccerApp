using FantasySoccerApp.Controls;
using FantasySoccerApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AnimationlessListView), typeof(AnimationlessListViewRenderer))]

namespace FantasySoccerApp.iOS.Renderers
{
    public class AnimationlessListViewRenderer : ListViewRenderer
    {
        public AnimationlessListViewRenderer()
        {
            AnimationsEnabled = false;
        }
    }
}
