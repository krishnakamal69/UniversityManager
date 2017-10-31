using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMofaUniversity.Models;

namespace DMofaUniversity.Controllers
{
    public class ManageRoleController : Controller
    {
        //
        // GET: /ManageRole/
        public ActionResult SaveRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveRole(tblRole role)
        {
            int sign = 0;
            string message = "";
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                db.tblRoles.Add(role);
                db.SaveChanges();
                sign = sign + 1;
            }
            if (sign>0)
            {
                message = "the role of a " + role.Role_Name + " is saved aginest the code +("+role.Role_Code+")";
            }
            TempData["m"] = message;
            return View();
        }
	}
}