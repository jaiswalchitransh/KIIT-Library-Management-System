create table logintable(
	id int NOT NULL IDENTITY(1,1) primary key,
	username varchar(150) not null,
	pass varchar(150) not null
)

select * from logintable;


create table NewBook(
	bid int NOT NULL IDENTITY(1,1) primary key,
	bName varchar(250) not null,
	bAuthor varchar(250) not null,
	bPubl varchar(250) not null,
	bPDate varchar(250) not null,
	bPrice bigint not null,
	bQuant bigint not null,
	)

select * from NewBook;


create table NewStudent(
	stuid int NOT NULL IDENTITY(1,1) primary key,
	sname varchar(250) NOT NULL,
	enroll varchar(250) NOT NULL,
	dep varchar(250) not null,
	sem varchar(250) not null,
	contact bigint not null,
	email varchar(250) not null
)

select * from NewStudent;


create table IRBook(
	id int NOT NULL IDENTITY(1,1) primary key,
	std_enroll varchar(250) not null,
	std_name varchar(250) not null,
	std_dep varchar(250) not null,
	std_sem varchar(250) not null,
	std_contact bigint not null,
	std_email varchar(250) not null,
	book_name varchar(250) not null,
	book_issue_date varchar(250) not null,
	book_return_date varchar(250),
	);

select * from IRBook;
