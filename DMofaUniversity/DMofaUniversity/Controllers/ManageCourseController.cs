using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMofaUniversity.Models;

namespace DMofaUniversity.Controllers
{
    public class ManageCourseController : Controller
    {
        //
        // GET: /ManageCourse/
        public ActionResult SaveCourse()
        {
            List<tblSemester> listofSemesters = new List<tblSemester>();
            using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
            {
                listofSemesters = db.tblSemesters.ToList();
            }
            ViewBag.semester = listofSemesters;
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourse(tblCourse tblCourse)
        {
            List<tblSemester> listofSemesters=new List<tblSemester>();
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                listofSemesters = db.tblSemesters.ToList();
            }
            ViewBag.semester = listofSemesters;
            int sign = 0;
            string message = "";
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                db.tblCourses.Add(tblCourse);
                db.SaveChanges();
                sign = sign + 1;
            }
            if (sign > 0)
            {
                message = tblCourse.Course_Title + " is successfully saved as a " + tblCourse.MajorNonMajor +
                          " course with " + tblCourse.Credit + " credits";
            }
            TempData["message"] = message;
            return View();
        }
	}
}