Create Table DoctorsDetails(
DoctorsID bigint Primary key identity(1,1) not null,
DoctorsName Nvarchar(100) not null,
Qualification Nvarchar(50) Not null,
PassoutYear bigint not null,
PhoneNumber bigint not null unique ,
Addresss Nvarchar(500) not null)
select *from DoctorsDetails
Create procedure InsertProcedure @DoctorsName Nvarchar(100),@Qualification Nvarchar(50),@PassoutYear bigint ,
@PhoneNumber bigint ,@Addresss Nvarchar(500) 
as 
begin
insert into DoctorsDetails values(@DoctorsName,@Qualification,@PassoutYear,@PhoneNumber,@Addresss )
end
exec InsertProcedure 'Sankar','BE Mech',2022,1234506709,'Thoppampatty'
Create procedure UpdateProcedure @DoctorsID bigint ,@DoctorsName Nvarchar(100),@Qualification Nvarchar(50),@PassoutYear bigint ,
@PhoneNumber bigint ,@Addresss Nvarchar(500) 
as
begin
update DoctorsDetails set DoctorsName=@DoctorsName,Qualification=@Qualification,PhoneNumber=@PhoneNumber,PassoutYear=@PassoutYear,
Addresss=@Addresss where DoctorsID=@DoctorsID
end
exec UpdateProcedure 1,'Sankar','BE Mech',2022,1234506909,'Thoppampatty'
Create Procedure DeleteProcedure @DoctorsID bigint
as 
begin
delete DoctorsDetails where @DoctorsID=DoctorsID
end
exec DeleteProcedure 2
Create Procedure SelectProcedure 
as 
begin
select* from DoctorsDetails
end
exec DeleteProcedure 1
