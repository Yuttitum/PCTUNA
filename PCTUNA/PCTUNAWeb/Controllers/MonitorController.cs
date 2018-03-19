using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PCTUNAWeb.Models;

namespace PCTUNAWeb.Controllers
{
    public class MonitorController : Controller
    {
        private IOTContext db = new IOTContext();

        public ActionResult Summary()
        {
            IQueryable<Summary> summaries = from
                Ope in db.Operations
                join Emp in db.Employees
                on Ope.EmployeeID equals Emp.ID
                group new { Ope, Emp } by new { Emp.No, Emp.FirstName, Emp.LastName } into OpeEmp
                select new Summary
                {
                    Code = OpeEmp.Key.No,
                    Name = OpeEmp.Key.FirstName,
                    LastName = OpeEmp.Key.LastName,
                    Output = OpeEmp.Sum(SumOutput => SumOutput.Ope.Output)
                };

            return View(summaries.ToList());
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}