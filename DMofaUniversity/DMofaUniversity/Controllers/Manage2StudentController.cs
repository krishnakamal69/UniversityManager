using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMofaUniversity.Models;

namespace DMofaUniversity.Controllers
{
    public class Manage2StudentController : Controller
    {
        //
        // GET: /Manage2Student/
        public ActionResult SaveStudent()
        {
            List<tblSemester> listofsemester=new List<tblSemester>();
            List<tblSesson> listofSessons=new List<tblSesson>();
            List<tblBatch> listofBatches=new List<tblBatch>();
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                listofBatches = db.tblBatches.ToList();
                listofSessons = db.tblSessons.ToList();
                listofsemester = db.tblSemesters.ToList();
            }
            ViewBag.semester = listofsemester;
            ViewBag.batch = listofBatches;
            ViewBag.sesson = listofSessons;
            return View();
        }
        [HttpPost]
        public ActionResult SaveStudent(tblStudent student)
        {
            List<tblSemester> listofsemester = new List<tblSemester>();
            List<tblSesson> listofSessons = new List<tblSesson>();
            List<tblBatch> listofBatches = new List<tblBatch>();
            using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
            {
                listofBatches = db.tblBatches.ToList();
                listofSessons = db.tblSessons.ToList();
                listofsemester = db.tblSemesters.ToList();
            }
            ViewBag.semester = listofsemester;
            ViewBag.batch = listofBatches;
            ViewBag.sesson = listofSessons;


            int sign = 0;
            string message = "";
            string fileName = Path.GetFileNameWithoutExtension(student.ImageFile.FileName);
            string extention = Path.GetExtension(student.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
            student.StudentImagePath = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            student.ImageFile.SaveAs(fileName);
            student.Roll = MakeRoll(student);
            using (DeptMofaUniversityStudentConn db=new DeptMofaUniversityStudentConn())
            {
                db.tblStudents.Add(student);
                db.SaveChanges();
                sign = sign + 1;
            }
            if (sign > 0)
            {
                message ="Hi! "+student.Name+", Your are admitted in Department of "+student.Deparment+" and your Roll is "+student.Roll;

            }
            TempData["m"] = message;
            ModelState.Clear();
            return View();
            
        }
        public string MakeRoll(tblStudent students)
        {
            string roll = "B-";
            string lastPart = "";
            string finalRoll = "";
            List<tblStudent> studentofaSemesterOfASemesterList = new List<tblStudent>();
            List<tblSesson> sessonlist = new List<tblSesson>();
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                studentofaSemesterOfASemesterList = db.tblStudents.ToList();
                sessonlist = db.tblSessons.ToList();
            }
            string newSesson = "";
            foreach (tblSesson sesson in sessonlist)
            {
                if (sesson.SessonID == students.SessonID)
                {
                    newSesson = sesson.Sesson;
                }
            }
            char[] sessonChararry = newSesson.ToCharArray();
            for (int i = 0; i < sessonChararry.Length; i++)
            {
                if (i == 2 || i == 3 || i == 7 || i == 8)
                {
                    roll += sessonChararry[i];

                }
            }
            string previousroll = "";
            foreach (tblStudent st in studentofaSemesterOfASemesterList)
            {
                if (st.Roll != null)
                {
                    if (st.SemisterID == students.SemisterID && st.SessonID == students.SessonID)
                    {
                        previousroll = st.Roll;
                    }
                }

            }
            if (previousroll != "")
            {
                char[] previousChararry = previousroll.ToCharArray();
                for (int i = 0; i < previousChararry.Length; i++)
                {
                    if (i == 6 || i == 7 || i == 8)
                    {
                        lastPart += previousChararry[i];
                    }
                }
                int lastpartInteger = Convert.ToInt16(lastPart);
                lastpartInteger += 1;
                finalRoll = roll + lastpartInteger.ToString("D3");
            }
            else
            {
                finalRoll = roll + 1.ToString("D3");
            }


            return finalRoll;
        }

        public ActionResult ShowStudent(tblStudent student)
        {
            tblStudent oneStudent=new tblStudent();
            using (DeptMofaUniversityStudentConn db=new DeptMofaUniversityStudentConn())
            {
                oneStudent = db.tblStudents.FirstOrDefault(s => s.Email == student.Email);
            }
            ViewBag.oneStudent = oneStudent;
            return View();
        }
	}
}