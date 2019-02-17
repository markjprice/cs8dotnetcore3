using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.EntityFrameworkCore;

using Packt.Shared;

namespace NorthwindWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void GetProductsButton_Click(object sender, RoutedEventArgs e)
        {
            string path = @"C:\Code\PracticalApps\NorthwindWeb\Northwind.db";

            if (!File.Exists(path))
            {
                MessageBox.Show(path, "Missing database file");
                return;
            }

            var builder = new DbContextOptionsBuilder();
            builder.UseSqlite($"Data Source={path}");

            using (var db = new Northwind(builder.Options))
            {
                await db.Products.ForEachAsync(p =>
                {
                    ProductsListBox.Items.Add(
                        $"{p.ProductID}: {p.ProductName} costs {p.UnitPrice:c}");
                    System.Threading.Thread.Sleep(100);
                });
            }
        }
    }
}
