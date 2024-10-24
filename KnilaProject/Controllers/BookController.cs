using KnilaProject.IRepository;
using KnilaProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnilaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //Sorted by Publishers,Author(last,first) then title
        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<List<BookModel>> GetAllBooks()
        {
            List<BookModel> lstBooks = new List<BookModel>();
            try
            {
                lstBooks=  await _bookRepository.GetAllBooks();
                return lstBooks;
            }
            catch (Exception ex)
            {
                return lstBooks;
            }

        }

        //Sorted by Author(last,first) then title
        [HttpGet]
        [Route("GetAllBooksSortByAuthor")]
        public async Task<List<BookModel>> GetAllBooksByAuthor()
        {
            List<BookModel> lstBooks = new List<BookModel>();
            try
            {
                lstBooks = await _bookRepository.GetAllBooksByAuthor();
                return lstBooks;
            }
            catch (Exception ex)
            {
                return lstBooks;
            }

        }

        //get book price 
        [HttpGet]
        [Route("GetBookPrice")]
        public async Task<decimal> GetAllBookPrice()
        {
            decimal booksPrice = new decimal();
            try
            {
                booksPrice = await _bookRepository.GetBookPrice();
                return booksPrice;
            }
            catch (Exception ex)
            {
                return booksPrice;
            }

        }


        [HttpPost]
        [Route("SaveBook")]
        public async Task<String> SaveBook(BookModel bookModel)
        {
            var response = string.Empty;
            try
            {
                response =  await _bookRepository.SaveBooks(bookModel);
                return response;
            }
            catch (Exception ex)
            {
                return response;
            }

        }


        [HttpPost]
        [Route("SaveBulkBook")]
        public async Task<String> SaveBulkBook(List<BookModel> lstBooks)
        {
            var response = string.Empty;
            try
            {
                response = await _bookRepository.SaveBulkBook(lstBooks);
                return response;
            }
            catch (Exception ex)
            {
                return response;
            }

        }

        //given Publisher based on the api 1 result otherwise given  the result based on author
        [HttpGet("GetBooksBasedSort")]
        public async Task<List<BookModel>> GetBooksBasedSort(string sortName)
        {
            var books = await _bookRepository.GetBooksBasedSort(sortName);
            return books;
        }
    }
}
