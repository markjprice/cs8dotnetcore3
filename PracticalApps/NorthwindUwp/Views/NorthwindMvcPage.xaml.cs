using System;

using NorthwindUwp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace NorthwindUwp.Views
{
    public sealed partial class NorthwindMvcPage : Page
    {
        public NorthwindMvcViewModel ViewModel { get; } = new NorthwindMvcViewModel();

        public NorthwindMvcPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
