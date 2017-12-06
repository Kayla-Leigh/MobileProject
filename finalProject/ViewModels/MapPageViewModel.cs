using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms.Xaml;
using static finalProject.Models.AdoptionModel;
using Xamarin.Forms;

namespace finalProject.ViewModels
{
    public class MapPageViewModel : ContentPage
    {
        public MapPageViewModel()
        {
            InitializeComponent();

            var initialMapLocation = MapSpan.FromCenterAndRadius
                                            (new Position(33.1307785, -117.1601826)
                                             , Distance.FromMiles(1));

            MySampleMap.MoveToRegion(initialMapLocation);


            PlaceAMarker();
        }

        private void PlaceAMarker()
        {
            var position = new Position(33.1307785, -117.1601826); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "custom pin",
                Address = "custom detail info"
            };

            MySampleMap.Pins.Add(pin);
        }
    }
}

