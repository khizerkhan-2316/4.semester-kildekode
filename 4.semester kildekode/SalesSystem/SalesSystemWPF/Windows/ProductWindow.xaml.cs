using BusinessLayer;
using DataAccessLayer.Model;
using DataTransferObjects;
using DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Xml.Linq;

namespace SalesSystem
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        private CategoryBLL categoryController = CategoryBLL.GetController();
        private List<CategoryDto> categories; 

        public ProductDetailDto ProductDetailDto {get; set;}
        private CategoryDto Category { get; set; }


        public ProductWindow()
        {
            InitializeComponent();
            this.TitleTextBlock.Text = "Opret produkt";
            this.CreateAndUpdateProductButton.Content = "Opret Produkt";
            this.CancelButton.Content = "Cancel";
            this.categories = categoryController.GetCategories();
            this.CategoriesComboBox.ItemsSource = this.categories;

            ProductDetailDto = new ProductDetailDto();

		}

        public ProductWindow(ProductDetailDto productDetailDto)
        {
            InitializeComponent();
            this.TitleTextBlock.Text = "Opdatere produkt";
            this.ProductDetailDto = productDetailDto;
            this.Category = productDetailDto.Category;
            this.CreateAndUpdateProductButton.Content = "Opdatere produkt";
            this.CancelButton.Content = "Cancel";
            this.NameTextBox.Text = this.ProductDetailDto.Name;
            this.DescriptionRichTextBox.Document.Blocks.Add(new Paragraph(new Run(this.ProductDetailDto.Description)));
            this.PriceTextBox.Text = this.ProductDetailDto.Price.ToString();
            this.categories = categoryController.GetCategories();
            this.CategoriesComboBox.ItemsSource = this.categories;
            this.CategoriesComboBox.SelectedItem = productDetailDto.Category;
            this.CategoriesComboBox.SelectedItem = this.categories.Find((CategoryDto category) => category.Name == productDetailDto.Category.Name);
            
           if(this.ProductDetailDto.SalePrice != null)
            {
                this.SalePriceTextBox.Text = this.ProductDetailDto.SalePrice.ToString();
            }
            
        }

        private void CreateAndUpdateProductButton_Click(object sender, RoutedEventArgs e)

        {
            string name = this.NameTextBox.Text;
            string description = new TextRange(this.DescriptionRichTextBox.Document.ContentStart, this.DescriptionRichTextBox.Document.ContentEnd).Text;
            string price = this.PriceTextBox.Text;
            string salePrice = this.SalePriceTextBox.Text;
            CategoryDto category = (CategoryDto) this.CategoriesComboBox.SelectedItem;
            if(validateData(name, description, price, salePrice, category))
            {

                initializeData(name, description, price, salePrice);


                this.DialogResult = true;
                this.Close();

            } 
        }

        private Boolean validateData(string name, string description, string price, string salePrice, CategoryDto category)
        {
            if(name.Length == 0 || name == "" || name.Trim().Length == 0)
            {
                this.ErrorLabel.Content = "Tjek feltet: Navn!";
                return false;
            }

            if(description.Length == 0 || description == "" || description.Trim().Length == 0)
            {
                this.ErrorLabel.Content = "Tjek feltet: Beskrivelse!";

                return false;
            }

            if(description.Trim().Length < 10)
            {
                this.ErrorLabel.Content = "Beskrivelse skal minimum være på 10 karakter.";
                return false;
            }

            if(category == null)
            {
                this.ErrorLabel.Content = "Du skal vælge en kategori";
                return false;
            }

            try
            {
                double.Parse(price);
                
                if(salePrice != null && salePrice.Length != 0)
                {
                    double.Parse(salePrice);
                }
            } catch(Exception e)
            {
                this.ErrorLabel.Content = e.Message;
                return false;
            }


            return true;
        }

        private void initializeData(string name, string description, string price, string salePrice)
        {
            this.Category = (CategoryDto)this.CategoriesComboBox.SelectedItem;

            if (this.ProductDetailDto != null)
            {
                this.ProductDetailDto.Name = name;
                this.ProductDetailDto.Description = description;
                this.ProductDetailDto.Price = Double.Parse(price);
                this.ProductDetailDto.Category = this.Category;


                if (salePrice != null && salePrice.Trim().Length != 0)
                {
                    this.ProductDetailDto.SalePrice = double.Parse(salePrice);
                }
            } else
            {
                this.ProductDetailDto = new ProductDetailDto { Name = name, Description = description, Price = Double.Parse(price), Category = this.Category };

                if (salePrice != null && salePrice.Trim().Length != 0)
                {
                    this.ProductDetailDto.SalePrice = double.Parse(salePrice);
                }
            }
        }

       
    }
}
