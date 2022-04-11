using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreStructure.Data;
using CoreStructure.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreStructure.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index1()
        {
            return View(_db.Categories.ToList());
        }

        public IActionResult Index()
        {
            List<CategoryViewModel> categoryList = new List<CategoryViewModel>();
            var items = _db.Categories.ToList();
            foreach (var item in items)
            {
                categoryList.Add(new CategoryViewModel {
                    Id = item.Id,
                    Name=item.Name,
                    Description=item.Description
                });
            }
            return View(categoryList);
        }

        public IActionResult Delete(int? Id) {
            var category = _db.Categories.Find(Id);
            return View(category);
        }
    }
}