using BookLibrary.Domain;
using BookLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Services
{
    public interface IBookService
    {
        public void AddBook(string name, string author, int price);

        public List<Book> GetBooks();
    }
}
