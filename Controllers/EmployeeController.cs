using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dynamic_eshop_pro.DALEntity;
using dynamic_eshop_pro.Models;

namespace dynamic_eshop_pro.Controllers
{
    public class EmployeeController : Controller
    {
         EmployeeContext context=null;
        public EmployeeController()
        {
            context= new EmployeeContext();
        }
        public ActionResult Index()
        {
            List<Employee> elist =context.employees.Include("Employee_Dept").ToList(); 
            return View(elist);
        }
       
        public ActionResult Create()
        {
            List<Employee_dept> dlist=context.employee_dept.ToList();
            List<SelectListItem> selectlist=new List<SelectListItem>();
            foreach(Employee_dept x in dlist)
            {
                selectlist.Add(new SelectListItem() { Text = x.DepartmentName, Value = x.Dept_Id.ToString()});
            }
            ViewData["Dept_id"]= selectlist;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            context.employees.Add(emp); 
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee e=context.employees.Find(id);
            List<Employee_dept> dlist=context.employee_dept.ToList();
            List<SelectListItem> selectlist=new List<SelectListItem>();
            foreach(Employee_dept x in dlist)
            {
                selectlist.Add(new SelectListItem() { Text = x.DepartmentName, Value = x.Dept_Id.ToString() });
            }
            ViewData["Dept_id"]=selectlist;
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            Employee e=context.employees.Find(emp.Id);
            e.Name= emp.Name;
            e.phoneNo=emp.phoneNo;
            e.Dept_id=emp.Dept_id;
           
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]  
        public ActionResult Delete(int id)
        {
            Employee emp = context.employees.Find(id);
            context.employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Employee emp=context.employees.Find(id);   
            return View(emp);
        }
    }
}