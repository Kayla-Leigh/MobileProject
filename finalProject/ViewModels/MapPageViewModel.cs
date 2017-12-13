using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms.Maps;
using static finalProject.Models.AdoptionModel;

using Xamarin.Forms;

namespace finalProject.ViewModels
{

    public class MapPageViewModel : BindableBase, INavigationAware
    {

        public Pet adoptionItem;
        public Geocoder geoCoder = new Geocoder();
        INavigationService _navigationService;
        public DelegateCommand GoBackCommand { get; set; }

        private Map _myMap;
        public Map myMap
        {
            get { return _myMap; }
            set { SetProperty(ref _myMap, value); }
        }

        private Position _myPosistion;
        public Position myPosistion {
            get { return _myPosistion; }
            set { SetProperty(ref _myPosistion, value); }
        }

        public MapPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;


            GoBackCommand = new DelegateCommand(GoBack);

           
        }

        public async void getGeoLoc() {
            var approximateLocations = await geoCoder.GetPositionsForAddressAsync(adoptionItem.Contact.City.CityLocation + ", " + adoptionItem.Contact.State.StateLocation);
            Device.BeginInvokeOnMainThread(() =>
            {

                foreach (var position in approximateLocations)
                {

                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label = "custom pin",
                        Address = "custom detail info"
                    };


                    myMap.Pins.Add(pin);
                    var newMapLocation = MapSpan.FromCenterAndRadius((position), Distance.FromMiles(1));
                    myMap.MoveToRegion(newMapLocation);
                }
            });


        }

        private void GoBack()
        {
            _navigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("AdoptionItemInfo"))
            {
                adoptionItem = (Pet)parameters["AdoptionItemInfo"];

            }

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("AdoptionItemInfo"))
            {
                adoptionItem = (Pet)parameters["AdoptionItemInfo"];

            }
        }


        public void OnNavigatingTo(NavigationParameters parameters)
        {

            if (parameters.ContainsKey("AdoptionItemInfo"))
            {
                adoptionItem = (Pet)parameters["AdoptionItemInfo"];
                getGeoLoc();
            }
        }
    }

}

