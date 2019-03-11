using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class BoardsAnalysis_sem1_ : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = "Data Source=DESKTOP-M8LUGSB\\SQLEXPRESS;Initial Catalog=Result_Analysis;Integrated Security=true";

        //Total marks 
        double total=0;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Total from Semester1";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        { 
        total=total+int.Parse(rs.GetValue(0).ToString());
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();
        Label1.Text = "Total Marks Of Students:"+total+"";

        //for student appeared
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester1";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label2.Text = "No. Of Students Appeared:"+rs.GetValue(0).ToString()+"";
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

     //for students passed
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester1 where Percentage>='40'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label3.Text = "No. of Student Passed:"+rs.GetValue(0).ToString()+"";
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        //% of student passing
        string Passing="0";
        string count="0";
        string percent="";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester1";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
           count= rs.GetValue(0).ToString();
     
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester1 where Percentage>='40'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Passing = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        percent = ((double.Parse(Passing) / double.Parse(count)) * 100).ToString();
       Label4.Text = "No. Of Student Passed="+percent+" %";


        //student above 60%
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester1 where Percentage>'60'";
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
        cmd.CommandText = "select count(*) from  Semester1";
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
        cmd.CommandText = "select count(*) from  Semester1 where Percentage>'60'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing1 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        percent1=((double.Parse(passing1)/double.Parse(count1))*100).ToString("00.00");
        Label6.Text = "Percentage of Students Above 60:"+percent1+" %";

        


       
        //students failed
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester1 where Percentage<'40'";
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
        cmd.CommandText = "select Total,Firstname,Middlename,Surname from Semester1 order by Percentage desc";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label8.Text = "Highest Marks:"+rs.GetValue(1).ToString()+" "+rs.GetValue(2).ToString()+" "+rs.GetValue(3).ToString()+"";
            break;
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        //Lowest marks

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Total,Firstname,Middlename,Surname from Semester1 order by Percentage asc";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Label9.Text = "Lowest Marks:"+rs.GetValue(1).ToString()+" "+rs.GetValue(2).ToString()+" "+rs.GetValue(3).ToString()+"";
            break;
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        //average marks
        double count2=0;
       double avg = 0;
      double temp = 0;
       
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester1";
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
        cmd.CommandText = "select Total from Semester1";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            temp = temp+int.Parse(rs.GetValue(0).ToString());  
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        avg = (temp / count2);
        Label10.Text = "Average:"+avg.ToString("00.00")+"";


        //Highest marks in Eng
        string H_Eng = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester1 where Eng_Th=(select max(Eng_Th) from Semester1)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        { 
        
        H_Eng=H_Eng + rs.GetValue(0).ToString()+" "+rs.GetValue(1).ToString()+" "+rs.GetValue(2).ToString()+" , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label11.Text = "Highest marks in English:"+H_Eng.ToString()+"";

        //Lowest Marks in English

        string L_Eng = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester1 where Eng_Th=(select min(Eng_Th) from Semester1)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_Eng = L_Eng + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label12.Text = "Lowest marks in English:" + L_Eng.ToString() + "";

        //Highest marks in Bsi
        string H_Bsi= "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester1 where Bsi_TH=(select max(Bsi_TH) from Semester1)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_Bsi = H_Bsi + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label13.Text = "Highest marks in Basic Science:" + H_Bsi.ToString() + "";

        //Lowest marks in Bsi
        string L_Bsi = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester1 where Bsi_TH=(select min(Bsi_TH) from Semester1)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_Bsi = L_Bsi + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label14.Text = "Lowest marks in Basic Science:" + L_Bsi.ToString() + "";

        //Highest marks in Bms
      
        string H_Bms = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester1 where Bms_TH=(select max(Bms_TH) from Semester1)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            H_Bms = H_Bms + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label15.Text = "Highest marks in Basic Mathemathics:" + H_Bms.ToString() + "";

        //Lowestmarks in Bms

        string L_Bms = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester1 where Bms_TH=(select min(Bms_TH) from Semester1)";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            L_Bms = L_Bms + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label16.Text = "Highest marks in Basic Mathemathics:" + L_Bms.ToString() + "";

        //kts in eng
        string k_eng = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester1 where Eng_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_eng = k_eng + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label17.Text = "Student With Kts in English:" + k_eng.ToString() + "";

        //kts in bsi
        string k_bsi = "";
     

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester1 where Bsi_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_bsi = k_bsi + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        Label18.Text = "Student With Kts in Basic Science:" + k_bsi.ToString() + "";

        //kts in bms

        string k_bms = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Firstname,Middlename,Surname from Semester1 where Bms_TH<=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {

            k_bms = k_bms + rs.GetValue(0).ToString() + " " + rs.GetValue(1).ToString() + " " + rs.GetValue(2).ToString() + " , ";

        } rs.Close();
        cmd.Dispose();
        cn.Close();

       
            Label19.Text = "Student With Kts in Basic Mathemathics:" + k_bms.ToString() + "";
        
        //% of Student passing in English

        string passing3 = "";
        string count3 = "";
        string eng_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester1";
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
        cmd.CommandText = "select count(*) from Semester1 where Eng_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing3 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();
        
        eng_percent = ((double.Parse(passing3) / double.Parse(count3)) * 100).ToString();

        Label23.Text = "Percentage of Student passing in English: "+eng_percent + "%";

        //% of Student passing in science

        string passing4 = "";
        string count4 = "";
        string bsi_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester1";
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
        cmd.CommandText = "select count(*) from Semester1 where Bsi_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing4 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        bsi_percent = ((double.Parse(passing4) / double.Parse(count4)) * 100).ToString();

        Label24.Text = "Percentage of Student passing in Basic Science: " + bsi_percent + "%";


        //% of Student passing in maths

        string passing5 = "";
        string count5 = "";
        string bms_percent = "";

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from  Semester1";
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
        cmd.CommandText = "select count(*) from Semester1 where Bsi_TH>=40";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            passing5 = rs.GetValue(0).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        bms_percent = ((double.Parse(passing5) / double.Parse(count5)) * 100).ToString();

        Label25.Text = "Percentage of Student passing in Basic Mathematics: " + bms_percent + "%";


    }
   
}