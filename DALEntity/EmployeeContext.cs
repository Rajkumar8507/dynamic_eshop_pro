using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using dynamic_eshop_pro.Models;

namespace dynamic_eshop_pro.DALEntity
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext():base() 
        {

        }
        protected override void OnModelCreating(DbModelBuilder  ModelBuilder)
        {
            ModelBuilder.Entity<Employee>().ToTable("Employe");
            ModelBuilder.Entity<Employee_dept>().ToTable("Employee_dept");
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Employee_dept> employee_dept {  get; set; }
    }
}