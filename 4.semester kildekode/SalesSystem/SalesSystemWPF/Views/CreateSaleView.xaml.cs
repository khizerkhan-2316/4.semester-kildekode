using BusinessLayer;
using DataAccessLayer.Model;
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

namespace SalesSystem.Views
{
    /// <summary>
    /// Interaction logic for CreateSaleView.xaml
    /// </summary>
    public partial class CreateSaleView : UserControl
    {
        private readonly CategoryController categoryController = CategoryController.GetController();
        private readonly ProductController productController = ProductController.GetController();
        private readonly SaleController saleController = SaleController.GetController();
        private SaleDetailDto newSale;

        public CreateSaleView()
        {
            InitializeComponent();
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            CategoryListBox.ItemsSource = categoryController.GetCategories();
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
            newSale = new SaleDetailDto();
            PopulateSaleDetailTextBlocks();
        }

        private void CategoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            CategoryDto category = (CategoryDto)this.CategoryListBox.SelectedItem;

            if (category != null)
            {
                ProductsListBox.ItemsSource = productController.GetProductsDetailsFromCategoryId(category.CategoryId);
            }
        }



        private void PopulateSaleDetailTextBlocks()
        {
            SaleDateTextBlock.Text = newSale.SaleDate.ToString();
            PriceTextBlock.Text = $"{newSale.TotalPrice} DKK"; ;
        }

        private void DiscountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double discount = double.Parse(DiscountTextBox.Text);
                ErrorLabel.Content = "";

                if(discount > 100 || discount < 1) {

                    this.ErrorLabel.Content = "Discount: 1 - 100";
                    return;
                }

                this.DiscountTextBlock.Text = $"{discount} %";

                CalculateAndSetTotalSalePrice(SalesLineListBox);
                return;


            } catch(Exception exception)
            {
                ErrorLabel.Content = "Discount skal være et tal mellem 1 og 100.";
                this.DiscountTextBlock.Text = $"0 %";
                Console.WriteLine(exception.ToString());
            }

            CalculateAndSetTotalSalePrice(SalesLineListBox);


        }

        private void ProductsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            ProductDetailDto selectedProduct = (ProductDetailDto)ProductsListBox.SelectedItem;

            if (selectedProduct == null)
            {
                return;
            }

            SalesLineDto newSalesline = new SalesLineDto
            {
                Quantity = 1,
                Product = selectedProduct
            };


            if (SalesLineListBox.Items.Count >= 1)
            {
                foreach(SalesLineDto dto in SalesLineListBox.Items)
                {
                    if(dto.Product.Name == newSalesline.Product.Name)
                    {
                        newSalesline.Quantity += dto.Quantity;
                        newSalesline.CalculateAndSetTotalPrice();
                        newSalesline.SalesLineId = dto.SalesLineId;
                        SalesLineListBox.Items.Remove(dto);
                        SalesLineListBox.Items.Add(newSalesline);
                        CalculateAndSetTotalSalePrice(SalesLineListBox);
                        return;
                    }
                }

                            
            }

            newSalesline.CalculateAndSetTotalPrice();
            SalesLineListBox.Items.Add(newSalesline);
            CalculateAndSetTotalSalePrice(SalesLineListBox);




        }

        private double CalculateAndSetTotalSalePrice(ListBox box)
        {
            List<SalesLineDto> list = new List<SalesLineDto>();
            foreach (SalesLineDto dto in box.Items)
            {
                list.Add(dto);
            }

            double totalPrice = list.Aggregate(0, (double acc, SalesLineDto s) => acc + s.TotalPrice);

            try
            {
                if(DiscountTextBox.Text.Trim() == "")
                {
                    this.PriceTextBlock.Text = totalPrice.ToString();
                    return totalPrice;
                }

                double discount = double.Parse(DiscountTextBox.Text);
                totalPrice -= (totalPrice / 100) * (double)discount;
                this.PriceTextBlock.Text = totalPrice.ToString();

            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }

            return totalPrice;
        }

        private void MobilePayRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            bool mobilepay = (bool)MobilePayRadioButton.IsChecked;
            if (mobilepay)
            {
                this.PaymentOptionTextBlock.Text = "MobilePay";

            }
        }

        private void CardRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            bool card = (bool)CardRadioButton.IsChecked;

            if (card)
            {
                this.PaymentOptionTextBlock.Text = "Dankort";
            }
        }

        private void CashRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            bool cash = (bool)CashRadioButton.IsChecked;

            if (cash)
            {
                this.PaymentOptionTextBlock.Text = "Kontant";
            }
        }

        private void AmountPaidTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                double amountPaid = Double.Parse(AmountPaidTextBox.Text);
                this.AmountPaidTextBlock.Text = amountPaid.ToString();
                this.ErrorLabel.Content = "";

                double price = CalculateAndSetTotalSalePrice(SalesLineListBox);
                
                if(amountPaid >= price)
                {
                    double amountToReturn = amountPaid - price;

                    AmountToReturnTextBlock.Text = amountToReturn.ToString();
                } else
                {
                    AmountToReturnTextBlock.Text = "";
                }

            } catch(Exception exception)
            {
                this.ErrorLabel.Content = "Beløb skal være et nummer";
                this.AmountPaidTextBlock.Text = "0";
                Console.WriteLine(exception.ToString());
            }
        }


        private void ResetView()
        {
            newSale = new SaleDetailDto();
            this.SalesLineListBox.Items.Clear();
            this.MobilePayRadioButton.IsChecked = false;
            this.CardRadioButton.IsChecked = false;
            this.AmountPaidTextBox.Text = "";
            this.AmountPaidTextBlock.Text = "";
            this.DiscountTextBox.Text = "";
            this.DiscountTextBlock.Text = "";
            this.PriceTextBlock.Text = "";
            this.PaymentOptionTextBlock.Text = "";
            this.SaleDateTextBlock.Text = newSale.SaleDate.ToString();
            this.AmountToReturnTextBlock.Text = "";
            this.ErrorLabel.Content = "";
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetView();
        }

        private void CreateSaleButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsSaleValid())
            {
                
                FinalizeSale();
                MessageBox.Show("Salg afsluttet!");
                ResetView();
            }
        }



        private bool IsSaleValid()
        {
            if(SalesLineListBox.Items.Count <= 0)
            {
                this.ErrorLabel.Content = "Du skal vælge et produkt før salget kan ske";
                return false;
            }

            if(!(bool) MobilePayRadioButton.IsChecked && (bool) !CardRadioButton.IsChecked && (bool) !CashRadioButton.IsChecked)
            {
                this.ErrorLabel.Content = "Du skal vælge en betalingsform";
            }

            if(AmountPaidTextBox.Text.Trim() == "")
            {
                this.ErrorLabel.Content = "Du skal indtaste det betale beløb";

            }

            if(!(double.Parse(AmountPaidTextBox.Text) >= double.Parse(PriceTextBlock.Text)))
            {
                this.ErrorLabel.Content = "Det betalte beløb skal være større eller samme som prisen.";
                return false;
            }


            return true;
        }


        private void FinalizeSale()
        {
            try
            {
                double? discount = Double.Parse(DiscountTextBox.Text);
                string paymentOption = GetSelctedPaymentOption();
                double amountPaid = double.Parse(AmountPaidTextBox.Text);
                double totalPrice = Double.Parse(PriceTextBlock.Text);

                double? amountReturned = Double.Parse(AmountToReturnTextBlock.Text);
                

                List<SalesLineDto> list = new List<SalesLineDto>();

                PaymentDto paymentDto = new PaymentDto
                {
                    AmountPaid = amountPaid
                };

                PaymentOptionDto paymentOptionDto = new PaymentOptionDto
                {
                    Name = paymentOption,
                    PaymentOptionId = Guid.NewGuid()
                };

                foreach (SalesLineDto dto in SalesLineListBox.Items)
                {
                    list.Add(dto);
                }

                newSale.TotalPrice = totalPrice;
                newSale.Discount = discount;
                newSale.PaymentOption = paymentOptionDto;
                newSale.Payment = paymentDto;
                newSale.SalesLines = list;
                newSale.AmountReturned = amountReturned;

                saleController.CreateSale(newSale);

            } catch(Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }


        private string GetSelctedPaymentOption()
        {
            if ((bool)MobilePayRadioButton.IsChecked)
            {
                return "MobilePay";
            } else if((bool)CardRadioButton.IsChecked)
            {
                return "Dankort";
            } else
            {
                return "Kontant";
            }
        }

        private void DelteSalesLineButton_Click(object sender, RoutedEventArgs e)
        {
            SalesLineDto selected = (SalesLineDto)SalesLineListBox.SelectedItem;

            if(selected == null)
            {
                MessageBox.Show("Du skal vælge en salgslinje for at slette den");
                    return;
            }

            SalesLineListBox.Items.Remove(selected);
            CalculateAndSetTotalSalePrice(this.SalesLineListBox);
        }
    }
}
