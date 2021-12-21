USE GuildCars
GO

--Standard CRUD method sprocs

--State Sprocs
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StateSelect')
      DROP PROCEDURE StateSelect
GO

CREATE PROCEDURE StateSelect (
	@StateAbbr CHAR(2)
) AS
Begin
	SELECT StateAbbr, StateName FROM State
	WHERE StateAbbr = @StateAbbr
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StateSelectAll')
      DROP PROCEDURE StateSelectAll
GO

CREATE PROCEDURE StateSelectAll AS
Begin
	SELECT StateAbbr, StateName FROM [State]
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StateInsert')
      DROP PROCEDURE StateInsert
GO

CREATE PROCEDURE StateInsert (
	@StateAbbr CHAR(2),
	@StateName VARCHAR(15)
) As
Begin
	INSERT INTO State (StateAbbr, StateName)
	VALUES (@StateAbbr, @StateName);
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StateUpdate')
      DROP PROCEDURE StateUpdate
GO

CREATE PROCEDURE StateUpdate (
	@StateAbbr CHAR(2),
	@StateName VARCHAR(15)
) As
Begin
	UPDATE State SET
	StateName = @StateName
	WHERE @StateAbbr = @StateAbbr
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'StateDelete')
      DROP PROCEDURE StateDelete
GO

CREATE PROCEDURE StateDelete (
	@StateAbbr CHAR(2)
	) AS
BEGIN
	BEGIN TRANSACTION
	DELETE FROM Purchase WHERE StateAbbr = @StateAbbr;
	DELETE FROM State WHERE StateAbbr = @StateAbbr;
	COMMIT TRANSACTION
END
GO


--BodyType Stored Procedures
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodyTypeSelect')
      DROP PROCEDURE BodyTypeSelect
GO

CREATE PROCEDURE BodyTypeSelect (
	@BodyTypeID INT
) AS
Begin
	SELECT BodyTypeID, BodyTypeName FROM BodyType
	WHERE BodyTypeID = @BodyTypeID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodyTypeSelectAll')
      DROP PROCEDURE BodyTypeSelectAll
GO

CREATE PROCEDURE BodyTypeSelectAll AS
Begin
	SELECT * FROM BodyType
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodyTypeInsert')
      DROP PROCEDURE BodyTypeInsert
GO

CREATE PROCEDURE BodyTypeInsert (
	@BodyTypeID INT OUTPUT,
	@BodyTypeName VARCHAR(15)
) As
Begin
	INSERT INTO BodyType (BodyTypeName)
	VALUES (@BodyTypeName);
	SET @BodyTypeID = SCOPE_IDENTITY();
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodyTypeUpdate')
      DROP PROCEDURE BodyTypeUpdate
GO

CREATE PROCEDURE BodyTypeUpdate (
	@BodyTypeID INT,
	@BodyTypeName VARCHAR(15)
) As
Begin
	UPDATE BodyType SET
	BodyTypeName = @BodyTypeName
	WHERE BodyTypeID = @BodyTypeID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'BodyTypeDelete')
      DROP PROCEDURE BodyTypeDelete
GO

CREATE PROCEDURE BodyTypeDelete (
	@BodyTypeID INT
	) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Vehicle WHERE BodyTypeID = @BodyTypeID;
	DELETE FROM BodyType WHERE BodyTypeID = @BodyTypeID;

	COMMIT TRANSACTION
END
GO



---------ExteriorColor SPROCS
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ExteriorColorSelect')
      DROP PROCEDURE ExteriorColorSelect
GO

CREATE PROCEDURE ExteriorColorSelect (
	@ExteriorColorID INT
) AS
Begin
	SELECT ExteriorColorID, ExteriorColorName, ExteriorColorHex FROM ExteriorColor
	WHERE ExteriorColorID = @ExteriorColorID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ExteriorColorSelectAll')
      DROP PROCEDURE ExteriorColorSelectAll
GO

CREATE PROCEDURE ExteriorColorSelectAll AS
Begin
	SELECT ExteriorColorID, ExteriorColorName, ExteriorColorHex FROM ExteriorColor
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ExteriorColorInsert')
      DROP PROCEDURE ExteriorColorInsert
GO

CREATE PROCEDURE ExteriorColorInsert (
	@ExteriorColorID INT OUTPUT,
	@ExteriorColorName VARCHAR(15),
	@ExteriorColorHex CHAR(6)
) As
Begin
	INSERT INTO ExteriorColor (ExteriorColorName, ExteriorColorHex)
	VALUES (@ExteriorColorName, @ExteriorColorHex);
	SET @ExteriorColorID = SCOPE_IDENTITY();
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ExteriorColorUpdate')
      DROP PROCEDURE ExteriorColorUpdate
GO

CREATE PROCEDURE ExteriorColorUpdate (
	@ExteriorColorID INT,
	@ExteriorColorName VARCHAR(15),
	@ExteriorColorHex CHAR(6)
) As
Begin
	UPDATE ExteriorColor SET
	ExteriorColorName = @ExteriorColorName,
	ExteriorColorHex = @ExteriorColorHex
	WHERE ExteriorColorID = @ExteriorColorID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ExteriorColorDelete')
      DROP PROCEDURE ExteriorColorDelete
GO

CREATE PROCEDURE ExteriorColorDelete (
	@ExteriorColorID INT
	) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Vehicle WHERE ExteriorColorID = @ExteriorColorID;
	DELETE FROM ExteriorColor WHERE ExteriorColorID = @ExteriorColorID;

	COMMIT TRANSACTION
END
GO




---------InteriorColor SPROCS
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InteriorColorSelect')
      DROP PROCEDURE InteriorColorSelect
GO

CREATE PROCEDURE InteriorColorSelect (
	@InteriorColorID INT
) AS
Begin
	SELECT InteriorColorID, InteriorColorName, InteriorColorHex FROM InteriorColor
	WHERE InteriorColorID = @InteriorColorID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InteriorColorSelectAll')
      DROP PROCEDURE InteriorColorSelectAll
GO

CREATE PROCEDURE InteriorColorSelectAll AS
Begin
	SELECT InteriorColorID, InteriorColorName, InteriorColorHex FROM InteriorColor
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InteriorColorInsert')
      DROP PROCEDURE InteriorColorInsert
GO

CREATE PROCEDURE InteriorColorInsert (
	@InteriorColorID INT OUTPUT,
	@InteriorColorName VARCHAR(15),
	@InteriorColorHex CHAR(6)
) As
Begin
	INSERT INTO InteriorColor (InteriorColorName, InteriorColorHex)
	VALUES (@InteriorColorName, @InteriorColorHex);
	SET @InteriorColorID = SCOPE_IDENTITY();
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InteriorColorUpdate')
      DROP PROCEDURE InteriorColorUpdate
GO

CREATE PROCEDURE InteriorColorUpdate (
	@InteriorColorID INT,
	@InteriorColorName VARCHAR(15),
	@InteriorColorHex CHAR(6)
) As
Begin
	UPDATE InteriorColor SET
	InteriorColorName = @InteriorColorName,
	InteriorColorHex = @InteriorColorHex
	WHERE InteriorColorID = @InteriorColorID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'InteriorColorDelete')
      DROP PROCEDURE InteriorColorDelete
GO

CREATE PROCEDURE InteriorColorDelete (
	@InteriorColorID INT
	) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Vehicle WHERE InteriorColorID = @InteriorColorID;
	DELETE FROM InteriorColor WHERE InteriorColorID = @InteriorColorID;

	COMMIT TRANSACTION
END
GO


--Make Stored Procedures
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeSelect')
      DROP PROCEDURE MakeSelect
GO

CREATE PROCEDURE MakeSelect (
	@MakeID INT
) AS
Begin
	SELECT MakeID, MakeName FROM Make
	WHERE MakeID = @MakeID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeSelectAll')
      DROP PROCEDURE MakeSelectAll
GO

CREATE PROCEDURE MakeSelectAll AS
Begin
	SELECT * FROM Make
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeInsert')
      DROP PROCEDURE MakeInsert
GO

CREATE PROCEDURE MakeInsert (
	@MakeID INT OUTPUT,
	@MakeName VARCHAR(15)
) As
Begin
	INSERT INTO Make (MakeName)
	VALUES (@MakeName);
	SET @MakeID = SCOPE_IDENTITY();
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeUpdate')
      DROP PROCEDURE MakeUpdate
GO

CREATE PROCEDURE MakeUpdate (
	@MakeID INT,
	@MakeName VARCHAR(15)
) As
Begin
	UPDATE Make SET
	MakeName = @MakeName
	WHERE MakeID = @MakeID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'MakeDelete')
      DROP PROCEDURE MakeDelete
GO

CREATE PROCEDURE MakeDelete (
	@MakeID INT
	) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Model WHERE MakeID = @MakeID;
	DELETE FROM Make WHERE MakeID = @MakeID;

	COMMIT TRANSACTION
END
GO

--Model Stored Procedures
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelSelect')
      DROP PROCEDURE ModelSelect
GO

CREATE PROCEDURE ModelSelect (
	@ModelID INT
) AS
Begin
	SELECT ModelID, MakeID, ModelName FROM Model
	WHERE ModelID = @ModelID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelSelectAll')
      DROP PROCEDURE ModelSelectAll
GO

CREATE PROCEDURE ModelSelectAll AS
Begin
	SELECT ModelID, MakeID, ModelName FROM Model
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelInsert')
      DROP PROCEDURE ModelInsert
GO

CREATE PROCEDURE ModelInsert (
	@ModelID INT OUTPUT,
	@MakeID INT,
	@ModelName VARCHAR(15)
) As
Begin
	INSERT INTO Model (ModelName, MakeID)
	VALUES (@ModelName, @MakeID);
	SET @ModelID = SCOPE_IDENTITY();
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelUpdate')
      DROP PROCEDURE ModelUpdate
GO

CREATE PROCEDURE ModelUpdate (
	@ModelID INT,
	@MakeID INT,
	@ModelName VARCHAR(15)
) As
Begin
	UPDATE Model SET
	ModelName = @ModelName,
	MakeID = @MakeID
	WHERE ModelID = @ModelID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ModelDelete')
      DROP PROCEDURE ModelDelete
GO

CREATE PROCEDURE ModelDelete (
	@ModelID INT
	) AS
BEGIN
	BEGIN TRANSACTION
	DELETE FROM Vehicle WHERE ModelID = @ModelID;
	DELETE FROM Model WHERE ModelID = @ModelID;
	COMMIT TRANSACTION
END
GO



--Vehicle Stored Procedures
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelect')
      DROP PROCEDURE VehicleSelect
GO

CREATE PROCEDURE VehicleSelect (
	@VIN CHAR(17)
) AS
Begin
	SELECT VIN, BodyTypeID, ModelID, InteriorColorID, ExteriorColorID, ModelYear, IsNew, IsManual, IsFeatured, IsSold, Mileage, RetailPrice, SalePrice, PurchasePrice, VehicleDesc, ImageFileName
	FROM Vehicle
	WHERE VIN = @VIN
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelectAll')
      DROP PROCEDURE VehicleSelectAll
GO

CREATE PROCEDURE VehicleSelectAll AS
Begin
	SELECT VIN, BodyTypeID, ModelID, InteriorColorID, ExteriorColorID, ModelYear, IsNew, IsManual, IsFeatured, IsSold, Mileage, RetailPrice, SalePrice, PurchasePrice, VehicleDesc, ImageFileName
	FROM Vehicle
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleInsert')
      DROP PROCEDURE VehicleInsert
GO

CREATE PROCEDURE VehicleInsert (
	@VIN CHAR(17),
	@BodyTypeID INT,
	@ModelID INT,
	@InteriorColorID INT,
	@ExteriorColorID INT,
	@ModelYear INT,
	@IsNew BIT,
	@IsManual BIT,
	@IsFeatured BIT,
	@IsSold BIT,
	@Mileage INT,
	@RetailPrice DECIMAL(12,2),
	@SalePrice DECIMAL(12,2),
	@PurchasePrice DECIMAL(12,2),
	@VehicleDesc VARCHAR(1028),
	@ImageFileName VARCHAR(50)
) As
Begin
	INSERT INTO Vehicle (VIN, BodyTypeID, ModelID, InteriorColorID, ExteriorColorID, ModelYear, IsNew, IsManual, IsFeatured, IsSold, Mileage, RetailPrice, SalePrice, PurchasePrice, VehicleDesc, ImageFileName)
	VALUES (@VIN, @BodyTypeID, @ModelID, @InteriorColorID, @ExteriorColorID, @ModelID, @IsNew, @IsManual, @IsFeatured, @IsSold, @Mileage, @RetailPrice, @SalePrice, @PurchasePrice, @VehicleDesc, @ImageFileName);
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleUpdate')
      DROP PROCEDURE VehicleUpdate
GO

CREATE PROCEDURE VehicleUpdate (
	@VIN CHAR(17),
	@BodyTypeID INT,
	@ModelID INT,
	@InteriorColorID INT,
	@ExteriorColorID INT,
	@ModelYear INT,
	@IsNew BIT,
	@IsManual BIT,
	@IsFeatured BIT,
	@IsSold BIT,
	@Mileage INT,
	@RetailPrice DECIMAL(12,2),
	@SalePrice DECIMAL(12,2),
	@PurchasePrice DECIMAL(12,2),
	@VehicleDesc VARCHAR(1028),
	@ImageFileName VARCHAR(50)
) As
Begin
	UPDATE Vehicle SET
	BodyTypeID = @BodyTypeID,
	ModelID = @ModelID,
	InteriorColorID = @InteriorColorID,
	ExteriorColorID = @ExteriorColorID,
	ModelYear = @ModelYear,
	IsNew = @IsNew,
	IsManual = @IsManual,
	IsFeatured = @IsFeatured,
	IsSold = @IsSold,
	Mileage = @Mileage,
	RetailPrice = @RetailPrice,
	SalePrice = @SalePrice,
	PurchasePrice = @PurchasePrice,
	VehicleDesc = @VehicleDesc,
	ImageFileName = @ImageFileName
	WHERE VIN = @VIN
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleDelete')
      DROP PROCEDURE VehicleDelete
GO

CREATE PROCEDURE VehicleDelete (
	@VIN CHAR(17)
	) AS
BEGIN
	BEGIN TRANSACTION
	DELETE FROM Purchase WHERE VIN = @VIN
	DELETE FROM Special WHERE VIN = @VIN;
	DELETE FROM Vehicle WHERE VIN = @VIN;
	COMMIT TRANSACTION
END
GO


--PurchaseType Stored Procedures
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseTypeSelect')
      DROP PROCEDURE PurchaseTypeSelect
GO

CREATE PROCEDURE PurchaseTypeSelect (
	@PurchaseTypeID INT
) AS
Begin
	SELECT PurchaseTypeID, PurchaseTypeName FROM PurchaseType
	WHERE PurchaseTypeID = @PurchaseTypeID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseTypeSelectAll')
      DROP PROCEDURE PurchaseTypeSelectAll
GO

CREATE PROCEDURE PurchaseTypeSelectAll AS
Begin
	SELECT PurchaseTypeID, PurchaseTypeName FROM PurchaseType
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseTypeInsert')
      DROP PROCEDURE PurchaseTypeInsert
GO

CREATE PROCEDURE PurchaseTypeInsert (
	@PurchaseTypeID INT OUTPUT,
	@PurchaseTypeName VARCHAR(15)
) As
Begin
	INSERT INTO PurchaseType (PurchaseTypeName)
	VALUES (@PurchaseTypeName);
	SET @PurchaseTypeID = SCOPE_IDENTITY();
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseTypeUpdate')
      DROP PROCEDURE PurchaseTypeUpdate
GO

CREATE PROCEDURE PurchaseTypeUpdate (
	@PurchaseTypeID INT,
	@PurchaseTypeName VARCHAR(15)
) As
Begin
	UPDATE PurchaseType SET
	PurchaseTypeName = @PurchaseTypeName
	WHERE PurchaseTypeID = @PurchaseTypeID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseTypeDelete')
      DROP PROCEDURE PurchaseTypeDelete
GO

CREATE PROCEDURE PurchaseTypeDelete (
	@PurchaseTypeID INT
	) AS
BEGIN
	BEGIN TRANSACTION
	DELETE FROM Purchase WHERE PurchaseTypeID = @PurchaseTypeID;
	DELETE FROM PurchaseType WHERE PurchaseTypeID = @PurchaseTypeID;
	COMMIT TRANSACTION
END
GO



--Purchase Stored Procedures
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseSelect')
      DROP PROCEDURE PurchaseSelect
GO

CREATE PROCEDURE PurchaseSelect (
	@PurchaseID INT
) AS
Begin
	SELECT PurchaseID, VIN, PurchaseTypeID, PurchaseDate, CustomerFirstName, CustomerLastName, CustomerEmail, CustomerPhone, StreetAddress, City, StateAbbr, Zipcode
	FROM Purchase
	WHERE PurchaseID = @PurchaseID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseSelectAll')
      DROP PROCEDURE PurchaseSelectAll
GO

CREATE PROCEDURE PurchaseSelectAll AS
Begin
	SELECT PurchaseID, VIN, PurchaseTypeID, PurchaseDate, CustomerFirstName, CustomerLastName, CustomerEmail, CustomerPhone, StreetAddress, City, StateAbbr, Zipcode
	FROM Purchase
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseInsert')
      DROP PROCEDURE PurchaseInsert
GO

CREATE PROCEDURE PurchaseInsert (
	@PurchaseID INT OUTPUT,
	@VIN CHAR(17),
	@PurchaseTypeID INT,
	@PurchaseDate DATE,
	@CustomerFirstName VARCHAR(50), 
	@CustomerLastName VARCHAR(50),
	@CustomerEmail VARCHAR(50),
	@CustomerPhone VARCHAR(10),
	@StreetAddress VARCHAR(50), 
	@City VARCHAR(50), 
	@StateAbbr CHAR(2), 
	@Zipcode VARCHAR(10)
) As
Begin
	INSERT INTO Purchase (VIN, PurchaseTypeID, PurchaseDate, CustomerFirstName, CustomerLastName, CustomerEmail, CustomerPhone, StreetAddress, City, StateAbbr, Zipcode)
	VALUES (@VIN, @PurchaseTypeID, @PurchaseDate, @CustomerFirstName, @CustomerLastName, @CustomerEmail, @CustomerPhone, @StreetAddress, @City, @StateAbbr, @Zipcode);
	SET @PurchaseID = SCOPE_IDENTITY();
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseUpdate')
      DROP PROCEDURE PurchaseUpdate
GO

CREATE PROCEDURE PurchaseUpdate (
	@PurchaseID INT,
	@VIN CHAR(17),
	@PurchaseTypeID INT,
	@PurchaseDate DATE,
	@CustomerFirstName VARCHAR(50), 
	@CustomerLastName VARCHAR(50), 
	@CustomerEmail VARCHAR(50),
	@CustomerPhone VARCHAR(10),
	@StreetAddress VARCHAR(50), 
	@City VARCHAR(50), 
	@StateAbbr CHAR(2), 
	@Zipcode VARCHAR(10)
) As
Begin
	UPDATE Purchase SET
	VIN = @VIN,
	PurchaseTypeID = @PurchaseTypeID,
	PurchaseDate = @PurchaseDate,
	CustomerFirstName = @CustomerFirstName,
	CustomerLastName = @CustomerLastName,
	CustomerEmail = @CustomerEmail,
	CustomerPhone = @CustomerPhone,
	StreetAddress = @StreetAddress,
	City = @City,
	StateAbbr = @StateAbbr,
	Zipcode = @Zipcode
	WHERE PurchaseID = @PurchaseID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'PurchaseDelete')
      DROP PROCEDURE PurchaseDelete
GO

CREATE PROCEDURE PurchaseDelete (
	@PurchaseID INT
	) AS
BEGIN
	BEGIN TRANSACTION
	DELETE FROM Purchase WHERE PurchaseID = @PurchaseID;
	COMMIT TRANSACTION
END
GO




--Special Stored Procedures
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialSelect')
      DROP PROCEDURE SpecialSelect
GO

CREATE PROCEDURE SpecialSelect (
	@SpecialID INT
) AS
Begin
	SELECT SpecialID, VIN, SpecialTitle, SpecialDescription 
	FROM Special
	WHERE SpecialID = @SpecialID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialSelectAll')
      DROP PROCEDURE SpecialSelectAll
GO

CREATE PROCEDURE SpecialSelectAll AS
Begin
	SELECT SpecialID, VIN, SpecialTitle, SpecialDescription 
	FROM Special
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialInsert')
      DROP PROCEDURE SpecialInsert
GO

CREATE PROCEDURE SpecialInsert (
	@SpecialID INT OUTPUT,
	@VIN CHAR(17),
	@SpecialTitle VARCHAR(50),
	@SpecialDescription VARCHAR(1028)
) As
Begin
	INSERT INTO Special (VIN, SpecialTitle, SpecialDescription)
	VALUES (@VIN, @SpecialTitle, @SpecialDescription);
	SET @SpecialID = SCOPE_IDENTITY();
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialUpdate')
      DROP PROCEDURE SpecialUpdate
GO

CREATE PROCEDURE SpecialUpdate (
	@SpecialID INT,
	@VIN CHAR(17),
	@SpecialTitle VARCHAR(50),
	@SpecialDescription VARCHAR(1028)
) As
Begin
	UPDATE Special SET
	VIN = @VIN,
	SpecialTitle = @SpecialTitle,
	SpecialDescription = @SpecialDescription
	WHERE SpecialID = @SpecialID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'SpecialDelete')
      DROP PROCEDURE SpecialDelete
GO

CREATE PROCEDURE SpecialDelete (
	@SpecialID INT
	) AS
BEGIN
	BEGIN TRANSACTION
	DELETE FROM Special WHERE SpecialID = @SpecialID;
	COMMIT TRANSACTION
END
GO


--Contact Stored Procedures
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactSelect')
      DROP PROCEDURE ContactSelect
GO

CREATE PROCEDURE ContactSelect (
	@ContactID INT
) AS
Begin
	SELECT ContactID, ContactName, ContactEmail, ContactPhone, ContactMessage
	FROM Contact
	WHERE ContactID = @ContactID
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactSelectAll')
      DROP PROCEDURE ContactSelectAll
GO

CREATE PROCEDURE ContactSelectAll AS
Begin
	SELECT ContactID, ContactName, ContactEmail, ContactPhone, ContactMessage
	FROM Contact
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactInsert')
      DROP PROCEDURE ContactInsert
GO

CREATE PROCEDURE ContactInsert (
	@ContactID INT OUTPUT,
	@ContactName VARCHAR(50),
	@ContactEmail VARCHAR(50),
	@ContactPhone VARCHAR(10),	
	@ContactMessage VARCHAR(1058)
) As
Begin
	INSERT INTO Contact (ContactName, ContactEmail, ContactPhone, ContactMessage)
	VALUES (@ContactName, @ContactEmail, @ContactPhone, @ContactMessage);
	SET @ContactID = SCOPE_IDENTITY();
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactUpdate')
      DROP PROCEDURE ContactUpdate
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'ContactDelete')
      DROP PROCEDURE ContactDelete
GO

CREATE PROCEDURE ContactDelete (
	@ContactID INT
	) AS
BEGIN
	BEGIN TRANSACTION

	DELETE FROM Contact WHERE ContactID = @ContactID;

	COMMIT TRANSACTION
END
GO


--custom and specific sprocs to project

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelectFeatured')
      DROP PROCEDURE VehicleSelectFeatured
GO

CREATE PROCEDURE VehicleSelectFeatured AS
Begin
	SELECT VIN, ModelYear, MakeName, ModelName, IsFeatured, RetailPrice, SalePrice, ImageFileName
	FROM Vehicle
	INNER JOIN Model ON Vehicle.ModelID = Model.ModelID
	INNER JOIN Make ON Model.MakeID = Make.MakeID
	WHERE IsFeatured = 1
	ORDER BY RetailPrice Desc
End
GO


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleSelectByNewOrUsed')
      DROP PROCEDURE VehicleSelectByNewOrUsed
GO

CREATE PROCEDURE VehicleSelectByNewOrUsed (
	@IsNew BIT
) As
Begin
	SELECT VIN, BodyType.BodyTypeName, Make.MakeName, Model.ModelName, InteriorColor.InteriorColorName, ExteriorColor.ExteriorColorName, ModelYear, IsNew, IsManual, IsFeatured, IsSold, Mileage, RetailPrice, SalePrice, PurchasePrice, VehicleDesc, ImageFileName
	FROM Vehicle
	INNER JOIN BodyType ON BodyType.BodyTypeID = Vehicle.BodyTypeID
	INNER JOIN Model ON Model.ModelID = Vehicle.ModelID
	INNER JOIN Make ON Model.MakeID = Make.MakeID
	INNER JOIN InteriorColor ON InteriorColor.InteriorColorID = Vehicle.InteriorColorID
	INNER JOIN ExteriorColor ON ExteriorColor.ExteriorColorID = Vehicle.ExteriorColorID
	WHERE IsNew = @IsNew
End
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'VehicleDetailSelect')
      DROP PROCEDURE VehicleDetailSelect
GO

CREATE PROCEDURE VehicleDetailSelect (
	@VIN CHAR(17)
) As
Begin
	SELECT Vehicle.VIN, BodyType.BodyTypeName, Make.MakeName, Model.ModelName, InteriorColor.InteriorColorName, ExteriorColor.ExteriorColorName, ModelYear, IsNew, IsManual, IsFeatured, IsSold, Mileage, RetailPrice, SalePrice, PurchasePrice, VehicleDesc, ImageFileName
	FROM Vehicle
	INNER JOIN BodyType ON BodyType.BodyTypeID = Vehicle.BodyTypeID
	INNER JOIN Model ON Model.ModelID = Vehicle.ModelID
	INNER JOIN Make ON Model.MakeID = Make.MakeID
	INNER JOIN InteriorColor ON InteriorColor.InteriorColorID = Vehicle.InteriorColorID
	INNER JOIN ExteriorColor ON ExteriorColor.ExteriorColorID = Vehicle.ExteriorColorID
	WHERE Vehicle.VIN = @VIN
End
GO