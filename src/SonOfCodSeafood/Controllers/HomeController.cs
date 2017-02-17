using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.Authorization;
using SonOfCodSeafood.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SonOfCodSeafood.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebsiteDbContext _db;
        public HomeController(WebsiteDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Newsletter()
        {
            if(User.IsInRole("Admin"))
            {
                ViewBag.Members = _db.NewsletterMembers.ToList();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Newsletter(NewsletterMember member)
        {
            _db.NewsletterMembers.Add(member);
            _db.SaveChanges();
            return RedirectToAction("Registered");
        }

        public IActionResult Registered()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteMember(int id)
        {
            var member = _db.NewsletterMembers.Where(m => m.NewsletterMemberId == id).FirstOrDefault();
            _db.Remove(member);
            _db.SaveChanges();

            return RedirectToAction("Newsletter");
        }
    }
}
