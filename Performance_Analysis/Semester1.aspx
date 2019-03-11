<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Semester1.aspx.cs" Inherits="Semester1" %>
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
              <%--  <a class="navbar-brand" href="#" ><strong style=""></strong></a>--%>
            </div>
            <div class="navbar-collapse collapse move-me">
                <ul class="nav navbar-nav navbar-right set-links">
                    <li><a href="Homepage.aspx">HOME</a></li>
                 <%--    <li><a href="Department.aspx">DEPARTMENT</a></li>--%>
                     <li><a href="Student.aspx">STUDENT </a></li>
                    <li><a href="Faculty.aspx">FACULTY</a></li>
                     <li><a href="Subject_Master.aspx">SUBJECT</a></li>
                       <li><a href="Subject_Mapping(Faculty).aspx">SUBJECT MAPPING</a></li>
                   <%-- <li><a href="seat_Number_Assignment.aspx">SEAT NUMBER ASSIGNMENT</a></li>--%>
                    <li><a href="Enter_Marks.aspx">ENTER MARKS</a></li>
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
    <h1><center>Semester 1</center></h1>
    <table>
     <tr>
    <td>ID</td>
    <td><asp:TextBox ID="Textbox1" runat="server"/></td>
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
    <td>Seat Number</td>
    <td><asp:TextBox ID="Textbox6" runat="server"/></td>
    </tr>
     <tr>
    <td>ENG TH</td>
    <td><asp:TextBox ID="Textbox7" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Textbox7" ErrorMessage="Enter Marks" ForeColor="Red"/></td>
    </tr>
     <tr>
    <td>ENG TW</td>
    <td><asp:TextBox ID="Textbox8" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Textbox8" ErrorMessage="Enter Marks" ForeColor="Red"/></td>
    </tr>
      <tr>
    <td>BSI TH</td>
    <td><asp:TextBox ID="Textbox9" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Textbox9" ErrorMessage="Enter Marks" ForeColor="Red"/></td>
    </tr>
      <tr>
    <td>BSI PR</td>
    <td><asp:TextBox ID="Textbox10" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Textbox10" ErrorMessage="Enter Marks" ForeColor="Red"/></td>
    </tr>
      <tr>
    <td>BMS TH</td>
    <td><asp:TextBox ID="Textbox11" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Textbox11" ErrorMessage="Enter Marks" ForeColor="Red"/></td>
    </tr>
      <tr>
    <td>EGG PR</td>
    <td><asp:TextBox ID="Textbox12" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Textbox12" ErrorMessage="Enter Marks" ForeColor="Red"/></td>
    </tr>
     <tr>
    <td>EGG TW</td>
    <td><asp:TextBox ID="Textbox13" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Textbox13" ErrorMessage="Enter Marks" ForeColor="Red"/></td>
    </tr>
     <tr>
    <td>CMF PR</td>
    <td><asp:TextBox ID="Textbox14" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Textbox14" ErrorMessage="Enter Marks" ForeColor="Red"/></td>
    </tr>
     <tr>
    <td>CMF TW</td>
    <td><asp:TextBox ID="Textbox15" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="Textbox15" ErrorMessage="Enter Marks" ForeColor="Red"/></td>
    </tr>
     <tr>
    <td>WCC TW</td>
    <td><asp:TextBox ID="Textbox16" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="Textbox16" ErrorMessage="Enter Marks" ForeColor="Red"/></td>
    </tr>
     <tr>
    <td>SW</td>
    <td><asp:TextBox ID="Textbox17" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="Textbox17" ErrorMessage="Enter Marks" ForeColor="Red"/></td>
    </tr>
    
     <tr>
    <td>Total</td>
    <td><asp:TextBox ID="Textbox18" runat="server" ReadOnly="True"/></td>
    </tr>
     <tr>
    <td>Percentage</td>
    <td><asp:TextBox ID="Textbox19" runat="server" ReadOnly="True"/></td>
    </tr>
     <tr>
    <td>Remarks</td>
    <td><asp:TextBox ID="Textbox20" runat="server"/></td>
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


