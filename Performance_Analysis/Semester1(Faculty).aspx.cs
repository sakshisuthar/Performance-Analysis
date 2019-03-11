using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class Semester1_Faculty_ : System.Web.UI.Page
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
            //Textbox10.Visible = false;
            //Textbox9.Visible = false;
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
        cmd.CommandText = "select count(*) from Semester1";
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
            cmd.CommandText = "select max(ID) from Semester1";
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

        string stud_Id = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "Select Stud_ID from Student where First_Name='" + Textbox4.Text + "'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            stud_Id = rs.GetValue(0).ToString();

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "Select Seat_No from Seat_No_Assig where Stud_ID='" + stud_Id + "'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Textbox6.Text = rs.GetValue(0).ToString();

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
        cmd.CommandText = "select Subject from Subject_Mapping where Faculty_ID='"+faculty_sub+"'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        { 
            ListItem item=new ListItem();
            item.Value=rs.GetValue(0).ToString();
            DropdownList1.Items.Add(item);
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

    }
    protected void DropdownList1_SelectedIndexChanged(object sender, EventArgs e)
    {


        if (DropdownList1.SelectedItem.ToString() == "ENG")
        {
            Textbox7.Enabled = true;
            Textbox8.Enabled= true;
            Textbox9.Enabled = false;
            Textbox10.Enabled = false;
        }
        else if(DropdownList1.SelectedItem.ToString()=="BSI")
        {
            Textbox8.Enabled = false;
            Textbox9.Enabled = true;
            Textbox7.Enabled = true;
            Textbox10.Enabled = false;
        }
        else if (DropdownList1.SelectedItem.ToString() == "BMS")
        {
            Textbox8.Enabled = false;
            Textbox9.Enabled = false;
            Textbox7.Enabled = true;
            Textbox10.Enabled = false;
        }
        else if (DropdownList1.SelectedItem.ToString() == "EGG")
        {
            Textbox8.Enabled = true;
            Textbox9.Enabled = true;
            Textbox7.Enabled = false;
            Textbox10.Enabled = false;
        
        }
        else if (DropdownList1.SelectedItem.ToString() == "CMF")
        {
            Textbox8.Enabled = true;
            Textbox9.Enabled = true;
            Textbox7.Enabled = false;
            Textbox10.Enabled = false;

        }
        else if (DropdownList1.SelectedItem.ToString() == "WCC")
        {
            Textbox8.Enabled = true;
            Textbox9.Enabled = false;
            Textbox7.Enabled = false;
            Textbox10.Enabled = false;

        }
        else if (DropdownList1.SelectedItem.ToString() == "SW")
        {
            Textbox8.Enabled = false;
            Textbox9.Enabled = false;
            Textbox7.Enabled = false;
            Textbox10.Enabled = true;

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int count = 0;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester1 where Enroll_No='"+Textbox2.Text+"'";
        rs = cmd.ExecuteReader();
        
        while (rs.Read())
        {
            count = int.Parse(rs.GetValue(0).ToString());
        } rs.Close();
        cmd.Dispose();
        cn.Close();

        string qry = "";

        

        if (DropdownList1.SelectedItem.ToString() == "ENG")
        {
            if (count == 0)
            {
                qry = "insert into Semester1(ID,Enroll_No,Surname,Firstname,Middlename,Seatnumber,Eng_TH,Eng_TW) values('"+Textbox1.Text+"','"+Textbox2.Text+"','"+Textbox3.Text+"','"+Textbox4.Text+"','"+Textbox5.Text+"','"+Textbox6.Text+"','"+Textbox7.Text+"','"+Textbox8.Text+"')";
                Label1.Text = "Successfull";
            }
            else
            {
                qry = "update Semester1 set Eng_TH='"+Textbox7.Text+"',Eng_TW='"+Textbox8.Text+"' where Enroll_No='"+Textbox2.Text+"'";
                Label1.Text = "Updated Successfully";
            }
        }
        else if (DropdownList1.SelectedItem.ToString() == "BSI")
        {
            if (count == 0)
            {
                qry = "insert into Semester1(ID,Enroll_No,Surname,Firstname,Middlename,Seatnumber,Bsi_TH,Bsi_PR) values('" + Textbox1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','" + Textbox4.Text + "','" + Textbox5.Text + "','" + Textbox6.Text + "','" + Textbox7.Text + "','" + Textbox9.Text + "')";
                Label1.Text = "Successfull"; 
            }
            else
            {
                qry = "update Semester1 set Bsi_TH='"+Textbox7.Text+"',Bsi_PR='"+Textbox9.Text+"' where Enroll_No='"+Textbox2.Text+"'";
                Label1.Text = "Updated Successfully";
            }
        }
        else if (DropdownList1.SelectedItem.ToString() == "BMS")
        {
            if (count == 0)
            {
                qry = "insert into Semester1(ID,Enroll_No,Surname,Firstname,Middlename,Seatnumber,Bms_TH) values('" + Textbox1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','" + Textbox4.Text + "','" + Textbox5.Text + "','" + Textbox6.Text + "','" + Textbox7.Text + "')";
                Label1.Text = "Successfull";
            }
            else
            {
                qry = "update Semester1 set Bms_TH='" + Textbox7.Text + "' where Enroll_No='" + Textbox2.Text + "'";
                Label1.Text = "Updated Successfully";
            }
        }
        else if (DropdownList1.SelectedItem.ToString() == "EGG")
        {
            if (count == 0)
            {
                qry = "insert into Semester1(ID,Enroll_No,Surname,Firstname,Middlename,Seatnumber,Egg_PR,Egg_TW) values('" + Textbox1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','" + Textbox4.Text + "','" + Textbox5.Text + "','" + Textbox6.Text + "','" + Textbox9.Text + "','"+Textbox8.Text+"')";
                Label1.Text = "Successfull";
            }
            else
            {
                qry = "update Semester1 set Egg_PR='" + Textbox9.Text + "',Egg_TW='"+Textbox8.Text+"' where Enroll_No='" + Textbox2.Text + "'";

                Label1.Text = "Updated Successfully";
            }
        }
        else if (DropdownList1.SelectedItem.ToString() == "CMF")
        {

            if (count == 0)
            {
                qry = "insert into Semester1(ID,Enroll_No,Surname,Firstname,Middlename,Seatnumber,Cmf_PR,Cmf_TW) values('" + Textbox1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','" + Textbox4.Text + "','" + Textbox5.Text + "','" + Textbox6.Text + "','" + Textbox9.Text + "','" + Textbox8.Text + "')";
                Label1.Text = "Successfull";
            }
            else
            {
                qry = "update Semester1 set Cmf_PR='" + Textbox9.Text + "',Cmf_TW='" + Textbox8.Text + "' where Enroll_No='" + Textbox2.Text + "'";
                Label1.Text = "Updated Successfully";
            }
        }
        else if (DropdownList1.SelectedItem.ToString() == "WCC")
        {

            if (count == 0)
            {
                qry = "insert into Semester1(ID,Enroll_No,Surname,Firstname,Middlename,Seatnumber,Wcc_TW ) values('" + Textbox1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','" + Textbox4.Text + "','" + Textbox5.Text + "','" + Textbox6.Text + "','" + Textbox8.Text + "')";
                Label1.Text = "Successfull";
            }
            else
            {
                qry = "update Semester1 set Wcc_TW='"+Textbox8.Text+"' where Enroll_No='" + Textbox2.Text + "'";
                Label1.Text = "Updated Successfully";
            }
        }
        else if (DropdownList1.SelectedItem.ToString() == "SW")
        {
            if (count == 0)
            {
                qry = "insert into Semester1(ID,Enroll_No,Surname,Firstname,Middlename,Seatnumber,Sw ) values('" + Textbox1.Text + "','" + Textbox2.Text + "','" + Textbox3.Text + "','" + Textbox4.Text + "','" + Textbox5.Text + "','" + Textbox6.Text + "','" + Textbox10.Text + "')";
                Label1.Text = "Successfull";
            }
            else
            {
                qry = "update Semester1 set Wcc_TW='" + Textbox10.Text + "' where Enroll_No='" + Textbox2.Text + "'";
                Label1.Text = "Updated Successfully";
            }
        }

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = qry;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();
        


        //----------------------------------------

        string ENG_TH="", ENG_TW="", BSI_TH="", BSI_PR="", BMS_TH="", EGG_PR="", EGG_TW="", CMF_PR="", CMF_TW="", WCC_TW="", SW="";
        double Total=0, Percentage=0;
        double d_ENG_TH = 0,d_ENG_TW = 0, d_BSI_TH = 0, d_BSI_PR = 0, d_BMS_TH = 0, d_EGG_PR = 0, d_EGG_TW = 0, d_CMF_PR = 0, d_CMF_TW = 0, d_WCC_TW = 0, d_SW = 0, d_Total = 0, d_Percentage = 0;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select  Eng_TH, Eng_TW, Bsi_TH, Bsi_PR, Bms_TH, Egg_PR, Egg_TW, Cmf_PR, Cmf_TW, Wcc_TW, Sw, Total, Percentage from Semester1 ";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            ENG_TH = rs.GetValue(0).ToString();
            ENG_TW = rs.GetValue(1).ToString();
            BSI_TH = rs.GetValue(2).ToString();
            BSI_PR = rs.GetValue(3).ToString();
            BMS_TH = rs.GetValue(4).ToString();
            EGG_PR =rs.GetValue(5).ToString();
            EGG_TW = rs.GetValue(6).ToString();
            CMF_PR =rs.GetValue(7).ToString();
            CMF_TW = rs.GetValue(8).ToString();
            WCC_TW = rs.GetValue(9).ToString();
            SW =rs.GetValue(10).ToString();
            
        } rs.Close();
        cmd.Dispose();
        cn.Close();
        if (ENG_TH != "")
        {
            d_ENG_TH = double.Parse(ENG_TH);
         }
        if (ENG_TW != "")
        {
            d_ENG_TW = double.Parse(ENG_TW);
        }
        if (BSI_TH != "")
        {
            d_BSI_TH = double.Parse(BSI_TH);
        }
        if (BSI_PR != "")
        {
            d_BSI_PR = double.Parse(BSI_PR);
        }
        if (BMS_TH != "")
        {
            d_BMS_TH = double.Parse(BMS_TH);
        }
        if (EGG_PR != "")
        {
            d_EGG_PR = double.Parse(EGG_PR);
        }
        if (EGG_TW != "")
        {
            d_EGG_TW = double.Parse(EGG_TW);
        }
        if (CMF_PR != "")
        {
            d_CMF_PR = double.Parse(CMF_PR);
        }
        if (CMF_TW != "")
        {
            d_CMF_TW = double.Parse(CMF_TW);
        }
        if (WCC_TW != "")
        {
            d_WCC_TW = double.Parse(WCC_TW);
        }
        if (SW != "")
        {
            d_SW = double.Parse(SW);
        }


        Total = d_ENG_TH + d_ENG_TW + d_BSI_TH + d_BSI_PR + d_BMS_TH + d_EGG_PR + d_EGG_TW + d_CMF_PR + d_CMF_TW + d_WCC_TW + d_SW;
        Percentage = (Total / 650) * 100;
        Percentage = System.Math.Round(Percentage,2);

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "update Semester1 set Total='" + Total + "',Percentage='" + Percentage + "' where Enroll_No='"+Textbox2.Text+"' ";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();

        Auto_Gen();
        Textbox2.Text = "";
        Textbox3.Text = "";
        Textbox4.Text = "";
        Textbox5.Text = "";
        DropdownList1.SelectedIndex = 0;
        Textbox6.Text = "";
        Textbox7.Text = "";
        Textbox8.Text = "";
        Textbox9.Text = "";
        Textbox10.Text = "";
    }
}