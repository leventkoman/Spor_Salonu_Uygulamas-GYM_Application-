using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GYMWebApp.Repository;
using GYMWebApp.DAL;

namespace GYMWebApp.Models
{
    public class AthleteModel : BaseClass, IOperations<Sporcu>
    {
        public Sporcu Create(Sporcu model)
        {

            if (model != null)
            {
                try
                {
                    Sporcu _tmpSporcu = new Sporcu();
                    _tmpSporcu.Adi = model.Adi;
                    _tmpSporcu.Soyadi = model.Soyadi;
                    _tmpSporcu.Yasi = model.Yasi;
                    db.Sporcu.Add(_tmpSporcu);
                    db.SaveChanges();
                    return _tmpSporcu;
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        public bool DeleteIt(Sporcu model)
        {
            if (model!=null)
            {
                try
                {
                    Sporcu _silinecekSporcu;
                    _silinecekSporcu = db.Sporcu.Find(model.Id);
                    db.Sporcu.Remove(_silinecekSporcu);
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
        
        public IList<Sporcu> ListtAll()
        {
            return db.Sporcu.ToList();
        }
    }
}