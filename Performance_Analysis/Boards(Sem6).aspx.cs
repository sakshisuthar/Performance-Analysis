using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Boards_Sem6_ : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rs;

    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = "Data Source=DESKTOP-M8LUGSB\\SQLEXPRESS;Initial Catalog=Result_Analysis;Integrated Security=true";
        ReplaceDiv();
    }
    public void ReplaceDiv()
    {
        string stud_enroll = "";
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Stud_Enrol from Student where Stud_Email='" + Session["Student_Username"] + "'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            stud_enroll = rs.GetValue(0).ToString();
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        string enroll_no = "";
        string surname = "";
        string firstname = "";
        string middlename = "";
        string seatnumber = "";
        string Man_TH = "";
        string Mco_TH = "";
        string Mco_PR = "";
        string Mco_TW = "";
        string Ajp_TH = "";
        string Ajp_PR = "";
        string Ajp_TW = "";
        string Oom_TH = "";
        string Oom_TW = "";
        string Ste_PR = "";
        string Ste_TW = "";
        string Ipr_OR = "";
        string Ipr_TW = "";
        string Ede_TW = "";
        string Sw = "";
        string Total = "";
        string Percentage = "";
        string Remarks = "";
        string Total1 = "";
        string FinalTotal = "";
        string FinalPercent="";

        //For Agregate
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Total From Semester5 where Enroll_No='" + stud_enroll + "' ";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Total1 = rs.GetValue(0).ToString();
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();



        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Enroll_No,Surname,Firstname,Middlename,Seatnumber,Man_TH,Mco_TH,Mco_PR,Mco_TW,Ajp_TH,Ajp_PR,Ajp_TW,Oom_TH,Oom_TW,Ste_PR,Ste_TW,Ipr_OR,Ipr_TW,Ede_TW,SW,Total,Percentage,Remarks from Semester6 where Enroll_No='" + stud_enroll + "' ";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            enroll_no = rs.GetValue(0).ToString();
            surname = rs.GetValue(1).ToString();
            firstname = rs.GetValue(2).ToString();
            middlename = rs.GetValue(3).ToString();
            seatnumber = rs.GetValue(4).ToString();        
            Man_TH = rs.GetValue(5).ToString();
            Mco_TH = rs.GetValue(6).ToString();
            Mco_PR = rs.GetValue(7).ToString();
            Mco_TW = rs.GetValue(8).ToString();
            Ajp_TH = rs.GetValue(9).ToString();
            Ajp_PR = rs.GetValue(10).ToString();
            Ajp_TW = rs.GetValue(11).ToString();
            Oom_TH = rs.GetValue(12).ToString();
            Oom_TW = rs.GetValue(13).ToString();
            Ste_PR = rs.GetValue(14).ToString();
            Ste_TW = rs.GetValue(15).ToString();
            Ipr_OR = rs.GetValue(16).ToString();
            Ipr_TW = rs.GetValue(17).ToString();
            Ede_TW = rs.GetValue(18).ToString();
            Sw = rs.GetValue(19).ToString();
            Total = rs.GetValue(20).ToString();
            Percentage = rs.GetValue(21).ToString();
            Remarks = rs.GetValue(22).ToString();
            }
        rs.Close();
        cmd.Dispose();
        cn.Close();

             FinalTotal = (int.Parse(Total.ToString()) + int.Parse(Total1.ToString())).ToString();

        FinalPercent = (((Double.Parse(FinalTotal.ToString()) / 1700) * 100)).ToString("00.00");



        string html = "<table width='100%' border='1'><tr><th colspan='4'><center>STATEMENT OF MARKS</center></th></tr><tr><td><b><center>Mr/Ms</b>:" + firstname + " " + middlename + " " + surname + "</center></td><td rowspan='3'><b><center>EXAMINATION 2016</center></b></td><td rowspan='3'><b><center>SEAT NO</b>:" + seatnumber + "</center></td><td rowspan='3'><b><center>SIXTH SEMESTER</center></b></td></tr><tr><td><b><center>ENROLLMENT NO:" + enroll_no + "</center></b></td></tr><tr><td><center><b>COURSE IF:DIPLOMA IN INFORMATION TECHNOLOGY</b></center></td></tr></table><br><table width='100%' border='1'><tr><th><center>TITLE OF SUBJECT</center></th><th><center>SUB HEAD</center></th><th><center>MAX MARKS</center></th><th><center>MIN MARKS</center></th><th><center>MARKS OBTAINED</center></th></tr><tr><td><center>MANAGEMENT (MAN)</center></td><td><center>TH</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Man_TH + "</center></td></tr><tr><td rowspan='3'><center>MOBILE COMPUTING (MCO)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Mco_TH + "</center></td></tr><tr><td><center>PR</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Mco_PR + "</center></td></tr></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Mco_TW + "</center></td></tr><tr><td rowspan='3'><center>ADVANCE JAVA PROGRAMMING (AJP)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Ajp_TH + "</center></td></tr><tr><td><center>PR</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Ajp_PR + "</center></td></tr></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Ajp_TW + "</center></td></tr><tr><td rowspan='2'><center>OBJECT ORIENTED MODELING & DESIGN (OOM)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Oom_TH + "</center></td></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Oom_TW + "</center></td></tr><tr><td rowspan='2'><center>SCRIPTING TECHNOLOGY (STE)</center></td><td><center>PR</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Ste_PR + "</center></td></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Ste_TW + "</center></td></tr><tr><td rowspan='2'><center>INDUSTRIAL PROJECTS (IPR)</center></td><td><center>OR</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Ipr_OR + "</center></td></tr><tr><td><center>TW</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Ipr_TW + "</center></td></tr><tr><td><center>ENTREPRENEURSHIP DEVELOPMENT (EDE)</center></td><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Ede_TW + "</center></td></tr><tr><td><center>SW</center></td><td><center>SW</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Sw + "</center></td></tr></table><br><table width='100%' border='1'><tr><td rowspan='3'><b><center>Date:" + System.DateTime.Now.ToShortDateString() + "</center></b></td><td><b><center>TOTAL MARKS</center></b></td><td><b><center>RESULT WITH %</center></b></td><td><b><center>MARKS OBTAINED</center></b></td><td><b><center>Grade</center></b></td></tr><td><center>800</center></td><td><center>" + Percentage + "</center></td><td><center>" + Total + "</center></td><td><center>" + Remarks + "</center></td></table><br><table width='100%' border='1'><tr><td rowspan='3'><b><center>Date:" + System.DateTime.Now.ToShortDateString() + "<br><b>SECRETARY</b><br>Maharashtra State Board Of Technical Education</b></center></td><td><b><center>Aggregate Marks</center></b></td><td><b><center>1700</center></b></td><td><b><center>" + FinalPercent + " %</center></b></td><td><b><center>" + FinalTotal + "</center></b></td></tr></table>";
            DivReplace.InnerHtml = html;
        
        }
    }
