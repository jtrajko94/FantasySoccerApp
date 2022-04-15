using Android.Content;
using FantasySoccerApp.Controls;
using FantasySoccerApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AnimationlessListView), typeof(AnimationlessListViewRenderer))]

namespace FantasySoccerApp.Droid.Renderers
{
    public class AnimationlessListViewRenderer : ListViewRenderer
    {
        public AnimationlessListViewRenderer(Context context) : base(context)
        {
            var animationlessListView = Element as AnimationlessListView;
            if (animationlessListView == null)
            {
                return;
            }
        }
    }
}
