using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace finalProject.Views
{
    public partial class AboutUs : ContentPage
    {
        public AboutUs()
        {
            InitializeComponent();

        }



        void NightModeToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            Page.BackgroundColor = Color.LightSlateGray;
        }

        void DayModeToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            Page.BackgroundColor = Color.White;
        }
    }
}
