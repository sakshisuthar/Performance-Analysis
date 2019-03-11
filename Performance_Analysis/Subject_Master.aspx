<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Subject_Master.aspx.cs" Inherits="Subject_Master" %>

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
          <%--      <a class="navbar-brand" href="#" ><strong style="">Admin Login</strong></a>--%>
            </div>
            <div class="navbar-collapse collapse move-me">
                <ul class="nav navbar-nav navbar-right set-links">
                    <li><a href="index.html" class="active-menu-item"></a></li>
                     <li><a href="Homepage.aspx" >HOME</a></li>
                     <%--<li><a href="Department.aspx">DEPARTMENT</a></li>--%>
                     <li><a href="Student.aspx">STUDENT </a></li>
                    <li><a href="Faculty.aspx">FACULTY</a></li>
                       <li><a href="Subject_Master.aspx">SUBJECT</a></li>
                         <li><a href="Subject_Mapping(Faculty).aspx">SUBJECT MAPPING</a></li>
                      <%--<li><a href="seat_Number_Assignment.aspx">SEAT NUMBER ASSIGNMENT</a></li>--%>
                      <li><a href="Enter_Marks.aspx">UPLOAD MARKS</a></li>
                      <li><a href="Change_Password(Admin).aspx">CHANGE PASSWORD</a></li>
                    <li><a href="Admin_Login.aspx">LOGOUT</a></li>
                    <li><a href="pgAdminLogin.aspx"></a></li>
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
    <center><h1>Subject Master</center></h1>
    <table>
    <tr>
    <td>SM ID</td>
    <td><asp:Textbox ID="Textbox1" runat="server"/></td>
    </tr>
    <tr>
  <td>Department</td>
    <td><asp:DropdownList ID="DropdownList1" runat="server">
    <asp:ListItem Text="CMPN" Value="CMPN"/>
    <asp:ListItem Text="IT" Value="IT"/>
     <asp:ListItem Text="EXTC" Value="EXTC"/>
      <asp:ListItem Text="ETRX" Value="ETRX"/>
       <asp:ListItem Text="MECH" Value="MECH"/>
        <asp:ListItem Text="CIVIL" Value="CIVIL"/>
         <asp:ListItem Text="CHEMICAL" Value="CHEMICAL"/>
    </asp:DropdownList></td>
    </tr>

    <tr>
    <td>Sem</td>
    <td><asp:DropdownList ID="DropdownList2" runat="server" >
    <asp:ListItem Text="Sem1" Value="Sem1"/>
    <asp:ListItem Text="Sem2" Value="Sem2"/>
     <asp:ListItem Text="Sem3" Value="Sem3"/>
     <asp:ListItem Text="Sem4" Value="Sem4"/>
    <asp:ListItem Text="Sem5" Value="Sem5"/>
     <asp:ListItem Text="Sem6" Value="Sem6"/>

   
    </asp:DropdownList></td>
    </tr>

    <tr>
    <td>Subject</td>
    <td><asp:Textbox ID="Textbox2" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Textbox2" ErrorMessage="Please Enter Subject" ForeColor="Red"/></td>
    </tr>

    <tr>
    <td>Subject Code</td>
    <td><asp:Textbox ID="Textbox3" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Textbox3" ErrorMessage="Please Enter Subject Code" ForeColor="Red"/></td>
    </tr>


    </table>
    <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click"/>
    <asp:Label ID="Label1" runat="server"/>
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

