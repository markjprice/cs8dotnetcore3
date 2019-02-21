using System;
using System.Collections.Generic;
using NorthwindMobile.Models;
using Xamarin.Forms;

namespace NorthwindMobile.Views
{
	public partial class CustomerDetails : ContentPage
	{
		private bool newCustomer = false; 

		public CustomerDetails()
		{
			InitializeComponent();
			BindingContext = new Customer();
			newCustomer = true;
			Title = "Add Customer";
		}

		public CustomerDetails(Customer customer)
		{
			InitializeComponent();
			BindingContext = customer;
			InsertButton.IsVisible = false;
		}

		async void InsertButton_Clicked(object sender, EventArgs e)
		{
			if (newCustomer)
			{
				Customer.Customers.Add((Customer)BindingContext);
			}
			await Navigation.PopAsync(animated: true);
		}
	}
}
