using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using GYMWebApp.DAL;
using GYMWebApp.Models;
using GYMWebApp.Repository;
using System.Data.Entity;

namespace GYMWebApp.Controllers
{
    public class HareketAltGrupController : BaseController
    {
        private ActionSubGroupModel _actsubgrupmodel=new ActionSubGroupModel();
        private HareketAltGrubu _haraltgrup=new HareketAltGrubu();
        private HareketGrubu _hargrup=new HareketGrubu();
        private ActionGroupModel _actingrupmodel=new ActionGroupModel();
        public ActionResult Index()
        {
            return View(_actsubgrupmodel.ListtAll());
        }

        public ActionResult Create()
        {
            List<HareketGrubu> althar = db.HareketGrubu.ToList();
            ViewBag.HareketAltGrubu = new SelectList(althar, "Id", "HareketAdi");

            return View(_haraltgrup);
        }
        [HttpPost]
        public ActionResult Create(HareketAltGrubu hareketaltgrubu, FormCollection _fc)
        {
            int hargrupId = Convert.ToInt32(_fc["HareketAdi"].ToString());
            hareketaltgrubu.HareketGrupId = hargrupId;
            _actsubgrupmodel.Create(hareketaltgrubu);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(HareketAltGrubu hareketaltgrubu)
        {
            _actsubgrupmodel.DeleteIt(hareketaltgrubu);
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id = 0)
        {
            List<HareketGrubu> althar2 = db.HareketGrubu.ToList();
            ViewBag.HareketAltGrubu2 = new SelectList(althar2, "Id", "HareketAdi");

            return View(db.HareketAltGrubu.Find(id));
        }

        [HttpPost]
        public ActionResult Update(HareketAltGrubu hareketaltgrubu , FormCollection _fc)
        {
            //int hargrupId = Convert.ToInt32(_fc["HareketAdi"].ToString());
            //hareketaltgrubu.HareketGrupId = hargrupId;
            db.Entry(hareketaltgrubu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}