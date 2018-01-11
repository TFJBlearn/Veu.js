using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Veu.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Veu()
        {
            return View();
        }

        public void Delete(int ID) 
        {
            OAEntities enty = new OAEntities();

            var user = enty.Users.Where(a => a.Id == ID).FirstOrDefault();

            enty.Entry(user).State = System.Data.EntityState.Deleted;

            int row = enty.SaveChanges();

            Response.Write(row);
            Response.End();
               
        }

        public JsonResult GetDate() 
        {
            OAEntities oa = new OAEntities();

            List<Users> ulist = oa.Users.ToList();

            return Json(ulist, JsonRequestBehavior.AllowGet);
        
        }

    }
}
