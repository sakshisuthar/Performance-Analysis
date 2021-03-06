﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Semester_TT1(Faculty).aspx.cs" Inherits="Semester_TT1_Faculty_" %>
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
                <a class="navbar-brand" href="#" ><strong style="">Performance Analysis</strong></a>
            </div>
            <div class="navbar-collapse collapse move-me">
                <ul class="nav navbar-nav navbar-right set-links">
                    <li><a href="index.html" class="active-menu-item"></a></li>
                     <li><a href="Enter_Marks(Faculty).aspx" >ENTER MARKS</a></li>
                    <li><a href="Change_Password(Faculty).aspx" >CHANGE PASSWORD</a></li>
                     <li><a href="Faculty_Login.aspx" >LOGOUT</a></li>
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
     <h1><center>Semester 1</center></h1>
    <table>
     <tr>
    <td>ID</td>
    <td><asp:TextBox ID="Textbox1" runat="server"/></td>
    </tr>
  
  <tr>
  <td> Test Type</td>
  <td><asp:DropdownList ID="DropdownList1" runat="server">
  <asp:ListItem Text="Monday Test" Value="Monday Test"/>
  <asp:ListItem Text="PT1" Value="PT1"/>
   <asp:ListItem Text="PT2" Value="PT2"/>
  </asp:DropdownList >
  </tr>
   <tr>
   <td>Enrollment No</td>
   <td><asp:Textbox ID="Textbox2" runat="server"/></td>
   <td><asp:Button ID="Button" runat="server" Text="Search" onclick="Button_Click" 
           ValidationGroup="a"/></td>
   </tr>
   <tr>
    <td>SurName</td>
    <td><asp:TextBox ID="Textbox3" runat="server"/></td>
    </tr>
     <tr>
    <td>FirstName</td>
    <td><asp:TextBox ID="Textbox4" runat="server"/></td>
    </tr>
     <tr>
    <td>MiddleName</td>
    <td><asp:TextBox ID="Textbox5" runat="server"/></td>
    </tr>
    <tr>
     <tr>
    <td>Roll No</td>
    <td><asp:TextBox ID="Textbox6" runat="server"/></td>
    </tr>
    <tr>
    <td>Subject</td>
     <td><asp:DropdownList ID="DropdownList2" runat="server" AutoPostBack="True" 
             onselectedindexchanged="DropdownList2_SelectedIndexChanged" >
     <asp:ListItem Value="Please Select One" Text="Please Select One"/>
     </asp:DropdownList></td>
     </tr>
    <tr>
    <td>ENG</td>
    <td><asp:Textbox ID="Textbox7" runat="server"/></td>
    </tr>
    <tr>
    <td>EPH</td>
    <td><asp:Textbox ID="Textbox8" runat="server"/></td>
    </tr>
     <tr>
    <td>ECH</td>
    <td><asp:Textbox ID="Textbox9" runat="server"/></td>
    </tr>
     <tr>
    <td>BMS</td>
    <td><asp:Textbox ID="Textbox10" runat="server"/></td>
    </tr>
    
    </table>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click"/>
    <asp:Label ID="Label1" runat="server"/>
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



