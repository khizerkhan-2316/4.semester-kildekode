using BusinessLayer;
using DataTransferObjects.Models;
using SalesSystem.Windows;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SalesSystem.Views
{
	/// <summary>
	/// Interaction logic for CategoryView.xaml
	/// </summary>
	public partial class CategoryView : UserControl
	{
		private CategoryBLL controller = CategoryBLL.GetController();
		private CategoryWindow window;

		public CategoryView()
		{
			InitializeComponent();
			Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
			CategoryListBox.ItemsSource = controller.GetCategories();
			Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
		}

		private void CreateCategoryButton_Click(object sender, RoutedEventArgs e)
		{
			window = new CategoryWindow();
			window.ShowDialog();


			if ((bool)window.DialogResult)
			{
				CreateCategoryEventHandler(window);
				MessageBox.Show("Kategori oprettet!");
				this.CategoryListBox.ItemsSource = controller.GetCategories();

			}
		}

		private void CreateCategoryEventHandler(CategoryWindow window)
		{
			controller.CreateCategory(window.category);
		}

		private void UpdateCategoryButton_Click(object sender, RoutedEventArgs e)
		{
			CategoryDto selectedCategory = (CategoryDto)this.CategoryListBox.SelectedItem;
			int index = this.CategoryListBox.SelectedIndex;

			if (selectedCategory == null)
			{
				MessageBox.Show("Vælg en kategori fra listen som du vil opdatere!");
				return;
			}

			this.window = new CategoryWindow(selectedCategory);
			this.window.ShowDialog();

			if ((bool)window.DialogResult)
			{
				UpdateProductHandler(window, selectedCategory);
				MessageBox.Show("Kategori Opdateret!");
				this.CategoryListBox.ItemsSource = controller.GetCategories();
				this.CategoryListBox.SelectedIndex = index;

			}
		}


		private void UpdateProductHandler(CategoryWindow window, CategoryDto category)
		{
			controller.UpdateCategory(category);
		}

		private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
		{

			CategoryDto selectedCategory = (CategoryDto)this.CategoryListBox.SelectedItem;

			if (selectedCategory == null)
			{
				MessageBox.Show("Vælg en kategori fra listen");
				return;
			}

			bool deleted = controller.DeleteCategory(selectedCategory.CategoryId);

			if (!deleted)
			{
				MessageBox.Show("Slet alle produkter som har denne kategori først!");
				return;
			}
			else
			{
				MessageBox.Show("Kategorien er slettet!");
				this.CategoryListBox.ItemsSource = controller.GetCategories();
				this.CategoryListBox.SelectedIndex = 0;
			}

		}

		private void CategoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CategoryDto category = (CategoryDto)this.CategoryListBox.SelectedItem;

			if (category != null)
			{
				CategoryDetailDto categoryDetailDto = controller.GetCategoryDetails(category.CategoryId);
				this.ProductsListBox.ItemsSource = categoryDetailDto.Products;
			}

		}
	}
}
