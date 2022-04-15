using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FantasySoccerApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
    }
}
