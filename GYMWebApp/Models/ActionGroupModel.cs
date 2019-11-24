using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GYMWebApp.DAL;
using GYMWebApp.Repository;

namespace GYMWebApp.Models
{
    public class ActionGroupModel : BaseClass, IOperations<HareketGrubu>
    {
        public HareketGrubu Create(HareketGrubu model)
        {
            if (model != null)
            {
                try
                {
                    HareketGrubu _tmpHargrup = new HareketGrubu();
                    _tmpHargrup.HareketAdi = model.HareketAdi;
                    db.HareketGrubu.Add(_tmpHargrup);
                    db.SaveChanges();
                    return _tmpHargrup;
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        public bool DeleteIt(HareketGrubu model)
        {
            if (model != null)
            {
                try
                {
                    HareketGrubu _silinecekhargrup;
                    _silinecekhargrup = db.HareketGrubu.Find(model.Id);
                    db.HareketGrubu.Remove(_silinecekhargrup);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        public IList<HareketGrubu> ListtAll()
        {
            return db.HareketGrubu.ToList();
        }

       
    }
}
    
