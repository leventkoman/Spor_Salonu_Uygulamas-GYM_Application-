using GYMWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GYMWebApp.DAL;
using GYMWebApp.Models;
using Microsoft.Owin.Security.Provider;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace GYMWebApp.Controllers
{
    public class AccountController : BaseController
    {
        private AccountRegisterModel _arm=new AccountRegisterModel();
        private AppUser _apuser=new AppUser();
        public ActionResult Signin(string returnURL)
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Signin(FormCollection _fc)
        {
            
            string _email = _fc["email"].ToString();
            string _parola = _fc["parola"].ToString();

            var _user = (from _userx in db.AppUser where _userx.Email == _email && _userx.Password == _parola select _userx).FirstOrDefault();

            if (_user!=null)
            {
                Session["Username"] = _user.Name + " " + _user.Surname;
                Session["Userrole"] = _user.AppRole.Role;

                return RedirectToAction("Index", "Anasayfa");
            }

            else
            {
               // ModelState.AddModelError("", "Hatalı e-posta veya yanlış şifre");
                 ViewBag.Loginerror = "Hatalı e-posta veya yanlış şifre";
            }
            
            return null;

        }

        public ActionResult Register()
        {
            
            List<AppRole> roller = db.AppRole.ToList();
            ViewBag.AppRole = new SelectList(roller, "Id", "Role");
            return View(_apuser);

        }

        [HttpPost]
        public ActionResult Register(AppUser appuser,FormCollection _fc)
        {
            var kullanici = db.AppUser.Where(x => x.Email == appuser.Email).FirstOrDefault();
            if (kullanici == null)
            {
                int roleID = Convert.ToInt32(_fc["Role"].ToString());
                appuser.RoleId = roleID;
                _arm.Create(appuser);
                return View("Signin");

            }
            else
            {
                ViewBag.HataMesaji = "Bu kullanıcı adı daha önce alınmıştır.";
                return View("_Error");
            }
           
        }


        public ActionResult RegisterEdit(int id = 0)
        {
            return View(db.AppUser.Find(id));
        }
        public ActionResult RegisterList(int id = 0)
        {
            return View(db.AppUser);
        }
    }
}