using KnilaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace KnilaProject.IRepository
{
    public interface IBookRepository
    {
       Task<List<BookModel>> GetAllBooks();
       Task<List<BookModel>> GetAllBooksByAuthor();
       Task<decimal> GetBookPrice();
       Task<String> SaveBulkBook(List<BookModel> lstBooks);
       Task<String> SaveBooks(BookModel bookModel);
       Task<List<BookModel>> GetBooksBasedSort(string sortName);
    }
}
