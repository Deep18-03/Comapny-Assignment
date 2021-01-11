using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Net.Http;
using NLog;
namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        dbmaektingEntities db = new dbmaektingEntities();

        //Log into file.
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //Log into database.
        readonly Logger loggerDB = LogManager.GetLogger("databaseLogger");


        // GET Method 
        //Provide functionality of Login
        [HttpGet]
        public ActionResult login()
        { 
            return View();
        }
       
        //Post Method
        [HttpPost]
       public ActionResult login(tbl_admin avm)
        {

            logger.Info("Entering the login Controller. Login method");
            
            try
            {
            
                tbl_admin ad = db.tbl_admin.Where(x => x.Email == avm.Email && x.password == avm.password && x.Username == avm.Username ).SingleOrDefault();
               
           
                if (ad != null)
                {
                    logger.Info("Exit login controller.Login success! " + DateTime.Now);
                    loggerDB.Info("Login Successfully");
                   

                    //Session Created
                    Session["ad_id"] = avm.ad_id;
                    Session["Email"] = avm.Email;
                    Session["Username"] = avm.Username;
                    Session["FirstName"] = ad.FirstName;
                    Session["LastName"] = ad.LastName;

                    return RedirectToAction("home", "Homee");

                }
                else
                {
                    loggerDB.Info("Login Failure:-(");
                    logger.Info("Exit login controller.Login Failure:-( " + DateTime.Now);

                    ViewBag.error = "Invalid username or password";
                }

                return View();
            }
            catch (Exception e)
            {
                logger.Error("Exception!" + e.Message);
                loggerDB.Error(e.ToString());
                return Content("Exception in login" + e.Message);
            }
           
        }


        //Provide functionality of Register New user
        public ActionResult RegistrationForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegistrationForm(tbl_admin user)
        {

            if (ModelState.IsValid)
            {
                HttpClient hc = new HttpClient();
                hc.BaseAddress = new Uri("https://localhost:44353/api/user");
                var insertrec = hc.PostAsJsonAsync<tbl_admin>("user", user);
                insertrec.Wait();
                var saverec = insertrec.Result;
                if (saverec.IsSuccessStatusCode)
                {
                    ViewBag.message = "The User " + user.Username + " is Inserted Successfully";
                }
            }

            return View();
        }

        //Provide functionality to user for logout
        public ActionResult Logout()
        {
           
            Session.Abandon();
            return RedirectToAction("login", "Admin");
        }
    }
}