using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.Controllers
{
    [Authorize (Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: A
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            if (!ModelState.IsValid)
            {
                return View(context.Users.ToList());
            }
            return View(context.Users.ToList());
        }
    }
}