﻿using IrshadEcommerceWeb.Data;
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
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
