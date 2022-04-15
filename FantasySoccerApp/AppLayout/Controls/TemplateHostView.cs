using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FantasySoccerApp.AppLayout.Controls
{
    [Preserve(AllMembers = true)]
    public class TemplateHostView : View
    {
        public Page Template { get; set; }
    }
}

