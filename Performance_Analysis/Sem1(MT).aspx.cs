using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Collections;
using System.Data.OleDb;
using System.Data;

public partial class Sem1_MT_ : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd1 = new SqlCommand();
    SqlDataReader rs;
    string auto = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        cn.ConnectionString = "Data Source=DESKTOP-M8LUGSB\\SQLEXPRESS;Initial Catalog=Result_Analysis;Integrated Security=true";

        if (!IsPostBack)
        {
            Auto_Gen();
        }
    }
    private void Auto_Gen()
    {

        int cnt;
        string id;
        int temp;
        temp = 0;
        cnt = 0;
        id = "";
        cn.Open();
        cmd1.Connection = cn;
        cmd1.CommandText = "select count(*) from Semester2_MT";
        rs = cmd1.ExecuteReader();
        while (rs.Read())
        {
            cnt = int.Parse(rs.GetValue(0).ToString());
        }
        rs.Close();
        cmd1.Dispose();
        cn.Close();
        if (cnt > 0)
        {
            cn.Open();
            cmd1.Connection = cn;
            cmd1.CommandText = "select max(ID) from Semester2_MT";
            rs = cmd1.ExecuteReader();
            while (rs.Read())
            {
                id = rs.GetValue(0).ToString();
            }
            rs.Close();
            cmd1.Dispose();
            cn.Close();
            temp = int.Parse(id.Substring(1, 4));
            temp++;
            id = "";
            id = temp.ToString();
            if (id.Length == 1)
            {
                id = "I000" + id;
            }
            else if (id.Length == 2)
            {
                id = "I00" + id;
            }
            else if (id.Length == 3)
            {
                id = "I0" + id;
            }
            else if (id.Length == 4)
            {
                id = "I" + id;
            }
            auto = id;
        }
        else
        {
            auto = "I0001";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string connString = "";
        FileUpload1.SaveAs(Server.MapPath("~/Upload/" + FileUpload1.FileName));//for uploading files
        string strFileType = Path.GetExtension(FileUpload1.FileName).ToLower();//getting path
        string path1 = FileUpload1.PostedFile.FileName;
        string path = System.IO.Path.GetFullPath(Server.MapPath("~/Upload/" + FileUpload1.FileName));//for storing files in .net folder
        if (strFileType.Trim() == ".xls")
        {
            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "E:\\Result_Analysis\\Upload\\sem2_MT.xls" + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";//for xls
        }
        else if (strFileType.Trim() == ".xlsx")
        {
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "E:\\Result_Analysis\\Upload\\sem2_MT.xlsx" + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";//for xlsx
        }
        //  string query = "select * FROM [IF1G$]";//for fetching data from excel sheet(sheet1)
        OleDbConnection conn = new OleDbConnection(connString);
        ArrayList list1 = new ArrayList();
        list1.Clear();
        ArrayList list2 = new ArrayList();
        list2.Clear();
        ArrayList list3 = new ArrayList();
        list3.Clear();
        ArrayList list4 = new ArrayList();
        list4.Clear();
        ArrayList list5 = new ArrayList();
        list5.Clear();
        ArrayList list6 = new ArrayList();
        list6.Clear();
        ArrayList list7 = new ArrayList();
        list7.Clear();
        ArrayList list8 = new ArrayList();
        list8.Clear();
        ArrayList list9 = new ArrayList();
        list9.Clear();
        ArrayList list10 = new ArrayList();
        list10.Clear();
        ArrayList list11 = new ArrayList();
        list11.Clear();
        ArrayList list12 = new ArrayList();
        list12.Clear();

        conn.Open();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader rs1;
        cmd.Connection = conn;
        cmd.CommandText = "select * from [IF2G$]";
        rs1 = cmd.ExecuteReader();
        while (rs1.Read())
        {
            list1.Add(rs1.GetValue(0).ToString());
            list2.Add(rs1.GetValue(1).ToString());
            list3.Add(rs1.GetValue(2).ToString());
            list4.Add(rs1.GetValue(3).ToString());
            list5.Add(rs1.GetValue(4).ToString());
            list6.Add(rs1.GetValue(5).ToString());
            list7.Add(rs1.GetValue(6).ToString());
            list8.Add(rs1.GetValue(7).ToString());
            list9.Add(rs1.GetValue(8).ToString());
            list10.Add(rs1.GetValue(9).ToString());
            list11.Add(rs1.GetValue(10).ToString());
            list12.Add(rs1.GetValue(11).ToString());
        } rs1.Close();
        cmd.Dispose();
        conn.Close();
        conn.Close();

        int i = 0;
        for (i = 0; i < list1.Count; i++)//for entering into the excel sheet
        {
            int count1 = 0;

            cn.Open();// connection for inserting data in database
            cmd1.Connection = cn;
            cmd1.CommandText = "select count(*) from Semester2_MT where Enroll_No='" + list1[i].ToString() + "'";
            rs = cmd1.ExecuteReader();
            while (rs.Read())
            {
                count1 = int.Parse(rs.GetValue(0).ToString());
            } rs.Close();
            cmd1.Dispose();
            cn.Close();

            string qry = "";
            if (count1 == 0)
            {
                Auto_Gen();//for inserting values in database
                qry = "insert into Semester2_MT (ID,Test_Type,Enroll_No,Surname,Firstname,Middlename,CMS,APH,ACH,PIC,BEL,BMS,Total,Percentage)values('" + auto + "','" + DropdownList1.Text + "','" + list1[i].ToString() + "','" + list2[i].ToString() + "','" + list3[i].ToString() + "','" + list4[i].ToString() + "','" + list5[i].ToString() + "','" + list6[i].ToString() + "','" + list7[i].ToString() + "','" + list8[i].ToString() + "','" + list9[i].ToString() + "','" + list10[i].ToString() + "','" + list11[i].ToString() + "','" + list12[i].ToString() + "')";

            }
            else
            {//updating database
                qry = "update  Semester2_MT set Test_Type='" + DropdownList1.Text + "', Surname='" + list2[i].ToString() + "',Firstname='" + list3[i].ToString() + "',Middlename='" + list4[i].ToString() + "',CMS='" + list5[i].ToString() + "',APH='" + list6[i].ToString() + "',ACH='" + list7[i].ToString() + "',PIC='" + list8[i].ToString() + "',BEL='" + list9[i].ToString() + "',BMS='" + list10[i].ToString() + "',TOTAL='" + list11[i].ToString() + "',Percentage='" + list12[i].ToString() + "' where Enroll_No='" + list1[i].ToString() + "' ";
            }

            cn.Open();
            cmd1.Connection = cn;
            cmd1.CommandText = qry;
            cmd1.ExecuteNonQuery();
            cmd1.Dispose();
            cn.Close();


            Label1.Text = "Successfully Uploaded";


        }
    }
}