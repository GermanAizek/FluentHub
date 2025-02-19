﻿using FluentHub.Services;
using FluentHub.ViewModels.Home;
using Microsoft.Extensions.DependencyInjection;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using muxc = Microsoft.UI.Xaml.Controls;

namespace FluentHub.Views.Home
{
    public sealed partial class ActivitiesPage : Page
    {
        public ActivitiesPage()
        {
            InitializeComponent();

            var provider = App.Current.Services;
            ViewModel = provider.GetRequiredService<ActivitiesViewModel>();
            navigationService = provider.GetRequiredService<INavigationService>();
        }

        private readonly INavigationService navigationService;
        public ActivitiesViewModel ViewModel { get; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string url = e.Parameter as string;

            var currentItem = navigationService.TabView.SelectedItem.NavigationHistory.CurrentItem;
            currentItem.Header = "Activities";
            currentItem.Description = "Viewer's activities";
            currentItem.Url = url;
            currentItem.Icon = new muxc.ImageIconSource
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Icons/Activities.png"))
            };

            var command = ViewModel.RefreshActivitiesCommand;
            if (command.CanExecute(null))
                command.Execute(null);
        }

        private void OnHomeRepositoriesListItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = e.ClickedItem as Repository;
            navigationService.Navigate<Repositories.OverviewPage>(clickedItem);
        }
    }
}
