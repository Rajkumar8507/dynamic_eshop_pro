using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dynamic_eshop_pro.DAL;
using dynamic_eshop_pro.Models;

namespace dynamic_eshop_pro.Controllers
{
    public class EmployeeController : Controller
    {
         Context c=null;
        public EmployeeController()
        {
            c= new Context();
        }
        public ActionResult Index()
        {
            List<Employee> employees = c.GetEmployees();
           


            return View(employees);
        }
        public ActionResult create()
        {
             return View();
        }
        [HttpPost]
        public ActionResult create(Employee e) 
        {
            c.AddEmployee(e);
            return View();
        }
    }
}