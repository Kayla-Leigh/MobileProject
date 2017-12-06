using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using static finalProject.Models.AdoptionModel;
using System.Runtime.CompilerServices;

namespace finalProject.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand NavToNewPageCommand { get; set; }
        public DelegateCommand GetAdoptionForLocationCommand { get; set; }
<<<<<<< HEAD
        public DelegateCommand<Pet> NavToMoreInfoPageCommand { get; set; }
=======
        public DelegateCommand<AdoptionItem> NavToMoreInfoPageCommand { get; set; }
        public DelegateCommand<AdoptionItem> DeleteCommand { get; set; }
>>>>>>> ba73ebc1f77fb4523feb99cf091766447d72fd06

        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _locationEnteredByUser;
        public string LocationEnteredByUser
        {
            get { return _locationEnteredByUser; }
            set { SetProperty(ref _locationEnteredByUser, value); }
        }

        private ObservableCollection<Pet> _adoptionCollection = new ObservableCollection<Pet>();
        public ObservableCollection<Pet> AdoptionCollection
        {
            get { return _adoptionCollection; }
            set { SetProperty(ref _adoptionCollection, value); }
        }

        INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavToNewPageCommand = new DelegateCommand(NavToNewPage);
            GetAdoptionForLocationCommand = new DelegateCommand(GetAdoptionForLocation);
<<<<<<< HEAD
            NavToMoreInfoPageCommand = new DelegateCommand<Pet>(NavToMoreInfoPage);
=======
            NavToMoreInfoPageCommand = new DelegateCommand<AdoptionItem>(NavToMoreInfoPage);
            DeleteCommand = new DelegateCommand<AdoptionItem>(DeleteView);
>>>>>>> ba73ebc1f77fb4523feb99cf091766447d72fd06

            Title = "Xamarin Forms Application + Prism";
            ButtonText = "Add Name";
        }

        private async void NavToMoreInfoPage(Pet adoptionItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("AdoptionItemInfo", adoptionItem);
            await _navigationService.NavigateAsync("MoreInfoPage", navParams);
        }

        private void DeleteView(AdoptionItem adoptionItem)
        {
            AdoptionCollection.RemoveAt(AdoptionCollection.IndexOf(adoptionItem));
        }

        internal async void GetAdoptionForLocation()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(
                string.Format(
                    $"http://api.petfinder.com/pet.find?key={ApiKeys.AdoptionKey}&location=" +
                    $"{LocationEnteredByUser}" + "&format=json"));
            var response = await client.GetAsync(uri);
            AdoptionItem adoptionData = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                adoptionData = AdoptionItem.FromJson(content);
                foreach(Pet pet in adoptionData.PetFinder.Pets.Pet) {
                    AdoptionCollection.Add(pet);
                }
            }
        }

        private async void NavToNewPage()
        {
            var navParams = new NavigationParameters();
            navParams.Add("NavFromPage", "MainPageViewModel");
            await _navigationService.NavigateAsync("AboutUs", navParams);

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}