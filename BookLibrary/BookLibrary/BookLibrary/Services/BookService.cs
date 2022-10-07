using BookLibrary.Domain;
using BookLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public void AddBook(string name, string author, int price)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(author) || price <= 0)
            {
                throw new ArgumentException("Invalid arguments");
            }

            var book = new Book()
            {
                Title = name,
                Author = author,
                Price = price
            };

            _bookRepository.Add(book);
        }

        public List<Book> GetBooks()
        {
            return _bookRepository.GetAll();
        }
    }
}
