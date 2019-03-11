using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AdminViewBoards_sem5_ : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = "Data Source=DESKTOP-M8LUGSB\\SQLEXPRESS;Initial Catalog=Result_Analysis;Integrated Security=true";
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        ReplaceDiv();
    }
    public void ReplaceDiv()
    {
        //string stud_enroll = "";
        //cn.Open();
        //cmd.Connection = cn;
        //cmd.CommandText = "select Stud_Enrol from Student where Stud_Email='" + Session["Student_Username"] + "'";
        //rs = cmd.ExecuteReader();
        //while (rs.Read())
        //{
        //    stud_enroll = rs.GetValue(0).ToString();
        //}
        //rs.Close();
        //cmd.Dispose();
        //cn.Close();

        string enroll_no = "";
        string surname = "";
        string firstname = "";
        string middlename = "";
        string seatnumber = "";
        string Osy_TH = "";
        string Osy_TW = "";
        string Sen_TH = "";
        string Ise_TH = "";
        string Ise_TW = "";
        string Jpr_TH = "";
        string Jpr_PR = "";
        string Jpr_TW = "";
        string Cte_TH = "";
        string Cte_PR = "";
        string Cte_TW = "";
        string Bsc_OR = "";
        string Bsc_TW = "";
        string Nma_PR = "";
        string Nma_TW = "";
        string Ppt_TW = "";
        string Sw = "";
        string Total = "";
        string Percentage = "";
        string Remarks = "";


        ///
        int count = 0;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester5 where Enroll_No='" + Textbox1.Text + "'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            count = int.Parse(rs.GetValue(0).ToString());
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Enroll_No,Surname,Firstname,Middlename,Seatnumber,Osy_TH,Osy_TW,Sen_TH,Ise_TH,Ise_TW,Jpr_TH,Jpr_PR,Jpr_TW,Cte_TH,Cte_PR,Cte_TW,Bsc_OR,Bsc_TW,Nma_PR,Nma_TW,Ppt_TW,SW,Total,Percentage,Remarks from Semester5 where Enroll_No='" + Textbox1.Text + "' ";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            enroll_no = rs.GetValue(0).ToString();
            surname = rs.GetValue(1).ToString();
            firstname = rs.GetValue(2).ToString();
            middlename = rs.GetValue(3).ToString();
            seatnumber = rs.GetValue(4).ToString();
            Osy_TH = rs.GetValue(5).ToString();
            Osy_TW = rs.GetValue(6).ToString();
            Sen_TH = rs.GetValue(7).ToString();
            Ise_TH = rs.GetValue(8).ToString();
            Ise_TW = rs.GetValue(9).ToString();
            Jpr_TH = rs.GetValue(10).ToString();
            Jpr_PR = rs.GetValue(11).ToString();
            Jpr_TW = rs.GetValue(12).ToString();
            Cte_TH = rs.GetValue(13).ToString();
            Cte_PR = rs.GetValue(14).ToString();
            Cte_TW = rs.GetValue(15).ToString();
            Bsc_OR = rs.GetValue(16).ToString();
            Bsc_TW = rs.GetValue(17).ToString();
            Nma_PR = rs.GetValue(18).ToString();
            Nma_TW = rs.GetValue(19).ToString();
            Ppt_TW = rs.GetValue(20).ToString();
            Sw = rs.GetValue(21).ToString();
            Total = rs.GetValue(22).ToString();
            Percentage = rs.GetValue(23).ToString();
            Remarks = rs.GetValue(24).ToString();
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        ////
        if (count > 0)
        {
            string html = "<table width='100%' border='1'><tr><th colspan='4'><center>STATEMENT OF MARKS</center></th></tr><tr><td><b><center>Mr/Ms</b>:" + firstname + " " + middlename + " " + surname + "</center></td><td rowspan='3'><b><center>EXAMINATION 2016</center></b></td><td rowspan='3'><b><center>SEAT NO</b>:" + seatnumber + "</center></td><td rowspan='3'><b><center>FIFTH SEMESTER</center></b></td></tr><tr><td><b><center>ENROLLMENT NO:" + enroll_no + "</center></b></td></tr><tr><td><center><b>COURSE IF:DIPLOMA IN INFORMATION TECHNOLOGY</b></center></td></tr></table><br><table width='100%' border='1'><tr><th><center>TITLE OF SUBJECT</center></th><th><center>SUB HEAD</center></th><th><center>MAX MARKS</center></th><th><center>MIN MARKS</center></th><th><center>MARKS OBTAINED</center></th></tr><tr><td rowspan='2'><center>OPERATING SYSTEM (OSY)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Osy_TH + "</center></td></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Osy_TW + "</center></td></tr><tr><td><center>SOFTWARE ENGINEERING (SEN)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Sen_TH + "</center></td></tr><tr><td rowspan='2'><center>INFORMATION SECURITY (ISE)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Ise_TH + "</center></td></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Ise_TW + "</center></td></tr><tr><td rowspan='3'><center>JAVA PROGRAMMING (JPR)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Jpr_TH + "</center></td></tr><tr><td><center>PR</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Jpr_PR + "</center></td></tr></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Jpr_TW + "</center></td></tr><tr><td rowspan='3'><center>COMMUNICATION TECHNOLOGY (CTE)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Cte_TH + "</center></td></tr><tr><td><center>PR</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Cte_PR + "</center></td></tr></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Cte_TW + "</center></td></tr><tr><td rowspan='2'><center>BEHAVIOURAL SCIENCE (BSC)</center></td><td><center>OR</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Bsc_OR + "</center></td></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Bsc_TW + "</center></td></tr><tr><td rowspan='2'><center>NETWORK MANAGEMENT & ADMINISTRATION (NMA)</center></td><td><center>PR</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Nma_PR + "</center></td></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Nma_TW + "</center></td></tr><tr><td><center>PROFESSIONAL PRACTICES-III (PPT)</center></td><td><center>TW</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Ppt_TW + "</center></td></tr><tr><td><center>SW</center></td><td><center>SW</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Sw + "</center></td></tr></table><br><table width='100%' border='1'><tr><td rowspan='3'><b><center>Date:" + System.DateTime.Now.ToShortDateString() + "</center></b></td><td><b><center>TOTAL MARKS</center></b></td><td><b><center>RESULT WITH %</center></b></td><td><b><center>MARKS OBTAINED</center></b></td><td><b><center>Grade</center></b></td></tr><td><center>900</center></td><td><center>" + Percentage + "</center></td><td><center>" + Total + "</center></td><td><center>" + Remarks + "</center></td></table>"; DivReplace.InnerHtml = html;
        }
        else
        {
            string html1 = "No Such records";
            DivReplace.InnerHtml = html1;
        }


    }
}