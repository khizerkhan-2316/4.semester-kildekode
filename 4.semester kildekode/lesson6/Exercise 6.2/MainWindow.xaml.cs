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

namespace Exercise_6._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string name = this.label1top.Content.ToString();

            this.label1top.Content = this.label2top.Content;

            this.label2top.Content = name;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            string name = this.label1bottom.Content.ToString();

            this.label1bottom.Content = this.label2bottom.Content;

            this.label2bottom.Content = name;

        }
    }
}
