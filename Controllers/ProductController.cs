using System;
using System.Linq;
using AudioStore.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
namespace AudioStore.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db) => _db = db;

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            var prod = _db.Products.FirstOrDefault(x => x.ID == id);
            ViewBag.category = _db.Categories.ToList();
            return View(prod);
        }
        
        public IActionResult IndexStore(string currentFilter, string searchString, int? page)
        {
            ViewBag.x = _db.Categories.ToList();
            
            var myList = from s in _db.Products
                         select s;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                myList = myList.Where(s => s.Name.Contains(searchString));
            }
            
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            return View(myList.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet("category/{id}")]
        public IActionResult Category(int id,  int? page,string currentFilter, string searchString)
        {
            var list = _db.Products.Where(x => x.CategoryID == id);
            ViewBag.category = _db.Categories.ToList();
            ViewBag.CurrentFilter = searchString;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(s => s.Name.Contains(searchString));
            }
            int pageSize = 9;
            int pageNumber = (page ?? 1);
           
            return View(list.ToPagedList(pageNumber, pageSize));
        }
    }
}