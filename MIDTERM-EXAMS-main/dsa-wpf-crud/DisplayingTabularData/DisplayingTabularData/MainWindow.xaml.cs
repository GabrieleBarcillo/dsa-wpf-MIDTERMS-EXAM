using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static DisplayingTabularData.MainWindow;

namespace DisplayingTabularData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
 
        public List<Product> Products { get; }

        // Simple model for grid rows
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }
        public class ShoppingCart
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
           

            Products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Description = "For gaming and editing", Price = 59999m },
                new Product { Id = 2, Name = "Smartphone", Description = "Portable and affordable", Price = 19999m }
            };
            this.DataContext = this;


        }


        //event handlers 
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IdTextBox.Text != "" &&  IdTextBox.Text != "" && DescriptionTextBox.Text != "" && PriceTextBox.Text != "")
                {

                    Products.Add(new Product
                    {
                        Id = int.Parse(IdTextBox.Text),
                        Name = NameTextBox.Text,
                        Description = DescriptionTextBox.Text,
                        Price = decimal.Parse(PriceTextBox.Text)
                    });
                    ProductsDataGrid.Items.Refresh();
                    //Empties the textboxes after adding
                    IdTextBox.Text = "";
                    NameTextBox.Text = "";
                    DescriptionTextBox.Text = "";
                    PriceTextBox.Text = "";
                }
            }
            catch
            {

                MessageBox.Show("Please fill in all fields correctly.");
            }




        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = ProductsDataGrid.SelectedItem as Product;
            if (selectedProduct != null)
            {
                Products.Remove(selectedProduct);
                MessageBox.Show("Successfully removed.");
                ProductsDataGrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select an item to remove.");
            }
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = ProductsDataGrid.SelectedItem as Product;
            if (selectedProduct != null)
            {
                ShoppingCartDataGrid.Items.Add(selectedProduct);
                ShoppingCartDataGrid.Items.Refresh();
                MessageBox.Show("Successfully added to cart.");
                Products.Remove(selectedProduct);
                ProductsDataGrid.Items.Refresh();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            IdTextBox.Clear(); 
            NameTextBox.Clear();
            DescriptionTextBox.Clear();
            PriceTextBox.Clear();
        }

        private void ShoppingCartDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
