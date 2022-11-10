using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudioStore.Helpers.Session;
using AudioStore.Models;
using AudioStore.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AudioStore.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db) => _db = db;

        private T GetSession<T>(string key)
        {
            return HttpContext.Session.GetObjects<T>(key);
        }
       
        public IActionResult Index()
        {   
            var list =_db.Users.ToList();
            ViewBag.oder = _db.Orders.ToList();
            var user = GetSession<User>("user");
            if (user != null)
            {
                ViewBag.user = user;
                return View(list);
            }
            return Redirect("/account/login");
        }

        

    }
}