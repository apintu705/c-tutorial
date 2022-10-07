using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary.Domain
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }

        public Book(string title, string author, int price)
        {
            Title = title;
            Author = author;
            Price = price;
        }

        public Book()
        {

        }
    }
}
