using IrshadEcommerceWeb.Data;
using IrshadEcommerceWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace IrshadEcommerceWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;            
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
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

                _db.Categories.Add(obj);
                _db.SaveChanges();
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
            Category? category = _db.Categories.FirstOrDefault(c => c.Id ==  Id);
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

                _db.Categories.Update(obj);
                _db.SaveChanges();
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
            Category? category = _db.Categories.FirstOrDefault(c => c.Id == Id);           
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? Id)
        {
            Category? obj = _db.Categories.FirstOrDefault(c => c.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
           
        }
    }
}
