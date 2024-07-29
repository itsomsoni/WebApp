using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var _categories = CategoriesRepo.GetCategories();
            return View(_categories);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = nameof(Edit);
            var Data = CategoriesRepo.GetCategoriesById(id);

            return View(Data);
            //return Content($"Your Selected Id = {id}");
        }
        [HttpPost]
        public IActionResult Edit(CategoriesModel model)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepo.UpdateCategories(model.CategoryId, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Add()
        {
            ViewBag.Action = nameof(Add);
            return View();
        }
        [HttpPost]
        public IActionResult Add(CategoriesModel model)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepo.AddCategories(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Delete(int CategoryId)
        {
            CategoriesRepo.DeleteCategories(CategoryId);
            return Redirect(nameof(Index));
        }
        public IActionResult AddNew()
        {
            return RedirectToAction(nameof(Add));
        }
    }
}
