using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMofaUniversity.Models;

namespace DMofaUniversity.Controllers
{
    public class ManageCourseTeacherController : Controller
    {
        //
        // GET: /ManageCourseTeacher/
        public ActionResult SaveCourseToTeacher()
        {
            List<tblSemester> listOfSemester = new List<tblSemester>();
            List<tblTeacher> listOfteacher = new List<tblTeacher>();
            using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
            {
                listOfSemester = db.tblSemesters.ToList();
                listOfteacher = db.tblTeachers.ToList();
            }
            ViewBag.semesters = listOfSemester;
            ViewBag.teachers = listOfteacher;
            return View();
        }
        [HttpPost]
        public ActionResult SaveCourseToTeacher(tblTeacherCourseAssign courseAssign)
        {
            string message = "";
            int sign = 0;
            List<tblSemester> listOfSemester = new List<tblSemester>();
            List<tblTeacher> listOfteacher = new List<tblTeacher>();
            using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
            {
                listOfSemester = db.tblSemesters.ToList();
                listOfteacher = db.tblTeachers.ToList();
            }
            ViewBag.semesters = listOfSemester;
            ViewBag.teachers = listOfteacher;
            string email = "";
            tblTeacher teacher=new tblTeacher();
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                teacher = db.tblTeachers.FirstOrDefault(m => m.TeacherID == courseAssign.TeacherId);
            }
            courseAssign.TeacherEmail = teacher.Email;
            using (CourseAssignConn db=new CourseAssignConn())
            {
                db.tblTeacherCourseAssigns.Add(courseAssign);
                db.SaveChanges();
                sign = sign + 1;
            }
            tblCourse course=new tblCourse();
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                course = db.tblCourses.FirstOrDefault(m => m.CID == courseAssign.CID);
            }
            if (sign>0)
            {
                message = course.Course_Title + " is assigned to " + teacher.Name;
            }
            TempData["m"] = message;
            return View();
        }
        public JsonResult GetCousreBySemesterId(int Semesterid)
        { 
            List<tblCourse>courseList=new List<tblCourse>();
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                courseList = db.tblCourses.Where(m=>m.SID==Semesterid).ToList();
            }
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }
	}
}