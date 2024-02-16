using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Entities;
using KidKinder.Context;

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
            return PartialView();
        }

        public ActionResult PartialClassRooms()
        {
            var values = context.ClassRooms.ToList();
            return PartialView(values);
        }

        public ActionResult PartialBookASeat()
        {
            return PartialView();
        }

        public ActionResult PartialTeacher()
        {
            return PartialView();
        }

        public ActionResult PartialTestimonial()
        {
            return PartialView();
        }

        public ActionResult PartialFooter()
        {
            return PartialView();
        }

        public ActionResult PartialScript()
        {
            return PartialView();
        }



    }
}