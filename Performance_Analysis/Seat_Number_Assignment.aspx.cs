using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Seat_Number_Assignment : System.Web.UI.Page
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
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "select Stud_ID,First_Name from Student";
            rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                ListItem item = new ListItem();
                item.Text = rs.GetValue(1).ToString();
                item.Value = rs.GetValue(0).ToString();
                DropdownList1.Items.Add(item);
            }
            rs.Close();
            cmd.Dispose();
            cn.Close();
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
        cmd.CommandText = "select count(*) from Seat_No_Assig";
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
            cmd.CommandText = "select max(Ass_ID) from Seat_No_Assig";
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
                id = "A000" + id;
            }
            else if (id.Length == 2)
            {
                id = "A00" + id;
            }
            else if (id.Length == 3)
            {
                id = "A0" + id;
            }
            else if (id.Length == 4)
            {
                id = "A" + id;
            }
            Textbox1.Text = id;
        }
        else
        {
            Textbox1.Text = "A0001";
        }
    }

    protected void Button_Click(object sender, EventArgs e)
    {
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "insert into Seat_No_Assig values('"+Textbox1.Text+"','"+DropdownList1.Text+"','"+Textbox2.Text+"','"+DropdownList2.Text+"')";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();

        Label1.Text = "Successfull";

        Textbox1.Text = "";
        Textbox2.Text = "";
        DropdownList1.SelectedIndex = 1;
        DropdownList2.SelectedIndex = 1;
    }
}