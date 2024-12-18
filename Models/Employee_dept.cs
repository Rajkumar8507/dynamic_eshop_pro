using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dynamic_eshop_pro.Models
{
    public class Employee_dept
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Dept_Id { get; set; }
        public string DepartmentName { get; set; }
        List<Employee> elist { get; set; }
    }
}