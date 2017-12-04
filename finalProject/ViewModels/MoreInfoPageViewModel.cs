using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms.Xaml;
using static finalProject.Models.AdoptionModel;

namespace Week9PrismExampleApp.ViewModels
{
    public class MoreInfoPageViewModel : BindableBase, INavigatedAware
    {
        INavigationService _navigationService;

        public DelegateCommand GoBackCommand { get; set; }

        private AdoptionItem _adoptionItem;
        public AdoptionItem AdoptionItem
        {
            get { return _adoptionItem; }
            set { SetProperty(ref _adoptionItem, value); }
        }

        public MoreInfoPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoBackCommand = new DelegateCommand(GoBack);
        }

        private void GoBack()
        {
            _navigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("AdoptionItemInfo"))
            {
                AdoptionItem = (AdoptionItem)parameters["AdoptionItemInfo"];
            }
        }
    }
}