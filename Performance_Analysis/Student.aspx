<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Student.aspx.cs" Inherits="Student" %>

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
               <%-- <a class="navbar-brand" href="#" ><strong style="">Student Details</strong></a>--%>
            </div>
            <div class="navbar-collapse collapse move-me">
                <ul class="nav navbar-nav navbar-right set-links">
                    <li><a href="index.html" class="active-menu-item"></a></li>
                    <li><a href="Homepage.aspx" >HOME</a></li>
                     <%--<li><a href="Department.aspx">DEPARTMENT</a></li>--%>
                     <li><a href="Student.aspx">STUDENT </a></li>
                    <li><a href="Faculty.aspx">FACULTY</a></li>
                                         <%--  <li><a href="Subject_Master.aspx">SUBJECT</a></li>
                                             <li><a href="Subject_Mapping(Faculty).aspx">SUBJECT MAPPING</a></li>
                --%>    <%--  <li><a href="seat_Number_Assignment.aspx">SEAT NUMBER ASSIGNMENT</a></li>--%>
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
    <center><h1>Student Details</h1></center>
    <table>
    <tr>
    <td>Stud ID</br></br></br></td>
    <td><asp:Textbox ID="Textbox1" runat="server"/></br></br></br></td>
    </tr>
     <tr>
    <td>SurName</br></br></br></td>
    <td><asp:Textbox ID="Textbox2" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Textbox2"  ForeColor="Red" ErrorMessage="Enter surName"/></br></br></td>
    </tr>
     <tr>
    <td>FirstName</br></br></br></td>
    <td><asp:Textbox ID="Textbox3" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Textbox3"  ForeColor="Red" ErrorMessage="Enter FirstName"/></br></br></td>
    </tr>
     <tr>
    <td>MiddleName</br></br></br></td>
    <td><asp:Textbox ID="Textbox4" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Textbox4"  ForeColor="Red" ErrorMessage="Enter LastName"/></br></br></td>
    </tr>
     <tr>
    <td>Stud Address</br></br></br></td>
    <td><asp:Textbox ID="Textbox5" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Textbox5"  ForeColor="Red" ErrorMessage="Enter Address"/></br></br></td>
    </tr>
    <tr>
    <td>Faculty Gender</br></br></br></td>
    <td><asp:DropdownList ID="DropdownList4" runat="server">
    <asp:ListItem Text="Male" Value="Male"/>
    <asp:ListItem Text="Female" Value="Female"/>
    
    </asp:DropdownList></br></br></br></td>
    </tr>
     <tr>
    <td>Stud Email</br></br></br></td>
    <td><asp:Textbox ID="Textbox6" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Textbox5"  ForeColor="Red" ErrorMessage="Enter Email Id"/>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="Textbox6" ErrorMessage="Enter Valid ID" 
            ForeColor="Red" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
         </td>
    </tr>
     <tr>
    <td>Stud Mobile No</br></br></br></td>
    <td><asp:Textbox ID="Textbox7" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Textbox6"  ForeColor="Red" ErrorMessage="Enter Mobile No"/></br></br></td>
    </tr>
     
     <tr>
    <td>Stud Enrollment No</br></br></br></td>
    <td><asp:Textbox ID="Textbox8" runat="server"/><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Textbox7"  ForeColor="Red" ErrorMessage="Enter Enrolment No"/></br></br></br></td>
    </tr>
     <tr>
    <td>Year</br></br></br></br></td>
    <td><asp:DropdownList ID="DropdownList1" runat="server">
    <asp:ListItem Text="FE" Value="FE"/>
    <asp:ListItem Text="SE" Value="SE"/>
     <asp:ListItem Text="TE" Value="TE"/>
   
    </asp:DropdownList></br></br></br></br></td>
    </tr>
    <tr>
    <td>Sem</br></br></br></td>
    <td><asp:DropdownList ID="DropdownList2" runat="server" 
            onselectedindexchanged="DropdownList2_SelectedIndexChanged">
    <asp:ListItem Text="Sem1" Value="Sem1"/>
    <asp:ListItem Text="Sem2" Value="Sem2"/>
     <asp:ListItem Text="Sem3" Value="Sem3"/>
     <asp:ListItem Text="Sem4" Value="Sem4"/>
    <asp:ListItem Text="Sem5" Value="Sem5"/>
     <asp:ListItem Text="Sem6" Value="Sem6"/>

   
    </asp:DropdownList></br></br></br></br></td>
    </tr>
     <tr>
    <td>Stud Department</br></br></td>
    <td><asp:DropdownList ID="DropdownList3" runat="server">
    <asp:ListItem Text="CMPN" Value="CMPN"/>
    <asp:ListItem Text="IT" Value="IT"/>
     <asp:ListItem Text="EXTC" Value="EXTC"/>
      <asp:ListItem Text="ETRX" Value="ETRX"/>
       <asp:ListItem Text="MECH" Value="MECH"/>
        <asp:ListItem Text="CIVIL" Value="CIVIL"/>
         <asp:ListItem Text="CHEMICAL" Value="CHEMICAL"/>
    </asp:DropdownList></br></br></br></td>
    </tr>

    </table>
    <asp:Button ID="Button1" runat="server" Text="save" onclick="Button1_Click1"/>
    <asp:Button ID="Button2" runat="server" Text="Update" onclick="Button2_Click1"  />
    <asp:Button ID="Button3" runat="server" Text="Delete" onclick="Button3_Click1"  />
    <asp:Button ID="Button4" runat="server" Text="Clear" onclick="Button4_Click"  />
    <asp:Label  ID="label1" runat="server"/>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" 
            onselectedindexchanged="GridView1_SelectedIndexChanged1">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Stud_ID" HeaderText="Stud_ID" 
                    SortExpression="Stud_ID" />
                <asp:BoundField DataField="Sur_Name" HeaderText="Sur_Name" 
                    SortExpression="Sur_Name" />
                <asp:BoundField DataField="First_Name" HeaderText="First_Name" 
                    SortExpression="First_Name" />
                <asp:BoundField DataField="Middle_Name" HeaderText="Middle_Name" 
                    SortExpression="Middle_Name" />
                <asp:BoundField DataField="Stud_Address" HeaderText="Stud_Address" 
                    SortExpression="Stud_Address" />
                <asp:BoundField DataField="Stud_Gender" HeaderText="Stud_Gender" 
                    SortExpression="Stud_Gender" />
                <asp:BoundField DataField="Stud_Email" HeaderText="Stud_Email" 
                    SortExpression="Stud_Email" />
                <asp:BoundField DataField="Stud_Mobile" HeaderText="Stud_Mobile" 
                    SortExpression="Stud_Mobile" />
                <asp:BoundField DataField="Stud_Enrol" HeaderText="Stud_Enrol" 
                    SortExpression="Stud_Enrol" />
                <asp:BoundField DataField="Stud_Year" HeaderText="Stud_Year" 
                    SortExpression="Stud_Year" />
                <asp:BoundField DataField="Stud_Sem" HeaderText="Stud_Sem" 
                    SortExpression="Stud_Sem" />
                <asp:BoundField DataField="Stud_Dept" HeaderText="Stud_Dept" 
                    SortExpression="Stud_Dept" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:Result_AnalysisConnectionString3 %>" 
            SelectCommand="SELECT * FROM [Student]"></asp:SqlDataSource>
        <br />
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



