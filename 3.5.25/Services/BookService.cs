using System.Collections.Generic;
using _3._5._25.Models;
using _3._5._25.Repositories;

namespace _3._5._25.Services
{
    public class BookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> GetAllBooks() => _repository.GetAllBooks();
        public Book GetBookById(int id) => _repository.GetBookById(id);
        public void AddBook(Book book) => _repository.AddBook(book);
        public void UpdateBook(Book book) => _repository.UpdateBook(book);
        public void DeleteBook(int id) => _repository.DeleteBook(id);
        public List<Book> Search(string keyword) => _repository.Search(keyword);
    }
}
