using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;

using Packt.Shared;

namespace NorthwindFluent
{
    public class CategoriesViewModel
    {
        public class CategoryJson
        {
            public int categoryID;
            public string categoryName;
            public string description;
        }

        public ObservableCollection<Category> Categories { get; set; }

        public CategoriesViewModel()
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("https://localhost:5002/");

                var serializer = new DataContractJsonSerializer(
                  typeof(List<CategoryJson>));

                var stream = http.GetStreamAsync("api/categories").Result;

                var cats = serializer.ReadObject(stream) as List<CategoryJson>;

                var categories = cats.Select(c => new Category
                {
                    CategoryID = c.categoryID,
                    CategoryName = c.categoryName,
                    Description = c.description
                });

                Categories = new ObservableCollection<Category>(categories);
            }
        }
    }
}
