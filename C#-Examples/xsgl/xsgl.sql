go
use xsgl
go
create table xsgl_user(
	user_id int identity primary key,
	user_name varchar(30) not null,
	user_pwd varchar(30)
)
go
create table xsgl_course(
	course_no int identity primary key,
	course_name varchar(30) not null unique,
	course_teacher varchar(30)
)
go
create table xsgl_student(
	stud_no varchar(8) primary key,
	stud_name nvarchar(30) not null,
	stud_sex nchar(2) not null,
	stud_birthDate datetime not null,
	stud_major nvarchar(30) not null,
	stud_isMember bit default(1),
	stud_pic image
)
go
create table xsgl_score(
	stud_no varchar(8) not null references xsgl_student(stud_no),
	course_no int not null references xsgl_course(course_no),
	score_score decimal(7,2) not null,
	primary key(stud_no,course_no)
) 
go 
insert into xsgl_user(user_name ,user_pwd) values('lwb','123456');
insert into xsgl_course(course_name) values('C语言');
insert into xsgl_course(course_name) values('Java');
insert into xsgl_course(course_name) values('ASP');
insert into xsgl_student(stud_no,stud_name,stud_sex,stud_birthDate,stud_major,stud_isMember) values ('101','张长海','男','1989-08-10','计算机',1);
insert into xsgl_student(stud_no,stud_name,stud_sex,stud_birthDate,stud_major,stud_isMember) values ('102','李学军','男','1990-01-20','计算机',1);
insert into xsgl_student(stud_no,stud_name,stud_sex,stud_birthDate,stud_major,stud_isMember) values ('201','王丽','女','1989-06-27','计算机',0);
insert into xsgl_student(stud_no,stud_name,stud_sex,stud_birthDate,stud_major,stud_isMember) values ('202','赵磊','男','1990-10-02','电子',0);
insert into xsgl_student(stud_no,stud_name,stud_sex,stud_birthDate,stud_major,stud_isMember) values ('203','田小蕊','女','1989-04-28','自动化',1);
insert into xsgl_score values('101',1,85);
insert into xsgl_score values('101',2,75);
insert into xsgl_score values('101',3,65);
insert into xsgl_score values('102',1,85);
insert into xsgl_score values('102',2,55);
insert into xsgl_score values('102',3,45);
insert into xsgl_score values('201',1,95);
insert into xsgl_score values('201',2,45);
insert into xsgl_score values('201',3,85);
insert into xsgl_score values('202',1,65);
insert into xsgl_score values('202',2,75);
insert into xsgl_score values('202',3,65);
insert into xsgl_score values('203',1,75);
insert into xsgl_score values('203',2,65);
insert into xsgl_score values('203',3,95);