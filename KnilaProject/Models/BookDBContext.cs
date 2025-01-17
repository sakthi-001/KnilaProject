﻿using KnilaProject.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace KnilaProject.Models
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options):base(options)
        {

        }
        public DbSet<BookModels> Books { get; set; }
    }
}
