using BookLibraryManager.Data;
using BookLibraryManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookLibraryManager.Controllers
{
    public class CategoryController : Controller
    {
        private readonly LibraryDBContext _dbContext;

        public CategoryController(LibraryDBContext libraryDBContext)
        {
            this._dbContext = libraryDBContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _dbContext.Categories;
            return View(categoryList);
        }

        // Create Category : GET
        public IActionResult CreateCategory()
        {
            return View();
        }

        // Create Category : Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Value for Name and Display can't be same.");
            }

            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                TempData["success"] = "Category added successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Error occured, try again.";
                return View(category);
            }

        }

        // Create Category : GET
        public IActionResult EditCategory(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }

            var categoryList = _dbContext.Categories.FirstOrDefault(x => x.Id == categoryId);

            if (categoryList == null)
            {
                return NotFound();
            }
            return View(categoryList);
        }

        // Create Category : Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(int? categoryId, [Bind("Id,Name,DisplayOrder")] Category category)
        {
            if (categoryId != category.Id)
            {
                return NotFound();
            }

            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "Value for Name and Display can't be same.");
            }

            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                TempData["success"] = "Category updated successfully.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Error occured, try again.";
                return View(category);
            }

        }

        // Create Category : GET
        public IActionResult DeleteCategory(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }

            var categoryList = _dbContext.Categories.FirstOrDefault(x => x.Id == categoryId);

            if (categoryList == null)
            {
                return NotFound();
            }
            return View(categoryList);
        }

        // Create Category : Post
        [HttpPost, ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategoryConfirm(int id)
        {
            var categoryList = _dbContext.Categories.Find(id);

            if (categoryList == null) { return NotFound(); }
            try
            {
                _dbContext.Categories.Remove(categoryList);
                _dbContext.SaveChanges();
                TempData["success"] = "Category deleted successfully.";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["error"] = "Error occured, try again.";
                return RedirectToAction("DeleteCategory", new { categoryId = id });
            }

        }
    }
}
