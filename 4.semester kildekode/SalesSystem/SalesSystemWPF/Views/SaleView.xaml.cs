using BusinessLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SalesSystem.Views
{
    /// <summary>
    /// Interaction logic for SaleView.xaml
    /// </summary>
    public partial class SaleView : UserControl
    {
        private SaleBLL controller = SaleBLL.GetController();

        public SaleView()
        {
            InitializeComponent();
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            SaleListBox.ItemsSource = controller.GetSales();
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

        }

        private void SaleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SaleDto selected = (SaleDto)SaleListBox.SelectedItem;

            SaleDetailDto details = controller.GetSaleDetails(selected.SaleId);

            SaleLinesListBox.ItemsSource = details.SalesLines;

            PopulateSaleTextBlocks(details);

            SaleLinesListBox.SelectedIndex = 0;
        }

        private void SaleLinesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SalesLineDto selected = (SalesLineDto)SaleLinesListBox.SelectedItem;
                    if(selected != null)
            {
                PopulateSalesLineTextBlocks(selected);
            }
        }

        private void PopulateSaleTextBlocks(SaleDetailDto sale)
        {
            SaleTotalPriceTextBlock.Text = sale.TotalPrice.ToString();
            AmountPaidTextBlock.Text = sale.Payment.AmountPaid.ToString();
            PaymentOptionTextBlock.Text = sale.PaymentOption.Name;
            SaleDateTextBlock.Text = sale.SaleDate.ToString();

            
            if(sale.AmountReturned != null)
            {
                ReturnedTextBlock.Text = sale.AmountReturned.ToString();
            } else
            {
                ReturnedTextBlock.Text = "Ingen tilbagebetaling";
            }

            if(sale.Discount != null)
            {
                DiscountTextBlock.Text = $"{sale.Discount} %"; ;  
            } else
            {
                DiscountTextBlock.Text = "Ingen discount givet";
            }



        }

        private void PopulateSalesLineTextBlocks(SalesLineDto salesLine)
        {
            ProductNameTextBlock.Text = salesLine.Product.Name;
            ProductPriceTextBlock.Text = salesLine.Product.Price.ToString();
            QuantityTextBlock.Text = salesLine.Quantity.ToString();
            SaleslinePriceTextBlock.Text = salesLine.TotalPrice.ToString();

            if(salesLine.Product.SalePrice != null)
            {
                ProductSalePriceTextBlock.Text = salesLine.Product.SalePrice.ToString();
            }
            else
            {
                ProductSalePriceTextBlock.Text = "Ingen Udsalgspris";
            }
        }

       
    }
}
