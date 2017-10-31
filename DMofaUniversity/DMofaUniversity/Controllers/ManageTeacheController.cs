using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMofaUniversity.Models;

namespace DMofaUniversity.Controllers
{
    public class ManageTeacheController : Controller
    {
        //
        // GET: /ManageTeache/
        public ActionResult SaveTeache()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveTeache(tblTeacher tblTeacher)
        {
            int sign = 0;
            string message = "";
            string fileName = Path.GetFileNameWithoutExtension(tblTeacher.ImageFile.FileName);
            string extention = Path.GetExtension(tblTeacher.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
            tblTeacher.TeacherImagePath = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            tblTeacher.ImageFile.SaveAs(fileName);
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                db.tblTeachers.Add(tblTeacher);
                db.SaveChanges();
                sign = sign + 1;

            }
            ModelState.Clear();
            if (sign > 0)
            {
                message = tblTeacher.Name + " is added as teacher";
            }
            TempData["message"] = message;
            return View();
         }
        
        public ActionResult ShowTeache(tblTeacher tblTeacher)
        { 
            Models.tblTeacher teacher=new tblTeacher();
            using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
            {
                teacher = db.tblTeachers.FirstOrDefault(m => m.Email == tblTeacher.Email);
            }
            
            ViewBag.ateacher = teacher;
            return View();
        }
	}
}