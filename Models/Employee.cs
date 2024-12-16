using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace dynamic_eshop_pro.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Employee_dept.Id))]
        public int DepartmentId { get; set; }
        public string phoneNo {  get; set; }
        public Employee_dept Employee_Dept { get; set; }    
    }
}