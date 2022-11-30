using BusinessLayer;
using SalesSystem.ViewModels;
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

namespace SalesSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private HomeViewModel homeViewModel;
        private ProductViewModel productViewModel;
        private CategoryViewModel categoryViewModel;
        private SaleViewModel saleViewModel;
        private CreateSaleViewModel createSaleViewModel;

        public MainWindow()
        {
            InitializeComponent();
            productViewModel = new ProductViewModel();
            homeViewModel = new HomeViewModel();
            categoryViewModel = new CategoryViewModel();
            saleViewModel = new SaleViewModel();
            createSaleViewModel = new CreateSaleViewModel();
            DataContext = homeViewModel;

        }

        private void ProductView_Click(object sender, RoutedEventArgs e)
        {
            ChangeBorder(e);

            DataContext = this.productViewModel;
        }

        private void CategoryView_Click(object sender, RoutedEventArgs e)
        {
            ChangeBorder(e);
            DataContext = this.categoryViewModel;



        }

        private void SaleView_Click(object sender, RoutedEventArgs e)
        {
            ChangeBorder(e);
            DataContext = this.saleViewModel;
        }

        private void CreateSaleView_Click(object sender, RoutedEventArgs e)
        {
            ChangeBorder(e);
            DataContext = this.createSaleViewModel;
        }


        private void ChangeBorder(RoutedEventArgs e)
        {
            int index = int.Parse(((Button)e.Source).Uid);

            GridCursor.Margin = new Thickness(10 + (150 * index), 35, 0, 0);
            GridCursor.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

       
    }
}
