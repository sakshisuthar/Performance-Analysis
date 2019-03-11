using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Boards_Sem4_ : System.Web.UI.Page
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
        string Est_TH = "";
        string Est_TW = "";
        string Chm_TH = "";
        string Chm_PR = "";
        string Chm_TW= "";
        string Dcn_TH = "";
        string Dcn_PR = "";
        string Dcn_TW = "";
        string Map_TH= "";
        string Map_PR = "";
        string Map_TW = "";
        string Oop_TH = "";
        string Oop_PR = "";
        string Oop_TW = "";
        string Amt_PR = "";
        string Amt_TW = "";
        string Ppt = "";
        string Sw = "";
        string Total = "";
        string Percentage = "";
        string Remarks = "";

         cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Enroll_No,Surname,Firstname,Middlename,Seatnumber,Est_TH,Est_TW,Chm_TH,Chm_PR,Chm_TW,Dcn_TH,Dcn_PR,Dcn_TW,Map_TH,Map_PR,Map_TW,Oop_TH,Oop_PR,Oop_TW,Amt_PR,Amt_TW,Ppt,SW,Total,Percentage,Remarks from Semester4 where Enroll_No='" + stud_enroll + "' ";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            enroll_no = rs.GetValue(0).ToString();
            surname = rs.GetValue(1).ToString();
            firstname = rs.GetValue(2).ToString();
            middlename = rs.GetValue(3).ToString();
            seatnumber = rs.GetValue(4).ToString();
            Est_TH = rs.GetValue(5).ToString();
            Est_TW = rs.GetValue(6).ToString();
            Chm_TH = rs.GetValue(7).ToString();
            Chm_PR = rs.GetValue(8).ToString();
            Chm_TW = rs.GetValue(9).ToString();
            Dcn_TH= rs.GetValue(10).ToString();
            Dcn_PR = rs.GetValue(11).ToString();
            Dcn_TW= rs.GetValue(12).ToString();
            Map_TH = rs.GetValue(13).ToString();
            Map_PR= rs.GetValue(14).ToString();
            Map_TW= rs.GetValue(15).ToString();
            Oop_TH = rs.GetValue(16).ToString();
            Oop_PR = rs.GetValue(17).ToString();
            Oop_TW = rs.GetValue(18).ToString();
            Amt_PR = rs.GetValue(19).ToString();
            Amt_TW = rs.GetValue(20).ToString();
            Ppt= rs.GetValue(21).ToString();
            Sw = rs.GetValue(22).ToString();
            Total = rs.GetValue(23).ToString();
            Percentage = rs.GetValue(24).ToString();
            Remarks = rs.GetValue(25).ToString();
        
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();
        ////


        string html = "<table width='100%' border='1'><tr><th colspan='4'><center>STATEMENT OF MARKS</center></th></tr><tr><td><b><center>Mr/Ms</b>:" + firstname + " " + middlename + " " + surname + "</center></td><td rowspan='3'><b><center>EXAMINATION 2016</center></b></td><td rowspan='3'><b><center>SEAT NO</b>:</center></td><td rowspan='3'><b><center>FOURTH SEMESTER</center></b></td></tr><tr><td><b><center>ENROLLMENT NO:" + enroll_no + "</center></b></td></tr><tr><td><center><b>COURSE IF:DIPLOMA IN INFORMATION TECHNOLOGY</b></center></td></tr></table><br><table width='100%' border='1'><tr><th><center>TITLE OF SUBJECT</center></th><th><center>SUB HEAD</center></th><th><center>MAX MARKS</center></th><th><center>MIN MARKS</center></th><th><center>MARKS OBTAINED</center></th></tr><tr><td rowspan='2'><center>ENVIROMENTAL STUDIES (EST)</center></td><td><center>TH</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Est_TH + "</center></td></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Est_TW + "</center></td></tr><tr><td rowspan='3'><center>COMPUTER HARDWARE & MAINTENANCE (CHM)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Chm_TH + "</center></td></tr><tr><td><center>PR</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Chm_PR + "</center></td></tr></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Chm_TW + "</center></td></tr><tr><td rowspan='3'><center>DATA COMMUNICATION & NETWORKING (DCN)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Dcn_TH + "</center></td></tr><tr><td><center>PR</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Dcn_PR + "</center></td></tr></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Dcn_TW + "</center></td></tr><tr><td rowspan='3'><center>MICROPROCESSOR & PROGRAMMING (MAP)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Map_TH + "</center></td></tr><tr><td><center>PR</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Map_PR + "</center></td></tr></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Map_TW + "</center></td></tr><tr><td rowspan='3'><center>OBJECT ORIENTED PROGRAMMING (OOP)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Oop_TH + "</center></td></tr><tr><td><center>PR</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Oop_PR + "</center></td></tr></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Oop_TW + "</center></td></tr><tr><td rowspan='2'><center>APPLIED MULTIMEDIA TECHNOLOGY (AMT)</center></td><td><center>PR</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Amt_PR + "</center></td></tr><tr><td><center>TW</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Amt_TW + "</center></td></tr><tr><td><center>PROFESSIONAL PRACTICES-II (PPT)</center></td><td><center>TW</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Ppt + "</center></td></tr><tr><td><center>SW</center></td><td><center>SW</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Sw + "</center></td></tr></table><br><table width='100%' border='1'><tr><td rowspan='3'><b><center>Date:" + System.DateTime.Now.ToShortDateString() + "</center></b></td><td><b><center>TOTAL MARKS</center></b></td><td><b><center>RESULT WITH %</center></b></td><td><b><center>MARKS OBTAINED</center></b></td><td><b><center>Grade</center></b></td></tr><td><center>900</center></td><td><center>" + Percentage + "</center></td><td><center>" + Total + "</center></td><td><center>" + Remarks + "</center></td></table>";
        DivReplace.InnerHtml = html;

    }

}