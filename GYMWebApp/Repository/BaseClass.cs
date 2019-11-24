using GYMWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYMWebApp.Repository
{
    public class BaseClass
    {
        public WorkOutDBEntities db = new WorkOutDBEntities();
    }
}