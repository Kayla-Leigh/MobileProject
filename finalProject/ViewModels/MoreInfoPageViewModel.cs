﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms.Xaml;

using static finalProject.Models.AdoptionModel;

namespace finalProject.ViewModels
{
    public class MoreInfoPageViewModel : BindableBase, INavigatedAware
    {
        INavigationService _navigationService;

        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand NavToMapPageCommand { get; set; }
        public DelegateCommand NavToContactPageCommand { get; set; }

        private Pet _adoptionItem;
        public Pet adoptionItem
        {
            get { return _adoptionItem; }
            set { SetProperty(ref _adoptionItem, value); }
        }

        public MoreInfoPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoBackCommand = new DelegateCommand(GoBack);
            NavToMapPageCommand = new DelegateCommand(NavToMapPage);
            NavToContactPageCommand = new DelegateCommand(NavToContactPage);

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


        private async void NavToMapPage()
        {
            var navParams = new NavigationParameters();
            navParams.Add("NavFromPage", "MoreInfoPageViewModel");
            navParams.Add("AdoptionItemInfo", adoptionItem);
            await _navigationService.NavigateAsync("MapPage", navParams);



        }

        private async void NavToContactPage()
        {
            var navParams = new NavigationParameters();
            navParams.Add("NavFromPage", "MoreInfoPageViewModel");
            navParams.Add("AdoptionItemInfo", adoptionItem);
            await _navigationService.NavigateAsync("ContactPage", navParams);



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
        }
    }
}