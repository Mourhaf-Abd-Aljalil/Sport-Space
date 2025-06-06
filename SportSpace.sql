CREATE DATABASE SportSpace1;

use SportSpace1;

CREATE TABLE Owner 
(
	Owner_ID INT PRIMARY KEY ,
	Name NVARCHAR(30),
	Email NVARCHAR(40),
	Phone_Number NVARCHAR(15) NOT NULL
);


CREATE TABLE Field 
(
	Field_ID INT PRIMARY KEY Identity(1,1),
	Owner_ID INT REFERENCES Owner(Owner_ID),
	Field_Name NVARCHAR(20),
	Location NVARCHAR(50),
	Field_Type NVARCHAR(20),
	Capacity INT CHECK( Capacity > 7 )
);



CREATE TABLE Offers
(
	Offer_ID INT PRIMARY KEY Identity(101,1),
	Field_ID INT REFERENCES Field(Field_ID),
	Descripyion NVARCHAR(200) NOT NULL,
	DiscountPercenttag Decimal CHECK( DiscountPercenttag > 0.0 ),
	Start_Date DateTime,
	End_Date DateTime 
);



CREATE TABLE Services
(
	Service_ID INT PRIMARY KEY Identity(1001,1),
	Service_Name NVARCHAR(20),
	Service_Cost Decimal CHECK( Service_Cost >= 0.0 )
);



CREATE TABLE Field_Services
(
	Field_Service_ID INT PRIMARY KEY IDENTITY(100,1),
	Service_ID INT REFERENCES Services(Service_ID),
	Field_ID INT REFERENCES Field(Field_ID)
);



CREATE TABLE Customer
(
	Customer_ID INT PRIMARY KEY  IDENTITY(5001,1),
	Booker_ID INT REFERENCES Booker(Booker_ID) ,
	Name NVARCHAR(30),
	Email NVARCHAR(40),
	Customer_Type BIT
);



CREATE TABLE Review
(
	Review_ID INT PRIMARY KEY IDENTITY(1,1),
	Customer_ID INT REFERENCES Customer(Customer_ID),
	Rating INT CHECK(Rating BETWEEN 1 AND 5),
	Comment NVARCHAR(255)
);



CREATE TABLE Booker 
(
	Booker_ID INT PRIMARY KEY  IDENTITY(1,1),
	Name NVARCHAR(30),
	Email NVARCHAR(40),
	Phone_Number NVARCHAR(15)
);



CREATE TABLE Booking
(
	Booking_ID INT PRIMARY KEY IDENTITY(1,1),
	Field_ID INT REFERENCES Field(Field_ID),
	Booker_ID INT REFERENCES Booker(Booker_ID),
	Booking_Date DateTime,
	Start_Time DateTime,
	End_Time DateTime,
	Booking_Cost Decimal CHECK( Booking_Cost > 0.0 )
);

CREATE TABLE Payment
(
	Payment_ID INT PRIMARY KEY IDENTITY(100,10),
	Booking_ID INT REFERENCES Booking(Booking_ID),
	Amount Decimal CHECK( Amount > 0.0 ),
	Payment_Date Date,
	Payment_Method NVARCHAR(25)
);

