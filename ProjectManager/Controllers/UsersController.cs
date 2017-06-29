using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.Controllers
{
    public class UsersController : Controller
    {
       private static ApplicationDbContext _context = new ApplicationDbContext();
       private UserManager<ApplicationUser> _userManger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
       private RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
       
        // GET: User   
        public ActionResult Index()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //_context.Users.ToList()
            return View(_context.Users.ToList());
        }

        public ActionResult RemoveRole(string Id,string roleId)
        {
           
            var Result =_userManger.RemoveFromRole(Id,_roleManager.FindById(roleId).Name);
            return  View();
        }

        public ActionResult AddRole(string Id)
        {
            
            if (Id != null)
            {
                var Result = _userManger.AddToRole(Id, "Manager");
            }
            return View();
        }
    }
};