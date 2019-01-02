using Bank2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Search(string q)
        {
            var db = new DBContext();
            var model = new ViewModels.StartPageViewModel();
            model.q = q;
            foreach (var user in db.GetAllUsers())
            {
                if(user.FirstName.Contains(q))
                {
                    var m = new ViewModels.StartPageUserViewModel
                    {
                        Id = user.Id,
                        Name = user.FirstName + " " + user.LastName
                    };
                    model.Users.Add(m);
                }
            }

            return View("Index", model);

        }

        public ActionResult Index()
        {
            var db = new DBContext();
            var model = new ViewModels.StartPageViewModel();

            foreach(var user in db.GetAllUsers())
            {
                var m = new ViewModels.StartPageUserViewModel
                {
                    Id = user.Id,
                    Name = user.FirstName + " " + user.LastName
                };
                model.Users.Add(m);
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}