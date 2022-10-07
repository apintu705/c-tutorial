using BookLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibrary.Repository
{
    public interface IBookRepository
    {
        public void Add(Book book);

        public List<Book> GetAll();
    }
}
