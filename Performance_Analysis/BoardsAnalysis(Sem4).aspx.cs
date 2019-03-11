using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class BoardsAnalysis_Sem4_ : System.Web.UI.Page
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
        cmd.CommandText = "select Total from Semester4";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            total = total + int.Parse(rs.GetValue(0).ToString());
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();
        Label1.Text = "Total Marks Of Students=" + total + "";

        //for student appeared
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester4";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label2.Text = "No. Of Students Appeared=" + rs.GetValue(0).ToString() + "";
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        //for students passed
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester4 where Percentage>='35'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label3.Text = "No. of Student Passed=" + rs.GetValue(0).ToString() + "";
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
        cmd.CommandText = "select count(*) from  Semester4";
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
        cmd.CommandText = "select count(*) from  Semester4 where Percentage>='35'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Passing = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        percent = ((double.Parse(Passing) / double.Parse(count)) * 100).ToString();
        Label4.Text = "No. Of Student Passed=" + percent + " %";

        //student above 60%
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester4 where Percentage>'60'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label5.Text = "No. of Students Above 60%=" + rs.GetValue(0).ToString() + "";
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
        cmd.CommandText = "select count(*) from  Semester4";
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
        cmd.CommandText = "select count(*) from  Semester4 where Percentage>'60'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing1 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        percent1 = ((double.Parse(passing1) / double.Parse(count1)) * 100).ToString("00.00");
        Label6.Text = "Percentage of Students Above 60=" + percent1 + " %";

        //students failed
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester4 where Percentage<'35'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label7.Text = "No. of Students Failed=" + rs.GetValue(0).ToString() + "";
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();


        //highest marks

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Total,Firstname,Middlename,Surname from Semester4 order by Percentage desc";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label8.Text = "Highest Marks=" + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " " + rs.GetValue(3).ToString() + "";
            break;
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();


        //Lowest marks

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Total,Firstname,Middlename,Surname from Semester4 order by Percentage asc";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label9.Text = "Lowest Marks=" + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " " + rs.GetValue(3).ToString() + "";
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
        cmd.CommandText = "select count(*) from Semester4";
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
        cmd.CommandText = "select Total from Semester4";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            temp = temp + int.Parse(rs.GetValue(0).ToString());
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        avg = (temp / count2);
        Label10.Text = "Average=" + avg.ToString("00.00") + "";



        //Highest marks in est

        string H_est = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Est_TH=(select max(Est_TH) from Semester4)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_est = H_est + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label11.Text = "Highest marks in Environmental Studies=" + H_est.ToString() + "";

        //lowest marks in dte

        string L_est = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Est_TH=(select min(Est_TH) from Semester4)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_est = L_est + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label12.Text = "Lowest marks inEnvironmental Studies=" + L_est.ToString() + "";

        //Highest marks in chm

        string H_chm = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Chm_TH=(select max(Chm_TH) from Semester4)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_chm = H_chm + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label13.Text = "Highest marks in Computer Hardware and Maintenance=" + H_chm.ToString() + "";

        //lowest marks in chm

        string L_chm = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Chm_TH=(select min(Chm_TH) from Semester4)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_chm = L_chm + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label14.Text = "Lowest marks in Computer Hardware and Maintenance=" + L_chm.ToString() + "";

        //Highest marks in dcn

        string H_dcn = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Dcn_TH=(select max(Dcn_TH) from Semester4)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_dcn = H_dcn + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label15.Text = "Highest marks in Data Communication and Networking=" + H_dcn.ToString() + "";

        //lowest marks in dcn

        string L_dcn = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Dcn_TH=(select min(Dcn_TH) from Semester4)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_dcn = L_dcn + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label16.Text = "Lowest marks in Data Communication and Networking=" + L_dcn.ToString() + "";

        //Highest marks in map

        string H_map = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Map_TH=(select max(Map_TH) from Semester4)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_map = H_map + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label17.Text = "Highest marks in Microprocessor and Programming=" + H_map.ToString() + "";

        //lowest marks in map

        string L_map = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Map_TH=(select min(Map_TH) from Semester4)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_map = L_map + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label18.Text = "Lowest marks in Microprocessor and Programming=" + L_map.ToString() + "";



        //Highest marks in oop

        string H_oop = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Oop_TH=(select max(Oop_TH) from Semester4)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_oop = H_oop + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label19.Text = "Highest marks in Object Oriented Programming=" + H_oop.ToString() + "";

        //lowest marks in map

        string L_oop = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Oop_TH=(select min(Oop_TH) from Semester4)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_oop = L_oop + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label20.Text = "Lowest marks in Object Oriented Programming=" + L_oop.ToString() + "";

        //kts in est

        string k_est = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Est_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_est = k_est + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label21.Text = "Students with Kts in Enviromental Studies =" + k_est.ToString() + "";

        //kts in chm

        string k_chm = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Chm_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_chm = k_chm + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label22.Text = "Students with Kts in Computer Hardware and Maintenance =" + k_chm.ToString() + "";

        //kts in dcn

        string k_dcn= "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Dcn_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_dcn = k_dcn + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label23.Text = "Students with Kts in Data Communication and networking =" + k_dcn.ToString() + "";



        //kts in map

        string k_map = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Map_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_map = k_map + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label24.Text = "Students with Kts in Microprocessor and Programming =" + k_map.ToString() + "";

        //kts in oop

        string k_oop = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester4 where Oop_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_oop = k_oop + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label25.Text = "Students with Kts in Object Oriented Programming =" + k_oop.ToString() + "";



        //% of Student passing in est

        string passing3 = "";
        string count3 = "";
        string est_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester4";
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
        cmd.CommandText = "select count(*) from Semester4 where Est_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing3 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        est_percent = ((double.Parse(passing3) / double.Parse(count3)) * 100).ToString();

        Label26.Text = "Percentage of Student passing in Environmental Studies= " + est_percent + "%";

        //% of Student passing in chm

        string passing4 = "";
        string count4 = "";
        string chm_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester4";
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
        cmd.CommandText = "select count(*) from Semester4 where Chm_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing4 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        chm_percent = ((double.Parse(passing4) / double.Parse(count4)) * 100).ToString();

        Label27.Text = "Percentage of Student passing in Computer Hardware and Maintenance= " + chm_percent + "%";

        //% of Student passing in est

        string passing5 = "";
        string count5 = "";
        string dcn_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester4";
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
        cmd.CommandText = "select count(*) from Semester4 where Dcn_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing5 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

       dcn_percent = ((double.Parse(passing5) / double.Parse(count5)) * 100).ToString();

        Label28.Text = "Percentage of Student passing in Data Communication and Networking= " + dcn_percent + "%";

        //% of Student passing in map

        string passing6 = "";
        string count6 = "";
        string map_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester4";
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
        cmd.CommandText = "select count(*) from Semester4 where Map_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing6 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        map_percent = ((double.Parse(passing6) / double.Parse(count6)) * 100).ToString();

        Label29.Text = "Percentage of Student passing in Microprocessor And Programming= " + map_percent + "%";

        //% of Student passing in est

        string passing7 = "";
        string count7 = "";
        string oop_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester4";
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
        cmd.CommandText = "select count(*) from Semester4 where Oop_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing7 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        oop_percent = ((double.Parse(passing3) / double.Parse(count3)) * 100).ToString();

        Label30.Text = "Percentage of Student passing in Environmental Studies= " + oop_percent + "%";
    }
}