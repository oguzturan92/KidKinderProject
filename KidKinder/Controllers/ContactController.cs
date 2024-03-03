using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Entities;
using KidKinder.Context;

namespace KidKinder.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult ContactHeaderPartial()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult ContactAddressPartial()
        {
            var adres = context.Addresses.FirstOrDefault();
            return PartialView(adres);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult NewMessage(string nameSurname, string email, string subject, string message)
        {
            var contact = new Contact()
            {
                NameSurname = nameSurname,
                Email = email,
                Subject = subject,
                Message = message,
                SendDate = DateTime.Now,
                IsRead = false
            };
            context.Contacts.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Contact");
        }

        public ActionResult ContactList()
        {
            var mesajlar = context.Contacts.OrderByDescending(i => i.SendDate).ToList();
            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult DetailContact(int id)
        {
            var value = context.Contacts.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return View(value);
        }

        public ActionResult DeleteContact(int id)
        {
            var value = context.Contacts.Find(id);
            context.Contacts.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ContactList");
        }
    }
}