IF (SELECT DB_ID('MyDb') ) IS NOT NULL AND ( OBJECT_ID('MyDb.dbo.Customers') ) IS NULL 
BEGIN
	USE MyDb;

	CREATE TABLE Customers (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		Name NVARCHAR(100),
		Address NVARCHAR(100),
		City NVARCHAR(50),
		ZipCode NVARCHAR(20),
		Country NVARCHAR(50),
		Description NVARCHAR(255),
		Code NVARCHAR(5),
		CreationDate DATETIME,
		IsEnable BIT
	);

	DECLARE @counter INT = 1;
	DECLARE @random INT = 0;

	WHILE @counter <= 10000000
	BEGIN
		SELECT @random = RAND() * 1000;

		INSERT INTO Customers (Name, Address, City, ZipCode, Country, Description, Code, CreationDate, IsEnable)
		VALUES (
			CONCAT('Customer_', @random),
			CONCAT('Address_', @random),
			CONCAT('City_', @random),
			CONCAT('Zip_', @random),
			CONCAT('Country_', @random),
			CONCAT('Description_', @random),
			RIGHT('0000' + CAST(@random AS NVARCHAR(5)), 5),
			GETDATE(),
			CAST(CAST(RAND() * 2 AS INT) AS BIT)
		);

		SET @counter = @counter + 1;
	END;
END


