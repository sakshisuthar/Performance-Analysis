using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Test_Sem2_ : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = "Data Source=DESKTOP-M8LUGSB\\SQLEXPRESS;Initial Catalog=Result_Analysis;Integrated Security=true";
        string stud_enroll = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Stud_Enrol from Student where Stud_Email='" + Session["Student_Username"] + "'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            stud_enroll = rs.GetValue(0).ToString();
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        SqlDataSource1.SelectCommand = "select * from Semester2_MT where Enroll_No='" + stud_enroll + "'";
  
    }
}