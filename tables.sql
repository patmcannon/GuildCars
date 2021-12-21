USE GuildCars
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='Special')
	DROP TABLE Special
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Purchase')
	DROP TABLE Purchase
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicle')
	DROP TABLE Vehicle
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='State')
	DROP TABLE State
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='InteriorColor')
	DROP TABLE InteriorColor
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='ExteriorColor')
	DROP TABLE ExteriorColor
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseType')
	DROP TABLE PurchaseType
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='BodyType')
	DROP TABLE BodyType
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Model')
	DROP TABLE Model
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
	DROP TABLE Make
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Contact')
	DROP TABLE Contact
GO



CREATE TABLE [State] (
	StateAbbr CHAR(2) PRIMARY KEY not null,
	StateName VARCHAR(15) not null
)


CREATE TABLE PurchaseType (
	PurchaseTypeID INT IDENTITY(1,1) PRIMARY KEY not null,
	PurchaseTypeName VARCHAR(15) not null
)


CREATE TABLE BodyType (
	BodyTypeID INT IDENTITY(1,1) PRIMARY KEY not null,
	BodyTypeName VARCHAR(15) not null
)


CREATE TABLE Make (
	MakeID INT IDENTITY(1,1) primary key not null,
	MakeName VARCHAR(15) not null
)

CREATE TABLE Model (
	ModelID INT IDENTITY(1,1) PRIMARY KEY not null,
	MakeID INT not null FOREIGN KEY REFERENCES Make(MakeID),
	ModelName VARCHAR(15) not null
)

CREATE TABLE InteriorColor (
	InteriorColorID INT IDENTITY(1,1) primary key not null,
	InteriorColorName VARCHAR(15) not null,
	InteriorColorHex CHAR(6) null
)

CREATE TABLE ExteriorColor (
	ExteriorColorID INT IDENTITY(1,1) primary key not null,
	ExteriorColorName VARCHAR(15) not null,
	ExteriorColorHex CHAR(6) null
)

CREATE TABLE Vehicle (
	VIN CHAR(17) PRIMARY KEY not null,
	BodyTypeID INT not null FOREIGN KEY REFERENCES BodyType(BodyTypeID),
	ModelID INT not null FOREIGN KEY REFERENCES Model(ModelID),
	InteriorColorID INT not null FOREIGN KEY REFERENCES InteriorColor(InteriorColorID),
	ExteriorColorID INT not null FOREIGN KEY REFERENCES ExteriorColor(ExteriorColorID),
	ModelYear INT not null,
	IsNew BIT not null,
	IsManual BIT not null,
	IsFeatured BIT not null,
	IsSold BIT not null,
	Mileage INT not null,
	RetailPrice DECIMAL(12,2) not null,
	SalePrice DECIMAL(12,2) null,
	PurchasePrice DECIMAL(12,2) null,
	VehicleDesc VARCHAR(1028) null,
	ImageFileName VARCHAR(50) null,

)

CREATE TABLE Special (
	SpecialID INT IDENTITY(1,1) primary key not null,
	VIN CHAR(17) not null FOREIGN KEY REFERENCES Vehicle(VIN), 
	SpecialTitle VARCHAR(50) not null,
	SpecialDescription VARCHAR(1028) not null,
)

CREATE TABLE Purchase (
	PurchaseID INT IDENTITY(1,1) PRIMARY KEY not null,
	VIN CHAR(17) not null FOREIGN KEY REFERENCES Vehicle(VIN),
	PurchaseTypeID INT not null FOREIGN KEY REFERENCES BodyType(BodyTypeID),
	PurchaseDate DATE not null,
	CustomerFirstName VARCHAR(50) not null,
	CustomerLastName VARCHAR(50) not null,
	CustomerEmail VARCHAR(50) null,
	CustomerPhone VARCHAR(10) null,
	StreetAddress VARCHAR(50) not null,
	City VARCHAR(50) not null,
	StateAbbr CHAR(2) not null FOREIGN KEY REFERENCES State(StateAbbr),
	Zipcode VARCHAR(10) not null
)

CREATE TABLE Contact (
	ContactID INT IDENTITY(1,1) PRIMARY KEY not null,
	ContactName VARCHAR(50) not null,
	ContactEmail VARCHAR(50) null,
	ContactPhone VARCHAR(10) null,
	ContactMessage VARCHAR(1058) not null
)
