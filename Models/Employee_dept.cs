using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dynamic_eshop_pro.Models
{
    public class Employee_dept
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
    }
}