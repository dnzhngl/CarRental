﻿CREATE DATABASE CarRental

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Email NVARCHAR(MAX) NULL,
	PasswordHash NVARCHAR(MAX) NULL,
	JoinDate DATETIME2(7) NOT NULL,
)

CREATE TABLE Customers(
	Id INT PRIMARY KEY FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	PhoneNumber nvarchaR(max) NULL,
	Address nvarchar(max) NULL,
)

CREATE TABLE IndividualCustomers(
	Id INT PRIMARY KEY FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	IdentityNo NVARCHAR(MAX) NULL,
	FirstName NVARCHAR(MAX) NULL,
	LastName NVARCHAR(MAX) NULL,
	DOB DATETIME NOT NULL,
)

CREATE TABLE CorporateCustomers(
	Id INT PRIMARY KEY FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CompanyName NVARCHAR(MAX) NULL,
	TaxNumber NVARCHAR(MAX) NULL
)

CREATE TABLE Brands(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(MAX) NULL,
)

CREATE TABLE Colors(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(MAX) NULL,
)

CREATE TABLE CarTypes(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(MAX) NULL,
)

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	LicensePlate NVARCHAR(10) NOT NULL,
	Capacity TINYINT NOT NULL,
	Model NVARCHAR(MAX)  NULL,
	ModelYear NVARCHAR(4) NULL,
	DailyPrice FLOAT NOT NULL,
	Description NVARCHAR(MAX) NULL,
	IsAvailable BIT NULL,
	BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
	CarTypeId INT FOREIGN KEY REFERENCES CarTypes(Id) NOT NULL,
	ColorId INT FOREIGN KEY REFERENCES Colors(Id) NOT NULL
)

-- CarImages table with GUID - NEWID() id  
--CREATE TABLE CarImages(
--	Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID() NOT NULL,
--	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
--	ImagePath VARBINARY(MAX) NOT NULL,
--	Date DATETIME NOT NULL
--)

CREATE TABLE CarImages(
	Id int PRIMARY KEY NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	ImagePath NVARCHAR(MAX) NOT NULL,
	Date DATETIME NOT NULL
)

CREATE TABLE Rentals(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL,
	CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL,
	RentDate DATETIME2(7) NOT NULL,
	ReturnDate DATETIME2(7) NULL,
	TotalPrice FLOAT NULL,
	Discount REAL NULL
)