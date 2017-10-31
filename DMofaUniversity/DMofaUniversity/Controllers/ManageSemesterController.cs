using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMofaUniversity.Models;

namespace DMofaUniversity.Controllers
{
    public class ManageSemesterController : Controller
    {
        //
        // GET: /ManageSemester/
        public ActionResult SaveSemester()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveSemester(tblSemester tblSemester)
        {
            int sign = 0;
            string message = "";
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                db.tblSemesters.Add(tblSemester);
                db.SaveChanges();
                sign = sign + 1;
            }
            if (sign>0)
            {
                message = tblSemester.Semester + " is successfully saved.";
            }
            TempData["message"] = message;
            return View();
        }
	}
}