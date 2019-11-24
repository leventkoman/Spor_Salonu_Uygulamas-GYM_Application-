using GYMWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GYMWebApp.DAL;

namespace GYMWebApp.Models
{
    public class ActionSubGroupModel : BaseClass, IOperations<HareketAltGrubu>
    {
        public HareketAltGrubu Create(HareketAltGrubu model)
        {
            if (model!=null)
            {
                try
                {
                    HareketAltGrubu _tmpHarAltGrup = new HareketAltGrubu();
                    _tmpHarAltGrup.HareketGrupId = model.HareketGrupId;
                    _tmpHarAltGrup.HarAltGrupAdi = model.HarAltGrupAdi;
                    db.HareketAltGrubu.Add(_tmpHarAltGrup);
                    db.SaveChanges();
                    return _tmpHarAltGrup;

                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        public bool DeleteIt(HareketAltGrubu model)
        {
            if (model!=null)
            {
                try
                {
                    HareketAltGrubu _silinecekharaltgrup;
                    _silinecekharaltgrup = db.HareketAltGrubu.Find(model.Id);
                    db.HareketAltGrubu.Remove(_silinecekharaltgrup);
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

        public IList<HareketAltGrubu> ListtAll()
        {
            return db.HareketAltGrubu.ToList();
        }
    }
}