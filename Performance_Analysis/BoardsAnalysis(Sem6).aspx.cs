using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class BoardsAnalysis_Sem6_ : System.Web.UI.Page
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
        cmd.CommandText = "select Total from Semester6";
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
        cmd.CommandText = "select count(*) from Semester6";
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
        cmd.CommandText = "select count(*) from Semester6 where Percentage>='35'";
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
        cmd.CommandText = "select count(*) from Semester6";
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
        cmd.CommandText = "select count(*) from Semester6 where Percentage>='35'";
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
        cmd.CommandText = "select count(*) from Semester6 where Percentage>'60'";
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
        cmd.CommandText = "select count(*) from Semester6";
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
        cmd.CommandText = "select count(*) from Semester6 where Percentage>'60'";
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
        cmd.CommandText = "select count(*) from Semester6 where Percentage<'35'";
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
        cmd.CommandText = "select Total,Firstname,Middlename,Surname from Semester6 order by Percentage desc";
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
        cmd.CommandText = "select Total,Firstname,Middlename,Surname from Semester6 order by Percentage asc";
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
        cmd.CommandText = "select count(*) from Semester6";
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
        cmd.CommandText = "select Total from Semester6";
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


        //Highest marks in man

        string H_man = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester6 where Man_TH=(select max(Man_TH) from Semester6)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_man = H_man + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label11.Text = "Highest marks in Management=" + H_man.ToString() + "";

        //lowest marks in man

        string L_man = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester6 where Man_TH=(select min(Man_TH) from Semester6)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_man = L_man + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label12.Text = "Lowest marks in Management=" + L_man.ToString() + "";


        //Highest marks in mco

        string H_mco = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester6 where Mco_TH=(select max(Mco_TH) from Semester6)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_mco = H_mco + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label13.Text = "Highest marks in Mobile Computing=" + H_mco.ToString() + "";


        //lowest marks in mco

        string L_mco = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester6 where Mco_TH=(select min(Mco_TH) from Semester6)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_mco = L_mco + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label14.Text = "Lowest marks in Mobile Computing=" + L_mco.ToString() + "";

        //Highest marks in ajp

        string H_ajp = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester6 where Ajp_TH=(select max(Ajp_TH) from Semester6)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_ajp = H_ajp + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label15.Text = "Highest marks in Advance Java programming=" + H_ajp.ToString() + "";

        //lowest marks in ajp

        string L_ajp = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester6 where Ajp_TH=(select min(Ajp_TH) from Semester6)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_ajp = L_ajp + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label16.Text = "Lowest marks in Advance Java programming=" + L_ajp.ToString() + "";


        //Highest marks in oom

        string H_oom = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester6 where Oom_TH=(select max(Oom_TH) from Semester6)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_oom = H_oom + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label17.Text = "Highest marks in Object Oriented Modelling and Design=" + H_oom.ToString() + "";

        //lowest marks in oom

        string L_oom = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester6 where Oom_TH=(select min(Oom_TH) from Semester6)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_oom = L_oom + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label18.Text = "Lowest marks in Object Oriented Modelling and Design=" + L_oom.ToString() + "";

        //kts in man

        string k_man = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester6 where Man_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_man = k_man + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label19.Text = "Students with Kts in Management =" + k_man.ToString() + "";

        //kts in mco

        string k_mco = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester6 where Man_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_mco = k_mco + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label20.Text = "Students with Kts in Mobile Computing =" + k_mco.ToString() + "";


        //kts in ajp

        string k_ajp = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester6 where Ajp_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_ajp = k_ajp + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label21.Text = "Students with Kts in Advance Java programming =" + k_ajp.ToString() + "";

        //kts in oom

        string k_oom = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester6 where Oom_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_oom = k_oom + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label22.Text = "Students with Kts in Object Oriented Modelling and Design=" + k_oom.ToString() + "";


        //% of Student passing in man

        string passing3 = "";
        string count3 = "";
        string man_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester6";
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
        cmd.CommandText = "select count(*) from Semester6 where Man_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing3 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        man_percent = ((double.Parse(passing3) / double.Parse(count3)) * 100).ToString();

        Label23.Text = "Percentage of Student passing in Management= " + man_percent + "%";


        //% of Student passing in mco

        string passing4 = "";
        string count4 = "";
        string mco_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester6";
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
        cmd.CommandText = "select count(*) from Semester6 where Mco_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing4 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        mco_percent = ((double.Parse(passing4) / double.Parse(count4)) * 100).ToString();

        Label24.Text = "Percentage of Student passing in Mobile Computing= " + mco_percent + "%";


        //% of Student passing in ajp

        string passing5 = "";
        string count5 = "";
        string ajp_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester6";
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
        cmd.CommandText = "select count(*) from Semester6 where Ajp_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing5 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

       ajp_percent = ((double.Parse(passing5) / double.Parse(count5)) * 100).ToString();

        Label25.Text = "Percentage of Student passing in Advance java programming= " + ajp_percent + "%";


        //% of Student passing in oom

        string passing6 = "";
        string count6 = "";
        string oom_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester6";
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
        cmd.CommandText = "select count(*) from Semester6 where Oom_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing6 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        oom_percent = ((double.Parse(passing6) / double.Parse(count6)) * 100).ToString();

        Label26.Text = "Percentage of Student passing in Object oriented Modeling and Design= " + oom_percent + "%";

    }
}