using System;
using System.Collections.ObjectModel;

using NorthwindUwp.Core.Models;
using NorthwindUwp.Core.Services;
using NorthwindUwp.Helpers;

namespace NorthwindUwp.ViewModels
{
    public class CustomersGridViewModel : Observable
    {
        public ObservableCollection<SampleOrder> Source
        {
            get
            {
                // TODO WTS: Replace this with your actual data
                return SampleDataService.GetGridSampleData();
            }
        }
    }
}
