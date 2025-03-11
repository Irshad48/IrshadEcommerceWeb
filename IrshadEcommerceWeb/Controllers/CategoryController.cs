using IrshadEcommerce.DataAccess.Data;
using IrshadEcommerce.DataAccess.Repository.IRepository;
using IrshadEcommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace IrshadEcommerceWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;            
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(!string.IsNullOrEmpty(obj.Name) && obj.Name.All(char.IsDigit))
            {
                //first parameter is Key - is asp-for set in the view for the model property
                //it will show error below field
                ModelState.AddModelError("Name", "Name should not be only integer, Pls enter valid Name");
            }
            if (obj.DisplayOrder.ToString() == obj.Name)
            {
                //If key is blank and in view asp-validation-summary-view is MOdelOnly then it will display validation at summary level
                //this validation just added as explain to show how it works- in real world, its not valid validation
                ModelState.AddModelError("", "Name and DisplayOrder should not be same");
            }
            if (ModelState.IsValid)
            {

                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? Id)
        {
            if( Id == 0 &&  Id == null)
            {
                return NotFound();
            }
            Category? category = _categoryRepo.Get(c => c.Id ==  Id);
            //other ways 
            //Category? category1 = _db.Categories.Find(CategoryId);
            //Category? category2 = _db.Categories.Where(c => c.Id == CategoryId).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (!string.IsNullOrEmpty(obj.Name) && obj.Name.All(char.IsDigit))
            {
                ModelState.AddModelError("Name", "Name should not be only integer, Pls enter valid Name");
            }
            if (ModelState.IsValid)
            {

                _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == 0 && Id == null)
            {
                return NotFound();
            }
            Category? category = _categoryRepo.Get(c => c.Id == Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? Id)
        {
            Category? obj = _categoryRepo.Get(c => c.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
           
        }
    }
}
