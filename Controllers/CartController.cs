using System;
using System.Collections.Generic;
using System.Linq;
using AudioStore.Helpers.Session;
using AudioStore.Models;
using AudioStore.Models.Entities;
using AudioStore.ViewModel.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AudioStore.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        //Dependency Injection
        private readonly ApplicationDbContext _db;
        public CartController(ApplicationDbContext db) => _db = db;
        public const string CARTKEY = "cart";
        OrderDetail orderDetail;

        List<CartItem> GetCartItems()
        {
            var cart = HttpContext.Session.GetString(CARTKEY);
            if (cart != null)
            {
                return GetSession<List<CartItem>>(CARTKEY);
            }
            return new List<CartItem>();
        }

        #region Helper session cart
        private void SaveToSession(List<CartItem> list)
        {
            HttpContext.Session.SetObjects(CARTKEY, list);
        }

        private T GetSession<T>(string key)
        {
            return HttpContext.Session.GetObjects<T>(key);
        }

        private void ClearCart() => HttpContext.Session.Remove(CARTKEY);

        #endregion

        public IActionResult Index()
        {
            var list = GetCartItems();
            return View(list);
        }

        [HttpPost("addcart", Name = "addcart")]
        public void AddToCart(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.ID == id);
            orderDetail = new OrderDetail()
            {
                ProductID = product.ID
            };
            var cart = GetCartItems();
            var cartItem = cart.Find(p => p.Product.ID == id);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem()
                {
                    Product = product,
                    Quantity = 1
                });
            }
            SaveToSession(cart);
        }

        [HttpPost("udpatecart", Name = "updatecart")]
        public IActionResult UpdateCart(int id, int quantity)
        {
            var cart = GetCartItems();
            var cartItem = cart.Find(p => p.Product.ID == id);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
            }
            SaveToSession(cart);
            return Ok();
        }

        [HttpPost("remove", Name = "remove")]
        public void RemoveProductById(int id)
        {
            var listItem = GetCartItems();
            foreach (var item in listItem)
            {
                if (item.Product.ID == id)
                {
                    listItem.Remove(item);
                    Console.WriteLine(item);
                    break;
                }
            }
            if (listItem.Count() > 0)
            {
                SaveToSession(listItem);
            }
            else
            {
                ClearCart();
            }
        }

        [HttpGet("checkout", Name = "checkout")]
        public IActionResult Checkout()
        {
            var user = GetSession<User>("user");
            if (user != null)
            {
                var cart = GetCartItems();
                ViewBag.user = user;
                return View(cart);
            }
            return Redirect("/account/login");
        }

        [HttpPost("checkout")]
        public IActionResult Checkout(double total)
        {
            var cart = GetCartItems();
            var user = GetSession<User>("user");

            var cartItem = cart.Select(c => c.Product);

            var order = new Order()
            {
                UserId = user.ID,
                TotalPrice = cart.Sum(c => c.Product.Price),
                Quantity = cart.Sum(c => c.Quantity)

            };
            _db.Orders.Add(order);
            _db.SaveChanges();
            ClearCart();
            return Redirect("/");
        }
    }
}