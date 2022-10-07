using BookLibrary.Services;

namespace BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var libraryService = new BookService();
            libraryService.AddBook("Harry Potter 1", "JKR", 100);

            var books = libraryService.GetBooks();
        }
    }
}
