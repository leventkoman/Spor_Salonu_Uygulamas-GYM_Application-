using GYMWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GYMWebApp.DAL;

namespace GYMWebApp.Models
{
    public class MeasurementModel : BaseClass, IOperations<Olcum>
    {
        public Olcum Create(Olcum model)
        {
            if (model!=null)
            {
                try
                {
                    Olcum _tmpMeasure = new Olcum();
                    _tmpMeasure.SporcuId = model.SporcuId;
                    _tmpMeasure.OlcumTipiId = model.OlcumTipiId;
                    _tmpMeasure.OlcumDegeri = model.OlcumDegeri;
                    _tmpMeasure.OlcumTarihi = model.OlcumTarihi;
                    db.Olcum.Add(_tmpMeasure);
                    db.SaveChanges();
                    return _tmpMeasure;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        public bool DeleteIt(Olcum model)
        {
            if (model!=null)
            {
                try
                {
                    Olcum _silinecekOlcum;
                    _silinecekOlcum = db.Olcum.Find(model.Id);
                    db.Olcum.Remove(_silinecekOlcum);
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

        public IList<Olcum> ListtAll()
        {
            return db.Olcum.ToList();
        }
    }
}