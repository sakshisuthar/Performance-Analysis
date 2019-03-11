<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Faculty_view_Boards(sem2).aspx.cs" Inherits="Faculty_view_Boards_sem2_" %>

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
<div class="col-md-13">
    <form id="form1" runat="server">
   <%-- <div style="overflow:auto; width:100" >--%>
     <asp:Textbox ID="Textbox1" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Search" onclick="Button1_Click" /></br></br>

     <div id="DivReplace" runat="server"></div>
     
        <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="Enroll_No" HeaderText="Enroll_No" 
                    SortExpression="Enroll_No" />
                <asp:BoundField DataField="Surname" HeaderText="Surname" 
                    SortExpression="Surname" />
                <asp:BoundField DataField="Firstname" HeaderText="Firstname" 
                    SortExpression="Firstname" />
                <asp:BoundField DataField="Middlename" HeaderText="Middlename" 
                    SortExpression="Middlename" />
                <asp:BoundField DataField="Seatnumber" HeaderText="Seatnumber" 
                    SortExpression="Seatnumber" />
                <asp:BoundField DataField="Cms_TH" HeaderText="Cms_TH" 
                    SortExpression="Cms_TH" />
                <asp:BoundField DataField="Cms_OR" HeaderText="Cms_OR" 
                    SortExpression="Cms_OR" />
                <asp:BoundField DataField="Cms_TW" HeaderText="Cms_TW" 
                    SortExpression="Cms_TW" />
                <asp:BoundField DataField="Aps_TH" HeaderText="Aps_TH" 
                    SortExpression="Aps_TH" />
                <asp:BoundField DataField="Aps_TW" HeaderText="Aps_TW" 
                    SortExpression="Aps_TW" />
                <asp:BoundField DataField="Pic_TH" HeaderText="Pic_TH" 
                    SortExpression="Pic_TH" />
                <asp:BoundField DataField="Pic_PR" HeaderText="Pic_PR" 
                    SortExpression="Pic_PR" />
                <asp:BoundField DataField="Pic_TW" HeaderText="Pic_TW" 
                    SortExpression="Pic_TW" />
                <asp:BoundField DataField="Bel_TH" HeaderText="Bel_TH" 
                    SortExpression="Bel_TH" />
                <asp:BoundField DataField="Bel_TW" HeaderText="Bel_TW" 
                    SortExpression="Bel_TW" />
                <asp:BoundField DataField="Ems_TH" HeaderText="Ems_TH" 
                    SortExpression="Ems_TH" />
                <asp:BoundField DataField="Dls_OR" HeaderText="Dls_OR" 
                    SortExpression="Dls_OR" />
                <asp:BoundField DataField="Wpd_PR" HeaderText="Wpd_PR" 
                    SortExpression="Wpd_PR" />
                <asp:BoundField DataField="Sw" HeaderText="Sw" SortExpression="Sw" />
                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                <asp:BoundField DataField="Percentage" HeaderText="Percentage" 
                    SortExpression="Percentage" />
                <asp:BoundField DataField="Remarks" HeaderText="Remarks" 
                    SortExpression="Remarks" />
            </Columns>
        </asp:GridView>--%>
       <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Result_AnalysisConnectionString17 %>" 
            SelectCommand="SELECT * FROM [Semester2]"></asp:SqlDataSource>--%>
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





