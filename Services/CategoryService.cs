using Library.Data;
using Library.Models.Entities;

namespace Library.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _db;

        public CategoryService(AppDbContext db)
        {
            _db = db;
        }

        public List<Category> GetAll() => _db.Categories.ToList();

        public Category? GetById(int id) => _db.Categories.Find(id);

        public void Add(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var c = _db.Categories.Find(id);
            if (c != null)
            {
                _db.Categories.Remove(c);
                _db.SaveChanges();
            }
        }
    }
}
