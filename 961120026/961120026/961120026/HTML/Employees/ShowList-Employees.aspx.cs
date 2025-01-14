﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _961120026.HTML.Employees
{
    public partial class ShowList_Employees : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["Samak"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            sqlcon.Open();
            DataTable n = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID as 'کد سازمانی' , Name as 'نام' , LastName as 'نام خانوادگی' , Part as 'بخش' , Position as 'سمت' FROM Employees UNION SELECT ID as 'کد سازمانی' , Name as 'نام' , LastName as 'نام خانوادگی' , Part as 'بخش' , Position as 'سمت' FROM Management UNION SELECT ID as 'کد سازمانی' , Name as 'نام' , LastName as 'نام خانوادگی'  , Part as 'بخش' , Position as 'سمت' FROM Supervisors ORDER BY [ID]; ", sqlcon);
            da.Fill(n);
            ShowListEmoloyeesGD.DataSource = n;
            ShowListEmoloyeesGD.DataBind();
            
            sqlcon.Close();

        }

        protected void ShowListEmployeesBackBTN_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home-Employees.aspx");
        }

        protected void ShowListEmployeesMoreBTN_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            DataTable n = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ID as 'کد سازمانی' , Name as 'نام' , LastName as 'نام خانوادگی' ,  Gender as 'جنسیت' , Part as 'بخش' , Position as 'سمت' FROM Employees UNION SELECT ID as 'کد سازمانی' , Name as 'نام' , LastName as 'نام خانوادگی', Gender as 'جنسیت' , Part as 'بخش' , Position as 'سمت' FROM Management UNION SELECT ID as 'کد سازمانی' , Name as 'نام' , LastName as 'نام خانوادگی' , Gender as 'جنسیت' , Part as 'بخش' , Position as 'سمت' FROM Supervisors ORDER BY [ID];", sqlcon);
            da.Fill(n);
            ShowListEmoloyeesGD.DataSource = n;
            ShowListEmoloyeesGD.DataBind();
            sqlcon.Close();
        }
    }
}