using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class BoardsAnalysis_Sem3_ : System.Web.UI.Page
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
        cmd.CommandText = "select Total from Semester3";
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
        cmd.CommandText = "select count(*) from Semester3";
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
        cmd.CommandText = "select count(*) from  Semester3 where Percentage>='35'";
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
        cmd.CommandText = "select count(*) from  Semester3";
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
        cmd.CommandText = "select count(*) from  Semester3 where Percentage>='35'";
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
        cmd.CommandText = "select count(*) from  Semester3 where Percentage>'60'";
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
        cmd.CommandText = "select count(*) from  Semester3";
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
        cmd.CommandText = "select count(*) from  Semester3 where Percentage>'60'";
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
        cmd.CommandText = "select count(*) from  Semester3 where Percentage<'35'";
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
        cmd.CommandText = "select Total,Firstname,Middlename,Surname from Semester3 order by Percentage desc";
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
        cmd.CommandText = "select Total,Firstname,Middlename,Surname from Semester3 order by Percentage asc";
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
        cmd.CommandText = "select count(*) from Semester3";
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
        cmd.CommandText = "select Total from Semester3";
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

        //Highest marks in ams

        string H_ams = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Ams_TH=(select max(Ams_TH) from Semester3)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_ams = H_ams + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label11.Text = "Highest marks in Applied Mathematics:" + H_ams.ToString() + "";

        //lowest marks in ams

        string L_ams = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Ams_TH=(select min(Ams_TH) from Semester3)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_ams = L_ams + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label12.Text = "Lowest marks in Applied Mathematics:" + L_ams.ToString() + "";



        //Highest marks in dsu

        string H_dsu = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Dsu_TH=(select max(Dsu_TH) from Semester3)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_dsu = H_dsu + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label13.Text = "Highest marks in Data Structure:" + H_dsu.ToString() + "";

        //lowest marks in dsu

        string L_dsu = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Dsu_TH=(select min(Dsu_TH) from Semester3)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_dsu = L_dsu + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label14.Text = "Lowest marks in Data Structure:" + L_dsu.ToString() + "";


        //Highest marks in ete

        string H_ete = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Ete_TH=(select max(Ete_TH) from Semester3)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_ete = H_ete + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label15.Text = "Highest marks in Electrical Technology:" + H_ete.ToString() + "";

        //lowest marks in ete

        string L_ete = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Ete_TH=(select min(Ete_TH) from Semester3)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_ete = L_ete + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label16.Text = "Lowest marks in Electrical Technology:" + L_ete.ToString() + "";


        //Highest marks in rdm

        string H_rdm = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Rdm_TH=(select max(Rdm_TH) from Semester3)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_rdm = H_rdm + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label17.Text = "Highest marks in Relational Database Management System:" + H_rdm.ToString() + "";


        //lowest marks in rdm

        string L_rdm = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Rdm_TH=(select min(Rdm_TH) from Semester3)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_rdm = L_rdm + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label18.Text = "Lowest marks in Relational Database Management System:" + L_rdm.ToString() + "";


        //Highest marks in dte

        string H_dte = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Dte_TH=(select max(Dte_TH) from Semester3)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_dte = H_dte + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label19.Text = "Highest marks in Digital Techniques:" + H_dte.ToString() + "";


        //lowest marks in dte

        string L_dte = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Dte_TH=(select min(Dte_TH) from Semester3)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_dte = L_dte + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label20.Text = "Lowest marks in Digital Techniques:" + L_dte.ToString() + "";

        //kts in ams

        string k_ams = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Ams_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_ams = k_ams + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label21.Text = "Students with Kts in Applied Mathematics :" + k_ams.ToString() + "";

        //kts in dsu

        string k_dsu = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Dsu_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_dsu = k_dsu + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label22.Text = "Students with Kts in Data Structure :" + k_dsu.ToString() + "";

        //kts in ete

        string k_ete = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Ete_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_ete = k_ete + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label23.Text = "Students with Kts in Electrical Technology :" + k_ete.ToString() + "";

        //kts in rdm

        string k_rdm = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Ete_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_rdm = k_rdm + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label24.Text = "Students with Kts in Relational Database Management System :" + k_rdm.ToString() + "";

        //kts in dte

        string k_dte = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester3 where Dte_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_dte = k_dte + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label25.Text = "Students with Kts in Digital Techniques:" + k_dte.ToString() + "";



        //% of Student passing in ams

        string passing3 = "";
        string count3 = "";
        string ams_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester3";
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
        cmd.CommandText = "select count(*) from Semester3 where Ams_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing3 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        ams_percent = ((double.Parse(passing3) / double.Parse(count3)) * 100).ToString();

        Label26.Text = "Percentage of Student passing in Applied Mathematics: " + ams_percent + "%";


        //% of Student passing in dsu

        string passing4= "";
        string count4 = "";
        string dsu_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester3";
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
        cmd.CommandText = "select count(*) from Semester3 where Dsu_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing4 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        dsu_percent = ((double.Parse(passing4) / double.Parse(count4)) * 100).ToString();

        Label27.Text = "Percentage of Student passing in Data Structure: " + dsu_percent + "%";


        //% of Student passing in ete

        string passing5 = "";
        string count5 = "";
        string ete_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester3";
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
        cmd.CommandText = "select count(*) from Semester3 where Ete_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing5 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        ete_percent = ((double.Parse(passing5) / double.Parse(count5)) * 100).ToString();

        Label28.Text = "Percentage of Student passing in Electrical Technology: " + ete_percent + "%";

        //% of Student passing in rdm

        string passing6 = "";
        string count6 = "";
        string rdm_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester3";
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
        cmd.CommandText = "select count(*) from Semester3 where Rdm_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing6 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        rdm_percent = ((double.Parse(passing6) / double.Parse(count6)) * 100).ToString();

        Label29.Text = "Percentage of Student passing in Relational Database Management System: " + rdm_percent + "%";

        //% of Student passing in rdm

        string passing7 = "";
        string count7 = "";
        string dte_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester3";
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
        cmd.CommandText = "select count(*) from Semester3 where Rdm_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing7 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

       dte_percent = ((double.Parse(passing7) / double.Parse(count7)) * 100).ToString();

        Label30.Text = "Percentage of Student passing in Digital Techniques: " + dte_percent + "%";
    }
}