using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYMWebApp.DAL;
using GYMWebApp.Models;
using System.Data.Entity;
using GYMWebApp.Repository;

namespace GYMWebApp.Controllers
{
    public class OlcumTipiController : BaseController
    {
        private OlcumTipi _olcumtipi=new OlcumTipi();
        private MeasurementTypeModel _mtm=new MeasurementTypeModel();
        public ActionResult Index()
        {
            return View(_mtm.ListtAll());
        }

        public ActionResult Create()
        {
            return View(_olcumtipi);
        }

        [HttpPost]
        public ActionResult Create(OlcumTipi olcumtipi)
        {
            _mtm.Create(olcumtipi);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(OlcumTipi olcumTipi)
        {
            _mtm.DeleteIt(olcumTipi);
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id = 0)
        {

            return View(db.OlcumTipi.Find(id));
        }

        [HttpPost]
        public ActionResult Update(OlcumTipi olcumtipi)
        {
            db.Entry(olcumtipi).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}