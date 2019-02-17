using System;

using NorthwindUwp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace NorthwindUwp.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
