using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [Authorize]
    public class AboutListController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult AboutListList()
        {
            var values = context.AboutLists.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAboutList()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAboutList(AboutList aboutList)
        {
            context.AboutLists.Add(aboutList);
            context.SaveChanges();
            return RedirectToAction("AboutListList");
        }

        [HttpGet]
        public ActionResult UpdateAboutList(int id)
        {
            var value = context.AboutLists.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAboutList(AboutList aboutList)
        {
            var value = context.AboutLists.Find(aboutList.AboutListId);
            value.Description = aboutList.Description;
            context.SaveChanges();
            return RedirectToAction("AboutListList");
        }


        public ActionResult DeleteAboutList(int id)
        {
            var value = context.AboutLists.Find(id);
            context.AboutLists.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AboutListList");
        }
    }
}