using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Net.Configuration;
using System.Configuration;
using dynamic_eshop_pro.Models;


namespace dynamic_eshop_pro.DAL
{
    public class Context
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public List<Employee> GetEmployees()
        {
            List<Employee> employeelist = new List<Employee>();
            SqlConnection con=new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select * from Employee", con);
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                Employee emp= new Employee();
                emp.Id=Convert.ToInt32(rd.GetValue(0).ToString());
                emp.Name=rd.GetValue(1).ToString();
                emp.DepartmentId=Convert.ToInt32(rd.GetValue(2).ToString());
                emp.phoneNo=rd.GetValue(3).ToString();
               //emp.Employee_Dept = rd.GetValue(4).ToString();                
                employeelist.Add(emp);
                
               

            }
            con.Close();
            return employeelist;
        }
        public bool AddEmployee(Employee emp)
        {

            SqlConnection con=new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("insert into Employee(Id,name,departmentid,phoneno",con);
            cmd.Parameters.AddWithValue("@Id",emp.Id);
            cmd.Parameters.AddWithValue("@name",emp.Name);
            cmd.Parameters.AddWithValue("@departmentid",emp.DepartmentId);
            cmd.Parameters.AddWithValue("@phoneno", emp.phoneNo);
            con.Open();
            int result=cmd.ExecuteNonQuery();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}