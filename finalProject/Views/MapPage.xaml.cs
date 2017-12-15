using System;
using System.Collections.Generic;
using finalProject.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace finalProject.Views

{

    public partial class MapPage : ContentPage
    {


        public MapPage()
        {
            InitializeComponent();



            ((MapPageViewModel)this.BindingContext).myMap = myMap;

        }




    }
}
