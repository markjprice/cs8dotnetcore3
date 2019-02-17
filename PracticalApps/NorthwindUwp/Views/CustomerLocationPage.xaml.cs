using System;

using NorthwindUwp.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace NorthwindUwp.Views
{
    public sealed partial class CustomerLocationPage : Page
    {
        public CustomerLocationViewModel ViewModel { get; } = new CustomerLocationViewModel();

        public CustomerLocationPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.InitializeAsync(mapControl);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.Cleanup();
        }
    }
}
