using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DMofaUniversity.Models;

namespace DMofaUniversity.Controllers
{
    public class ManageBatchController : Controller
    {
        //
        // GET: /ManageBatch/
        public ActionResult SaveBatch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveBatch(tblBatch tblBatch)
        {
            int sign = 0;
            string message = "";
            using (DeptMofaUniversityConn db=new DeptMofaUniversityConn())
            {
                db.tblBatches.Add(tblBatch);
                db.SaveChanges();
                sign = sign + 1;
            }
            if (sign>0)
            {
                message = tblBatch.Batch + " is Successfully saved.";
            }
            TempData["message"] = message;
            return View();
        }
	}
}