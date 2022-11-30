using Lesson8.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.DAL
{
    internal class BookInitializer : DropCreateDatabaseIfModelChanges<BookContext>
    {

        protected override void Seed(BookContext context)
        {
            Library library = new Library("Viby Bibliotek", "Skanderborgvej 123");
            


            Book book1 = new Book("MySQL - All you need to know", "This book is an excellent guide for you on how to use SQL (Structured Query Language) in relational database management systems.", "Nicholas Brown", "Education", 200, 100, "English", "9781088474266");
            Book book2 = new Book("Harry Potter - The four gates", "This book is an excellent guide for you on how to use SQL (Structured Query Language) in relational database management systems.", "Nicholas Brown", "Education", 200, 100, "English", "9781088474266");
            Book book3 = new Book("De vise sten", "This book is an excellent guide for you on how to use SQL (Structured Query Language) in relational database management systems.", "Nicholas Brown", "Education", 200, 100, "English", "9781088474266");
            Book book4 = new Book("Test", "This book is an excellent guide for you on how to use SQL (Structured Query Language) in relational database management systems.", "Nicholas Brown", "Education", 200, 100, "English", "9781088474266");
            Book book5 = new Book("learn C#", "This book is an excellent guide for you on how to use SQL (Structured Query Language) in relational database management systems.", "Nicholas Brown", "Education", 200, 100, "English", "9781088474266");

            library.Books.Add(book1);
            library.Books.Add(book2);
            library.Books.Add(book3);
            library.Books.Add(book4);
            library.Books.Add(book5);

            book1.LibraryID = library.LibraryID;
            book2.LibraryID = library.LibraryID;
            book3.LibraryID = library.LibraryID;
            book4.LibraryID = library.LibraryID;
            book5.LibraryID = library.LibraryID;

            book1.library = library;
            book2.library = library;
            book3.library = library;
            book4.library = library;
            book5.library = library;

            context.Libraries.Add(library);
            context.Books.Add(book1);
            context.Books.Add(book2);
            context.Books.Add(book3);
            context.Books.Add(book4);
            context.Books.Add(book5);


            Library library2 = new Library("Brabrand Bibliotek", "Karensvej 124s");

            Book book11 = new Book("The good way of Integration testing", "This book is an excellent guide for Integration testing", "Nicholas Brown", "Education", 200, 100, "English", "9781088474266");
            Book book12 = new Book("The good way of Integration testing part 3", "This book is an excellent guide for Integration testing", "Nicholas Brown", "Education", 200, 100, "English", "9781088474266");
            Book book13 = new Book("The good way of Integration testing part 4", "This book is an excellent guide for Integration testing", "Nicholas Brown", "Education", 200, 100, "English", "9781088474266");
            Book book14 = new Book("The good way of Integration testing part 5", "This book is an excellent guide for Integration testing", "Nicholas Brown", "Education", 200, 100, "English", "9781088474266");
            Book book15 = new Book("The good way of Integration testing part 6", "This book is an excellent guide for Integration testing", "Nicholas Brown", "Education", 200, 100, "English", "9781088474266");

            library2.Books.Add(book11);
            library2.Books.Add(book12);
            library2.Books.Add(book13);
            library2.Books.Add(book14);
            library2.Books.Add(book15);

            book11.LibraryID = library2.LibraryID;
            book12.LibraryID = library2.LibraryID;
            book13.LibraryID = library2.LibraryID;
            book14.LibraryID = library2.LibraryID;
            book15.LibraryID = library2.LibraryID;

            book11.library = library2;
            book12.library = library2;
            book13.library = library2;
            book14.library = library2;
            book15.library = library2;

            context.Libraries.Add(library2);
            context.Books.Add(book11);
            context.Books.Add(book12);
            context.Books.Add(book13);
            context.Books.Add(book14);
            context.Books.Add(book15);

            context.SaveChanges();
        }
    }
}
