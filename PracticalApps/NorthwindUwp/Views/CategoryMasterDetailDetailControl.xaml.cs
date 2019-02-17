using System;

using NorthwindUwp.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NorthwindUwp.Views
{
    public sealed partial class CategoryMasterDetailDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(CategoryMasterDetailDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public CategoryMasterDetailDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CategoryMasterDetailDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
