using System;

using NorthwindUwp.ViewModels;

using Windows.UI.Xaml.Controls;

namespace NorthwindUwp.Views
{
    public sealed partial class CustomersGridPage : Page
    {
        public CustomersGridViewModel ViewModel { get; } = new CustomersGridViewModel();

        // TODO WTS: Change the grid as appropriate to your app, adjust the column definitions on CustomersGridPage.xaml.
        // For more details see the documentation at https://docs.microsoft.com/windows/communitytoolkit/controls/datagrid
        public CustomersGridPage()
        {
            InitializeComponent();
        }
    }
}
