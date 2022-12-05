using DataTransferObjects;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace SalesSystem.Windows
{
	/// <summary>
	/// Interaction logic for CategoryWindow.xaml
	/// </summary>
	public partial class CategoryWindow : Window
	{
		public CategoryDto category;

		public string CategoryName { get; set; }
		public CategoryWindow()
		{
			InitializeComponent();
			InitializeViewData("Opret Kategori");

			this.category = new CategoryDto
			{
				CategoryId = Guid.NewGuid(),
				Name = ""
			};

		}

		public CategoryWindow(CategoryDto categoryToBeUpdated)
		{
			InitializeComponent();
			InitializeViewData("Opdatere Kategori");


			this.category = categoryToBeUpdated;
			this.NameTextBox.Text = this.category.Name;
		}

		private void CreateAndUpdateCategory_Click(object sender, RoutedEventArgs e)
		{
			string name = this.NameTextBox.Text;

			if (validateData(name))
			{
				this.category.Name = name;
				this.DialogResult = true;
				this.Close();
			}
		}

		private void InitializeViewData(string title)
		{
			this.TitleTextBlock.Text = title;
			this.CreateAndUpdateCategory.Content = title;
			this.CancelButton.Content = "Cancel";

		}

		private bool validateData(string name)
		{
			if (name.Trim().Length < 2)
			{
				this.ErrorLabel.Content = "Navnet skal være på minimum 2 karakter";
				return false;
			}

			return true;
		}
	}
}
