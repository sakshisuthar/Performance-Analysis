<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Faculty.aspx.cs" Inherits="Faculty" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!--[if IE]>
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <![endif]-->
    <title>Performance Analysis</title>
    <!-- BOOTSTRAP CORE STYLE CSS -->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
     <!-- FONTAWESOME STYLE CSS -->
     <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLE CSS -->
    <link href="assets/css/style.css" rel="stylesheet" />
</head>
<body > 
   
        <div class="navbar navbar-inverse navbar-fixed-top " >
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
              <%--  <a class="navbar-brand" href="#" ><strong style="">Faculty Details</strong></a>--%>
            </div>
            <div class="navbar-collapse collapse move-me">
                <ul class="nav navbar-nav navbar-right set-links">
                    <li><a href="Homepage.aspx" >HOME</a></li>
<%--                     <li><a href="Department.aspx">DEPARTMENT</a></li>--%>
                     <li><a href="Student.aspx">STUDENT </a></li>
                    <li><a href="Faculty.aspx">FACULTY</a></li>
                                         <%--  <li><a href="Subject_Master.aspx">SUBJECT</a></li>
                                             <li><a href="Subject_Mapping(Faculty).aspx">SUBJECT MAPPING</a></li>--%>
                     <%-- <li><a href="seat_Number_Assignment.aspx">SEAT NUMBER ASSIGNMENT</a></li>--%>
                      <li><a href="Enter_Marks.aspx">UPLOAD MARKS</a></li>
                       <li><a href="Analysis.aspx">ANALYSIS</a></li>
                      <li><a href="Change_Password(Admin).aspx">CHANGE PASSWORD</a></li>
                    <li><a href="Admin_Login.aspx">LOGOUT</a></li>
                </ul>
            </div>

        </div>
    </div>
    <!--MENU SECTION END-->
    <section id="home-sec">
        <div class="overlay text-center">
            <h1 >Performance Analysis</h1>
            <hr class="hr-set"/>

            <p>Secured | Anonymous</p>
        </div>
    </section>
    <!--HOME SECTION END-->

    <section id="features-sec"  >
        <div class="container">
           
            <div class="row text-center" >
<div class="col-md-3">
    <form id="form1" runat="server">
    <div>
    <center><h1>Faculty Details</h1></center>
    <table>
    <tr>
    <td>Faculty ID</br></br></td>
    <td><asp:Textbox ID="Textbox1" runat="server"/></br></td>
    </tr>
    <tr>
    <td>Faculty Name</br></br></td>
    <td><asp:Textbox ID="Textbox2" runat="server"/><asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="Textbox2" ErrorMessage="Enter Name" ForeColor="Red"/></td>
    </tr>
    <tr>
    <td>Faculty Email</br></br></td>
    <td><asp:Textbox ID="Textbox3" runat="server"/><asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="Textbox3" ErrorMessage="Enter Name" ForeColor="Red"/>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="Textbox3" ErrorMessage="RegularExpressionValidator" 
            ForeColor="Red" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Enter Valid Email</asp:RegularExpressionValidator>
        </td>
    </tr>
   
   <tr>
   <td>Faculty Subject</td>
   <td><asp:TextBox ID="TextBox6" runat="server"/></td>
   </tr>
    <tr>
    <td>Faculty Mobile No</td>
    <td><asp:Textbox ID="Textbox4" runat="server" MaxLength="10"/><asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="Textbox4" ErrorMessage="Enter Mobile No" ForeColor="Red"/></td>
    </tr>
    <tr>
    <td>Faculty Address</br></br></br></td>
    <td><asp:Textbox ID="Textbox5" runat="server"/><asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="Textbox5" ErrorMessage="Enter Address" ForeColor="Red"/></td>
    </tr>
   <tr>
    <td>Faculty Gender</td>
    <td><asp:DropdownList ID="DropdownList2" runat="server">
    <asp:ListItem Text="Male" Value="Male"/>
    <asp:ListItem Text="Female" Value="Female"/>
    
    </asp:DropdownList></td>
    </tr>
     <tr>
   <td>Faculty Age</td>
    <td><asp:Textbox ID="Textbox7" runat="server" MaxLength="10"/><asp:RequiredFieldValidator ID="rfv6" runat="server" ControlToValidate="Textbox7" ErrorMessage="Enter Age" ForeColor="Red"/></td>
    </tr>

     <tr>
    <td>Faculty Department</td>
    <td><asp:DropdownList ID="DropdownList1" runat="server">
    <asp:ListItem Text="CMPN" Value="CMPN"/>
    <asp:ListItem Text="IT" Value="IT"/>
     <asp:ListItem Text="EXTC" Value="EXTC"/>
      <asp:ListItem Text="ETRX" Value="ETRX"/>
       <asp:ListItem Text="MECH" Value="MECH"/>
        <asp:ListItem Text="CIVIL" Value="CIVIL"/>
         <asp:ListItem Text="CHEMICAL" Value="CHEMICAL"/>
    </asp:DropdownList>
    </tr>
    </table>
    <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click1" />
    <asp:Button ID="Button2" runat="server" Text="Update" onclick="Button2_Click" />
    <asp:Button ID="Button3" runat="server" Text="Delete" onclick="Button3_Click" />
    <asp:Button ID="Button4" runat="server" Text="Clear" onclick="Button4_Click" />
    <asp:LABEL ID="label1" runat="server"/>
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" 
            onselectedindexchanged="GridView1_SelectedIndexChanged1">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Faculty_ID" HeaderText="Faculty_ID" 
                    SortExpression="Faculty_ID" />
                <asp:BoundField DataField="Faculty_Name" HeaderText="Faculty_Name" 
                    SortExpression="Faculty_Name" />
                <asp:BoundField DataField="Faculty_Email" HeaderText="Faculty_Email" 
                    SortExpression="Faculty_Email" />
                <asp:BoundField DataField="Faculty_Subject" HeaderText="Faculty_Subject" 
                    SortExpression="Faculty_Subject" />
                <asp:BoundField DataField="Faculty_Mob" HeaderText="Faculty_Mob" 
                    SortExpression="Faculty_Mob" />
                <asp:BoundField DataField="Faculty_Adress" HeaderText="Faculty_Adress" 
                    SortExpression="Faculty_Adress" />
                <asp:BoundField DataField="Faculty_Gender" HeaderText="Faculty_Gender" 
                    SortExpression="Faculty_Gender" />
                <asp:BoundField DataField="Faculty_Age" HeaderText="Faculty_Age" 
                    SortExpression="Faculty_Age" />
                <asp:BoundField DataField="Faculty_Dept" HeaderText="Faculty_Dept" 
                    SortExpression="Faculty_Dept" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Result_AnalysisConnectionString %>" 
            SelectCommand="SELECT * FROM [Faculty]"></asp:SqlDataSource>
    </div>
    </form>
</div>
            </div>
        </div>
    </section>
     <!--FEATURES SECTION END-->
    <div class="copy-txt">
         <div class="container">
        <div class="row">
<div class="col-md-12 set-foot" >
    &copy 2016. All rights reserved | Design by :
</div>
            </div>
                   </div>
    </div>
     <!-- COPY TEXT SECTION END-->
    <!-- JAVASCRIPT FILES PLACED AT THE BOTTOM TO REDUCE THE LOADING TIME  -->
    <!-- CORE JQUERY  -->
    <script src="assets/js/jquery-1.11.1.js"></script>
    <!-- BOOTSTRAP SCRIPTS  -->
    <script src="assets/js/bootstrap.js"></script>
    <!-- CUSTOM SCRIPTS  -->
    <script src="assets/js/custom.js"></script>
</body>
</html>



