using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using GYMWebApp.DAL;
using GYMWebApp.Repository;

namespace GYMWebApp.Models
{
    public class WorkoutModel : BaseClass, IOperations<Antreman>
    {
        public Antreman Create(Antreman model)
        {
            if (model!=null)
            {
                try
                {

                    Antreman _tmpAntreman =new Antreman();
                    _tmpAntreman.SporcuId = model.SporcuId;
                    _tmpAntreman.HarAltGrupId = model.HarAltGrupId;
                    db.Antreman.Add(_tmpAntreman);
                    db.SaveChanges();
                    return _tmpAntreman;
                }
                catch
                {
                    throw;
                }
            }

            return null;
        }

        public bool DeleteIt(Antreman model)
        {
            if (model!=null)
            {
                try
                {
                    Antreman _silinecekantreman;
                    _silinecekantreman = db.Antreman.Find(model.Id);
                    db.Antreman.Remove(_silinecekantreman);
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

        public IList<Antreman> ListtAll()
        {
            return db.Antreman.ToList();
        }
    }
}