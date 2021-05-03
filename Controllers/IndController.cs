using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraineeResourceManagement.Models;

namespace TraineeResourceManagement.Controllers
{
    public class IndController : Controller
    {
        // GET: Ind
        public ActionResult spoc()
        {
            try
            {
                Database1 m = new Database1();
                int j = (int)Session["pm"];
                string log = m.logins.Where(i => i.loginid == j).Select(i => i.job).FirstOrDefault();
                ViewBag.msg = m.logins.Where(i => i.loginid == j).Select(i => i.username).FirstOrDefault();

                if (log == "SPOC")
                {

                }
                else
                {
                    return Redirect("/main/Login");
                }
            }
            catch (Exception)
            {
                return Redirect("/main/Login");
            }
            return View();
        }
        public ActionResult edit(int id, string dom)
        {
            ViewBag.id = id;
            Database1 m = new Database1();
            Class1 c = new Class1();
            var req = m.requests.Where(i => i.reqid == id).FirstOrDefault();
            c.cpmname = m.logins.Where(i => i.loginid == req.pmid).Select(i => i.username).FirstOrDefault();
            c.csdate = req.sdate;
            c.cedate = req.edate;
            var det = m.trainers.Where(i => i.domain == dom).Select(i => i);
            foreach (var i in det)
            {
                c.lm.Add(new SelectListItem() { Text = i.tname, Value = i.tid.ToString() });
            }
            return View(c);
        }
        [HttpPost]
        public ActionResult edit(int qid, int tn, int room)
        {
            Database1 m = new Database1();

            request r = m.requests.Where(i => i.reqid == qid).FirstOrDefault();
            r.tid = tn;
            r.room = room;
            r.status = "Submitted";
            m.SaveChanges();
            return RedirectToAction("dashboard", "request");
        }
    }
}
