using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GYMWebApp.Models
{
    public class AntremanModel
    {
        public int SporcuId { get; set; }
        public int HarAltGrupId { get; set; }
        public List<SelectListItem> SporcuListele { get; set; }
        public List<SelectListItem> HarAltGrupListele { get; set; }
    }
}