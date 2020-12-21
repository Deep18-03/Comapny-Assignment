using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SourceControlAssignment.Models;

namespace SourceControlAssignment.Controllers
{
    
    public class HomeController : Controller
    {
        UserEntities db = new UserEntities();
        public ActionResult Dashboard(int id)
        {
            ViewUser ad = new ViewUser();
            Person p = db.Person.Where(x => x.PersonId == id).SingleOrDefault();
            ad.FirstName = p.FirstName;
            ad.LastName = p.LastName;
            ad.Email = p.Email;
            ad.MobileNo = p.MobileNo;
            ad.Address = p.Address;
            ad.image = p.image;
            ad.Age = p.Age;
            ad.City = p.City;
            ad.State = p.State;

            return View(ad);
        }
        public ActionResult Login_Fail()
        {
            return View();
        }
     
    }
}