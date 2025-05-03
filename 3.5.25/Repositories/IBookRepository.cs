using System.Collections.Generic;
using _3._5._25.Models;

namespace _3._5._25.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
        List<Book> Search(string keyword);
    }
}
