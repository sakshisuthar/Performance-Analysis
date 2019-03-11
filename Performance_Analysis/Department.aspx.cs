using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Department : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = "Data Source=DESKTOP-M8LUGSB\\SQLEXPRESS;Initial Catalog=Result_Analysis;Integrated Security=true";
        Auto_Gen();
    }
    private void Auto_Gen()
    {
        int cnt;
        string id;
        int temp;
        temp = 0;
        cnt = 0;
        id = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Department";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            cnt = int.Parse(rs.GetValue(0).ToString());
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();
        if (cnt > 0)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "select max(Dept_ID) from Department";
            rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                id = rs.GetValue(0).ToString();
            }
            rs.Close();
            cmd.Dispose();
            cn.Close();
            temp = int.Parse(id.Substring(1, 4));
            temp++;
            id = "";
            id = temp.ToString();
            if (id.Length == 1)
            {
                id = "D000" + id;
            }
            else if (id.Length == 2)
            {
                id = "D00" + id;
            }
            else if (id.Length == 3)
            {
                id = "D0" + id;
            }
            else if (id.Length == 4)
            {
                id = "D" + id;
            }
            Textbox1.Text = id;
        }
        else
        {
           Textbox1.Text = "D0001";
        }
    }

    protected void Button_Click(object sender, EventArgs e)
    {
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "insert into Department values('"+Textbox1.Text+"','"+DropdownList1.Text+"','"+Textbox3.Text+"')";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();

        label1.Text = "Successfull";
        Auto_Gen();
       DropdownList1.SelectedIndex = 1;
        Textbox3.Text = "";

    }
}