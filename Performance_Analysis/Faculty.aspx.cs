using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Faculty : System.Web.UI.Page
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
            GridView1.Visible = true;
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
        cmd.CommandText = "select count(*) from Faculty";
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
            cmd.CommandText = "select max(Faculty_ID) from Faculty";
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
                id = "F000" + id;
            }
            else if (id.Length == 2)
            {
                id = "F00" + id;
            }
            else if (id.Length == 3)
            {
                id = "F0" + id;
            }
            else if (id.Length == 4)
            {
                id = "F" + id;
            }
            Textbox1.Text = id;
        }
        else
        {
            Textbox1.Text = "F0001";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //cn.Open();
        //cmd.Connection = cn;
        //cmd.CommandText = "insert into Faculty values('" + Textbox1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','"+Textbox4.Text+"','"+Textbox5.Text+"','"+DropdownList2.Text+"','"+Textbox7.Text+"','"+DropdownList1.Text+"')";
        //cmd.ExecuteNonQuery();
        //cmd.Dispose();
        //cn.Close();

        //cn.Open();
        //cmd.Connection = cn;
        //cmd.CommandText = "insert into Faculty_Login values('" + Textbox3.Text + "','" + Textbox4.Text + "')";
        //cmd.ExecuteNonQuery();
        //cmd.Dispose();
        //cn.Close();


        //label1.Text = "Successfull";
        //Auto_Gen();
        //Textbox2.Text = "";
        //Textbox3.Text = "";
        //Textbox4.Text = "";
        //Textbox5.Text = "";
        //Textbox7.Text = "";
        //DropdownList2.SelectedIndex = 1;
        //DropdownList1.SelectedIndex = 1;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "update Faculty set Faculty_Name='" + Textbox2.Text + "',Faculty_Email='" + Textbox3.Text + "',Faculty_Subject='"+TextBox6.Text+"',Faculty_Mob='" + Textbox4.Text + "',Faculty_Adress='" + Textbox5.Text + "',Faculty_Gender ='" + DropdownList2.Text + "',Faculty_Age='" + Textbox7.Text + "',Faculty_Dept='" + DropdownList1.Text + "' where Faculty_ID='" + Textbox1.Text + "'";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();

        SqlDataSource1.SelectCommand = "Select *  from Faculty ";
        label1.Text = "Updated Successfully";
        Auto_Gen();

       
        Textbox2.Text = "";
        Textbox3.Text = "";
        Textbox4.Text = "";
        Textbox5.Text = "";
        Textbox7.Text = "";
        DropdownList1.SelectedIndex = 1;
        DropdownList2.SelectedIndex = 1;
       
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "Delete from Faculty where Faculty_ID='" + Textbox1.Text + "'";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();

        SqlDataSource1.SelectCommand = "Select *  from Faculty ";
        label1.Text = "Deleted Successfully";
        Auto_Gen();
     
        Textbox2.Text = "";
        Textbox3.Text = "";
        Textbox4.Text = "";
        Textbox5.Text = "";
        Textbox7.Text = "";
        DropdownList1.SelectedIndex = 1;
        DropdownList2.SelectedIndex = 1;
       
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
       
        Textbox2.Text = "";
        Textbox3.Text = "";
        Textbox4.Text = "";
        Textbox5.Text = "";
        TextBox6.Text = "";
        Textbox7.Text = "";
        DropdownList1.SelectedIndex = 1;
        DropdownList2.SelectedIndex = 1;
        Auto_Gen();
    }
   
    protected void Button1_Click1(object sender, EventArgs e)
    {
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "insert into Faculty values('" + Textbox1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','"+TextBox6.Text+"','" + Textbox4.Text + "','" + Textbox5.Text + "','" + DropdownList2.Text + "','" + Textbox7.Text + "','" + DropdownList1.Text + "')";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "insert into Faculty_Login values('" + Textbox3.Text + "','" + Textbox4.Text + "')";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();


        label1.Text = "Successfull";
        SqlDataSource1.SelectCommand = "select * from Faculty";
        Auto_Gen();
        Textbox2.Text = "";
        Textbox3.Text = "";
        Textbox4.Text = "";
        Textbox5.Text = "";
        TextBox6.Text = "";
        Textbox7.Text = "";
        DropdownList2.SelectedIndex = 1;
        DropdownList1.SelectedIndex = 1;
    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Textbox1.Text = GridView1.SelectedRow.Cells[1].Text;
        Textbox2.Text = GridView1.SelectedRow.Cells[2].Text;
        Textbox3.Text = GridView1.SelectedRow.Cells[3].Text;
        TextBox6.Text = GridView1.SelectedRow.Cells[4].Text;
        Textbox4.Text = GridView1.SelectedRow.Cells[5].Text;
        Textbox5.Text = GridView1.SelectedRow.Cells[6].Text;
        DropdownList2.Text = GridView1.SelectedRow.Cells[7].Text;
        Textbox7.Text = GridView1.SelectedRow.Cells[8].Text;
        DropdownList1.Text = GridView1.SelectedRow.Cells[9].Text;
    }
}