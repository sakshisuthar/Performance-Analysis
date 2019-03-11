using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Change_Password_Student_t : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = "Data Source=DESKTOP-M8LUGSB\\SQLEXPRESS;Initial Catalog=Result_Analysis;Integrated Security=true";
   

    }
    protected void Button_Click(object sender, EventArgs e)
    {
        int count = 0;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Student_Login where Password='" + Textbox1.Text + "' and Username='" + Session["Student_Username"].ToString() + "'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            count = int.Parse(rs.GetValue(0).ToString());
        } rs.Close();
        cmd.Dispose();
        cn.Close();

        if (count > 0)
        {


            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "update Student_Login set Password='" + Textbox3.Text + "' where Username='" + Session["Student_Username"].ToString() + "'";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
            label1.Text = "Updated Successfully";
        }
        else
        {
            label1.Text = "Incorrect Password";
        }
        Textbox1.Text = "";
        Textbox2.Text = "";
        Textbox3.Text = "";

    }
}