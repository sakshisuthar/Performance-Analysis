using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


public partial class Semester1 : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    SqlDataReader rs;
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
        cmd.Connection = cn;
        cmd.CommandText = "select count(*) from Semester1";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            cnt = int.Parse(rs.GetValue(0).ToString());
        }
        rs.Close();
        cmd.Dispose();
        cn.Close();
        if (cnt > 0)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = "select max(ID) from Semester1";
            rs = cmd.ExecuteReader();
            while (rs.Read())
            {
                id = rs.GetValue(0).ToString();
            }
            rs.Close();
            cmd.Dispose();
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
            Textbox1.Text = id;
        }
        else
        {
            Textbox1.Text = "I0001";
        }
    }
    protected void Button_Click(object sender, EventArgs e)
    {
        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "select Sur_Name,First_Name,Middle_Name from Student where Stud_Enrol='"+Textbox2.Text+"'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Textbox3.Text = rs.GetValue(0).ToString();
            Textbox4.Text = rs.GetValue(1).ToString();
            Textbox5.Text = rs.GetValue(2).ToString();

        } rs.Close();
        cmd.Dispose();
        cn.Close();

        string stud_Id = "";
            cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "Select Stud_ID from Student where First_Name='"+Textbox4.Text+"'";
        rs=cmd.ExecuteReader();
        while(rs.Read())
        {
      stud_Id=rs.GetValue(0).ToString();

        }rs.Close();
        cmd.Dispose();
        cn.Close();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "Select Seat_No from Seat_No_Assig where Stud_ID='" + stud_Id + "'";
        rs = cmd.ExecuteReader();
        while (rs.Read())
        {
            Textbox6.Text = rs.GetValue(0).ToString();

        } rs.Close();
        cmd.Dispose();
        cn.Close();


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        double ENG_TH,ENG_TW,BSI_TH,BSI_PR,BMS_TH,EGG_PR,EGG_TW,CMF_PR,CMF_TW,WCC_TW,SW,Total,Percentage;
        ENG_TH = double.Parse(Textbox7.Text);
        ENG_TW = double.Parse(Textbox8.Text);
        BSI_TH = double.Parse(Textbox9.Text);
        BSI_PR = double.Parse(Textbox10.Text);
        BMS_TH = double.Parse(Textbox11.Text);
        EGG_PR = double.Parse(Textbox12.Text);
        EGG_TW = double.Parse(Textbox13.Text);
        CMF_PR = double.Parse(Textbox14.Text);
        CMF_TW = double.Parse(Textbox15.Text);
        WCC_TW = double.Parse(Textbox16.Text);
        SW = double.Parse(Textbox17.Text);

        Total=ENG_TH+ENG_TW+BSI_TH+BSI_PR+BMS_TH+EGG_PR+EGG_TW+CMF_PR+CMF_TW+WCC_TW+SW;
        Percentage = (Total / 650) * 100;
       Percentage= System.Math.Round(Percentage,2);
        Textbox18.Text = Total.ToString();
        Textbox19.Text = Percentage.ToString();

        cn.Open();
        cmd.Connection = cn;
        cmd.CommandText = "insert into Semester1 values('"+Textbox1.Text+"','"+Textbox2.Text+"','"+Textbox3.Text+"','"+Textbox4.Text+"','"+Textbox5.Text+"','"+Textbox6.Text+"','"+Textbox7.Text+"','"+Textbox8.Text+"','"+Textbox9.Text+"','"+Textbox10.Text+"','"+Textbox11.Text+"','"+Textbox12.Text+"','"+Textbox13.Text+"','"+Textbox14.Text+"','"+Textbox15.Text+"','"+Textbox16.Text+"','"+Textbox17.Text+"','"+Textbox18.Text+"','"+Textbox19.Text+"','"+Textbox20.Text+"')";
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        cn.Close();
        Label1.Text = "Successfull";
        Auto_Gen();

        Textbox2.Text = "";
        
        Textbox3.Text = "";
        Textbox4.Text = "";
        Textbox5.Text = "";
        Textbox6.Text = "";
        Textbox7.Text = "";
        Textbox8.Text = "";
        Textbox9.Text = "";
        Textbox10.Text = "";
        Textbox11.Text = "";
        Textbox12.Text = "";
        Textbox13.Text = "";
        Textbox14.Text = "";
        Textbox15.Text = "";
        Textbox16.Text = "";
        Textbox17.Text = "";
        Textbox18.Text = "";
        Textbox19.Text = "";
        Textbox20.Text = "";
     




    }
}