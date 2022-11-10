using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudioStore.Models;
using AudioStore.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace AudioStore.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db) => _db = db;

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet("product")]
        public IActionResult IndexProduct(string currentFilter, string searchString, int? page)
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

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(myList.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet("product/detail")]
        public async Task<IActionResult> DetailProduct(int id)
        {
            ViewBag.x = _db.Categories.ToList();

            var exits = await _db.Products.Where(x => x.ID == id).FirstOrDefaultAsync();
            return View(exits);
        }

        [HttpGet("product/create")]
        public IActionResult CreateProduct()
        {
            ViewBag.z = _db.Products.ToList();
            // ViewBag.x = _db.Categories.ToList();
            IEnumerable<Category> categories = _db.Categories.ToList();
            SelectList cateList = new SelectList(categories, "ID", "Name");
            ViewBag.cate = cateList;
            
            return View();
        }

        [HttpPost("product/create")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Add(product);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("IndexProduct");

                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, $"{e.Message}");
                }
            }
            ModelState.AddModelError(string.Empty, $"Create fail");
            return View(product);
        }

        [HttpGet("product/delete")]
        public async Task<IActionResult> DeleteProduct(int id, Product product)
        {
            try
            {
                var exits = _db.Products.Where(x => x.ID == id).FirstOrDefault();
                if (exits != null)
                {
                    _db.Remove(exits);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("IndexProduct");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return View();
        }

        [HttpGet("product/edit")]
        public async Task<IActionResult> EditProduct(int id)
        {
            ViewBag.z = _db.Products.ToList();
            ViewBag.x = _db.Categories.ToList();
            var exits = await _db.Products.Where(x => x.ID == id).FirstOrDefaultAsync();
            return View(exits);
        }

        [HttpPost("product/edit")]
        public async Task<IActionResult> EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exits = _db.Products.Where(x => x.ID == product.ID).FirstOrDefault();
                    if (exits != null)
                    {
                        exits.Name = product.Name;
                        exits.CategoryID = product.CategoryID;
                        exits.Thumnail = product.Thumnail;
                        exits.Stock = product.Stock;
                        exits.Price = product.Price;
                        exits.Desc = product.Desc;
                        exits.Detail = product.Detail;
                    }
                    await _db.SaveChangesAsync();
                    return RedirectToAction("IndexProduct");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return View();
        }

        //------------------------------------------
        //ACCOUNT
        [HttpGet("account")]
        public IActionResult IndexAccount(string currentFilter, string searchString, int? page)
        {
            var myList = from s in _db.Users
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
                myList = myList.Where(s => s.Username.Contains(searchString));
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(myList.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet("account/detail")]
        public async Task<IActionResult> DetailAccount(int id)
        {
            var exits = await _db.Users.Where(x => x.ID == id).FirstOrDefaultAsync();
            return View(exits);
        }

        //------------------------------------------
        //CATEGORY
        [HttpGet("category")]
        public IActionResult IndexCategory(string currentFilter, string searchString, int? page)
        {
            var myList = from s in _db.Categories
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

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(myList.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet("category/detail")]
        public async Task<IActionResult> DetailCategory(int id)
        {
            var exits = await _db.Categories.Where(x => x.ID == id).FirstOrDefaultAsync();
            return View(exits);
        }

        [HttpGet("category/create")]
        public IActionResult CreateCategory() => View();

        [HttpPost("category/create")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Add(category);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("IndexCategory");

                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, $"erro{e.Message}");
                }
            }
            
            return View(category);
        }

        [HttpGet("category/delete")]
        public async Task<IActionResult> DeleteCategory(Category category)
        {
            try
            {
                var exits = _db.Categories.Where(x => x.ID == category.ID).FirstOrDefault();
                if (exits != null)
                {
                    _db.Remove(exits);
                    await _db.SaveChangesAsync();
                    return Redirect("/admin/category");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return View();
        }

        [HttpGet("category/edit")]
        public async Task<IActionResult> EditCategory(int id)
        {
            var exits = await _db.Categories.Where(x => x.ID == id).FirstOrDefaultAsync();
            return View(exits);
        }

        [HttpPost("category/edit")]
        public async Task<IActionResult> EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exits = _db.Categories.Where(x => x.ID == category.ID).FirstOrDefault();
                    if (exits != null)
                    {
                        exits.Name = category.Name;
                        Console.WriteLine("co update");
                    }
                    await _db.SaveChangesAsync();
                    return RedirectToAction("IndexCategory");
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return View();
        }
        [HttpGet("order")]
         public IActionResult IndexOder( int? page)
        {
            ViewBag.x = _db.Users.ToList();
            var myList = from s in _db.Orders select s;
           
            

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(myList.ToPagedList(pageNumber, pageSize));
        }

        
    }
}