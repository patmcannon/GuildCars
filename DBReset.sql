USE GuildCars
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DBReset')
      DROP PROCEDURE DBReset
GO

CREATE PROCEDURE DBReset AS
Begin
	DELETE FROM Purchase;
	DELETE FROM Special;
	DELETE FROM Contact;
	DELETE FROM Vehicle;
	DELETE FROM [State];
	DELETE FROM BodyType;
	DELETE FROM InteriorColor;
	DELETE FROM ExteriorColor;
	DELETE FROM Model;
	DELETE FROM Make;
	DELETE FROM PurchaseType;
	DELETE FROM AspNetRoles;
	DELETE FROM AspNetUsers WHERE id = '00000000-0000-0000-0000-000000000000';

	DBCC CHECKIDENT ('BodyType', RESEED, 1)
	DBCC CHECKIDENT ('ExteriorColor', RESEED, 1)
	DBCC CHECKIDENT ('InteriorColor', RESEED, 1)
	DBCC CHECKIDENT ('Make', RESEED, 1)
	DBCC CHECKIDENT ('Model', RESEED, 1)
	DBCC CHECKIDENT('Purchase', RESEED, 1)
	DBCC CHECKIDENT ('PurchaseType', RESEED, 1)
	DBCC CHECKIDENT ('Special', RESEED, 1)
	DBCC CHECKIDENT ('Contact', RESEED, 1)

	
	SET IDENTITY_INSERT PurchaseType ON;
	INSERT INTO PurchaseType (PurchaseTypeID, PurchaseTypeName)
	VALUES (1, 'Bank Finance'),
	(2, 'Cash'),
	(3, 'Dealer Finance')
	SET IDENTITY_INSERT PurchaseType OFF;


	INSERT INTO [State] (StateAbbr, StateName)
	VALUES ('OH', 'Ohio'),
	('KY', 'Kentucky'),
	('MN', 'Minnesota')

	SET IDENTITY_INSERT BodyType ON;
	INSERT INTO BodyType (BodyTypeID, BodyTypeName)
	VALUES (1, 'Car'),
	(2, 'SUV'),
	(3, 'Truck'),
	(4, 'Van')
	SET IDENTITY_INSERT BodyType OFF;

	
	SET IDENTITY_INSERT InteriorColor ON;
	INSERT INTO InteriorColor (InteriorColorID, InteriorColorName, InteriorColorHex)
	VALUES (1, 'White', 'FFFFFF'),
	(2, 'Black', '000000')
	SET IDENTITY_INSERT InteriorColor OFF;
	
	
	SET IDENTITY_INSERT ExteriorColor ON;
	INSERT INTO ExteriorColor (ExteriorColorID, ExteriorColorName, ExteriorColorHex)
	VALUES (1, 'White', 'FFFFFF'),
	(2, 'Black', '000000')
	SET IDENTITY_INSERT ExteriorColor OFF;

	SET IDENTITY_INSERT Make ON;
	INSERT INTO Make (MakeID, MakeName)
	VALUES (1, 'Honda'),
	(2, 'Ford')
	SET IDENTITY_INSERT Make OFF;

	SET IDENTITY_INSERT Model ON;
	INSERT INTO Model (ModelID, MakeID, ModelName)
	VALUES (1, 1, 'Civic'),
	(2, 1, 'Accord'),
	(3, 2, 'Taurus')
	SET IDENTITY_INSERT Model OFF;

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName)
	Values('00000000-0000-0000-0000-000000000000', 0, 0, 'test@test.com', 0, 0, 0, 'test');


	INSERT INTO Vehicle(VIN, BodyTypeID, ModelID, InteriorColorID, ExteriorColorID, ModelYear, IsNew, IsManual, IsFeatured, IsSold, Mileage, RetailPrice, SalePrice, PurchasePrice, VehicleDesc, ImageFileName)
	VALUES('1G4HP54K62U137426', 1, 1, 1, 1, 2001, 0, 1, 1, 0, 400000, 100.00, 90.00, 90.00, 'Test description', 'placeholder.png'),
	('1FAFP42X62F177164', 2, 1, 2, 2, 2015, 1, 1, 1, 1, 200, 30000.00, 20000.00, 20000.00, 'Test description for 2', 'placeholder.png'),
	('JN8AS5MT6CW257718', 2, 1, 2, 2, 2013, 0, 1, 1, 0, 125000, 30000.00, 20000.00, 20000.00, 'Test description for x', 'placeholder.png'),
	('5N1AR2MM4DC650209', 3, 3, 1, 2, 2013, 0, 1, 1, 0, 45975, 30000.00, 20000.00, 20000.00, 'Test description for 4', 'placeholder.png'),
	('5TFBV54178X070365', 2, 2, 2, 1, 2020, 1, 1, 1, 0, 500, 65000.00, 60000.00, 60000.00, 'Test description for 3', 'placeholder.png');
	
	SET IDENTITY_INSERT Purchase ON;
	INSERT INTO Purchase(PurchaseID, VIN, PurchaseTypeID, PurchaseDate, CustomerFirstName, CustomerLastName, CustomerEmail, CustomerPhone, StreetAddress, City, StateAbbr, Zipcode)
	VALUES(1, '5TFBV54178X070365', 3, '1/1/2020', 'John', 'Smith', 'JOHNSMITH@email.com', '5551234', '1234 Main Street', 'Minneapolis', 'MN', '55425');
	SET IDENTITY_INSERT Purchase OFF;
	
	SET IDENTITY_INSERT Special ON;
	INSERT INTO Special (SpecialID, VIN, SpecialTitle, SpecialDescription)
	VALUES (1, '1FAFP42X62F177164', 'FIRST SPECIAL!', 'This is a test special, and the first ever for Guild Cards.'),
	(2, '5TFBV54178X070365', 'SECOND SPECIAL!', 'Here is another special that will blow your mind.'),
	(3, '5N1AR2MM4DC650209', 'THIRD SPECIAL!', 'As if it couldn''t get any better.')
	SET IDENTITY_INSERT Special OFF;

	SET IDENTITY_INSERT Contact ON;
	INSERT INTO Contact (ContactID, ContactName, ContactEmail, ContactPhone, ContactMessage)
	VALUES (1, 'Johnny Test', 'jt@messages.com', '7635551234', 'Please call me.'),
	(2, 'Jane Doe', 'jane@doe.com', '1234567891', 'I am interested in a vehicle.')
	SET IDENTITY_INSERT Contact OFF;
End