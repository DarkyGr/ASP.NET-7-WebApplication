create database db_webapplication01

use db_webapplication01

create table users(
	u_id int primary key identity,
	u_name varchar(50),
	u_email varchar(50),
	u_key varchar(100),
)