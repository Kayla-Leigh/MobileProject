using System;

using Xamarin.Forms;

namespace finalProject
{
    public class Models : ContentPage
    {
        public Models()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

