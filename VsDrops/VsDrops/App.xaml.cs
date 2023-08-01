using Microsoft.Maui.Controls;

namespace VsDrops
{
    internal partial class App : Application
    {
        public new App Current => (App)Application.Current;

        public App()
        {
            this.InitializeComponent();
        }
    }
}
