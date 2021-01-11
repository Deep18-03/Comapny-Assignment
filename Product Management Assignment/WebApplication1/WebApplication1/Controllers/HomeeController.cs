using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.IO;
using PagedList;


namespace WebApplication1.Controllers
{
    
    public class HomeeController : Controller
    {
        dbmaektingEntities db = new dbmaektingEntities();
     

        //Home page
        public ActionResult Home()
        {

            return View();
                
        }

        //To add New Product in databse
        public ActionResult Create()
        {
            //table name tbl_categoriess in database for dynamic dropdownlist for Categories
            var CategoryList = db.tbl_categoriess.ToList();
            ViewBag.CategoryList = new SelectList(CategoryList, "Category", "Category");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product cvm,HttpPostedFileBase imgfile)
        {
            string path = uploadingimgfile(imgfile);
            if(path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";
            }
            else
            {
                //To save data in database from ADDProduct
                Product pro = new Product();
                pro.Name = cvm.Name;
                pro.Price = cvm.Price;
                pro.ShortDescription = cvm.ShortDescription;
                pro.Description = cvm.Description;
                pro.Category=cvm.Category;
               
                pro.Quantity = cvm.Quantity;
                pro.Image = path;
                db.Product.Add(pro);
                db.SaveChanges();
                
                return RedirectToAction("Home"); 
            }
            return View();
        }   //end,,,,,,,,,,,,,,,,,,,,

        //It will provide Product List to view
        public ActionResult ViewProduct(int?page,string sortBy)
        {
            
            ViewBag.NameSort = sortBy == "Name" ? "Name_desc" : "Name";
          
            ViewBag.CategorySort = sortBy == "Category" ? "Category_desc" : "Category";

            var products = db.Product.AsQueryable();
            //For sorthing
            switch (sortBy)
            {
                case "Name":
                    products = products.OrderBy(x => x.Name);
                    break;
                case "Name_desc":
                    products = products.OrderBy(x=>x.Name);
                    break;
                case "Category_desc":
                    products = products.OrderBy(x => x.Category);
                    break;
                default:
                    products = products.OrderBy(x => x.pro_id);
                    break;
            }
             
            return View(products.ToPagedList(page ?? 1,6));
        }

        [HttpPost]
        public ActionResult ViewProduct(int? page, string search, string searchby)
        {

            int pagesize = 6, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            //Searching 
            var list = db.Product.Where(x => x.Name.Contains(search)).OrderByDescending(x => x.pro_id).ToList();
            IPagedList<Product> stu = list.ToPagedList(pageindex, pagesize);

            return View(stu);
            
        }


        //Provide details of particular Product
        public ActionResult ViewDetails(int? id)
        {
       
            Prodetails ad = new Prodetails();
            if (id!=null)
            {
                Product p = db.Product.Where(x => x.pro_id == id).SingleOrDefault();
                ad.pro_id = p.pro_id;
                ad.Name = p.Name;
                ad.Image = p.Image;
                ad.Description = p.Description;
                ad.ShortDescription = p.ShortDescription;
                ad.Price = p.Price;
                ad.Quantity = p.Quantity;
                ad.Category = p.Category;


                return View(ad);
            }
            else
            {
                return RedirectToAction("login", "Admin");
            }
        }

        //Provide functionality to Delete product 
        public ActionResult Delete(int? id)
        {

            Product p = db.Product.Where(x => x.pro_id == id).SingleOrDefault();

            db.Product.Remove(p);
            db.SaveChanges();

            return RedirectToAction("ViewProduct");
        }


        //Provide functionality of Image upload
        public string uploadingimgfile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if(file !=null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if(extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg")|| extension.ToLower().Equals(".png"))
               {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/upload/"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);

                    }
                    catch(Exception ex)
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