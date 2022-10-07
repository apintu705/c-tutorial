using BookLibrary;
using BookLibrary.Domain;
using BookLibrary.Services;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace BookLibary.Tests
{
    [Binding]
    public class BookLibrarySteps
    {
        private IBookService _libraryService;
        private string _name, _author;
        private int _price;
        private Exception _exception;
        private List<Book> _books;

        public BookLibrarySteps()
        {
            _libraryService = new BookService();
        }

        [Given(@"I have a book with name ""(.*)""")]
        public void GivenIHaveABookWithName(string name)
        {
            _name = name;
        }
        
        [Given(@"author is ""(.*)""")]
        public void GivenAuthorIs(string author)
        {
            _author = author;
        }
        
        [Given(@"price is ""(.*)""")]
        public void GivenPriceIs(int price)
        {
            _price = price;
        }
        
        [When(@"I add the book the library")]
        public void WhenIAddTheBookTheLibrary()
        {
            try
            {
                _libraryService.AddBook(_name, _author, _price);
            }
            catch(Exception ex)
            {
                _exception = ex;
            }
        }
        
        [Then(@"I should have an error ""(.*)""")]
        public void ThenIShouldHaveAnError(string message)
        {
            Assert.Equal(message, _exception.Message);
        }


        [Then(@"my library would look like this")]
        public void ThenMyLibraryWouldLookLikeThis(Table table)
        {
            var books = _libraryService.GetBooks();
            table.CompareToSet(books);
        }

        [Given(@"I have a library of books")]
        public void GivenIHaveALibraryOfBooks()
        {
        }

        [When(@"I fetch my books")]
        public void WhenIFetchMyBooks()
        {
            _books = _libraryService.GetBooks();
        }

        [Then(@"I should have the following books")]
        public void ThenIShouldHaveTheFollowingBooks(Table table)
        {
            table.CompareToSet(_books);
        }


        [BeforeScenario("addBook")]
        public void AddSampleBookForAdd()
        {
            _libraryService.AddBook("C# in depth", "XYZ", 150);
        }

        [BeforeScenario("listBook")]
        public void AddSampleBookForList()
        {
            _libraryService.AddBook("Harry Potter", "JKR", 100);
            _libraryService.AddBook("Harry Potter 2", "JKR", 200);
            _libraryService.AddBook("C# in depth", "XYZ", 150);
        }
    }
}
