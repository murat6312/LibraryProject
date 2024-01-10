using DataAcces.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {       
        }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MURATEK\\SQLEXPRESS;Database=LibraryDb;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public  DbSet<Author> Authors { get; set; }
        public  DbSet<Book> Books { get; set; }
        public  DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookRent> BookRents { get; set; }


    }
}
