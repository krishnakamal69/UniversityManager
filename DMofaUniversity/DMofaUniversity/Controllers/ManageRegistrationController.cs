using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMofaUniversity.Models;
using WebGrease.Css.Ast.Selectors;

namespace DMofaUniversity.Controllers
{
    public class ManageRegistrationController : Controller
    {
        //
        // GET: /ManageRegistration/
        public ActionResult ManageRegistrationForm()
        {
            return View();
        }
        [HttpGet]
        public ActionResult RegisterATeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterATeacher(tblUser user)
        {
            int sign = 0;
            string message="";
            tblTeacher teacher = new tblTeacher();
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                teacher = db.tblTeachers.FirstOrDefault(m => m.Email == user.Email);
            }
            if (teacher==null)
            {
                message = "Email not Matched";
                
            }
            else if (user.Code!="R-T001")
            {
                message = "Your Code is wrong";
            }
            else
            {
                tblRole tblRole = new tblRole();
                using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
                {
                    tblRole = db.tblRoles.FirstOrDefault(m => m.Role_Code == user.Code);
                }

                user.User_RoleId = tblRole.RoleID.ToString();
                user.Email = teacher.Email;
                using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
                {
                    db.tblUsers.Add(user);
                    db.SaveChanges();
                    sign = sign + 1;
                }
                if (sign > 0)
                {
                    message = "Hi " + user.UserName + " , You are Registered as a Teacher";
                } 
            }
           
            TempData["m"] = message;
            return View();
        }
        [HttpGet]
        public ActionResult RegisterAStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterAStudent(tblUser user)
        {
            int sign = 0;
            string message = "";
            tblStudent student=new tblStudent();
            using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
            {
                student = db.tblStudents.FirstOrDefault(m => m.Email == user.Email);
            }
            if (student == null)
            {
                message = "Email not Matched";

            }
            else if (user.Code != "R-S001")
            {
                message = "Your Code is wrong";
            }
            else
            {
                tblRole tblRole = new tblRole();
                using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
                {
                    tblRole = db.tblRoles.FirstOrDefault(m => m.Role_Code == user.Code);
                }

                user.User_RoleId = tblRole.RoleID.ToString();
                user.Email = student.Email;
                using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
                {
                    db.tblUsers.Add(user);
                    db.SaveChanges();
                    sign = sign + 1;
                }
                if (sign > 0)
                {
                    message = "Hi " + user.UserName + " , You are Registered as a Student";
                }
            }

            TempData["m"] = message;
            return View();
          }
        [HttpGet]
        public ActionResult RegisterASectionOfficer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterASectionOfficer(tblUser user)
        {
            int sign = 0;
            string message = "";

            if (user.Code != "R-SE001")
            {
                message = "Your Code is wrong";
            }
            else
            {
                tblRole tblRole = new tblRole();
                using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
                {
                    tblRole = db.tblRoles.FirstOrDefault(m => m.Role_Code == user.Code);
                }

                user.User_RoleId = tblRole.RoleID.ToString();
                
                using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
                {
                    db.tblUsers.Add(user);
                    db.SaveChanges();
                    sign = sign + 1;
                }
                if (sign > 0)
                {
                    message = "Hi " + user.UserName + " , You are Registered as a Section Officer";
                }
            }

            TempData["m"] = message;
            return View();

        }


        public ActionResult RegisterAChairman()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterAChairman(tblUser user)
        {
            int sign = 0;
            string message = "";
            tblTeacher teacher = new tblTeacher();
            using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
            {
                teacher = db.tblTeachers.FirstOrDefault(m => m.Email == user.Email);
            }
            if (teacher == null)
            {
                message = "Email not Matched";

            }
            else if (user.Code != "R-C001")
            {
                message = "Your Code is wrong";
            }
            else
            {
                tblRole tblRole = new tblRole();
                using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
                {
                    tblRole = db.tblRoles.FirstOrDefault(m => m.Role_Code == user.Code);
                }

                user.User_RoleId = tblRole.RoleID.ToString();
                user.Email = teacher.Email;
                using (DeptMofaUniversityConn db = new DeptMofaUniversityConn())
                {
                    db.tblUsers.Add(user);
                    db.SaveChanges();
                    sign = sign + 1;
                }
                if (sign > 0)
                {
                    message = "Hi " + user.UserName + " , You are Registered as a Chairman";
                }
            }

            TempData["m"] = message;
            return View();
        }
        [HttpGet]
        public ActionResult ManageLogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ManageLogIn(tblUser user)
        {
            string message = "";
            tblUser oneUser=new tblUser();
            using(DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                oneUser = db.tblUsers.FirstOrDefault(m => m.Email == user.Email && m.User_Password==user.User_Password);
            }
            if (oneUser==null)
            {
                message = " Dear User at first you should Register or Your Email or Password is incorrect";
            }
            else
            {
                Session["Email"] = oneUser.Email;
                return RedirectToAction("Index", "Home");

            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("ManageLogIn", "ManageRegistration");
        }

	}
}