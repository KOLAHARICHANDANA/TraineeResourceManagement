using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraineeResourceManagement.Models;


namespace TraineeResourceManagement.Controllers
{
    public class requestController : Controller
    {
        // GET: request

        // GET: request
        public ActionResult projm()
        {

            try
            {
                Database1 m = new Database1();
                int j = (int)Session["pm"];
                string log = m.logins.Where(i => i.loginid == j).Select(i => i.job).FirstOrDefault();
                ViewBag.msg = m.logins.Where(i => i.loginid == j).Select(i => i.username).FirstOrDefault();

                if (log == "PM")
                {

                    var domains = m.trainers.Select(i => i.domain).Distinct();

                    foreach (var i in domains)
                    {
                        c.dm.Add(new SelectListItem() { Text = i.ToString(), Value = i.ToString() });
                    }

                    return View(c);
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

        }
        [HttpPost]
        public ActionResult projm(string req, string dom, DateTime sd, DateTime edn)
        {
            Database1 m = new Database1();
            request r = new request();
            r.domain = dom;
            r.reqname = req;
            r.sdate = sd;
            r.edate = edn;
            r.status = "Requested";
            r.pmid = (int)Session["pm"];
            m.requests.Add(r);
            m.SaveChanges();
            return RedirectToAction("dashboard");

        }

        public ActionResult dashboard()
        {
            List<Class1> l = new List<Class1>();
            try
            {
                Database1 m = new Database1();
                Class1 c = new Class1();
                int j = (int)Session["pm"];
                string log = m.logins.Where(i => i.loginid == j).Select(i => i.job).FirstOrDefault();
                ViewBag.job = log;

                ViewBag.msg = m.logins.Where(i => i.loginid == j).Select(i => i.username).FirstOrDefault();
                if (log != null)
                {
                    var con = m.requests.Select(i => i);
                    if (log == "PM")
                    {
                        con = m.requests.Where(i => i.pmid == j).Select(i => i);
                    }
                    else if (log == "TRAINER")
                    {
                        var x = m.logins.Where(i => i.loginid == j).FirstOrDefault();
                        var y = m.trainers.Where(i => i.tname == x.username).Select(i => i).FirstOrDefault();
                        con = m.requests.Where(i => i.tid ==y.tid && (i.status == "Confirmed" || i.status == "onprocess" || i.status == "onhold" || i.status == "completed"));
                    }

                    foreach (var i in con)
                    {

                        l.Add(new Class1() { creqid = i.reqid, creqname = i.reqname, cdomain = i.domain, cstatus = i.status, });
                    }
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
            return View(l);
        }
        public ActionResult details(int id)
        {
            Database1 m = new Database1();
            Class1 c = new Class1();
            var result = m.requests.Where(i => i.reqid == id).FirstOrDefault();
            c.ctid = result.tid;
            c.csdate = result.sdate;
            c.cedate = result.edate;
            c.croom = result.room;
            c.cexename = m.trainers.Where(i => i.tid == result.tid).Select(i => i.tname).FirstOrDefault();
            ViewBag.pmreqiq = id;
            return View(c);
        }
        public ActionResult confirm(int id)
        {
            try
            {
                Database1 m = new Database1();

                request r = m.requests.Where(i => i.reqid == id).FirstOrDefault();
                r.status = "Confirmed";
                m.SaveChanges();
                return Redirect("dashboard");
            }
            catch (Exception)
            {
                return Redirect("/main/Login");
            }
        }
        public ActionResult cancel(int id)
        {
            try
            {
                Database1 m = new Database1();

                request r = m.requests.Where(i => i.reqid == id).FirstOrDefault();
                r.status = "Cancelled";
                m.SaveChanges();
                return Redirect("dashboard");
            }

            catch (Exception)
            {
                return Redirect("/main/Login");
            }
        }
    }
}
    


