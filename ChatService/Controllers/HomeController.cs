using ChatService.Data;
using ChatService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatService.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
    }
}