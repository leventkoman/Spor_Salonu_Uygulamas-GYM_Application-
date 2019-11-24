using GYMWebApp.DAL;
using GYMWebApp.Models;
using GYMWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace GYMWebApp.Controllers
{
    public class AnasayfaController : BaseController
    {
        private AthleteModel athmodel = new AthleteModel();
        private Sporcu _sp = new Sporcu();

       private AccountRegisterModel _arm=new AccountRegisterModel();

        public ActionResult RegisterList()
        {
            return View(_arm.ListtAll());
        }

        public ActionResult Index()
        {
            
            if (Session["Userrole"]!=null && Session["Userrole"].ToString()=="Admin")
            {

                return View(athmodel.ListtAll());
            }

            return RedirectToAction("Signin", "Account");

        }

        public ActionResult Signout()
        {

            return View();
        }

        public ActionResult Create()
        {

            return View(_sp);
        }

        [HttpPost]
        public ActionResult Create(Sporcu sporcu)
        {
            athmodel.Create(sporcu);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Sporcu sporcu)
        {
            athmodel.DeleteIt(sporcu);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id=0)
        {
   
            return View(db.Sporcu.Find(id));
        }

        [HttpPost]
        public ActionResult Update(Sporcu sporcu)
        {
            db.Entry(sporcu).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}