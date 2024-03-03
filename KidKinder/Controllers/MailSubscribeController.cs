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
    public class MailSubscribeController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult MailSubscribeList()
        {
            var values = context.MailSubscribes.ToList();
            return View(values);
        }

        public ActionResult DeleteMailSubscribe(int id)
        {
            var value = context.MailSubscribes.Find(id);
            context.MailSubscribes.Remove(value);
            context.SaveChanges();
            return RedirectToAction("MailSubscribeList");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult NewMailSubscribe(string nameSurname, string email)
        {
            var mailSubscribe = new MailSubscribe()
            {
                NameSurname = nameSurname,
                Email = email
            };
            context.MailSubscribes.Add(mailSubscribe);
            context.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

    }
}