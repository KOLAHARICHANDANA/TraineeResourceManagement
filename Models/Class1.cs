using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TraineeResourceManagement.Models
{
    public class Class1
    {
        public int creqid { get; set; }
        public string creqname { get; set; }
        public string cdomain { get; set; }
        public DateTime csdate { get; set; }
        public DateTime cedate { get; set; }
        public int cpmid { get; set; }
        public string cstatus { get; set; }
        public int ctid { get; set; }
        public int cexid { get; set; }
        public int croom { get; set; }
        public string cexename { get; set; }
        public string cpmname { get; set; }
        public List<SelectListItem> lm = new List<SelectListItem>();
        public List<SelectListItem> dm = new List<SelectListItem>();
    }
}
