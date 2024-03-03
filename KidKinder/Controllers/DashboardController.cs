using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidKinder.Context;
using KidKinder.Entities;

namespace KidKinder.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            ViewBag.ResimÇizmeCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "Resim Çizim").Select(y => y.BranchId).FirstOrDefault()).Count();
            ViewBag.AvgPrice = context.ClassRooms.Average(x => x.Price).ToString("0.00");
            ViewBag.ToplamResimSayisi = context.Galleries.Count().ToString();
            ViewBag.ToplamOkunmamisMesajSayisi = context.Contacts.Where(i => !i.IsRead).Count().ToString();

            // GoogleCharts verileri
            ViewBag.Bugun = context.Contacts.Where(c => c.SendDate.Year == DateTime.Today.Year && c.SendDate.Month == DateTime.Today.Month && c.SendDate.Day == DateTime.Today.Day).Count();
            ViewBag.Bugun1 = context.Contacts.Where(c => c.SendDate.Year == DateTime.Today.Year && c.SendDate.Month == DateTime.Today.Month && c.SendDate.Day == DateTime.Today.Day-1).Count();
            ViewBag.Bugun2 = context.Contacts.Where(c => c.SendDate.Year == DateTime.Today.Year && c.SendDate.Month == DateTime.Today.Month && c.SendDate.Day == DateTime.Today.Day-2).Count();

            return View();
        }
    }
}













