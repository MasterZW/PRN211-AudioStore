using System;
using System.Dynamic;
using System.Linq;
using AudioStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AudioStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db) => _db = db;
        public IActionResult Index()
        {
            ViewBag.x = _db.Categories.ToList();
            var list = _db.Products.ToList();
            return View(list);
        }

        [HttpGet("category/{id}")]
        public IActionResult ViewByCategory(int id)
        {
            var list = _db.Products.Where(x => x.CategoryID == id);
            ViewBag.category = _db.Categories.ToList();
            return View(list);
        }
    }
}
