using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GYMWebApp.DAL;
using GYMWebApp.Repository;

namespace GYMWebApp.Models
{
    public class MeasurementTypeModel : BaseClass, IOperations<OlcumTipi>

    {
        public OlcumTipi Create(OlcumTipi model)
        {
            if (model!=null)
            {
                try
                {
                    OlcumTipi _tmpOlcumtipi=new OlcumTipi();
                    _tmpOlcumtipi.OlcumTipi1 = model.OlcumTipi1;
                    db.OlcumTipi.Add(_tmpOlcumtipi);
                    db.SaveChanges();
                    return _tmpOlcumtipi;

                }
                catch
                {
                    return null;
                }
                
            }
            return null;
        }

        public bool DeleteIt(OlcumTipi model)
        {
            if (model!=null)
            {
                try
                {
                    OlcumTipi _silinecekolcumtipi;
                    _silinecekolcumtipi = db.OlcumTipi.Find(model.Id);
                    db.OlcumTipi.Remove(_silinecekolcumtipi);
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

        public IList<OlcumTipi> ListtAll()
        {
            return db.OlcumTipi.ToList();
        }
    }
}