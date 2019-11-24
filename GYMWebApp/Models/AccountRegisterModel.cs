using GYMWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using GYMWebApp.DAL;

namespace GYMWebApp.Models
{
    public class AccountRegisterModel : BaseClass, IOperations<AppUser>
    {
        public AppUser Create(AppUser model)
        {
            if (model!=null)
            {
                try
                {
                    AppUser _tmpAppuser=new AppUser();
                    _tmpAppuser.Name = model.Name;
                    _tmpAppuser.Surname = model.Surname;
                    _tmpAppuser.Email = model.Email;
                    _tmpAppuser.Password = model.Password;
                    _tmpAppuser.RoleId = model.RoleId;
                    db.AppUser.Add(_tmpAppuser);
                    db.SaveChanges();
                    return _tmpAppuser;
                }
                catch
                {
                    return null;
                }
            }

            return null;

        }

        public bool DeleteIt(AppUser model)
        {
            throw new NotImplementedException();
        }

        public IList<AppUser> ListtAll()
        {
            return db.AppUser.ToList();
        }
    }
}