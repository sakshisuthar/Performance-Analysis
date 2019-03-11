using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Semester_TT1_Faculty_ : System.Web.UI.Page
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
        cmd.CommandText = "select count(*) from Semester1_tt";
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
            cmd.CommandText = "select max(ID) from Semester1_tt";
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
                id = "I000" + id;
            }
            else if (id.Length == 2)
            {
                id = "I00" + id;
            }
            else if (id.Length == 3)
            {
                id = "I0" + id;
            }
            else if (id.Length == 4)
            {
                id = "I" + id;
            }
            Textbox1.Text = id;
        }
        else
        {
            Textbox1.Text = "I0001";
        }
    }
   
    protected void Button_Click(object sender, EventArgs e)
    {
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Sur_Name,First_Name,Middle_Name from Student where Stud_Enrol='" + Textbox2.Text + "'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Textbox3.Text = rs.GetValue(0).ToString();
            Textbox4.Text = rs.GetValue(1).ToString();
            Textbox5.Text = rs.GetValue(2).ToString();

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        string faculty_sub = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Faculty_ID  from Faculty where Faculty_Email='" + Session["faculty_Username"] + "' ";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            faculty_sub = rs.GetValue(0).ToString();
        } rs.Close();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Subject from Subject_Mapping where Faculty_ID='" + faculty_sub + "'";
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

    }
    protected void DropdownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropdownList2.SelectedItem.ToString() == "ENG")
        {
            Textbox7.Enabled = true;
            Textbox8.Enabled = false;
            Textbox9.Enabled = false;
            Textbox10.Enabled = false;
        }
        else if (DropdownList2.SelectedItem.ToString() == "EPH")
        {
            Textbox7.Enabled = false;
            Textbox8.Enabled = true;
            Textbox9.Enabled = false;
            Textbox10.Enabled = false;
        }
        else if (DropdownList2.SelectedItem.ToString() == "ECH")
        {
            Textbox7.Enabled = false;
            Textbox8.Enabled = false;
            Textbox9.Enabled = true;
            Textbox10.Enabled = false;
        }
        else if (DropdownList2.SelectedItem.ToString() == "BMS")
        {
            Textbox7.Enabled = false;
            Textbox8.Enabled = false;
            Textbox9.Enabled = false;
            Textbox10.Enabled = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int count = 0;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester1 where Enroll_No='" + Textbox2.Text + "'";
        rs = cmd.ExecuteReader();

        while (rs.Read())
        {
            count = int.Parse(rs.GetValue(0).ToString());
        } rs.Close();
        cmd.Dispose();
        cn.Close();


        string qry = "";

        if (DropdownList2.SelectedItem.ToString() == "ENG")
        {
            if (count == 0)
            {
                qry = "Insert into Semester1_tt(ID,Test_Type,Enroll_No,Surname,Firstname,Middlename,Rollnumber,ENG)values('" + Textbox1.Text + "','" + DropdownList1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','" + Textbox4.Text + "','" + Textbox5.Text + "','" + Textbox6.Text + "','" + Textbox7.Text + "')";
                Label1.Text = "Successfull";
            }
            else
            {
                qry = "update Semester1_tt set ENG='"+Textbox7.Text+"' where Enroll_No='"+Textbox2.Text+"' ";
                Label1.Text = "Updated Successfully";
            }

        }
        else if (DropdownList2.SelectedItem.ToString() == "EPH")
        {
            if (count == 0)
            {
                qry = "Insert into Semester1_tt(ID,Test_Type,Enroll_No,Surname,Firstname,Middlename,Rollnumber,EPH)values('" + Textbox1.Text + "','" + DropdownList1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','" + Textbox4.Text + "','" + Textbox5.Text + "','" + Textbox6.Text + "','" + Textbox8.Text + "')";
                Label1.Text = "successfull";
            }else
            {
                qry = "update Semester1_tt set EPH='"+Textbox8.Text+"' where Enroll_No='" + Textbox2.Text + "' ";
                Label1.Text = "Updated Successfully";
            }
        
        }
        else if (DropdownList2.SelectedItem.ToString() == "ECH")
        {
            if (count == 0)
            {
                qry = "Insert into Semester1_tt(ID,Test_Type,Enroll_No,Surname,Firstname,Middlename,Rollnumber,ECH)values('" + Textbox1.Text + "','" + DropdownList1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','" + Textbox4.Text + "','" + Textbox5.Text + "','" + Textbox6.Text + "','" + Textbox9.Text + "')";
                Label1.Text = "successfull";
            }
            else
            {
                qry = "update Semester1_tt set ECH='"+Textbox9.Text+"' where Enroll_No='" + Textbox2.Text + "' ";
                Label1.Text = "Updated Successfully";
            }
        }
        else if (DropdownList2.SelectedItem.ToString() == "BMS")
        {
            if (count == 0)
            {
                qry = "Insert into Semester1_tt(ID,Test_Type,Enroll_No,Surname,Firstname,Middlename,Rollnumber,BMS)values('" + Textbox1.Text + "','" + DropdownList1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','" + Textbox4.Text + "','" + Textbox5.Text + "','" + Textbox6.Text + "','" + Textbox10.Text + "')";
                Label1.Text = "successfull";
            }
            else
            {
                qry = "update Semester1_tt set BMS='"+Textbox10.Text+"' where Enroll_No='" + Textbox2.Text + "' ";
                Label1.Text = "Updated Successfully";
            }
        }

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = qry;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();

        //--------------------------------------------------------------------------------
        string ENG = "", EPH = "", ECH = "", BMS = "";
        double Total=0, Percentage=0;
        double d_ENG=0, d_EPH=0, d_ECH=0, d_BMS=0;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select ENG,EPH,ECH,BMS from Semester1_tt";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            ENG = rs.GetValue(0).ToString();
            EPH = rs.GetValue(1).ToString();
            ECH = rs.GetValue(2).ToString();
            BMS = rs.GetValue(3).ToString();
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        if (ENG != "")
        {
            d_ENG = double.Parse(ENG);
        }
        if (EPH != "")
        {
            d_EPH = double.Parse(EPH);
        }
        if (ECH != "")
        {
            d_ECH = double.Parse(ECH);
        }
        if (BMS != "")
        {
            d_BMS = double.Parse(BMS);
        }

        Total = d_ENG + d_EPH + d_ECH + d_BMS;
        Percentage = (Total / 100) * 100;
        Percentage = System.Math.Round(Percentage, 2);

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "update Semester1_tt set Total='" + Total + "',Percentage='" + Percentage + "' where Enroll_No='" + Textbox2.Text + "' ";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();

        Auto_Gen();
        Textbox2.Text = "";
        Textbox3.Text = "";
        Textbox4.Text = "";
        Textbox5.Text = "";
        DropdownList1.SelectedIndex = 0;
        DropdownList2.SelectedIndex = 0;
        Textbox6.Text = "";
        Textbox7.Text = "";
        Textbox8.Text = "";
        Textbox9.Text = "";
        Textbox10.Text = "";


    }
}