﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Collections;

public partial class Semester3_read_ : System.Web.UI.Page
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
        cmd1.CommandText = "select count(*) from Semester2";
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
            cmd1.CommandText = "select max(ID) from Semester2";
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
            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/Upload/" + FileUpload1.FileName) + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";//for xls
        }
        else if (strFileType.Trim() == ".xlsx")
        {
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath("~/Upload/" + FileUpload1.FileName) + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";//for xlsx
        }
        string query = "select * FROM [IF3G$]";//for fetching data from excel sheet(sheet1)
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
        ArrayList list13 = new ArrayList();
        list13.Clear();
        ArrayList list14 = new ArrayList();
        list14.Clear();
        ArrayList list15 = new ArrayList();
        list15.Clear();
        ArrayList list16 = new ArrayList();
        list16.Clear();
        ArrayList list17 = new ArrayList();
        list17.Clear();
        ArrayList list18 = new ArrayList();
        list18.Clear();
        ArrayList list19 = new ArrayList();
        list19.Clear();
        ArrayList list20 = new ArrayList();
        list20.Clear();
        ArrayList list21 = new ArrayList();
        list21.Clear();
        ArrayList list22 = new ArrayList();
        list22.Clear();

        conn.Open();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader rs1;
        cmd.Connection = conn;
        cmd.CommandText = "select * from [IF3G$]";
        rs1 = cmd.ExecuteReader();
        while (rs1.Read())
        {
            if (rs1.GetValue(0).ToString() != "")
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
                list13.Add(rs1.GetValue(12).ToString());
                list14.Add(rs1.GetValue(13).ToString());
                list15.Add(rs1.GetValue(14).ToString());
                list16.Add(rs1.GetValue(15).ToString());
                list17.Add(rs1.GetValue(16).ToString());
                list18.Add(rs1.GetValue(17).ToString());
                list19.Add(rs1.GetValue(18).ToString());
                list20.Add(rs1.GetValue(19).ToString());
                list21.Add(rs1.GetValue(20).ToString());
                list22.Add(rs1.GetValue(21).ToString());

            }
        }
        rs1.Close();
        cmd.Dispose();
        conn.Close();
        conn.Dispose();

        int i = 0;
        for (i = 0; i < list1.Count; i++)//for entering into the excel sheet
        {
            int count1 = 0;

            cn.Open();// connection for inserting data in database
            cmd1.Connection = cn;
            cmd1.CommandText = "select count(*) from Semester3 where Enroll_No='" + list1[i].ToString() + "'";
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
                Auto_Gen();//for inserting values into database
                qry = "insert into Semester3 (ID,Enroll_No,Surname,Firstname,Middlename,Seatnumber,Ams_TH ,Dsu_TH ,Dsu_PR,Dsu_TW  ,Ete_TH,Ete_TW,Rdm_TH ,Rdm_OR,Rdm_TW ,Dte_TH ,Dte_TW,Gui_PR,Ppo_TW,Sw ,Total,Percentage,Remarks)values('" + auto + "','" + list1[i].ToString() + "','" + list2[i].ToString() + "','" + list3[i].ToString() + "','" + list4[i].ToString() + "','" + list5[i].ToString() + "','" + list6[i].ToString() + "','" + list7[i].ToString() + "','" + list8[i].ToString() + "','" + list9[i].ToString() + "','" + list10[i].ToString() + "','" + list11[i].ToString() + "','" + list12[i].ToString() + "','" + list13[i].ToString() + "','" + list14[i].ToString() + "','" + list15[i].ToString() + "','" + list16[i].ToString() + "','" + list17[i].ToString() + "','" + list18[i].ToString() + "','" + list19[i].ToString() + "','" + list20[i].ToString() + "','" + list21[i].ToString() + "','" + list22[i].ToString() + "')";

            }
            else
            {//for updating database
                qry = "update  Semester3 set Surname='" + list2[i].ToString() + "',Firstname='" + list3[i].ToString() + "',Middlename='" + list4[i].ToString() + "',Seatnumber='" + list5[i].ToString() + "',Ams_TH='" + list6[i].ToString() + "',Dsu_TH='" + list7[i].ToString() + "',Dsu_PR ='" + list8[i].ToString() + "',Dsu_TW ='" + list9[i].ToString() + "',Ete_TH='" + list10[i].ToString() + "',Ete_TW='" + list11[i].ToString() + "',Rdm_TH='" + list12[i].ToString() + "',Rdm_OR='" + list13[i].ToString() + "',Rdm_TW='" + list14[i].ToString() + "',Dte_TH ='" + list15[i].ToString() + "',Dte_TW='" + list16[i].ToString() + "',Gui_PR='" + list17[i].ToString() + "',Ppo_TW='" + list18[i].ToString() + "',Sw ='" + list19[i].ToString() + "',Total='" + list20[i].ToString() + "',Percentage='" + list21[i].ToString() + "',Remarks='" + list22[i].ToString() + "' where Enroll_No='" + list1[i].ToString() + "' ";
            }

            cn.Open();
            cmd1.Connection = cn;
            cmd1.CommandText = qry;
            cmd1.ExecuteNonQuery();
            cmd1.Dispose();
            cn.Close();

            Label1.Text = "Updated Successfully";



        }
    }
}