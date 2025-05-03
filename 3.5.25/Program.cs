using System;
using _3._5._25.Models;
using _3._5._25.Repositories;
using _3._5._25.Services;

namespace _3._5._25
{
    class Program
    {
        static void Main(string[] args)
        {
            IBookRepository repository = new BookRepository();
            BookService service = new BookService(repository);

            while (true)
            {
                Console.WriteLine("\nBook Management System");
                Console.WriteLine("1. View All Books");
                Console.WriteLine("2. View Book by ID");
                Console.WriteLine("3. Add Book");
                Console.WriteLine("4. Update Book");
                Console.WriteLine("5. Delete Book");
                Console.WriteLine("6. Search Books");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            foreach (var book in service.GetAllBooks())
                                Console.WriteLine($"{book.Id}. {book.Title} by {book.Author} ({book.Year})");
                            break;

                        case "2":
                            Console.Write("Enter Book ID: ");
                            int id = int.Parse(Console.ReadLine());
                            var bookById = service.GetBookById(id);
                            if (bookById != null)
                                Console.WriteLine($"{bookById.Id}. {bookById.Title} by {bookById.Author} ({bookById.Year})");
                            else
                                Console.WriteLine("Book not found.");
                            break;

                        case "3":
                            var newBook = new Book();
                            Console.Write("Title: ");
                            newBook.Title = Console.ReadLine();
                            Console.Write("Author: ");
                            newBook.Author = Console.ReadLine();
                            Console.Write("Year: ");
                            newBook.Year = int.Parse(Console.ReadLine());
                            service.AddBook(newBook);
                            Console.WriteLine("Book added successfully.");
                            break;

                        case "4":
                            Console.Write("Enter ID to update: ");
                            var updateBook = new Book();
                            updateBook.Id = int.Parse(Console.ReadLine());
                            Console.Write("Title: ");
                            updateBook.Title = Console.ReadLine();
                            Console.Write("Author: ");
                            updateBook.Author = Console.ReadLine();
                            Console.Write("Year: ");
                            updateBook.Year = int.Parse(Console.ReadLine());
                            service.UpdateBook(updateBook);
                            Console.WriteLine("Book updated.");
                            break;

                        case "5":
                            Console.Write("Enter ID to delete: ");
                            int deleteId = int.Parse(Console.ReadLine());
                            service.DeleteBook(deleteId);
                            Console.WriteLine("Book deleted.");
                            break;

                        case "6":
                            Console.Write("Enter keyword: ");
                            string keyword = Console.ReadLine();
                            var results = service.Search(keyword);
                            if (results.Count == 0)
                                Console.WriteLine("No books found.");
                            else
                                foreach (var b in results)
                                    Console.WriteLine($"{b.Id}. {b.Title} by {b.Author} ({b.Year})");
                            break;

                        case "7":
                            return;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
