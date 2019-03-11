using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class BoardsAnalysis_Sem2_ : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = "Data Source=DESKTOP-M8LUGSB\\SQLEXPRESS;Initial Catalog=Result_Analysis;Integrated Security=true";
        //Total marks 
        double total = 0;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Total from Semester2";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            total = total + int.Parse(rs.GetValue(0).ToString());
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();
        Label1.Text = "Total Marks Of Students:" + total + "";

        //for student appeared
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester2";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label2.Text = "No. Of Students Appeared:" + rs.GetValue(0).ToString() + "";
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        //for students passed
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester2 where Percentage>='35'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label3.Text = "No. of Student Passed:" + rs.GetValue(0).ToString() + "";
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();


        //% of student passing
        string Passing = "0";
        string count = "0";
        string percent = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester2";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            count = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester2 where Percentage>='35'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Passing = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        percent = ((double.Parse(Passing) / double.Parse(count)) * 100).ToString();
        Label4.Text = "No. Of Student Passed:" + percent + " %";

        //student above 60%
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester2 where Percentage>'60'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label5.Text = "No. of Students Above 60%:" + rs.GetValue(0).ToString() + "";
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();


        //% of studentabove 60% 
        string count1 = "0";
        string passing1 = "0";
        string percent1 = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester2";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            count1 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester2 where Percentage>'60'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing1 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        percent1 = ((double.Parse(passing1) / double.Parse(count1)) * 100).ToString("00.00");
        Label6.Text = "Percentage of Students Above 60:" + percent1 + " %";

        //students failed
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester2 where Percentage<'35'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label7.Text = "No. of Students Failed:" + rs.GetValue(0).ToString() + "";
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();


        //highest marks

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Total,Firstname,Middlename,Surname from Semester2 order by Percentage desc";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label8.Text = "Highest Marks:" + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " " + rs.GetValue(3).ToString() + "";
            break;
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();


        //Lowest marks

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Total,Firstname,Middlename,Surname from Semester2 order by Percentage asc";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label9.Text = "Lowest Marks:" + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " " + rs.GetValue(3).ToString() + "";
            break;
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        //average marks
        double count2 = 0;
        double avg = 0;
        double temp = 0;

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester2";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            count2 = int.Parse(rs.GetValue(0).ToString());
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Total from Semester2";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            temp = temp + int.Parse(rs.GetValue(0).ToString());
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        avg = (temp / count2);
        Label10.Text = "Average:" + avg.ToString("00.00") + "";


        //Highest marks in Cms

        string H_Cms = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Cms_TH=(select max(Cms_TH) from Semester2)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_Cms = H_Cms + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label11.Text = "Highest marks in Communication Skills:" + H_Cms.ToString() + "";

        //lowest marks in Cms

        string L_Cms = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Cms_TH=(select min(Cms_TH) from Semester2)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_Cms = L_Cms + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label12.Text = "Lowest marks in Communication Skills:" + L_Cms.ToString() + "";

        //Highest marks in Aps

        string H_Aps = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Aps_TH=(select max(Aps_TH) from Semester2)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_Aps = H_Aps + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label13.Text = "Highest marks in Applied Science:" + H_Aps.ToString() + "";


        //lowest marks in Cms

        string L_Aps = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Aps_TH=(select min(Aps_TH) from Semester2)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_Aps = L_Aps + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label14.Text = "Lowest marks in Applied Science:" + L_Aps.ToString() + "";

        //Highest marks in pic

        string H_pic = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Pic_TH=(select max(Pic_TH) from Semester2)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_pic = H_pic + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label15.Text = "Highest marks in Programming in 'C':" + H_pic.ToString() + "";

        //lowest marks in pic

        string L_pic = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Pic_TH=(select min(Pic_TH) from Semester2)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_pic = L_pic + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label16.Text = "Lowest marks in Programming in 'C':" + L_pic.ToString() + "";

        //Highest marks in bel

        string H_bel= "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Bel_TH=(select max(Bel_TH) from Semester2)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_bel = H_bel + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label17.Text = "Highest marks in Basic Electronics:" + H_bel.ToString() + "";

        //lowest marks in bel

        string L_bel = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Bel_TH=(select min(Bel_TH) from Semester2)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_bel = L_bel + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label18.Text = "Lowest marks in Programming in Basic Electronics:" + L_bel.ToString() + "";

        //Highest marks in ems

        string H_ems = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Ems_TH=(select max(Ems_TH) from Semester2)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_ems = H_ems + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label19.Text = "Highest marks in Engineering Mathematics:" + H_ems.ToString() + "";

        //lowest marks in ems

        string L_ems = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Ems_TH=(select min(Ems_TH) from Semester2)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_ems = L_ems + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label20.Text = "Lowest marks in Programming in Basic Electronics:" + L_ems.ToString() + "";

        //kts in cms

        string k_cms = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Cms_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_cms = k_cms + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label21.Text = "Students with Kts in Communication skills:" + k_cms.ToString() + "";

        //kts in Aps

        string k_aps = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Aps_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_aps = k_aps + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label22.Text = "Students with Kts in Applied Science:" + k_aps.ToString() + "";

        //kts in pic

        string k_pic = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Pic_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_pic = k_pic + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label23.Text = "Students with Kts in Programming In 'C':" + k_pic.ToString() + "";

        //kts in bel

        string k_bel = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Bel_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_bel = k_bel + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label24.Text = "Students with Kts in Basic Electronics:" + k_bel.ToString() + "";


        //kts in ems

        string k_ems = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester2 where Ems_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_ems = k_ems + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label25.Text = "Students with Kts in Engineering Mathematics:" + k_ems.ToString() + "";


        //% of Student passing in cms

        string passing3 = "";
        string count3 = "";
        string cms_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester2";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            count3 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester2 where Cms_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing3 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        cms_percent = ((double.Parse(passing3) / double.Parse(count3)) * 100).ToString();

        Label26.Text = "Percentage of Student passing in Communication Skills: " + cms_percent + "%";

        //% of Student passing in aps

        string passing4 = "";
        string count4 = "";
        string aps_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester2";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            count4 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester2 where Aps_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing4 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        aps_percent = ((double.Parse(passing4) / double.Parse(count4)) * 100).ToString();

        Label27.Text = "Percentage of Student passing in Applied Science: " + aps_percent + "%";

        //% of Student passing in pic

        string passing5 = "";
        string count5 = "";
        string pic_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester2";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            count5 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester2 where Pic_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing5 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        pic_percent = ((double.Parse(passing5) / double.Parse(count5)) * 100).ToString();

        Label28.Text = "Percentage of Student passing in Programming in C: " + pic_percent + "%";

        //% of Student passing in bel

        string passing6 = "";
        string count6 = "";
        string bel_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester2";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            count6 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester2 where Bel_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing6 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        bel_percent = ((double.Parse(passing6) / double.Parse(count6)) * 100).ToString();

        Label29.Text = "Percentage of Student passing in Basic electronics: " + bel_percent + "%";

        //% of Student passing in ems

        string passing7 = "";
        string count7 = "";
        string ems_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester2";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            count7 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester2 where Ems_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing7 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        ems_percent = ((double.Parse(passing7) / double.Parse(count7)) * 100).ToString();

        Label30.Text = "Percentage of Student passing in Engineering Mathematics: " + ems_percent + "%";



    }
}