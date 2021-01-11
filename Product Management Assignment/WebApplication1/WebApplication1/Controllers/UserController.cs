using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class UserController : ApiController
    {
        //To get the deatils of register User
        public IHttpActionResult Admin(tbl_admin uc)
        {
            dbmaektingEntities nd = new dbmaektingEntities();
            nd.tbl_admin.Add(new tbl_admin()
            {
                Email=uc.Email,
                Username=uc.Username,
                password=uc.password,
                ConfirmPassword=uc.ConfirmPassword,
                FirstName=uc.FirstName,
                LastName=uc.LastName

            });
            nd.SaveChanges();
            return Ok();
        }
    }
}
