using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MarkusLib.Models;

namespace MarkusLib
{
    public class LibContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Lib;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book() { ID = 1, title = "Brothers Kazamarov", author = "Fyodor Dostoyevsky", summary = "One should pray for redemption, rather than punishment."},
                new Book() { ID = 2, title = "Naked Lunch", author = " William S. Burroughs", summary = "The dark and seedy underworld."},
                new Book() { ID = 3, title = "Man's Search for Meaning", author = "Viktor E. Frankyl", summary = "Happiness through suffering."});
        }
    }
}
