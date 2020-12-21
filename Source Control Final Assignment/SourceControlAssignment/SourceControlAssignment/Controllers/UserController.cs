using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SourceControlAssignment.Models;
using NLog;


namespace SourceControlAssignment.Controllers
{
    public class UserController : Controller
    {
        UserEntities dbmodel = new UserEntities();

        //Log into file.
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //Log into database.
        readonly Logger loggerDB = LogManager.GetLogger("databaseLogger");

        // GET: User/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        public ActionResult Login(Person user)
        {
            logger.Info("Entering the login Controller. Login method");

            try
            {
                Person ad = dbmodel.Person.Where(x => x.Email == user.Email && x.Password == user.Password).SingleOrDefault();

                if (ad != null)
                {
                    logger.Info("Exit login controller.Login success! " + DateTime.Now);
                    loggerDB.Info("Login Successfully");
            
                    Session["PersonId"] = user.PersonId;
                    Session["Email"] = user.Email;
                    Session["FirstName"] = user.FirstName;


                    return RedirectToAction("Dashboard", "Home", new { id=ad.PersonId});

                }
                else
                {
                    logger.Info("Exit login controller.Login Failure:-( "+ DateTime.Now);
                    loggerDB.Info("Login Failure:-(");
                    
                    return RedirectToAction("Login_Fail", "Home");
                }

                return View("Login");
            }
            catch (Exception e)
            {
                logger.Error("Exception!" + e.Message);
                loggerDB.Error(e.ToString());
                return Content("Exception in login" + e.Message);
            }
           
        }
        // GET: User/RegistrationForm
        public ActionResult RegistrationForm()
        {
            return View();
        }

       // POST: User/RegistrationForm
        [HttpPost]
       public ActionResult RegistrationForm(Person user, HttpPostedFileBase imgfile)
        {
            string path = uploadingimgfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";
            }
            else
            {
                Person ad = new Person();
                ad.FirstName = user.FirstName;
                ad.LastName = user.LastName;
                ad.Email = user.Email;
                ad.MobileNo = user.MobileNo;
                ad.Address = user.Address;
                ad.Age = user.Age;
                ad.City = user.City;
                ad.State = user.State;
                ad.Birthdate = user.Birthdate;
                ad.Confirm_Password = user.Confirm_Password;
                ad.Password = user.Confirm_Password;
                ad.Gender = user.Gender;
                ad.image = path;
                dbmodel.Person.Add(ad);
                dbmodel.SaveChanges();
                return RedirectToAction("Login");
            }

            
            

            
            return View();
        }

        //Logut Method
        public ActionResult Logout()
        {
            logger.Info("Logout Successffuly" + DateTime.Now);
            loggerDB.Info("Logout Successfully");

            Session.Abandon();
            return RedirectToAction("Login", "User");
        }


        //for uploading Image file
        public string uploadingimgfile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/upload/"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);

                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only jpg,jpeg or png formats are acceptable....');</scripts>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please selct a file');</scripts");
                path = "-1";
            }

            return path;

        }//end for image upload
    }
}