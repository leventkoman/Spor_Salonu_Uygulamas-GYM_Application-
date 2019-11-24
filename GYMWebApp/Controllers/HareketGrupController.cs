using GYMWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYMWebApp.DAL;
using GYMWebApp.Models;
using System.Data.Entity;

namespace GYMWebApp.Controllers
{
    public class HareketGrupController : BaseController
    {
        private HareketGrubu _hareketgrubu=new HareketGrubu();
        private ActionGroupModel _actgrupmod=new ActionGroupModel();
        public ActionResult Index()
        {
            return View(_actgrupmod.ListtAll());
        }

        public ActionResult Create()
        {
            return View(_hareketgrubu);
        }

        [HttpPost]
        public ActionResult Create(HareketGrubu hareketgrubu)
        {
            _actgrupmod.Create(hareketgrubu);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(HareketGrubu hareketgurubu)
        {
            _actgrupmod.DeleteIt(hareketgurubu);
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id = 0)
        {

            return View(db.HareketGrubu.Find(id));
        }

        [HttpPost]
        public ActionResult Update(HareketGrubu hareketgrubu)
        {
            db.Entry(hareketgrubu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}