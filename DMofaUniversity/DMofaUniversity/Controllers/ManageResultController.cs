using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using DMofaUniversity.DataAccessLayer;
using DMofaUniversity.Models;
using WebGrease.Css.Ast.Selectors;

namespace DMofaUniversity.Controllers
{
    public class ManageResultController : Controller
    {
        //
        // GET: /ManageResult/
        public ActionResult GetResultSheet()
        {
            
            List<tblSemester> listofSemesters=new List<tblSemester>();
            List<tblSesson> listofSesson=new List<tblSesson>();
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                listofSemesters = db.tblSemesters.ToList();
                listofSesson = db.tblSessons.ToList();
            }
            ViewBag.SemesterList = listofSemesters;
            ViewBag.Sesson = listofSesson;
            return View();
        }
        [HttpPost]
        public ActionResult GetResultSheet(SemesterCourse semesterCourse)
        {
            List<tblSemester> listofSemesters = new List<tblSemester>();
            List<tblSesson> listofSesson = new List<tblSesson>();
            using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
            {
                listofSemesters = db.tblSemesters.ToList();
                listofSesson = db.tblSessons.ToList();
            }
            ViewBag.SemesterList = listofSemesters;
            ViewBag.Sesson = listofSesson;

            StudentOfaSemesterGateway studentOfaSemesterGateway=new StudentOfaSemesterGateway();
            List<tblStudent> studentlist=new List<tblStudent>();
            studentlist = studentOfaSemesterGateway.GetStudentOfaSemester(semesterCourse);
            DeptMofaUniversityConn database=new DeptMofaUniversityConn();
            DataTable dt = new DataTable("Grid");
                    dt.Columns.AddRange(new DataColumn[5]
                { 
                    new DataColumn("StudentID"),
                    new DataColumn("CID"),
                    new DataColumn("FirstMidMark"),
                    new DataColumn("SecondtMidMark"),
                    new DataColumn("Roll"),
             
                });
                var midResults = from midResult in database.tblMidResults
                                     select midResult;
                foreach (var midResult in midResults)
                {
                    dt.Rows.Add(midResult.);
                }
             using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
             }


            return View();
        }
        public JsonResult GetCousreBySemesterId(int SemesterId)
        {   
            string conString = WebConfigurationManager.ConnectionStrings["commonCon"].ToString();
            List<tblCourse>courseList=new List<tblCourse>();
            using (SqlConnection conn=new SqlConnection(conString))
            {
                SqlCommand com = new SqlCommand("select tblCourse.CID,tblCourse.Course_Title from  tblCourse inner join tblTeacherCourseAssign on tblCourse.CID=tblTeacherCourseAssign.CID" +
                                                " where tblTeacherCourseAssign.TeacherEmail='" + (string)Session["Email"] + "' and tblCourse.SID='" + SemesterId + "'", conn);
                conn.Open();
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        tblCourse course=new tblCourse();
                        course.CID = Convert.ToInt16(reader[0]);
                        course.Course_Title = reader[1].ToString();
                        courseList.Add(course);
                    }
                    reader.Close();
                }
            }
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }



	}
}