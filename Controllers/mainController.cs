using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace TraineeResourceManagement.Controllers
{
    public class mainController : Controller
    {
        // GET: main
        
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string Uname, string pwd)
        {
            Database1 m = new Database1();
            int log = m.logins.Where(i => i.username == Uname && i.password == pwd).Select(i => i.loginid).FirstOrDefault();
            string job = m.logins.Where(i => i.username == Uname && i.password == pwd).Select(i => i.job).FirstOrDefault();
            if (log != 0 && job == "PM")
            {
                Session["pm"] = log;
                return Redirect("/request/projm");
            }
            if (log != 0 && job == "SPOC")
            {
                Session["pm"] = log;
                return Redirect("/Ind/spoc");
            }
            if (log != 0 && job == "TRAINER")
            {
                Session["pm"] = log;
                return Redirect("/train/train");
            }

            return View("Login");
        }


        public ActionResult logout()
        {
            Session.Abandon();
            return Redirect("/main/Login");
        }
    }
}
    
