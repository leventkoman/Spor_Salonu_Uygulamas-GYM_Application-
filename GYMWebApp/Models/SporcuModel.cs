using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.WebPages.Html;

namespace GYMWebApp.Models
{
    public class SporcuModel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Yasi { get; set; }
        
    }
}