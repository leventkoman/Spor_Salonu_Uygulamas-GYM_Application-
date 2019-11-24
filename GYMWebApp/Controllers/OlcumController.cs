using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYMWebApp.DAL;
using GYMWebApp.Models;
using GYMWebApp.Repository;
using System.Data.Entity;
using System.Web.DynamicData.ModelProviders;

namespace GYMWebApp.Controllers
{
    public class OlcumController : BaseController
    {
        private MeasurementModel _mamodel = new MeasurementModel();
        private Olcum _olcum = new Olcum();
        private Sporcu _sp = new Sporcu();
        OlcumTipi _olctip = new OlcumTipi();

        public ActionResult Index()
        {
            return View(_mamodel.ListtAll());
        }

        public ActionResult Create()
        {
            List<SelectListItem> sporlis = new List<SelectListItem>();
            foreach (var item in db.Sporcu.ToList())
            {
                sporlis.Add(new SelectListItem { Text = item.Adi, Value = item.Id.ToString() });
            }

            ViewBag.SporcuListesi = sporlis;

            List<SelectListItem> olcumtipi = new List<SelectListItem>();
            foreach (var item in db.OlcumTipi.ToList())
            {
                olcumtipi.Add(new SelectListItem { Text = item.OlcumTipi1, Value = item.Id.ToString() });
            }

            ViewBag.OlcumTipiListesi = olcumtipi;
            return View(_olcum);
        }

        [HttpPost]
        public ActionResult Create(Olcum olcum)
        {

            olcum.OlcumTarihi = DateTime.Now;
            _mamodel.Create(olcum);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Olcum olcum)
        {

            _mamodel.DeleteIt(olcum);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id = 0)
        {
            List<SelectListItem> sporlis = new List<SelectListItem>();
            foreach (var item in db.Sporcu.ToList())
            {
                sporlis.Add(new SelectListItem { Text = item.Adi, Value = item.Id.ToString() });
            }

            ViewBag.SporcuListesi = sporlis;

            List<SelectListItem> olcumtipi = new List<SelectListItem>();
            foreach (var item in db.OlcumTipi.ToList())
            {
                olcumtipi.Add(new SelectListItem { Text = item.OlcumTipi1, Value = item.Id.ToString() });
            }

            ViewBag.OlcumTipiListesi = olcumtipi;

            return View(db.Olcum.Find(id));
        }

        [HttpPost]
        public ActionResult Update(Olcum olcum)
        {
            olcum.OlcumTarihi = DateTime.Now;
            db.Entry(olcum).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ListToDate(DateTime? StrDate, DateTime? EnDate, FormCollection _fc)
        {
            var data = db.Olcum
                .Where(o => o.OlcumTarihi >= StrDate && o.OlcumTarihi < EnDate)
                .Select(o => new TariheGoreOlcumListele
                {
                    Adi = o.Sporcu.Adi,
                    Soyadi = o.Sporcu.Soyadi,
                    Tarih = o.OlcumTarihi.Value
                });
            return View(data);
        }

        public ActionResult ListToOlcum(string searchString)
        {
                var olcum = from x in db.Olcum
                    select x;
                if (!String.IsNullOrEmpty(searchString))
                {
                    olcum = olcum.Where(s => s.Id.Equals(searchString));
                }
                return View(olcum.ToList());
        }
    }
}