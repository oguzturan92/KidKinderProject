using KidKinder.Context;
using KidKinder.Entities;
using KidKinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            var model = new AboutModel()
            {
                About = context.Abouts.FirstOrDefault(),
                AboutLists = context.AboutLists.ToList(),
                Services = context.Services.ToList(),
                Teachers = context.Teachers.ToList()
            };
            return View(model);
        }

        public ActionResult AboutList()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            context.Abouts.Add(about);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = context.Abouts.Find(about.AboutId);
            value.BıgImageUrl = about.BıgImageUrl;
            value.Header = about.Header;
            value.Title = about.Title;
            value.Description = about.Description;
            value.SmallImageUrl = about.SmallImageUrl;
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }


        public ActionResult DeleteAbout(int id)
        {
            var value = context.Abouts.Find(id);
            context.Abouts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AboutList");
        }

    }
}