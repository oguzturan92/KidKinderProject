using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Entities;
using KidKinder.Context;
using KidKinder.Models;

namespace KidKinder.Controllers
{
    public class DefaultController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartialHead()
        {
            return PartialView();
        }

        public ActionResult PartialNavBar()
        {
            return PartialView();
        }

        public ActionResult PartialFeature()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }

        public ActionResult PartialService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }

        public ActionResult PartialAbout()
        {
            var model = new AboutModel()
            {
                About = context.Abouts.FirstOrDefault(),
                AboutLists = context.AboutLists.Take(3).ToList()
            };
            return PartialView(model);
        }

        public ActionResult PartialClassRooms()
        {
            var values = context.ClassRooms.OrderByDescending(i => i.ClassRoomId).Take(3).ToList();
            return PartialView(values);
        }

        public ActionResult PartialBookASeat()
        {
            return PartialView();
        }

        public ActionResult PartialTeacher()
        {
            var values = context.Teachers.ToList();
            return PartialView(values);
        }

        public ActionResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

        public ActionResult PartialFooter()
        {
            var adres = context.Addresses.FirstOrDefault();
            return PartialView(adres);
        }

        public ActionResult PartialScript()
        {
            return PartialView();
        }



    }
}