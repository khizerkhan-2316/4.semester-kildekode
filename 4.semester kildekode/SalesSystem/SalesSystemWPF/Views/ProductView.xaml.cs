using BusinessLayer;
using DataAccessLayer.Model;
using DataTransferObjects;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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

namespace SalesSystem.Views
{
    /// <summary>
    /// Interaction logic for ProductView.xaml
    /// </summary>
    public partial class ProductView : UserControl
    {
        private ProductController controller = ProductController.GetController();
        private PictureController pictureController = PictureController.GetController();    
        ProductWindow window;
        public ProductView()
        {
            InitializeComponent();
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            ProductListBox.ItemsSource = controller.GetProducts();
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

        }

        private void ProductListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductDto selectedProduct = (ProductDto) this.ProductListBox.SelectedItem;
            if(selectedProduct != null)
            {
                ProductDetailDto productDetailDto = controller.GetProductDetails(selectedProduct.ProductId);
                this.NameTextBlock.Text = productDetailDto.Name;
                this.DescriptionTextBlock.Text = productDetailDto.Description;
                this.PriceTextBlock.Text = productDetailDto.Price.ToString();
                this.CategoryTextBlock.Text = productDetailDto.Category.Name;

                if (productDetailDto.SalePrice != null)
                {
                    this.SalePriceTextBlock.Text = productDetailDto.SalePrice.ToString();
                }
                else
                {
                    this.SalePriceTextBlock.Text = "Ingen salgspris";
                } 
            }
            
           

        }

        private void CreateProductButton_Click(object sender, RoutedEventArgs e)
        {
             window = new ProductWindow();
             window.ShowDialog();

            if ((bool)window.DialogResult)
            {
                createProductEventHandler(window.ProductDetailDto);
                MessageBox.Show("Produkt oprettet!");
                this.ProductListBox.ItemsSource = controller.GetProducts();
                  
            }


        }

  

        private void UpdateProductButton_Click(object sender, RoutedEventArgs e)
        {
            ProductDto selectedProduct = (ProductDto) this.ProductListBox.SelectedItem;
            int index = this.ProductListBox.SelectedIndex;

            if(selectedProduct == null)
            {
                MessageBox.Show("Vælg et produkt fra listen som du vil opdatere!");
                return;
            }

            this.window = new ProductWindow(controller.GetProductDetails(selectedProduct.ProductId));
            window.ShowDialog();

            if ((bool)window.DialogResult)
            {
                updateProductHandler(window.ProductDetailDto);
                MessageBox.Show("Produkt Opdateret!");
                this.ProductListBox.ItemsSource = controller.GetProducts();
                this.ProductListBox.SelectedIndex = index;

            }
            }


        private void updateProductHandler(ProductDetailDto productDetailDto)
        {
            string name = productDetailDto.Name;
            string description = productDetailDto.Description;
            double price = productDetailDto.Price;
            double? salePrice = productDetailDto.SalePrice;
			PictureDto defaultPicture = pictureController.GetDefaultImage();

			controller.UpdateProductWithPicture(productDetailDto.ProductId, name, description, price, salePrice, productDetailDto.Category, defaultPicture);
        }


        private void createProductEventHandler(ProductDetailDto productDetailDto)
        {
            string name = productDetailDto.Name;
            string description = productDetailDto.Description;
            double price = productDetailDto.Price;
            double? salePrice = productDetailDto.SalePrice;
            CategoryDto category = productDetailDto.Category;
            PictureDto defaultPicture = pictureController.GetDefaultImage();

			controller.CreateProductWithPicture(name, description, price, salePrice, category, defaultPicture);
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            ProductDto selectedProduct = (ProductDto) this.ProductListBox.SelectedItem;
            
            if(selectedProduct != null)
            {
                controller.DeleteProduct(selectedProduct.ProductId);
                MessageBox.Show("Produktet er slettet!");
                this.ProductListBox.ItemsSource = controller.GetProducts();
                this.ProductListBox.SelectedIndex = 0;
            } else
            {
                MessageBox.Show("Vælg et produkt fra listen du vil slette");
            }

        }
    }
}
