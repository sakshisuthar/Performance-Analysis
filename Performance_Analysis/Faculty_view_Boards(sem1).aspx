<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Faculty_view_Boards(sem1).aspx.cs" Inherits="Faculty_view_Boards_sem1_" %>

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
    <div>
     
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
                <asp:BoundField DataField="Eng_TH" HeaderText="Eng_TH" 
                    SortExpression="Eng_TH" />
                <asp:BoundField DataField="Eng_TW" HeaderText="Eng_TW" 
                    SortExpression="Eng_TW" />
                <asp:BoundField DataField="Bsi_TH" HeaderText="Bsi_TH" 
                    SortExpression="Bsi_TH" />
                <asp:BoundField DataField="Bsi_PR" HeaderText="Bsi_PR" 
                    SortExpression="Bsi_PR" />
                <asp:BoundField DataField="Bms_TH" HeaderText="Bms_TH" 
                    SortExpression="Bms_TH" />
                <asp:BoundField DataField="Egg_PR" HeaderText="Egg_PR" 
                    SortExpression="Egg_PR" />
                <asp:BoundField DataField="Egg_TW" HeaderText="Egg_TW" 
                    SortExpression="Egg_TW" />
                <asp:BoundField DataField="Cmf_PR" HeaderText="Cmf_PR" 
                    SortExpression="Cmf_PR" />
                <asp:BoundField DataField="Cmf_TW" HeaderText="Cmf_TW" 
                    SortExpression="Cmf_TW" />
                <asp:BoundField DataField="Wcc_TW" HeaderText="Wcc_TW" 
                    SortExpression="Wcc_TW" />
                <asp:BoundField DataField="Sw" HeaderText="Sw" SortExpression="Sw" />
                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                <asp:BoundField DataField="Percentage" HeaderText="Percentage" 
                    SortExpression="Percentage" />
                <asp:BoundField DataField="Remarks" HeaderText="Remarks" 
                    SortExpression="Remarks" />
            </Columns>
        </asp:GridView>--%>
       <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Result_AnalysisConnectionString16 %>" 
            SelectCommand="SELECT * FROM [Semester1]"></asp:SqlDataSource>--%>
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




