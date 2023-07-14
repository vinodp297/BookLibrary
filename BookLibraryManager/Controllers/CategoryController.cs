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
    }
}
