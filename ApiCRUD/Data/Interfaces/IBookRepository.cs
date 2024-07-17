using ApiCRUD.Models;

namespace ApiCRUD.Data.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book> Get(int id);
        Task Add(Book book);
        Task Update(int id, Book book);
        Task Delete(int id);
    }
}
