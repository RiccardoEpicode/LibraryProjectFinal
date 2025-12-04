using Library.Models.Entities;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _env;

        public BookController(
            IBookService bookService,
            IAuthorService authorService,
            ICategoryService categoryService,
            IWebHostEnvironment env)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_bookService.GetAll());
        }

        public IActionResult Create()
        {
            ViewBag.Authors = _authorService.GetAll();
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book b, IFormFile? cover)
        {
            if (cover != null)
            {
                string path = Path.Combine(_env.WebRootPath, "uploads", cover.FileName);
                using var stream = System.IO.File.Create(path);
                cover.CopyTo(stream);

                b.CoverImg = "/uploads/" + cover.FileName;
            }

            _bookService.Add(b);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Authors = _authorService.GetAll();
            ViewBag.Categories = _categoryService.GetAll();

            return View(_bookService.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Book b)
        {
            _bookService.Update(b);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
