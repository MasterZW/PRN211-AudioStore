using System.Linq;
using AudioStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AudioStore.Models.Entities;
using AudioStore.Helpers.Session;
using AudioStore.Models.Enums;
using AudioStore.Utils.Hash;
using System;

namespace AudioStore.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db) => _db = db;

        [HttpGet("login", Name = "login")]
        public IActionResult Login()
        {
            var user = HttpContext.Session.GetObjects<User>("user");
            if (user != null)
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string pwd)
        {
            if (ModelState.IsValid)
            {
                var hashPassword = Md5.GetMD5(pwd);
                
                var user = _db.Users.FirstOrDefault(us => us.Username == username);
                if (user != null && user.Password == hashPassword)
                {
                    if (user.Role == UserRole.Admin)
                    {
                        return Redirect("/admin");
                    }
                    HttpContext.Session.SetObjects("user", user);
                    HttpContext.Session.SetObjects("role", user.Role);
                    HttpContext.Session.SetString("userName", user.Username);
                    return Redirect("/");
                }
                else
                {
                    ViewBag.error = "Wrong username or password.";
                }
            }
            else
            {
                ViewBag.error = "Login failed";
            }
            return View();
        }

        [HttpPost("logout", Name = "logout")]
        public void Logout()
        {
            HttpContext.Session.Remove("user");
            HttpContext.Session.Remove("userName");
            HttpContext.Session.Remove("role");
        }

        [HttpGet("register", Name = "register")]
        public IActionResult Register() => View();
        
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                var userName = _db.Users.FirstOrDefault(us => us.Username == user.Username);
                var email = _db.Users.FirstOrDefault(us => us.Email == user.Email);
                if (userName == null && email == null)
                {
                    user.Password = Md5.GetMD5(user.Password); //hashing
                    user.AvatarID = 1; //default avatar
                    user.Role = Models.Enums.UserRole.Customer;
                    user.CreateAt = DateTime.Now;
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    return RedirectToAction("login");
                }
                else
                {
                    ViewBag.error = "Username or Email does not exist.";
                }
            }
            return View();
        }
        

        [HttpGet("auth", Name = "auth")]
        public IActionResult Authentication() => View();
    }
}