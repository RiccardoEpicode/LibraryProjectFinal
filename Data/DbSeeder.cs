using Library.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            db.Database.Migrate();

            if (!db.Authors.Any())
            {
                db.Authors.AddRange(
                    new Author { Name = "Stephen King" },
                    new Author { Name = "J. K. Rowling" },
                    new Author { Name = "George Orwell" }
                );
            }

            if (!db.Categories.Any())
            {
                db.Categories.AddRange(
                    new Category { Name = "Horror" },
                    new Category { Name = "Fantasy" },
                    new Category { Name = "Dystopian" }
                );
            }

            db.SaveChanges();

            if (!db.Books.Any())
            {
                db.Books.AddRange(
                    new Book
                    {
                        Title = "It",
                        AuthorId = db.Authors.First(a => a.Name == "Stephen King").Id,
                        CategoryId = db.Categories.First(c => c.Name == "Horror").Id,
                        IsAvailable = true
                    },
                    new Book
                    {
                        Title = "Harry Potter and the Philosopher's Stone",
                        AuthorId = db.Authors.First(a => a.Name == "J. K. Rowling").Id,
                        CategoryId = db.Categories.First(c => c.Name == "Fantasy").Id,
                        IsAvailable = true
                    },
                    new Book
                    {
                        Title = "1984",
                        AuthorId = db.Authors.First(a => a.Name == "George Orwell").Id,
                        CategoryId = db.Categories.First(c => c.Name == "Dystopian").Id,
                        IsAvailable = true
                    }
                );
            }

            db.SaveChanges();
        }
    }
}
