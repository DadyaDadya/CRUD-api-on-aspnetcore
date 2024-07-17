using ApiCRUD.Data.Interfaces;
using ApiCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCRUD.Controllers
{
    [Route("api")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        public CRUDController(IBookRepository repository)
        {
            this.repository = repository;
        }
        IBookRepository repository;

        [HttpGet]
        public async Task<List<Book>> Get()
        {
            return await repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await repository.Get(id);
        }

        [HttpPost]
        public async Task Post(Book book)
        {
            await repository.Add(book);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, Book book)
        {
            await repository.Update(id, book);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await repository.Delete(id);
        }
    }
}
