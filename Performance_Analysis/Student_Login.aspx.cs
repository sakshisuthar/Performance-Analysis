using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Student_Login : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = "Data Source=DESKTOP-M8LUGSB\\SQLEXPRESS;Initial Catalog=Result_Analysis;Integrated Security=true";
        if (!IsPostBack)
        {

            Label1.Visible = false;
        }
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int login = 0;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Student_Login where Username='"+Textbox1.Text+"' and Password='"+Textbox2.Text+"'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            login = int.Parse(rs.GetValue(0).ToString());
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        if (login > 0)
        {
            Session["Student_Username"] = Textbox1.Text;
            Response.Redirect("Homepage(Student).aspx");
        }
        else
        {
            Label1.Text = "Incorrect Password";
            Label1.Visible = true;
        }


    }
}