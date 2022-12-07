using BusinessLayer;
using DataTransferObjects;
using DataTransferObjects.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SalesSystem.Views
{
	/// <summary>
	/// Interaction logic for ProductView.xaml
	/// </summary>
	public partial class ProductView : UserControl
	{
		private ProductBLL controller = ProductBLL.GetController();
		private PictureBLL pictureController = PictureBLL.GetController();
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
			ProductDto selectedProduct = (ProductDto)this.ProductListBox.SelectedItem;
			if (selectedProduct != null)
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
			ProductDto selectedProduct = (ProductDto)this.ProductListBox.SelectedItem;
			int index = this.ProductListBox.SelectedIndex;

			if (selectedProduct == null)
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
			controller.UpdateProduct(productDetailDto);
		}


		private void createProductEventHandler(ProductDetailDto productDetailDto)
		{

			productDetailDto.Picture = pictureController.GetDefaultImage();
			controller.CreateProduct(productDetailDto);

		}

		private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
		{
			ProductDto selectedProduct = (ProductDto)this.ProductListBox.SelectedItem;

			if (selectedProduct != null)
			{
				controller.DeleteProduct(selectedProduct.ProductId);
				MessageBox.Show("Produktet er slettet!");
				this.ProductListBox.ItemsSource = controller.GetProducts();
				this.ProductListBox.SelectedIndex = 0;
			}
			else
			{
				MessageBox.Show("Vælg et produkt fra listen du vil slette");
			}

		}
	}
}
