using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Student : System.Web.UI.Page
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
        cmd.CommandText = "select count(*) from Student";
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
            cmd.CommandText = "select max(Stud_ID) from Student";
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
                id = "S000" + id;
            }
            else if (id.Length == 2)
            {
                id = "S00" + id;
            }
            else if (id.Length == 3)
            {
                id = "S0" + id;
            }
            else if (id.Length == 4)
            {
                id = "S" + id;
            }
            Textbox1.Text = id;
        }
        else
        {
            Textbox1.Text = "S0001";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //cn.Open();
        //cmd.Connection = cn;
        //cmd.CommandText = "insert into Student values('" + Textbox1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','" +DropdownList4.Text + "','" + Textbox5.Text + "','"+Textbox6.Text+"','"+Textbox7.Text+"','" + DropdownList1.Text + "','" + DropdownList2.Text + "','"+DropdownList3.Text+"')";
        //cmd.ExecuteNonQuery();
        //cmd.Dispose();
        //cn.Close();

        //cn.Open();
        //cmd.Connection = cn;
        //cmd.CommandText = "insert into Student_Login values('" + Textbox5.Text + "','" + Textbox6.Text + "')";
        //cmd.ExecuteNonQuery();
        //cmd.Dispose();
        //cn.Close();

        //label1.Text = "Successfull";
        //Auto_Gen();
        //Textbox2.Text="";
        //Textbox3.Text = "";    
        //Textbox5.Text = "";
        //Textbox6.Text = "";
        //Textbox7.Text = "";
        //DropdownList1.SelectedIndex = 1;
        //DropdownList2.SelectedIndex = 1;
        //DropdownList3.SelectedIndex = 1;
        //DropdownList4.SelectedIndex = 1;

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
    //    cn.Open();
    //    cmd.Connection = cn;
    //    cmd.CommandText = "update Student set Stud_Name='"+Textbox2.Text+"',Stud_Address='"+Textbox3.Text+"',Stud_Gender='"+DropdownList4.Text+"',Stud_Email='"+Textbox5.Text+"',Stud_Mobile='"+Textbox6.Text+"',Stud_Enrol='"+Textbox7.Text+"',Stud_Year='"+DropdownList1.Text+"',Stud_Sem='"+DropdownList2.Text+"',Stud_Dept='"+DropdownList3.Text+"' where Stud_ID='"+Textbox1.Text+"'";
    //    cmd.ExecuteNonQuery();
    //    cmd.Dispose();
    //    cn.Close();

    //    label1.Text = "Updated Successfully";
    //    Auto_Gen();
    //    SqlDataSource1.SelectCommand = "Select * from Student";

    //    Textbox2.Text = "";
    //    Textbox3.Text = "";
    //    Textbox5.Text = "";
    //    Textbox6.Text = "";
    //    Textbox7.Text = "";
    //    DropdownList1.SelectedIndex = 1;
    //    DropdownList2.SelectedIndex = 1;
    //    DropdownList3.SelectedIndex = 1;
    //    DropdownList4.SelectedIndex = 1;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //cn.Open();
        //cmd.Connection = cn;
        //cmd.CommandText = "Delete from Student where Stud_ID='"+Textbox1.Text+"'";
        //cmd.ExecuteNonQuery();
        //cmd.Dispose();
        //cn.Close();

        //label1.Text = "Deleted Successfully";
        //Auto_Gen();
        

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Textbox1.Text = "";
        Textbox2.Text = "";
        Textbox3.Text = "";
        Textbox4.Text = "";
        Textbox5.Text = "";
        Textbox6.Text = "";
        Textbox7.Text = "";
        Textbox8.Text = "";
        DropdownList1.SelectedIndex = 1;
        DropdownList2.SelectedIndex = 1;
        DropdownList3.SelectedIndex = 1;
        DropdownList4.SelectedIndex = 1;
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "insert into Student values('" + Textbox1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','"+Textbox4.Text+"','"+Textbox5.Text+"','" + DropdownList4.Text + "','" + Textbox6.Text + "','" + Textbox7.Text + "','" + Textbox8.Text + "','" + DropdownList1.Text + "','" + DropdownList2.Text + "','" + DropdownList3.Text + "')";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();
        

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "insert into Student_Login values('" + Textbox6.Text + "','" + Textbox7.Text + "')";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();

        label1.Text = "Successfull";
        Auto_Gen();
        Textbox2.Text = "";
        Textbox3.Text = "";
        Textbox4.Text = "";
        Textbox5.Text = "";
        Textbox6.Text = "";
        Textbox7.Text = "";
        Textbox8.Text = "";
        DropdownList1.SelectedIndex = 1;
        DropdownList2.SelectedIndex = 1;
        DropdownList3.SelectedIndex = 1;
        DropdownList4.SelectedIndex = 1;
        GridView1.Visible = true;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
         cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "update Student set Sur_Name='"+Textbox2.Text+"',First_Name='"+Textbox3.Text+"',Middle_Name='"+Textbox4.Text+"',Stud_Address='"+Textbox5.Text+"',Stud_Gender='"+DropdownList4.Text+"',Stud_Email='"+Textbox6.Text+"',Stud_Mobile='"+Textbox7.Text+"',Stud_Enrol='"+Textbox8.Text+"',Stud_Year='"+DropdownList1.Text+"',Stud_Sem='"+DropdownList2.Text+"',Stud_Dept='"+DropdownList3.Text+"' where Stud_ID='"+Textbox1.Text+"'";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();

        SqlDataSource1.SelectCommand = "Select * from Student";
        label1.Text = "Updated Successfully";
        Auto_Gen();
       

        Textbox2.Text = "";
        Textbox3.Text = "";
        Textbox5.Text = "";
        Textbox6.Text = "";
        Textbox4.Text = "";
        Textbox8.Text = "";
        Textbox7.Text = "";
        DropdownList1.SelectedIndex = 1;
        DropdownList2.SelectedIndex = 1;
        DropdownList3.SelectedIndex = 1;
        DropdownList4.SelectedIndex = 1;
   
    }
protected void  Button3_Click1(object sender, EventArgs e)
{
     cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "Delete from Student where Stud_ID='"+Textbox1.Text+"'";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();

        SqlDataSource1.SelectCommand = "Select * from Student";
        label1.Text = "Updated Successfully";
        Auto_Gen();


        Textbox1.Text = "";
        Textbox2.Text = "";
        Textbox3.Text = "";
        Textbox5.Text = "";
        Textbox4.Text = "";
        Textbox8.Text = "";
        Textbox6.Text = "";
        Textbox7.Text = "";
        DropdownList1.SelectedIndex = 1;
        DropdownList2.SelectedIndex = 1;
        DropdownList3.SelectedIndex = 1;
        DropdownList4.SelectedIndex = 1;
}
protected void DropdownList2_SelectedIndexChanged(object sender, EventArgs e)
{

}
protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
{
    Textbox1.Text = GridView1.SelectedRow.Cells[1].Text;
    Textbox2.Text = GridView1.SelectedRow.Cells[2].Text;
    Textbox3.Text = GridView1.SelectedRow.Cells[3].Text;
    Textbox4.Text = GridView1.SelectedRow.Cells[4].Text;
    Textbox5.Text = GridView1.SelectedRow.Cells[5].Text;
    DropdownList4.Text = GridView1.SelectedRow.Cells[6].Text;

    Textbox6.Text = GridView1.SelectedRow.Cells[7].Text;
    Textbox7.Text = GridView1.SelectedRow.Cells[8].Text;
    Textbox8.Text = GridView1.SelectedRow.Cells[9].Text;
    DropdownList1.Text = GridView1.SelectedRow.Cells[10].Text;
    DropdownList2.Text = GridView1.SelectedRow.Cells[11].Text;
    DropdownList3.Text = GridView1.SelectedRow.Cells[12].Text;
}
}