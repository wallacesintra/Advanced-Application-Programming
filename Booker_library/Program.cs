using System.Collections.Generic;

/*
Booker University library maintains an inventory of books. The list includes the details: Author, price, title,
book_number and number of copies of each book. Whenever new books are purchased the librarian adds the book
details into the database. The chief librarian occasionally requests for a list of all the books in the database.
Required
Construct a simple class called book with suitable data members and member functions to:-
(i) Insert a new book record into the database
(ii) Display a list of all books in the database
(iii) Write a main function to test the program
*/
namespace Booker_library;

public class Book
{
    public string Author { get; set; }
    public double Price { get; set; }
    public string Title { get; set; }
    public string BookNumber { get; set; }
    public int NumberOfCopies { get; set; }

}

public class Library
{
    private List<Book> bookList = new List<Book>();

    public void AddBook(Book book)
    {
        bookList.Add(book);
    }

    public void DisplayBooks()
    {
        foreach (var book in bookList)
        {
            Console.WriteLine($"Author: {book.Author}, Price: {book.Price}, Title: {book.Title}, Book Number: {book.BookNumber}, Number of Copies: {book.NumberOfCopies}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Library library = new Library();

        library.AddBook(new Book { Author = "J.F Kennedy", Price = 10.0, Title = "Don't die on Job", BookNumber = "BN1", NumberOfCopies = 5 });
        library.AddBook(new Book { Author = "Wallace Wahongo", Price = 15.0, Title = "Introduction to Kotlin", BookNumber = "BN2", NumberOfCopies = 3 });

        library.DisplayBooks();
    }
}
