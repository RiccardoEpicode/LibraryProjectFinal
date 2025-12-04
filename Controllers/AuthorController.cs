using Library.Models.Entities;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        public IActionResult Index() => View(_service.GetAll());

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Author a)
        {
            _service.Add(a);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_service.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Author a)
        {
            _service.Update(a);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
