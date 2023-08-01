using Microsoft.Maui.Controls;
using System;

namespace VsDrops
{
    internal partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnLoaded(object sender, EventArgs args)
        {
            this.Window.Title = this.Title;
        }
    }
}
