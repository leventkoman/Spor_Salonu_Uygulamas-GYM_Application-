using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace GYMWebApp.Models
{
    public class HareketAltGrupModel
    {
        public int Id { get; set; }
        public string HarAltGrupAdi { get; set; }
        public int HareketGrupId { get; set; }
    }
}