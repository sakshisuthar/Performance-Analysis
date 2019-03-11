using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Subject_Mapping_Faculty_ : System.Web.UI.Page
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
            cmd.CommandText = "select Faculty_ID,Faculty_Name from Faculty";
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
        cmd.CommandText = "select count(*) from  Subject_Mapping";
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
            cmd.CommandText = "select max(SM_ID) from Subject_Mapping";
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
            //    id = "A" + id;
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
        cmd.CommandText = "insert into Subject_Mapping values('"+Textbox1.Text+"','"+DropdownList1.Text+"','"+DropdownList2.Text+"','"+DropdownList3.Text+"','"+DropdownList4.Text+"')";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();
        Auto_Gen();
       
        Label1.Text = "Successfull";
   
        DropdownList1.SelectedIndex = 0;
        DropdownList2.SelectedIndex = 0;
        DropdownList3.SelectedIndex = 0;
        DropdownList4.SelectedIndex = 0;
    }
    protected void DropdownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
       
       
    }
    protected void DropdownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "Select Subject from Subject_Master where Department='" + DropdownList2.SelectedValue.ToString() + "'and Sem='" + DropdownList3.SelectedValue.ToString() + "'"; ;
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            ListItem item = new ListItem();
            item.Value = rs.GetValue(0).ToString();
           
            DropdownList4.Items.Add(item);
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();
    }
    protected void DropdownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropdownList2.Items.Clear();
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Faculty_Dept from Faculty where Faculty_ID='"+DropdownList1.SelectedValue.ToString()+"' ";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            ListItem item = new ListItem();

            item.Value = rs.GetValue(0).ToString();
            DropdownList2.Items.Add(item);

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

      
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "Select Subject from Subject_Master where Department='" + DropdownList2.SelectedValue.ToString() + "'and Sem='" + DropdownList3.SelectedValue.ToString() + "'"; ;
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            ListItem item = new ListItem();
            item.Value = rs.GetValue(0).ToString();

            DropdownList4.Items.Add(item);
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

    }
    protected void DropdownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Textbox1_TextChanged(object sender, EventArgs e)
    {

    }
}