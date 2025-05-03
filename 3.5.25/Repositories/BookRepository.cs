using System.Collections.Generic;
using System.Linq;
using _3._5._25.Models;

namespace _3._5._25.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", Year = 2008 },
            new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andy Hunt", Year = 1999 },
            new Book { Id = 3, Title = "Design Patterns", Author = "Erich Gamma", Year = 1994 }
        };

        public List<Book> GetAllBooks() => books;

        public Book GetBookById(int id) => books.FirstOrDefault(b => b.Id == id);

        public void AddBook(Book book)
        {
            book.Id = books.Max(b => b.Id) + 1;
            books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existing = GetBookById(book.Id);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.Year = book.Year;
            }
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
                books.Remove(book);
        }

        public List<Book> Search(string keyword)
        {
            keyword = keyword.ToLower();
            return books.Where(b => b.Title.ToLower().Contains(keyword) || b.Author.ToLower().Contains(keyword)).ToList();
        }
    }
}
