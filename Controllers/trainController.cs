using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TraineeResourceManagement.Controllers
{
    public class trainController : Controller
    {
        // GET: train
       
        public ActionResult train()
        {
            try
            {
               Database1  m = new Database1();
                int j = (int)Session["pm"];
                string log = m.logins.Where(i => i.loginid == j).Select(i => i.job).FirstOrDefault();
                ViewBag.msg = m.logins.Where(i => i.loginid == j).Select(i => i.username).FirstOrDefault();

                if (log == "TRAINER")
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
        public ActionResult update(int id)
        {
            ViewBag.con = id;
            return View();


        }
        public ActionResult onhold(int id)
        {

            Database1 m = new Database1();
            request r = m.requests.Where(i => i.reqid == id).FirstOrDefault();
            r.status = "onhold";
            m.SaveChanges();
            return Redirect("/request/dashboard");



        }
        public ActionResult onprocess(int id)
        {

          Database1  m = new Database1();

            request r = m.requests.Where(i => i.reqid == id).FirstOrDefault();

            r.status = "onprocess";
            m.SaveChanges();
            return Redirect("/request/dashboard");


        }
        public ActionResult completed(int id)
        {

           Database1  m = new Database1();

            request r = m.requests.Where(i => i.reqid == id).FirstOrDefault();

            r.status = "completed";
            m.SaveChanges();
            return Redirect("/request/dashboard");



        }
    }
}
