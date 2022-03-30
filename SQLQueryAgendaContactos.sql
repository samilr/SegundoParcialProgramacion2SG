create database Agenda
go

use Agenda

create table Contactos 
(
Id int identity (1,1) primary key,
Firt_Name nvarchar (100),
Last_Name nvarchar (100),
Firt_Address nvarchar (100),
Date_Birthday date,
Phone_Number nvarchar (15)
)

insert into Contactos 
values
('Samir','Gonzalez','Santo Domingo','2002-08-31','8091234567')


--------------------------MOSTRAR 
create proc MostrarContactos
as
select *from Contactos
go

--------------------------INSERTAR 
create proc InsetarContactos
@name nvarchar (100),
@lastName nvarchar (100),
@address nvarchar (100),
@dateBirthday date,
@phoneNumber nvarchar (10)
as
insert into Contactos values (@name,@lastName,@address,@dateBirthday,@phoneNumber)
go

--EDITAR

create proc EditarContactos 
@name nvarchar (20),
@lastName nvarchar (20),
@address nvarchar (100),
@dateBirthday date,
@phoneNumber nvarchar (10),
@idCont int
as
update Contactos set Firt_name=@name, Last_Name=@lastName, Firt_Address=@address, Date_Birthday=@dateBirthday, Phone_Number=@phoneNumber where Id=@idCont
go

--ELIMINAR
create proc EliminarContactos
@idCont int
as
delete from Contactos where Id=@idCont
go


--create proc MostrarPorBusqueda
--@name nvarchar (20)
--as
--select * from Contactos where Firt_Name = @name
--go
--drop table Contactos