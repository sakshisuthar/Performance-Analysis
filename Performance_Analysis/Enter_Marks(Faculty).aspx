<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Enter_Marks(Faculty).aspx.cs" Inherits="Enter_Marks_Faculty_" %>

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
                     <li><a href="View_Marks(Faculty).aspx" >VIEW MARKS</a></li>
                     <li><a href="Enter_Marks(Faculty).aspx" >ENTER MARKS</a></li>
                    <li><a href="Change_Password(Faculty).aspx" >CHANGE PASSWORD</a></li>
                     <li><a href="Student_Login.aspx" >LOGOUT</a></li>
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
    <h1><center>BOARDS</center></h1>

    </div>
    <table width=100%>
    <tr>
   <td> <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="Red" 
        NavigateUrl="~/Semester1(Faculty).aspx">Semester1</asp:HyperLink></td>
   
   <td><asp:HyperLink ID="HyperLink2" runat="server" ForeColor="Red" 
       >Semester2</asp:HyperLink></td>
   </td>
   
   <td><asp:HyperLink ID="HyperLink3" runat="server" ForeColor="Red" 
       >Semester3</asp:HyperLink></td>
   </td>
   </tr>
  
   <tr>
   <td><asp:HyperLink ID="HyperLink4" runat="server" ForeColor="Red" 
       >Semester4</asp:HyperLink></td>
   </td>
   
   <td><asp:HyperLink ID="HyperLink5" runat="server" ForeColor="Red" 
       >Semester5</asp:HyperLink></td>
   </td>
 
   <td><asp:HyperLink ID="HyperLink6" runat="server" ForeColor="Red" 
       >Semester6</asp:HyperLink></td>
   </td>
  
   </tr>
   </table>
   <h1><hr></h1>
    <table width=100%>
    <tr>
   <td> 
       <asp:HyperLink ID="HyperLink7" runat="server" ForeColor="Red" NavigateUrl="~/Semester_TT1(Faculty).aspx" 
        >Semester1</asp:HyperLink></td>
   
   <td><asp:HyperLink ID="HyperLink8" runat="server" ForeColor="Red" 
       >Semester2</asp:HyperLink></td>
   </td>
   
   <td><asp:HyperLink ID="HyperLink9" runat="server" ForeColor="Red" 
       >Semester3</asp:HyperLink></td>
   </td>
   </tr>
  
   <tr>
   <td><asp:HyperLink ID="HyperLink10" runat="server" ForeColor="Red" 
       >Semester4</asp:HyperLink></td>
   </td>
   
   <td><asp:HyperLink ID="HyperLink11" runat="server" ForeColor="Red" 
       >Semester5</asp:HyperLink></td>
   </td>
 
   <td><asp:HyperLink ID="HyperLink12" runat="server" ForeColor="Red" 
       >Semester6</asp:HyperLink></td>
   </td>
  
   </tr>
   </table>
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



