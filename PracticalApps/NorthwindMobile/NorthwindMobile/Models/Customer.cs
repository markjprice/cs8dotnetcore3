using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NorthwindMobile.Models
{
	public class Customer : INotifyPropertyChanged
	{
		public static IList<Customer> Customers;

		static Customer()
		{
			Customers = new ObservableCollection<Customer>();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private string customerID;
		private string companyName;
		private string contactName;
		private string city;
		private string country;
		private string phone;

		public string CustomerID
		{
			get => customerID;
			set
			{
				customerID = value;
				PropertyChanged?.Invoke(this,
					new PropertyChangedEventArgs("CustomerID"));
			}
		}

		public string CompanyName
		{
			get => companyName;
			set
			{
				companyName = value;
				PropertyChanged?.Invoke(this,
					new PropertyChangedEventArgs("CompanyName"));
			}
		}

		public string ContactName
		{
			get => contactName;
			set
			{
				contactName = value;
				PropertyChanged?.Invoke(this,
					new PropertyChangedEventArgs("ContactName"));
			}
		}

		public string City
		{
			get => city;
			set
			{
				city = value;
				PropertyChanged?.Invoke(this,
					new PropertyChangedEventArgs("City"));
			}
		}

		public string Country
		{
			get => country;
			set
			{
				country = value;
				PropertyChanged?.Invoke(this,
					new PropertyChangedEventArgs("Country"));
			}
		}

		public string Phone
		{
			get => phone;
			set
			{
				phone = value;
				PropertyChanged?.Invoke(this,
					new PropertyChangedEventArgs("Phone"));
			}
		}

		public string Location
		{
			get => string.Format("{0}, {1}", City, Country);
		}

		// for testing before calling web service 
		public static void AddSampleData()
		{
			Customers.Add(new Customer
			{
				CustomerID = "ALFKI",
				CompanyName = "Alfreds Futterkiste",
				ContactName = "Maria Anders",
				City = "Berlin",
				Country = "Germany",
				Phone = "030-0074321"
			});

			Customers.Add(new Customer
			{
				CustomerID = "FRANK",
				CompanyName = "Frankenversand",
				ContactName = "Peter Franken",
				City = "München",
				Country = "Germany",
				Phone = "089-0877310"
			});

			Customers.Add(new Customer
			{
				CustomerID = "SEVES",
				CompanyName = "Seven Seas Imports",
				ContactName = "Hari Kumar",
				City = "London",
				Country = "UK",
				Phone = "(171) 555-1717"
			});
		}
	}
}