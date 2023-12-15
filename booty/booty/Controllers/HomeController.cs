using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace booty.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult bruh()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Register(FormCollection fc)
        {
            String fname = Convert.ToString(fc["Firstname"]);
            String lname = Convert.ToString(fc["Lastname"]);
            String email = Convert.ToString(fc["Email"]);
            String password = Convert.ToString(fc["Password"]);

            FriendsEntities fe = new FriendsEntities();
            User u = new User();
            u.FirstName = fname;
            u.LastName = lname;
            u.Email = email;
            u.Password = password;
            u.RoleID = 3;

            fe.Users.Add(u);
            fe.SaveChanges();

            return View();
        }

        public ActionResult UserUpdate()
        {
            FriendsEntities rdbe = new FriendsEntities();
            User u = (from a in rdbe.Users
                      where a.UserID == 2
                      select a).FirstOrDefault();


            u.Password = "guapo";
            u.RoleID = 3;
            rdbe.SaveChanges();

            return View();
        }

        public ActionResult UserDelete()
        {
            FriendsEntities rdbe = new FriendsEntities();
            User u = (from a in rdbe.Users
                      where a.UserID == 2
                      select a).FirstOrDefault();
            rdbe.Users.Remove(u);
            rdbe.SaveChanges();

            return View();
        }

        public ActionResult ShowUsers()
        {
            FriendsEntities fe = new FriendsEntities();

            var userList = (from a in fe.Users
                            select a).ToList();

            ViewData["ListOfUsers"] = userList;

            return View();
        }
    }
}
