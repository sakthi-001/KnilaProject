﻿using KnilaProject.IRepository;
using KnilaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KnilaProject.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDBContext _dbContext;

        public BookRepository(BookDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {

            return await _dbContext.Books.OrderBy(e => e.Publisher)
        .ThenBy(e => e.AuthorLastName)
        .ThenBy(e => e.AuthorFirstName).ThenBy(e => e.Title)
        .ToListAsync();
        }
        public async Task<List<BookModel>> GetAllBooksByAuthor()
        {

            return await _dbContext.Books
        .OrderBy(e => e.AuthorLastName)
        .ThenBy(e => e.AuthorFirstName).ThenBy(e => e.Title)
        .ToListAsync();
        }
        public async Task<String> SaveBooks(BookModel bookModel)
        {

            await _dbContext.Books.AddAsync(bookModel);
            _dbContext.SaveChanges();
            return "Data Saved";
        }

        public async Task<String> SaveBulkBook(List<BookModel> lstBooks)
        {

           await _dbContext.Books.AddRangeAsync(lstBooks);
            _dbContext.SaveChanges();
            return "Data Saved";
        }
    public async Task<decimal> GetBookPrice()
    {

        return await _dbContext.Books.Select(s=> s.Price).SumAsync();
    }

      public  async Task<List<BookModel>> GetBooksBasedSort(string sortName)
        {
            var books = await _dbContext.Books
           .FromSqlRaw("EXEC GetBooksBasedSort @SortName = {0}", sortName)
           .ToListAsync();
            return books;
        }
    }
}