using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Subject_Master : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {

        cn.ConnectionString = "Data Source=DESKTOP-M8LUGSB\\SQLEXPRESS;Initial Catalog=Result_Analysis;Integrated Security=true";
        if (!IsPostBack)
        {
            Auto_Gen();
        }
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
        cmd.CommandText = "select count(*) from Subject_Master";
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
            cmd.CommandText = "select max(SM_ID) from Subject_Master";
            rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                id = rs.GetValue(0).ToString();
            }
            rs.Close();
            cmd.Dispose();
            cn.Close();
            temp = int.Parse(id.Substring(2, 3));
            temp++;
            id = "";
            id = temp.ToString();
            if (id.Length == 1)
            {
                id = "SM00" + id;
            }
            else if (id.Length == 2)
            {
                id = "SM0" + id;
            }
            else if (id.Length == 3)
            {
                id = "SM" + id;
            }
            //else if (id.Length == 4)
            //{
            //    id = "S" + id;
            //}
            Textbox1.Text = id;
        }
        else
        {
            Textbox1.Text = "SM001";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "insert into Subject_Master values('"+Textbox1.Text+"','"+DropdownList1.Text+"','"+DropdownList2.Text+"','"+Textbox2.Text+"','"+Textbox3.Text+"')";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();
 
        Label1.Text = "Successfull";
        Auto_Gen();
     
        Textbox2.Text = "";
        Textbox3.Text = "";
        DropdownList1.SelectedIndex = 0;
        DropdownList2.SelectedIndex = 0;

    }
}