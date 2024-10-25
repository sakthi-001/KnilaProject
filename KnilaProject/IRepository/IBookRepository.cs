using KnilaProject.Model.Models;
using KnilaProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace KnilaProject.IRepository
{
    public interface IBookRepository
    {
       Task<List<BookModels>> GetAllBooks();
       Task<List<BookModels>> GetAllBooksByAuthor();
       Task<decimal> GetBookPrice();
       Task<String> SaveBulkBook(List<BookModels> lstBooks);
       Task<String> SaveBooks(BookModels bookModel);
       Task<List<BookModels>> GetBooksBasedSort(string sortName);
    }
}
