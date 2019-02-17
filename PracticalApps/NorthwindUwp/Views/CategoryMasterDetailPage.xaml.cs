using System;

using NorthwindUwp.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NorthwindUwp.Views
{
    public sealed partial class CategoryMasterDetailPage : Page
    {
        public CategoryMasterDetailViewModel ViewModel { get; } = new CategoryMasterDetailViewModel();

        public CategoryMasterDetailPage()
        {
            InitializeComponent();
            Loaded += CategoryMasterDetailPage_Loaded;
        }

        private async void CategoryMasterDetailPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(MasterDetailsViewControl.ViewState);
        }
    }
}
