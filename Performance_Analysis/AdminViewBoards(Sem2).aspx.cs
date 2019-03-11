using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AdminViewBoards_Sem2_ : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rs;
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = "Data Source=DESKTOP-M8LUGSB\\SQLEXPRESS;Initial Catalog=Result_Analysis;Integrated Security=true";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ReplaceDiv();
    }
    public void ReplaceDiv()
    {


        string enroll_no = "";
        string surname = "";
        string firstname = "";
        string middlename = "";
        string seatnumber = "";
        string Cms_TH = "";
        string Cms_OR = "";
        string Cms_TW = "";
        string Aps_TH = "";
        string Aps_TW = "";
        string Pic_TH = "";
        string Pic_PR = "";
        string Pic_TW = "";
        string Bel_TH = "";
        string Bel_TW = "";
        string EMS_TH = "";
        string Dls_OR = "";
        string Wpd_PR = "";
        string SW = "";
        string Total = "";
        string Percentage = "";
        string Remarks = "";
        //
        int count = 0;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "Select count(*) from Semester2 where Enroll_No='" + Textbox1.Text + "'";
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
        cmd.CommandText = "select Enroll_No,Surname,Firstname,Middlename,Seatnumber, Cms_TH,Cms_OR,Cms_TW, Aps_TH, Aps_TW,Pic_TH,Pic_PR,Pic_TW,Bel_TH,Bel_TW ,EMS_TH,Dls_OR,Wpd_PR, SW,Total,Percentage,Remarks from Semester2 where Enroll_No='" + Textbox1.Text + "' ";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            enroll_no = rs.GetValue(0).ToString();
            surname = rs.GetValue(1).ToString();
            firstname = rs.GetValue(2).ToString();
            middlename = rs.GetValue(3).ToString();
            seatnumber = rs.GetValue(4).ToString();
            Cms_TH = rs.GetValue(5).ToString();
            Cms_OR = rs.GetValue(6).ToString();
            Cms_TW = rs.GetValue(7).ToString();
            Aps_TH = rs.GetValue(8).ToString();
            Aps_TW = rs.GetValue(9).ToString();
            Pic_TH = rs.GetValue(10).ToString();
            Pic_PR = rs.GetValue(11).ToString();
            Pic_TW = rs.GetValue(12).ToString();
            Bel_TH = rs.GetValue(13).ToString();
            Bel_TW = rs.GetValue(14).ToString();
            EMS_TH = rs.GetValue(15).ToString();
            Dls_OR = rs.GetValue(16).ToString();
            Wpd_PR = rs.GetValue(17).ToString();
            SW = rs.GetValue(18).ToString();
            Total = rs.GetValue(19).ToString();
            Percentage = rs.GetValue(20).ToString();
            Remarks = rs.GetValue(21).ToString();
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();

        if (count > 0)
        {
            string html = "<table width='100%' border='1'><tr><th colspan='4'><center>STATEMENT OF MARKS</center></th></tr><tr><td><center><b>Mr/Ms</b>:" + firstname + " " + middlename + " " + surname + "</center></td><td rowspan='3'><center><b>EXAMINATION 2016</b></center></td><td rowspan='3'><center><b>SEAT NO</b>:" + seatnumber + "</center></td><td rowspan='3'><center><b>SECOND SEMESTER</b></center></td></tr><tr><td><center><b>ENROLLMENT NO</b>:" + enroll_no + "</center></td></tr><tr><td><center><b>COURSE IF</b>:DIPLOMA IN INFORMATION TECHNOLOGY</center></td></tr></table><br><table><table width='100%' border='1'><tr><th><center>TITLE OF SUBJECT</center></th><th ><center>SUB HEAD</center></th><th ><center>MAX. MARKS</center></th><th ><center>MIN. MARKS</center></th><th><center>MARKS OBTAINED</center></th><tr ><td rowspan='3'><center>COMMUNICATION SKILLS (CMS)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Cms_TH + "</center></td></tr><tr><td><center>OR</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Cms_OR + "</center></td></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Cms_TW + "</center></td></tr><tr><td rowspan='2'><center>APPLIED SCIENCE (APS)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Aps_TH + "</center></td></tr><tr><td><center>TW</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Aps_TW + "</center></td></tr><tr><td rowspan='3'><center>PROGRAMMING IN 'C' (PIC)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Pic_TH + "</center></td></tr><tr><td><center>PR</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Pic_TH + "</center></td></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Pic_TW + "</center></td></tr><tr><td rowspan='2'><center>BASIC ELECTRONICS (BEL)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + Bel_TH + "</center></td></tr><tr><td><center>TW</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Bel_TW + "</center></td></tr><tr><td><center>ENGINEERING MATHEMATICS (EMS)</center></td><td><center>TH</center></td><td><center>100</center></td><td><center>40</center></td><td><center>" + EMS_TH + "</center></td></tr><tr><td><center>DEVELOPMENT OF LIFE SKILLS (DLS)</center></td><td><center>OR</center></td><td><center>25</center></td><td><center>10</center></td><td><center>" + Dls_OR + "</center></td></tr><tr><td><center>WEB PAGE DESIGNING (WPD)</center></td><td><center>PR</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + Wpd_PR + "</center></td></tr><tr><td><center>SW</center></td><td><center>SW</center></td><td><center>50</center></td><td><center>20</center></td><td><center>" + SW + "</center></td></tr></table><br><table width='100%' border='1'><tr><td rowspan='3'><b><center>Date:" + System.DateTime.Now.ToShortDateString() + "</center></b></td><td><b><center>TOTAL MARKS</center></b></td><td><b><center>RESULT WITH %</center></b></td><td><b><center>MARKS OBTAINED</center></b></td><td><b><center>Grade</center></b></td></tr><td><center>650</center></td><td><center>" + Percentage + "</center></td><td><center>" + Total + "</center></td><td><center>" + Remarks + "</center></td></table>";
            DivReplace.InnerHtml = html;
        }
        else
        {

            string html1 = "NO SUCH RECORDS";
            DivReplace.InnerHtml = html1;
        }

    }

}