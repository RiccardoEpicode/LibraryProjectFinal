using Library.Models.Entities;

namespace Library.Services
{
    public interface IAuthorService
    {
        List<Author> GetAll();
        Author? GetById(int id);
        void Add(Author author);
        void Update(Author author);
        void Delete(int id);
    }
}
