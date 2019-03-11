using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class AdminViewBoards : System.Web.UI.Page
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
        string Eng_TH = "";
        string Eng_TW = "";
        string Bsi_TH = "";
        string Bsi_PR = "";
        string Bms_TH = "";
        string Egg_PR = "";
        string Egg_TW = "";
        string Cmf_PR = "";
        string Cmf_TW = "";
        string Wcc_TW = "";
        string Sw = "";
        string Total = "";
        string Percentage = "";
        string Remarks = "";

        // for all details
        int count = 0;
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "Select count(*) from Semester1 where Enroll_No='" + Textbox1.Text + "'";
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
        cmd.CommandText = "select Enroll_No,Surname,Firstname,Middlename,Seatnumber, Eng_TH, Eng_TW,Bsi_TH ,Bsi_PR,Bms_TH,Egg_PR,Egg_TW,Cmf_PR,Cmf_TW,Wcc_TW,SW,Total,Percentage,Remarks from Semester1 where Enroll_No='" + Textbox1.Text + "' ";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            enroll_no = rs.GetValue(0).ToString();
            surname = rs.GetValue(1).ToString();
            firstname = rs.GetValue(2).ToString();
            middlename = rs.GetValue(3).ToString();
            seatnumber = rs.GetValue(4).ToString();
            Eng_TH = rs.GetValue(5).ToString();
            Eng_TW = rs.GetValue(6).ToString();
            Bsi_TH = rs.GetValue(7).ToString();
            Bsi_PR = rs.GetValue(8).ToString();
            Bms_TH = rs.GetValue(9).ToString();
            Egg_PR = rs.GetValue(10).ToString();
            Egg_TW = rs.GetValue(11).ToString();
            Cmf_PR = rs.GetValue(12).ToString();
            Cmf_TW = rs.GetValue(13).ToString();
            Wcc_TW = rs.GetValue(14).ToString();
            Sw = rs.GetValue(15).ToString();
            Total = rs.GetValue(16).ToString();
            Percentage = rs.GetValue(17).ToString();
            Remarks = rs.GetValue(18).ToString();
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();



        if (count > 0)
        {
            string html = "<table width='100%' border='1'><tr><th colspan='4'><center>STATEMENT OF MARKS</center></th></tr><tr><td><b>Mr/Ms</b>:" + firstname + " " + middlename + " " + surname + "</td><td rowspan='3'><b>EXAMINATION 2016</b></td><td rowspan='3'><b>SEAT NO</b>:" + seatnumber + "</td><td rowspan='3'><b>FIRST SEMESTER</b></td></tr><tr><td><b>ENROLLMENT NO</b>:" + enroll_no + "</td></tr><tr><td><b>COURSE IF</b>:DIPLOMA IN INFORMATION TECHNOLOGY</td></tr></table><br><table width='100%' border='1'><tr><th><center>TITLE OF SUBJECT</center></th><th ><center>SUB HEAD</center></th><th ><center>MAX. MARKS</center></th><th ><center>MIN. MARKS</center></th><th><center>MARKS OBTAINED</center></th><tr><td rowspan='2'>ENGLISH (ENG)</td><td>TH</td><td>100</td><td>40</td><td>" + Eng_TH + "</td></tr><tr><td>TW</td><td>25</td><td>10</td><td>" + Eng_TW + "</td></tr><tr><td rowspan='2'>BASIC SCIENCE (BSI)</td><td>TH</td><td>100</td><td>40</td><td>" + Bsi_TH + "</td></tr><tr><td>PR</td><td>50</td><td>20</td><td>" + Bsi_PR + "</td></tr><tr><td>BASIC MATHEMATICS (BMS)</td><td>TH</td><td>100</td><td>40</td><td>" + Bms_TH + "</td></tr><tr><td rowspan='2'>ENGINEERING GRAPHICS (EGG)</td><td>PR</td><td>50</td><td>20</td><td>" + Egg_PR + "</td></tr><tr><td>TW</td><td>50</td><td>20</td><td>" + Egg_TW + "</td></tr><tr><td rowspan='2'>COMPUTER FUNDAMENTALS (CMF)</td><td>PR</td><td>50</td><td>20</td><td>" + Cmf_PR + "</td></tr><tr><td>TW</td><td>25</td><td>10</td><td>" + Cmf_TW + "</td></tr><tr><td>BASIC EORKSHOP PRACTISE (WPI)</td><td>TW</td><td>50</td><td>20</td><td>" + Wcc_TW + "</td></tr><tr><td>SW</td><td>SW</td><td>50</td><td>20</td><td>" + Sw + "</td></tr></table><br><table width='100%' border='1'><tr><td rowspan='3'><b>Date:" + System.DateTime.Now.ToShortDateString() + "</b></td><td><b>TOTAL MARKS</b></td><td><b>RESULT WITH %</b></td><td><b>MARKS OBTAINED</b></td><td><b>Grade</b></td></tr><td>650</td><td>" + Percentage + "</td><td>" + Total + "</td><td>" + Remarks + "</td></table>";
            DivReplace.InnerHtml = html;
        }
        else
        {

            string html1 = "NO SUCH RECORDS";
            DivReplace.InnerHtml = html1;
        }
    }

}