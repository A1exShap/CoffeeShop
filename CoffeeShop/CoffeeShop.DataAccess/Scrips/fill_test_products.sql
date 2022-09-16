USE CoffeeStore

DECLARE @products TABLE (
	Id UNIQUEIDENTIFIER NOT NULL,
	Name NVARCHAR(250) NOT NULL,
	Description NVARCHAR(500) NULL,
	NomenclatureNumber NVARCHAR(20) NOT NULL,
	ProductTypeId UNIQUEIDENTIFIER NOT NULL
)

-- Coffee beans
DECLARE @coffeeBeansTypeID UNIQUEIDENTIFIER
SET @coffeeBeansTypeID = (SELECT PT.Id FROM [dbo].[ProductTypes] AS PT WHERE PT.Name = 'Coffee (beans)')

INSERT INTO @products (Id, Name, Description, NomenclatureNumber, ProductTypeId)
VALUES(NEWID(), 'Sunshine Mexico', 'Best Mexican arabica', '0001-0001', @coffeeBeansTypeID)

INSERT INTO @products (Id, Name, Description, NomenclatureNumber, ProductTypeId)
VALUES(NEWID(), 'Sunshine Columbia', 'Best Columbian arabica', '0001-0002', @coffeeBeansTypeID)

INSERT INTO @products (Id, Name, Description, NomenclatureNumber, ProductTypeId)
VALUES(NEWID(), 'Sunshine Java', 'Best Javanian arabica', '0001-0003', @coffeeBeansTypeID)

INSERT INTO @products (Id, Name, Description, NomenclatureNumber, ProductTypeId)
VALUES(NEWID(), 'Sunshine Ephiopia', 'Best Ephiopian arabica', '0001-0004', @coffeeBeansTypeID)

-- Ground coffee
DECLARE @groundCoffeeTypeID UNIQUEIDENTIFIER
SET @groundCoffeeTypeID = (SELECT PT.Id FROM [dbo].[ProductTypes] AS PT WHERE PT.Name = 'Coffee (ground)')

INSERT INTO @products (Id, Name, Description, NomenclatureNumber, ProductTypeId)
VALUES(NEWID(), 'LessCafe Express', 'Your best morning start', '0002-0001', @groundCoffeeTypeID)

INSERT INTO @products (Id, Name, Description, NomenclatureNumber, ProductTypeId)
VALUES(NEWID(), 'LessCafe Gusto', 'For those who understand', '0002-0002', @groundCoffeeTypeID)

-- Coffee machine
DECLARE @coffeeMachineTypeID UNIQUEIDENTIFIER
SET @coffeeMachineTypeID = (SELECT PT.Id FROM [dbo].[ProductTypes] AS PT WHERE PT.Name = 'Coffee machine')

INSERT INTO @products (Id, Name, Description, NomenclatureNumber, ProductTypeId)
VALUES(NEWID(), 'BrewMaster 200', 'Your personal barrista', '0003-0001', @coffeeMachineTypeID)

INSERT INTO @products (Id, Name, Description, NomenclatureNumber, ProductTypeId)
VALUES(NEWID(), 'BrewMaster 300', 'Just delicious', '0003-0002', @coffeeMachineTypeID)

MERGE [dbo].[Products] AS Target
	USING (SELECT * FROM @products) AS Source
	ON (Target.Id = Source.Id)
WHEN MATCHED THEN
    UPDATE SET
		Name = Source.Name,
		Description = Source.Description,
		NomenclatureNumber = Source.NomenclatureNumber,
		ProductTypeId = Source.ProductTypeId
WHEN NOT MATCHED THEN  
    INSERT (Id, Name, Description, NomenclatureNumber, ProductTypeId)  
    VALUES (Source.Id, Source.Name, Source.Description, Source.NomenclatureNumber, Source.ProductTypeId);