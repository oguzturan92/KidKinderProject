using KidKinder.Context;
using KidKinder.Entities;
using KidKinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace KidKinder.Controllers
{
    [Authorize]
    public class BookASeatController : Controller
    {
        KidKinderContext context = new KidKinderContext();

        [HttpGet]
        public ActionResult BookASeatList()
        {
            var values = context.BookASeats.ToList();
            return View(values);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult CreateBookASeat(string name, string email)
        {
            var bookASeat = new BookASeat()
            {
                Name = name,
                Email = email
            };
            context.BookASeats.Add(bookASeat);
            context.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

        public ActionResult DeleteBookASeat(int id)
        {
            var value = context.BookASeats.Find(id);
            context.BookASeats.Remove(value);
            context.SaveChanges();
            return RedirectToAction("BookASeatList");
        }
    }
}