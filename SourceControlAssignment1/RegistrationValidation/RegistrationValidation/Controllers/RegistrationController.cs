using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RegistrationValidation.Models;
using System.IO;

namespace RegistrationValidation.Controllers
{
   

    public class RegistrationController : Controller
    {
        UserDBEntities dbmodel = new UserDBEntities();
        // GET: Registration

        //Get method of Registratiomn form 
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(tbl_user user)
        {

            try {
                //Save user data in database
                dbmodel.tbl_user.Add(user);
                dbmodel.SaveChanges();
                return RedirectToAction("Form");
            }
            catch(Exception e)
            {

            }
            return View("Form");

        }
    }
}