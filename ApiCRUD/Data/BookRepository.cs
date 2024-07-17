using ApiCRUD.Data.Db;
using ApiCRUD.Data.Interfaces;
using ApiCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCRUD.Data
{
    public class BookRepository : IBookRepository
    {
        public BookRepository(BookDBContext context)
        {
            this.context = context;
        }
        BookDBContext context;

        public async Task<List<Book>> GetAll()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
            return await context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, Book book)
        {
            Book bookFromDb = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (bookFromDb == null) return;
            bookFromDb.Title = book.Title;
            bookFromDb.Author = book.Author;
            bookFromDb.Description = book.Description;
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Book book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }
    }
}
