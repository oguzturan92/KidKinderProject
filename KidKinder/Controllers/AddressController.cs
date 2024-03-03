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
    public class AddressController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult AddressList()
        {
            var values = context.Addresses.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAddress(Address address)
        {
            context.Addresses.Add(address);
            context.SaveChanges();
            return RedirectToAction("AddressList");
        }

        [HttpGet]
        public ActionResult UpdateAddress(int id)
        {
            var value = context.Addresses.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAddress(Address address)
        {
            var value = context.Addresses.Find(address.AddressId);
            value.Description = address.Description;
            value.AddressDetail = address.AddressDetail;
            value.Email = address.Email;
            value.Phone = address.Phone;
            value.OpeningHours = address.OpeningHours;
            context.SaveChanges();
            return RedirectToAction("AddressList");
        }


        public ActionResult DeleteAddress(int id)
        {
            var value = context.Addresses.Find(id);
            context.Addresses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AddressList");
        }
    }
}