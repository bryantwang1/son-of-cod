using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SonOfCodSeafood.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace SonOfCodSeafood.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly WebsiteDbContext _db;
        private readonly UserManager<WebsiteUser> _userManager;
        private readonly SignInManager<WebsiteUser> _signInManager;

        public RolesController(UserManager<WebsiteUser> userManager, SignInManager<WebsiteUser> signInManager, WebsiteDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Index()
        {
            var roles = _db.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreateRole()
        {
            try
            {
                string roleName = HttpContext.Request.Form["RoleName"];
                _db.Roles.Add(new IdentityRole()
                {
                    Name = roleName,
                    NormalizedName = roleName.ToUpper()
                });
                _db.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully!";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(string roleName)
        {
            var thisRole = _db.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            _db.Roles.Remove(thisRole);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public IActionResult Edit(string id)
        //{
        //    var thisRole = _db.Roles.Where(r => r.Id == id).FirstOrDefault();
        //    return View(thisRole);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(IdentityRole role)
        //{
        //    try
        //    {
        //        var thisRole = _db.Roles.Where(r => r.Id == role.Id).FirstOrDefault();
        //        thisRole.Name = role.Name;
        //        thisRole.NormalizedName = role.Name.ToUpper();
        //        _db.Entry(thisRole).State = EntityState.Modified;
        //        _db.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public IActionResult Manage()
        {
            var roleList = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            var userList = _db.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRoleToUser(string userName, string roleName)
        {
            WebsiteUser user = _db.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            await _userManager.AddToRoleAsync(user, roleName);

            ViewBag.ResultMessage = "Role created successfully!";

            var list = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
                new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            var userList = _db.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;
            return View("Manage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetRoles(string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                WebsiteUser user = _db.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                ViewBag.RolesForThisUser = await _userManager.GetRolesAsync(user);

                var list = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;

                var userList = _db.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
                ViewBag.Users = userList;

            }
            return View("Manage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRoleForUser(string userName, string roleName)
        {
            WebsiteUser user = _db.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            bool inRole = await _userManager.IsInRoleAsync(user, roleName);
            if (inRole)
            {
                int adminCount = 0;
                if(roleName == "Admin")
                {
                    var adminRole = await _db.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefaultAsync();
                    adminCount = await _db.UserRoles.Where(ur => ur.RoleId == adminRole.Id).CountAsync();
                }

                if(adminCount > 1)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                    ViewBag.ResultMessage = "Role removed from this user successfully!";
                }
            }
            else
            {
                ViewBag.ResultMessage = "This user doesn't belong to the selected role.";
            }

            var list = _db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            var userList = _db.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;

            return View("Manage");
        }
    }
}
