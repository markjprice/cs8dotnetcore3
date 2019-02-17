using System;

using NorthwindUwp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace NorthwindUwp.Views
{
    public sealed partial class AboutPage : Page
    {
        public AboutViewModel ViewModel { get; } = new AboutViewModel();

        public AboutPage()
        {
            InitializeComponent();
        }
    }
}
