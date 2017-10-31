using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMofaUniversity.Models;

namespace DMofaUniversity.Controllers
{
    public class ManageSessonController : Controller
    {
        //
        // GET: /ManageSesson/
        public ActionResult SaveSesson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveSesson(tblSesson tblSesson)
        {
            int sign = 0;
            string message = "";
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                db.tblSessons.Add(tblSesson);
                db.SaveChanges();
                sign = sign = 1;
            }
            if (sign>0)
            {
                message = tblSesson.Sesson + " is successfully saved";
            }
            TempData["messge"] = message;
            return View();
            
        }
	}
}