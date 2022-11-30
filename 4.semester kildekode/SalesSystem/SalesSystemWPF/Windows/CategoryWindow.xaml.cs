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
            this.TitleTextBlock.Text = "Opret kategori";
            this.CreateAndUpdateCategory.Content = "Opret Kategori";
            this.CancelButton.Content = "Cancel";
        }

        public CategoryWindow(CategoryDto categoryToBeUpdated)
        {
            InitializeComponent();
            this.TitleTextBlock.Text = "Opdatere Kategori";
            this.category = categoryToBeUpdated;
            this.CreateAndUpdateCategory.Content = "Opdatere Kategori";
            this.CancelButton.Content = "Cancel";
            this.NameTextBox.Text = this.category.Name;
        }

        private void CreateAndUpdateCategory_Click(object sender, RoutedEventArgs e)
        {
            string name = this.NameTextBox.Text;

            if (validateData(name))
            {
                this.CategoryName = name;
                this.DialogResult = true;
                this.Close();
            }
        } 

        private bool validateData(string name)
        {
            if(name.Trim().Length < 2)
            {
                this.ErrorLabel.Content = "Navnet skal være på minimum 2 karakter";
                return false;
            }

            return true;
        }
    }
}
