using Microsoft.EntityFrameworkCore;
using ApiCRUD.Models;

namespace ApiCRUD.Data.Db
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; }
    }
}
