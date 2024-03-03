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
    public class GalleryController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        [AllowAnonymous]
        public ActionResult Index()
        {
            var values = context.Galleries.Where(i => i.GalleryApproval).OrderBy(i => i.GalleryRow).ToList();
            return View(values);
        }

        public ActionResult GalleryList()
        {
            var values = context.Galleries.OrderBy(i => i.GalleryRow).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateGallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateGallery(Gallery gallery)
        {
            context.Galleries.Add(gallery);
            context.SaveChanges();
            return RedirectToAction("GalleryList");
        }

        [HttpGet]
        public ActionResult UpdateGallery(int id)
        {
            var value = context.Galleries.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateGallery(Gallery gallery)
        {
            var value = context.Galleries.Find(gallery.GalleryId);
            value.GalleryUrl = gallery.GalleryUrl;
            value.GalleryRow = gallery.GalleryRow;
            value.GalleryApproval = gallery.GalleryApproval;
            context.SaveChanges();
            return RedirectToAction("GalleryList");
        }


        public ActionResult DeleteGallery(int id)
        {
            var value = context.Galleries.Find(id);
            context.Galleries.Remove(value);
            context.SaveChanges();
            return RedirectToAction("GalleryList");
        }

    }
}