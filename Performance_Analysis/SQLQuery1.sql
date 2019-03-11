create database Result_Analysis
create table Admin_Login
(Username varchar(800),
Password varchar(800))

insert into Admin_Login (Username,Password)values ('admin','admin')
select * from Admin_Login
select count(*) from Admin_Login where Username='admin' and Password='admin'


create table Department
(Dept_ID varchar(5),
Dept_Name varchar(800),
Dept_HOD varchar (800))

select * from Department

create table Faculty
(Faculty_ID varchar(5),
Faculty_Name varchar(800),
Faculty_Email varchar(800),
Faculty_Mob varchar(800),
Faculty_Adress varchar(800),
Faculty_Gender varchar(800),
Faculty_Age varchar(800),
Faculty_Dept varchar(800))

select* from  Faculty
select count(*) from Faculty
drop table Faculty
delete from Faculty where Faculty_Name='Yadav'

create table Faculty_Login
(Username varchar(800),
Password varchar(800))

select* from  Faculty_Login
drop table Faculty_Login
delete from Faculty_Login where Password='9029426487'

create table Student
(Stud_ID varchar(5),
Sur_Name varchar(800),
First_Name varchar(800),
Middle_Name varchar(800),
Stud_Address varchar(800),
Stud_Gender varchar(800),
Stud_Email varchar(800),
Stud_Mobile varchar(800),
Stud_Enrol varchar(800),
Stud_Year varchar(800),
Stud_Sem varchar(800),
Stud_Dept varchar(800))

select * from Student
drop table Student
delete from Student where Stud_ID='S0001'
 
create table Student_Login
(Username varchar(800),
Password varchar(800))

select * from Student_Login
delete from Student_Login where Username='abhi@gmail.com'

create table Seat_No_Assig
(Ass_ID varchar(5),
Stud_ID varchar(800),
Seat_No varchar(800),
Sem varchar(800))

select * from Seat_No_Assig

create table Subject_Master
(SM_ID varchar(5),
Department varchar(800),
Sem varchar(800),
Subject varchar(800),
Subject_Code varchar(800))

select * from Subject_Master
drop table Subject_Master
delete from Subject_Master where Sem='Sem3'

create table Subject_Mapping
(SM_ID varchar(5),
Faculty_ID varchar(800),
Faculty_Dept varchar(800),
Sem varchar(800),
Subject varchar(800))

select * from Subject_Mapping
delete from Subject_Mapping where Faculty_ID='F0001'
create table Semester1
(ID varchar(5),
Enroll_No varchar(800),
Surname varchar(800),
Firstname varchar(800),
Middlename varchar(800), 
Seatnumber varchar(800),
Eng_TH varchar(800),
Eng_TW varchar(800),
Bsi_TH varchar(800),
Bsi_PR varchar(800),
Bms_TH varchar(800),
Egg_PR varchar(800),
Egg_TW varchar(800),
Cmf_PR varchar(800),
Cmf_TW varchar(800),
Wcc_TW varchar(800),
Sw varchar(800),
Total varchar(800),
Percentage varchar(800),
Remarks varchar(800))


select Firstname,Middlename,Surname from Semester1 where Eng_Th=(select max(Eng_Th) from Semester1)
select Firstname,Middlename,Surname from Semester1 where Eng_Th=(select min(Eng_Th) from Semester1)

select * from Semester1
select Total,Firstname,Middlename,Surname from Semester1 order by Percentage desc limit 3
select Firstname,Middlename,Surname from Semester1 where Eng_TH<=50
select Firstname,Middlename,Surname from Semester1 where Bsi_TH<=35
select Firstname,Middlename,Surname from Semester1 where Bms_TH<=35
select max(Total) from Semester1 group by Total order by Total desc limit 5

select count(*) from Semester1 where Eng_TH>=40



create table Semester2
(ID varchar(5),
Enroll_No varchar(800),
Surname varchar(800),
Firstname varchar(800),
Middlename varchar(800), 
Seatnumber varchar(800),
Cms_TH varchar(800),
Cms_OR varchar(800),
Cms_TW varchar(800),
Aps_TH varchar(800),
Aps_TW varchar(800),
Pic_TH varchar(800),
Pic_PR varchar(800),
Pic_TW varchar(800),
Bel_TH varchar(800),
Bel_TW varchar(800),
Ems_TH varchar(800),
Dls_OR varchar(800),
Wpd_PR varchar(800),
Sw varchar(800),
Total varchar(800),
Percentage varchar(800),
Remarks varchar(800)) 

select Enroll_No,Surname,Firstname,Middlename,Seatnumber, Cms_TH,Cms_OR,Cms_TW, Aps_TH, Aps_TW,Pic_TH,Pic_PR,Pic_TW,Bel_TH,Bel_TW ,EMS_TH,Dls_OR,Wpd_PR, SW,Total,Percentage,Remarks from Semester2 where Enroll_No='E0001'
select Firstname,Middlename,Surname from Semester2 where Cms_TH=(select max(Cms_TH) from Semester2)
select * from Semester2
select Firstname,Middlename,Surname from Semester2 where Ems_TH=(select min(Ems_TH) from Semester2)
create table Semester3
(ID varchar(5),
Enroll_No varchar(800),
Surname varchar(800),
Firstname varchar(800),
Middlename varchar(800), 
Seatnumber varchar(800),
Ams_TH varchar(800),
Dsu_TH varchar(800),
Dsu_PR varchar(800),
Dsu_TW varchar(800),
Ete_TH varchar(800),
Ete_TW varchar(800),
Rdm_TH varchar(800),
Rdm_OR varchar(800),
Rdm_TW varchar(800),
Dte_TH varchar(800),
Dte_TW varchar(800),
Gui_PR varchar(800),
Ppo_TW varchar(800),
Sw varchar(800),
Total varchar(800),
Percentage varchar(800),
Remarks varchar(800))

select * from Semester3

create table Semester4
(ID varchar(5),
Enroll_No varchar(800),
Surname varchar(800),
Firstname varchar(800),
Middlename varchar(800), 
Seatnumber varchar(800),
Est_TH varchar(800),
Est_TW varchar(800),
Chm_TH varchar(800),
Chm_PR varchar(800),
Chm_TW varchar(800),
Dcn_TH varchar(800),
Dcn_PR varchar(800),
Dcn_TW varchar(800),
Map_TH varchar(800),
Map_PR varchar(800),
Map_TW varchar(800),
Oop_TH varchar(800),
Oop_PR varchar(800),
Oop_TW varchar(800),
Amt_PR varchar(800),
Amt_TW varchar(800),
Ppt varchar(800),
Sw varchar(800),
Total varchar(800),
Percentage varchar(800),
Remarks varchar(800))

select * from Semester4

create table Semester5
(ID varchar(5),
Enroll_No varchar(800),
Surname varchar(800),
Firstname varchar(800),
Middlename varchar(800), 
Seatnumber varchar(800),
Osy_TH varchar(800),
Osy_TW varchar(800),
Sen_TH varchar(800),
Ise_TH varchar(800),
Ise_TW varchar(800),
Jpr_TH varchar(800),
Jpr_PR varchar(800),
Jpr_TW varchar(800),
Cte_TH varchar(800),
Cte_PR varchar(800),
Cte_TW varchar(800),
Bsc_OR varchar(800),
Bsc_TW varchar(800),
Nma_PR varchar(800),
Nma_TW varchar(800),
Ppt_TW varchar(800),
Sw varchar(800),
Total varchar(800),
Percentage varchar(800),
Remarks varchar(800))

select * from Semester5

create table Semester6
(ID varchar(5),
Enroll_No varchar(800),
Surname varchar(800),
Firstname varchar(800),
Middlename varchar(800), 
Seatnumber varchar(800),
Man_TH varchar(800),
Mco_TH varchar(800),
Mco_PR varchar(800),
Mco_TW varchar(800),
Ajp_TH varchar(800),
Ajp_PR varchar(800),
Ajp_TW varchar(800),
Oom_TH varchar(800),
Oom_TW varchar(800),
Ste_PR varchar(800),
Ste_TW varchar(800),
Ipr_OR varchar(800),
Ipr_TW varchar(800),
Ede_TW varchar(800),
Sw varchar(800),
Total varchar(800),
Percentage varchar(800),
Remarks varchar(800))

select * from Semester6 
drop table Semester6
select count(*) from Semester6
delete from semester6 where Enroll_No='E0002'
select count(*) from Semester5 where Enroll_No='E0002'

create table Semester1_MT
(ID varchar(5),
Test_Type varchar(800),
Enroll_No varchar(800),
Surname varchar(800),
Firstname varchar(800),
Middlename varchar(800), 
ENG varchar(800),
EPH varchar(800),
ECH varchar(800),
BMS varchar(800),
Total varchar(800),
Percentage varchar(800))

select * from Semester1_MT
drop table Semester1_MT

create table Semester2_MT
(ID varchar(5),
Test_Type varchar(800),
Enroll_No varchar(800),
Surname varchar(800),
Firstname varchar(800),
Middlename varchar(800), 
CMS varchar(800),
APH varchar(800),
ACH varchar(800),
PIC varchar(800),
BEL varchar(800),
BMS varchar(800),
Total varchar(800),
Percentage varchar(800))

select * from Semester2_MT


create table Semester3_MT
(ID varchar(5),
Test_Type varchar(800),
Enroll_No varchar(800),
Surname varchar(800),
Firstname varchar(800),
Middlename varchar(800), 
AMS varchar(800),
DSU varchar(800),
ETE varchar(800),
RDM varchar(800),
DTE varchar(800),
Total varchar(800),
Percentage varchar(800))

select * from Semester3_MT

create table Semester4_MT
(ID varchar(5),
Test_Type varchar(800),
Enroll_No varchar(800),
Surname varchar(800),
Firstname varchar(800),
Middlename varchar(800), 
EST varchar(800),
CHM varchar(800),
DCN varchar(800),
MAP varchar(800),
OOP varchar(800),
Total varchar(800),
Percentage varchar(800))

select * from Semester4_MT

create table Semester5_MT
(ID varchar(5),
Test_Type varchar(800),
Enroll_No varchar(800),
Surname varchar(800),
Firstname varchar(800),
Middlename varchar(800), 
OSY varchar(800),
SEN varchar(800),
ISE varchar(800),
JPR varchar(800),
CTE varchar(800),
Total varchar(800),
Percentage varchar(800))

select * from Semester5_MT

create table Semester6_MT
(ID varchar(5),
Test_Type varchar(800),
Enroll_No varchar(800),
Surname varchar(800),
Firstname varchar(800),
Middlename varchar(800), 
MAN varchar(800),
STE varchar(800),
MOC varchar(800),
AJP varchar(800),
OOMD varchar(800),
Total varchar(800),
Percentage varchar(800))

select * from Semester6_MT
