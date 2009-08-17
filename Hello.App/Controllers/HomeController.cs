﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hello.Repo;
using Hello.Utils;
using System.Text;

namespace Hello.App.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private HelloRepoDataContext _repo;

        public HomeController() : this(new HelloRepoDataContext(Settings.ConnectionString)) { }

        public HomeController(HelloRepoDataContext repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            var users = _repo
                .Users
                .Where(u => !u.ShadowAccount)
                .Take(25);

            var userTypes = _repo
                .UserTypes
                .OrderBy(ut => ut.Ordering)
                .ToList();

            ViewData["UserTypes"] = userTypes;

            return View(users);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Join()
        {
            var userTypes = _repo
                .UserTypes
                .OrderBy(ut => ut.Ordering)
                .ToList();

            ViewData["UserTypes"] = userTypes;

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Join(string userType, string tag1, string tag2, string tag3)
        {
            //var twitterUrl = new StringBuilder("http://twitter.com/?status=");

            return Redirect(
                "http://twitter.com/?status=" + 
                Url.Encode(String.Format("@{0} hello !{1} #{2} #{3} #{4}",
                    Settings.TwitterBotUsername,
                    userType,
                    TagHelper.Clean(tag1),
                    TagHelper.Clean(tag2),
                    TagHelper.Clean(tag3))));
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Faq()
        {
            return View();
        }
    }
}
