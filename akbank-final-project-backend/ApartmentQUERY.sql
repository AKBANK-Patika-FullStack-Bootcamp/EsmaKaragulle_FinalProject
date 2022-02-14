--Database olusturuldu.
create database ApartmentManagementDb

--Olusturulan database kullanildi.
use ApartmentDb

-- fatura tipleri tablosu olusturuldu.
create table InvoiceTypes(
Id int primary key identity(1,1),
InvoiceName nvarchar(30)
)

--user tablosu create
create table Users(
Id int primary key identity(1,1),
IdentityNo nvarchar(11) null,
FirstName nvarchar(30),
LastName nvarchar(30),
Email nvarchar(40),
Password nvarchar(30),
PasswordHash varbinary(500),
PasswordSalt varbinary(500),
Plate nvarchar(30) null,
IsActive bit,
IsDeleted bit
)

--aidatlar tablosu olusturuldu.
create table Duess (
Id int primary key identity(1,1),
Amount int
)

--Apartmanlar tablosu olusturuldu
create table Apartments(
Id int primary key identity(1,1),
DuesId int,
OwnerId int,
TenantId int null,
ResidentType nvarchar(30) null,
BlockNo nvarchar(10) null,
FloorNo nvarchar(10)null,
DoorNo nvarchar(10) null,
ApartmentType nvarchar(30) null,
IsBlank bit,
IsActive bit,
IsDeleted bit,
foreign key  (DuesId) references Duess(Id),
foreign key (OwnerId) references Users(Id),
foreign key (TenantId) references Users(Id)
)
--Odemeler tablosu olsuturuldu
create table Payments(
Id int primary key identity(1,1),
UserId int,
ApartmentId int,
InvoiceId int,
Amount int,
SuccessPayment bit,
BillingDate datetime,
DueDate datetime,
foreign key (UserId) references Users(Id),
foreign key  (ApartmentId) references Apartments(Id),
foreign key (InvoiceId) references InvoiceTypes(Id)
)

create table Mails(
Id int primary key identity(1,1),
FromMail nvarchar(100),
ToMail nvarchar(100),
Subject nvarchar(100),
Body nvarchar(250),
IsNew bit,
IsRead bit,
IsDeleted bit,
SendDate datetime,
OpenDate datetime
)

create table OperationClaims(
Id int primary key identity(1,1),
Name nvarchar(50)
)

create table UserOperationClaims(
Id int primary key identity(1,1),
UserId int,
OperationClaimId int,
foreign key  (UserId) references Users(Id),
foreign key (OperationClaimId) references OperationClaims(Id)

)
