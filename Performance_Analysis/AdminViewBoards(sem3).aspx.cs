using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AdminViewBoards_sem3_ : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = "Data Source=DESKTOP-M8LUGSB\\SQLEXPRESS;Initial Catalog=Result_Analysis;Integrated Security=true";
    }
    public void ReplaceDiv()
    {


        string enroll_no = "";
        string surname = "";
        string firstname = "";
        string middlename = "";
        string seatnumber = "";
        string Ams_TH = "";
        string Dsu_TH = "";
        string Dsu_PR = "";
        string Dsu_TW = "";
        string Ete_TH = "";
        string Ete_TW = "";
        string Rdm_TH = "";
        string Rdm_OR = "";
        string Rdm_TW = "";
        string Dte_TH = "";
        string Dte_TW = "";
        string Gui_PR = "";
        string Ppo_TW = "";
        string Sw = "";
        string Total = "";
        string Percentage = "";
        string Remarks = "";

        //cn
        int count = 0;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "Select count(*) from Semester3 where Enroll_No='" + Textbox1.Text + "'";
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
        cmd.CommandText = "select Enroll_No,Surname,Firstname,Middlename,Seatnumber,Ams_TH,Dsu_TH,Dsu_PR,Dsu_TW,Ete_TH,Ete_TW,Rdm_TH,Rdm_OR,Rdm_TW,Dte_TH,Dte_TW,Gui_PR,Ppo_TW ,SW,Total,Percentage,Remarks from Semester3 where Enroll_No='" + Textbox1.Text + "' ";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            enroll_no = rs.GetValue(0).ToString();
            surname = rs.GetValue(1).ToString();
            firstname = rs.GetValue(2).ToString();
            middlename = rs.GetValue(3).ToString();
            seatnumber = rs.GetValue(4).ToString();
            Ams_TH = rs.GetValue(5).ToString();
            Dsu_TH = rs.GetValue(6).ToString();
            Dsu_PR = rs.GetValue(7).ToString();
            Dsu_TW = rs.GetValue(8).ToString();
            Ete_TH = rs.GetValue(9).ToString();
            Ete_TW = rs.GetValue(10).ToString();
            Rdm_TH = rs.GetValue(11).ToString();
            Rdm_OR = rs.GetValue(12).ToString();
            Rdm_TW = rs.GetValue(13).ToString();
            Dte_TH = rs.GetValue(14).ToString();
            Dte_TW = rs.GetValue(15).ToString();
            Gui_PR = rs.GetValue(16).ToString();
            Ppo_TW = rs.GetValue(17).ToString();
            Sw = rs.GetValue(18).ToString();
            Total = rs.GetValue(19).ToString();
            Percentage = rs.GetValue(20).ToString();
            Remarks = rs.GetValue(21).ToString();

        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        if (count > 0)
        {

            string html = "<table width='100%' border='1'><tr><th colspan='4'><center>STATEMENT OF MARKS</center></th></tr><tr><td><b><center>Mr/Ms</b>:" + firstname + " " + middlename + " " + surname + "</center></td><td rowspan='3'><b><center>EXAMINATION 2016</center></b></td><td rowspan='3'><b><center>SEAT NO</b>:</center></td><td rowspan='3'><b><center>THIRD SEMESTER</center></b></td></tr><tr><td><b><center>ENROLLMENT NO:" + enroll_no + "</center></b></td></tr><tr><td><center><b>COURSE IF:DIPLOMA IN INFORMATION TECHNOLOGY</b></center></td></tr></table><br><table width='100%' border='1'><tr><th><center>TITLE OF SUBJECT</center></th><th><center>SUB HEAD</center></th><th><center>MAX MARKS</center></th><th><center>MIN MARKS</center></th><th><center>MARKS OBTAINED</center></th></tr><tr><td><center>APPLIED MATHEMATICS (AMS)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Ams_TH + "</center></td></tr><tr><td rowspan='3'><center>DATA STRUCTURE (DSU)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Dsu_TH + "</center></td></tr><tr><td><center>PR</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Dsu_PR + "</center></td></tr></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Dsu_TW + "</center></td></tr><tr><td rowspan='2'><center>ELECTRICAL TECHNOLOGY (ETE)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Ete_TH + "</center></td></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Ete_TW + "</center></td></tr><tr><td rowspan='3'><center>RELATIONAL DATABASE MANAGEMENT SYSTEM (RDM)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Rdm_TH + "</center></td></tr><tr><td><center>OR</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Rdm_OR + "</center></td></tr></tr><tr><td><center>TW</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Rdm_TW + "</center></td></tr></tr><tr><td rowspan='2'><center>DIGITAL TECHNIQUES (DTE)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Dte_TH + "</center></td></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Dte_TW + "</center></td></tr><tr><td><center>GRAPHICAL USER INTERFACE PROGRAMMING (GUI)</center></td><td><center>PR</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Gui_PR + "</center></td></tr><tr><td><center>PROFESSIONAL PRATICES-I (PPO)</center></td><td><center>TW</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Ppo_TW + "</center></td></tr><tr><td><center>SW</center></td><td><center>SW</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Sw + "</center></td></tr></table><br><table width='100%' border='1'><tr><td rowspan='3'><b><center>Date:" + System.DateTime.Now.ToShortDateString() + "</center></b></td><td><b><center>TOTAL MARKS</center></b></td><td><b><center>RESULT WITH %</center></b></td><td><b><center>MARKS OBTAINED</center></b></td><td><b><center>Grade</center></b></td></tr><td><center>850</center></td><td><center>" + Percentage + "</center></td><td><center>" + Total + "</center></td><td><center>" + Remarks + "</center></td></table>";

            DivReplace.InnerHtml = html;
        }
        else
        {

            string html1 = "NO SUCH RECORDS";

            DivReplace.InnerHtml = html1;
        }


    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        ReplaceDiv();
    }
}