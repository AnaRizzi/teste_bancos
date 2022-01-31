create database ana_teste;
use ana_teste;

create table clientes(
Id int primary key auto_increment,
Nome varchar(100) not null,
Cpf varchar(11) not null unique
);


create table comentarios(
Id int primary key auto_increment,
Id_cliente int not null,
Comentario varchar(300) not null,
foreign key (Id_cliente) references clientes(Id)
);
