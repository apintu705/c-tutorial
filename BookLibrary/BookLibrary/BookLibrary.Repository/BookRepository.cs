using BookLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibrary.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            _books = new List<Book>();
        }

        public void Add(Book book)
        {
            _books.Add(book);
        }

        public List<Book> GetAll()
        {
            return _books.ToList();
        }
    }
}
