using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GYMWebApp.DAL;

namespace GYMWebApp.Models
{
    public class TariheGoreOlcumListele
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public DateTime Tarih { get; set; }
        public Sporcu sporcular { get; set; }

    }
}