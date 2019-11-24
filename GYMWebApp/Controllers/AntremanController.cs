using GYMWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GYMWebApp.DAL;
using GYMWebApp.Models;
using System.Data;
using System.Data.Entity;

namespace GYMWebApp.Controllers
{
    public class AntremanController : BaseController
    {
        private WorkoutModel workoutmodel = new WorkoutModel();
        private Antreman _ant = new Antreman();
        private Sporcu _sp = new Sporcu();
        private HareketAltGrubu _haraltgrup = new HareketAltGrubu();
        private Antreman _silinecek;


        public ActionResult Index()
        {
     
            List<SelectListItem> sporcuant = new List<SelectListItem>();
            foreach (var item in db.Sporcu)
            {
                sporcuant.Add(new SelectListItem { Text = item.Adi+" "+item.Soyadi, Value = item.Id.ToString() });
            }

            ViewBag.Sporcular = sporcuant;
            return View(workoutmodel.ListtAll());
        }

        [HttpPost]
        public ActionResult Index(string Id)
        {
            List<SelectListItem> sporcuant = new List<SelectListItem>();
            foreach (var item in db.Sporcu)
            {                          
                    sporcuant.Add(new SelectListItem { Text = item.Adi + " " + item.Soyadi, Value = item.Id.ToString() });   
            }
            ViewBag.Sporcular = sporcuant;

            int Ids = Convert.ToInt32(Id);         
            var sporcuantreman = (from x in db.Antreman where x.Sporcu.Id == Ids select x).ToList();
            return View(sporcuantreman);
        }

        public ActionResult Create()
        {
            //AntremanModel model = getSporcu();
            List<SelectListItem> sporlis = new List<SelectListItem>();
            foreach (var item in db.Sporcu.ToList())
            {
                sporlis.Add(new SelectListItem { Text = item.Adi + "  " + item.Soyadi, Value = item.Id.ToString() });
            }

            ViewBag.SporcuListesi = sporlis;


            List<SelectListItem> _ant3 = new List<SelectListItem>();
            foreach (var item in db.HareketAltGrubu.ToList())
            {
                _ant3.Add(new SelectListItem { Text = item.HarAltGrupAdi, Value = item.Id.ToString() });

            }

            ViewBag.Antreman2 = _ant3;


            return View(_ant);
        }
        [HttpPost]
        public ActionResult Create(Antreman antreman, FormCollection _fc)
        {
            antreman.HarAltGrupId = antreman.Id;
            workoutmodel.Create(antreman);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Antreman antreman)
        {
            if (_silinecek!=null)
            {
                workoutmodel.DeleteIt(antreman);
            }
           
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id = 0)
        {
            List<SelectListItem> _ant = new List<SelectListItem>();
            foreach (var item in db.Sporcu.ToList())
            {
                _ant.Add(new SelectListItem { Text = item.Adi, Value = item.Id.ToString() });
            }

            ViewBag.Antreman = _ant;


            List<SelectListItem> _ant2 = new List<SelectListItem>();
            foreach (var item in db.HareketAltGrubu.ToList())
            {
                _ant2.Add(new SelectListItem { Text = item.HarAltGrupAdi, Value = item.Id.ToString() });
            }

            ViewBag.Antreman2 = _ant2;
            return View(db.Antreman.Find(id));
        }

        [HttpPost]
        public ActionResult Update(Antreman antreman)
        {

            db.Entry(antreman).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public AntremanModel getSporcu()
        //{
        //    AntremanModel _antlevent = new AntremanModel();
        //    _antlevent.SporcuListele = (from spo in db.Sporcu.ToList()
        //                                select new SelectListItem
        //                                {
        //                                    Selected = false,
        //                                    Text = spo.Adi,

        //                                    Value = spo.Id.ToString()
        //                                }).ToList();
        //    _antlevent.SporcuListele.Insert(0, new SelectListItem
        //    {
        //        Selected = true,
        //        Value = "",
        //        Text = "Seçiniz"
        //    });
        //    return getSporcu();
        //}
    }
}