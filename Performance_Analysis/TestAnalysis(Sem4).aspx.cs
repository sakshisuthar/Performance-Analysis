using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class TestAnalysis_Sem4_ : System.Web.UI.Page
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
        cmd.CommandText = "select Total from Semester4_MT";
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
        cmd.CommandText = "select count(*) from Semester4_MT";
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
        cmd.CommandText = "select count(*) from Semester4_MT where Percentage>='35'";
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
        cmd.CommandText = "select count(*) from Semester4_MT";
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
        cmd.CommandText = "select count(*) from Semester4_MT where Percentage>='35'";
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
        cmd.CommandText = "select count(*) from Semester4_MT where Percentage>'60'";
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
        cmd.CommandText = "select count(*) from Semester4_MT";
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
        cmd.CommandText = "select count(*) from Semester4_MT where Percentage>'60'";
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
        cmd.CommandText = "select count(*) from Semester4_MT where Percentage<'35'";
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
        cmd.CommandText = "select Total,Firstname,Middlename,Surname from Semester4_MT order by Percentage desc";
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
        cmd.CommandText = "select Total,Firstname,Middlename,Surname from Semester4_MT order by Percentage asc";
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
        cmd.CommandText = "select count(*) from Semester4_MT";
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
        cmd.CommandText = "select Total from Semester4_MT";
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

    }
}