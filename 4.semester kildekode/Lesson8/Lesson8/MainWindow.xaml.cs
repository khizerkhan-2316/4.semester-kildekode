using Lesson8.DAL;
using Lesson8.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Lesson8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window


    {

        BookContext bookContext;
        BookInitializer bookInitializer;

        public MainWindow()
        {
            bookContext = new BookContext();

            bookInitializer = new BookInitializer();


            bookInitializer.InitializeDatabase(bookContext);
            
            InitializeComponent();



            foreach (Book book in bookContext.Books)
            {
                booksList.Items.Add(book);
            } 


            foreach (Library library in bookContext.Libraries)
            {
                LibrariesList.Items.Add(library);
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book("New Book", "The new book", "Martin Larsen", "Fantasy", 5000, 3213, "English", "123-2321-23");
            bookContext.Books.Add(book);
            bookContext.SaveChangesAsync();
            booksList.Items.Add(book);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Library library = new Library("Viby Bibliotek", "Skanderborgvej 122 8260 Viby J");
            bookContext.Libraries.Add(library);
            bookContext.SaveChangesAsync();
            LibrariesList.Items.Add(library);
        }

        private void LibrariesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Library library = (Library) this.LibrariesList.SelectedItem;

            this.NameTextBox.Text = library.Name;
            this.AddressTextBox.Text = library.Address;

            List<Book> books = this.bookContext.Books.Where(book => book.LibraryID == library.LibraryID).ToList();

            this.booksList.Items.Clear();

            books.ForEach((Book book) => this.booksList.Items.Add(book));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Library library = (Library)this.LibrariesList.SelectedItem;
            String name = this.NameTextBox.Text;
            String address = this.AddressTextBox.Text;

            if (library != null && name.Length != 0 && address.Length != 0)
            {
                library.Name = name;
                library.Address = address;
                this.bookContext.Libraries.AddOrUpdate(library);
                this.bookContext.SaveChanges();

            }

        }
    }
}
