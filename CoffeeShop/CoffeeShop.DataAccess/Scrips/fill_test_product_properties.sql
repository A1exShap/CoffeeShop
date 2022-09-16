USE CoffeeStore

-- Sunshine Mexico
DECLARE @sunshineMexicoId UNIQUEIDENTIFIER
SET @sunshineMexicoId = (SELECT P.Id FROM [dbo].[Products] AS P WHERE Name = 'Sunshine Mexico')

-- Sunshine Columbia
DECLARE @sunshineColumbiaId UNIQUEIDENTIFIER
SET @sunshineColumbiaId = (SELECT P.Id FROM [dbo].[Products] AS P WHERE Name = 'Sunshine Columbia')

-- Sunshine Java
DECLARE @sunshineJavaId UNIQUEIDENTIFIER
SET @sunshineJavaId = (SELECT P.Id FROM [dbo].[Products] AS P WHERE Name = 'Sunshine Java')

-- Sunshine Ephiopia
DECLARE @sunshineEphiopiaId UNIQUEIDENTIFIER
SET @sunshineEphiopiaId = (SELECT P.Id FROM [dbo].[Products] AS P WHERE Name = 'Sunshine Ephiopia')

-- LessCafe Express
DECLARE @lessCafeExpressId UNIQUEIDENTIFIER
SET @lessCafeExpressId = (SELECT P.Id FROM [dbo].[Products] AS P WHERE Name = 'LessCafe Express')

-- LessCafe Gusto
DECLARE @lessCafeGustoId UNIQUEIDENTIFIER
SET @lessCafeGustoId = (SELECT P.Id FROM [dbo].[Products] AS P WHERE Name = 'LessCafe Gusto')

-- BrewMaster 200
DECLARE @brewMaster200Id UNIQUEIDENTIFIER
SET @brewMaster200Id = (SELECT P.Id FROM [dbo].[Products] AS P WHERE Name = 'BrewMaster 200')

-- BrewMaster 300
DECLARE @brewMaster300Id UNIQUEIDENTIFIER
SET @brewMaster300Id = (SELECT P.Id FROM [dbo].[Products] AS P WHERE Name = 'BrewMaster 300')

-- ProductProperties
------------------------------------------------------------------------------------------------
DECLARE @productProperties TABLE (
	Id UNIQUEIDENTIFIER NOT NULL,
	ProductTypeId UNIQUEIDENTIFIER NOT NULL,
	Name NVARCHAR(200) NOT NULL,
	ValueType SMALLINT NOT NULL,
	IsActive BIT NOT NULL
)

-- Coffee beans
DECLARE @coffeeBeansTypeID UNIQUEIDENTIFIER
SET @coffeeBeansTypeID = (SELECT PT.Id FROM [dbo].[ProductTypes] AS PT WHERE PT.Name = 'Coffee (beans)')

INSERT INTO @productProperties (Id, ProductTypeId, Name, ValueType, IsActive)
VALUES(NEWID(), @coffeeBeansTypeID, 'Sort', 3, 1)

INSERT INTO @productProperties (Id, ProductTypeId, Name, ValueType, IsActive)
VALUES(NEWID(), @coffeeBeansTypeID, 'Origin', 1, 1)

INSERT INTO @productProperties (Id, ProductTypeId, Name, ValueType, IsActive)
VALUES(NEWID(), @coffeeBeansTypeID, 'Strength', 3, 1)

-- Ground coffee
DECLARE @groundCoffeeTypeID UNIQUEIDENTIFIER
SET @groundCoffeeTypeID = (SELECT PT.Id FROM [dbo].[ProductTypes] AS PT WHERE PT.Name = 'Coffee (ground)')

INSERT INTO @productProperties (Id, ProductTypeId, Name, ValueType, IsActive)
VALUES(NEWID(), @groundCoffeeTypeID, 'Sort', 3, 1)

INSERT INTO @productProperties (Id, ProductTypeId, Name, ValueType, IsActive)
VALUES(NEWID(), @groundCoffeeTypeID, 'Origin', 1, 1)

INSERT INTO @productProperties (Id, ProductTypeId, Name, ValueType, IsActive)
VALUES(NEWID(), @groundCoffeeTypeID, 'Strength', 3, 1)

-- Coffee machine
DECLARE @coffeeMachineTypeID UNIQUEIDENTIFIER
SET @coffeeMachineTypeID = (SELECT PT.Id FROM [dbo].[ProductTypes] AS PT WHERE PT.Name = 'Coffee machine')

INSERT INTO @productProperties (Id, ProductTypeId, Name, ValueType, IsActive)
VALUES(NEWID(), @coffeeMachineTypeID, 'CoffeeMachineType', 3, 1)

INSERT INTO @productProperties (Id, ProductTypeId, Name, ValueType, IsActive)
VALUES(NEWID(), @coffeeMachineTypeID, 'GuaranteePeriod', 2, 1)

INSERT INTO @productProperties (Id, ProductTypeId, Name, ValueType, IsActive)
VALUES(NEWID(), @coffeeMachineTypeID, 'CoffeeGrinder', 2, 1)

INSERT INTO @productProperties (Id, ProductTypeId, Name, ValueType, IsActive)
VALUES(NEWID(), @coffeeMachineTypeID, 'Cappuccinatore', 2, 1)


MERGE [dbo].[ProductProperties] AS Target
	USING (SELECT * FROM @productProperties) AS Source  
	ON (Target.Id = Source.Id)
WHEN MATCHED THEN
    UPDATE SET
		ProductTypeId = Source.ProductTypeId,
		Name = Source.Name,
		ValueType = Source.ValueType,
		IsActive = Source.IsActive
WHEN NOT MATCHED THEN  
    INSERT (Id, ProductTypeId, Name, ValueType, IsActive)  
    VALUES (Source.Id, Source.ProductTypeId, Source.Name, Source.ValueType, Source.IsActive);


-- PropertyEnums
------------------------------------------------------------------------------------------------
DECLARE @propertyEnums TABLE (
	Id UNIQUEIDENTIFIER NOT NULL,
	Name NVARCHAR(100) NOT NULL,
	ValueType SMALLINT NOT NULL
)

INSERT INTO @propertyEnums (Id, Name, ValueType)
VALUES(NEWID(), 'Coffee Strength', 1)

INSERT INTO @propertyEnums (Id, Name, ValueType)
VALUES(NEWID(), 'Coffee Sort Type', 1)

INSERT INTO @propertyEnums (Id, Name, ValueType)
VALUES(NEWID(), 'Coffee Machine Type', 1)

MERGE [dbo].[PropertyEnums] AS Target
	USING (SELECT * FROM @propertyEnums) AS Source  
	ON (Target.Name = Source.Name)
WHEN MATCHED THEN
    UPDATE SET
		ValueType = Source.ValueType
WHEN NOT MATCHED THEN  
    INSERT (Id, Name, ValueType)
    VALUES (Source.Id, Source.Name, Source.ValueType);


-- PropertyEnumValues
------------------------------------------------------------------------------------------------
DECLARE @propertyEnumValues TABLE (
	Id UNIQUEIDENTIFIER NOT NULL,
	EnumId UNIQUEIDENTIFIER NOT NULL,
	StringValue NVARCHAR(200) NULL,
	NumericValue NUMERIC(28, 6) NULL
)

-- Coffee Strength
DECLARE @coffeeStrengthEnumId UNIQUEIDENTIFIER
SET @coffeeStrengthEnumId = (SELECT P.Id FROM [dbo].[PropertyEnums] AS P WHERE Name = 'Coffee Strength')

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeStrengthEnumId, NULL, 1)

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeStrengthEnumId, NULL, 2)

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeStrengthEnumId, NULL, 3)

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeStrengthEnumId, NULL, 4)

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeStrengthEnumId, NULL, 5)

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeStrengthEnumId, NULL, 6)

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeStrengthEnumId, NULL, 7)

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeStrengthEnumId, NULL, 8)

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeStrengthEnumId, NULL, 9)

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeStrengthEnumId, NULL, 10)


-- Coffee Sort Type
DECLARE @coffeeSortTypeEnumId UNIQUEIDENTIFIER
SET @coffeeSortTypeEnumId = (SELECT P.Id FROM [dbo].[PropertyEnums] AS P WHERE Name = 'Coffee Sort Type')

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeSortTypeEnumId, 'Arabica', NULL)

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeSortTypeEnumId, 'Robust', NULL)

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeSortTypeEnumId, 'Mixed', NULL)


-- Coffee Machine Type
DECLARE @coffeeMachineTypeEnumId UNIQUEIDENTIFIER
SET @coffeeMachineTypeEnumId = (SELECT P.Id FROM [dbo].[PropertyEnums] AS P WHERE Name = 'Coffee Machine Type')

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeMachineTypeEnumId, 'Drip', NULL)

INSERT INTO @propertyEnumValues (Id, EnumId, StringValue, NumericValue)
VALUES(NEWID(), @coffeeMachineTypeEnumId, 'Espresso', NULL)


MERGE [dbo].[PropertyEnumValues] AS Target
	USING (SELECT * FROM @propertyEnumValues) AS Source  
	ON (Target.Id = Source.Id AND Target.EnumId = Source.EnumId)
WHEN MATCHED THEN
    UPDATE SET
		StringValue = Source.StringValue,
		NumericValue = Source.NumericValue
WHEN NOT MATCHED THEN  
    INSERT (Id, EnumId, StringValue, NumericValue)
    VALUES (Source.Id, Source.EnumId, Source.StringValue, Source.NumericValue);


-- ProductPropertyValues
------------------------------------------------------------------------------------------------
DECLARE @productPropertyValues TABLE (
	Id UNIQUEIDENTIFIER NOT NULL,
	PropertyId UNIQUEIDENTIFIER NOT NULL,
	ProductId UNIQUEIDENTIFIER NOT NULL,
	StringValue NVARCHAR(500) NULL,
	NumericValue NUMERIC(28, 6) NULL,
	EnumValueId UNIQUEIDENTIFIER NULL
)

-- Coffee Strength
DECLARE @coffeeBeansStrengthPropId UNIQUEIDENTIFIER
SET @coffeeBeansStrengthPropId = (SELECT P.Id FROM [dbo].[ProductProperties] AS P WHERE ProductTypeId = @coffeeBeansTypeID AND Name = 'Strength')

DECLARE @groundCoffeeStrengthPropId UNIQUEIDENTIFIER
SET @groundCoffeeStrengthPropId = (SELECT P.Id FROM [dbo].[ProductProperties] AS P WHERE ProductTypeId = @groundCoffeeTypeID AND Name = 'Strength')

DECLARE @coffeeStrengthValue1Id UNIQUEIDENTIFIER
SET @coffeeStrengthValue1Id = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeStrengthEnumId AND NumericValue = 1)

DECLARE @coffeeStrengthValue2Id UNIQUEIDENTIFIER
SET @coffeeStrengthValue2Id = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeStrengthEnumId AND NumericValue = 2)

DECLARE @coffeeStrengthValue3Id UNIQUEIDENTIFIER
SET @coffeeStrengthValue3Id = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeStrengthEnumId AND NumericValue = 3)

DECLARE @coffeeStrengthValue4Id UNIQUEIDENTIFIER
SET @coffeeStrengthValue4Id = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeStrengthEnumId AND NumericValue = 4)

DECLARE @coffeeStrengthValue5Id UNIQUEIDENTIFIER
SET @coffeeStrengthValue5Id = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeStrengthEnumId AND NumericValue = 5)

DECLARE @coffeeStrengthValue6Id UNIQUEIDENTIFIER
SET @coffeeStrengthValue6Id = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeStrengthEnumId AND NumericValue = 6)

DECLARE @coffeeStrengthValue7Id UNIQUEIDENTIFIER
SET @coffeeStrengthValue7Id = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeStrengthEnumId AND NumericValue = 7)

DECLARE @coffeeStrengthValue8Id UNIQUEIDENTIFIER
SET @coffeeStrengthValue8Id = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeStrengthEnumId AND NumericValue = 8)

DECLARE @coffeeStrengthValue9Id UNIQUEIDENTIFIER
SET @coffeeStrengthValue9Id = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeStrengthEnumId AND NumericValue = 9)

DECLARE @coffeeStrengthValue10Id UNIQUEIDENTIFIER
SET @coffeeStrengthValue10Id = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeStrengthEnumId AND NumericValue = 10)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @coffeeBeansStrengthPropId, @sunshineMexicoId, NULL, NULL, @coffeeStrengthValue7Id)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @coffeeBeansStrengthPropId, @sunshineColumbiaId, NULL, NULL, @coffeeStrengthValue6Id)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @coffeeBeansStrengthPropId, @sunshineEphiopiaId, NULL, NULL, @coffeeStrengthValue5Id)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @coffeeBeansStrengthPropId, @sunshineJavaId, NULL, NULL, @coffeeStrengthValue8Id)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @groundCoffeeStrengthPropId, @lessCafeExpressId, NULL, NULL, @coffeeStrengthValue6Id)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @groundCoffeeStrengthPropId, @lessCafeGustoId, NULL, NULL, @coffeeStrengthValue7Id)


-- Coffee Sort Type
DECLARE @coffeeBeansSortTypePropId UNIQUEIDENTIFIER
SET @coffeeBeansSortTypePropId = (SELECT P.Id FROM [dbo].[ProductProperties] AS P WHERE ProductTypeId = @coffeeBeansTypeID AND Name = 'Sort')

DECLARE @groundCoffeeSortPropId UNIQUEIDENTIFIER
SET @groundCoffeeSortPropId = (SELECT P.Id FROM [dbo].[ProductProperties] AS P WHERE ProductTypeId = @groundCoffeeTypeID AND Name = 'Sort')

DECLARE @arabicaEnumValueId UNIQUEIDENTIFIER
SET @arabicaEnumValueId = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeSortTypeEnumId AND StringValue = 'Arabica')

DECLARE @robustEnumValueId UNIQUEIDENTIFIER
SET @robustEnumValueId = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeSortTypeEnumId AND StringValue = 'Robust')

DECLARE @mixedEnumValueId UNIQUEIDENTIFIER
SET @mixedEnumValueId = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeSortTypeEnumId AND StringValue = 'Mixed')

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @coffeeBeansSortTypePropId, @sunshineMexicoId, NULL, NULL, @arabicaEnumValueId)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @coffeeBeansSortTypePropId, @sunshineColumbiaId, NULL, NULL, @arabicaEnumValueId)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @coffeeBeansSortTypePropId, @sunshineEphiopiaId, NULL, NULL, @robustEnumValueId)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @coffeeBeansSortTypePropId, @sunshineJavaId, NULL, NULL, @robustEnumValueId)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @groundCoffeeSortPropId, @lessCafeExpressId, NULL, NULL, @mixedEnumValueId)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @groundCoffeeSortPropId, @lessCafeGustoId, NULL, NULL, @mixedEnumValueId)


-- Coffee Machine Type
DECLARE @coffeeMachineTypePropId UNIQUEIDENTIFIER
SET @coffeeMachineTypePropId = (SELECT P.Id FROM [dbo].[ProductProperties] AS P WHERE Name = 'CoffeeMachineType')

DECLARE @dripMachineEnumValueId UNIQUEIDENTIFIER
SET @dripMachineEnumValueId = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeMachineTypeEnumId AND StringValue = 'Drip')

DECLARE @espressoMachineEnumValueId UNIQUEIDENTIFIER
SET @espressoMachineEnumValueId = (SELECT P.Id FROM [dbo].[PropertyEnumValues] AS P WHERE EnumId = @coffeeMachineTypeEnumId AND StringValue = 'Espresso')

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @coffeeMachineTypePropId, @brewMaster200Id, NULL, NULL, @dripMachineEnumValueId)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @coffeeMachineTypePropId, @brewMaster300Id, NULL, NULL, @espressoMachineEnumValueId)


-- Origin
DECLARE @beansOriginPropId UNIQUEIDENTIFIER
SET @beansOriginPropId = (SELECT P.Id FROM [dbo].[ProductProperties] AS P WHERE ProductTypeId = @coffeeBeansTypeID AND Name = 'Origin')

DECLARE @groundOriginPropId UNIQUEIDENTIFIER
SET @groundOriginPropId = (SELECT P.Id FROM [dbo].[ProductProperties] AS P WHERE ProductTypeId = @groundCoffeeTypeID AND Name = 'Origin')

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @beansOriginPropId, @sunshineMexicoId, 'Mexico', NULL, NULL)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @beansOriginPropId, @sunshineColumbiaId, 'Columbia', NULL, NULL)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @beansOriginPropId, @sunshineEphiopiaId, 'Ephiopia', NULL, NULL)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @beansOriginPropId, @sunshineJavaId, 'Java', NULL, NULL)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @groundOriginPropId, @lessCafeExpressId, 'Italia', NULL, NULL)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @groundOriginPropId, @lessCafeGustoId, 'Brazil', NULL, NULL)


-- GuaranteePeriod
DECLARE @guaranteePeriodPropId UNIQUEIDENTIFIER
SET @guaranteePeriodPropId = (SELECT P.Id FROM [dbo].[ProductProperties] AS P WHERE Name = 'GuaranteePeriod')

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @guaranteePeriodPropId, @brewMaster200Id, NULL, 36, NULL)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @guaranteePeriodPropId, @brewMaster300Id, NULL, 48, NULL)


-- CoffeeGrinder
DECLARE @coffeeGrinderPropId UNIQUEIDENTIFIER
SET @coffeeGrinderPropId = (SELECT P.Id FROM [dbo].[ProductProperties] AS P WHERE Name = 'CoffeeGrinder')

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @coffeeGrinderPropId, @brewMaster200Id, NULL, 1, NULL)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @coffeeGrinderPropId, @brewMaster300Id, NULL, 1, NULL)


-- Cappuccinatore
DECLARE @CappuccinatorePropId UNIQUEIDENTIFIER
SET @CappuccinatorePropId = (SELECT P.Id FROM [dbo].[ProductProperties] AS P WHERE Name = 'Cappuccinatore')

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @CappuccinatorePropId, @brewMaster200Id, NULL, 0, NULL)

INSERT INTO @productPropertyValues (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
VALUES(NEWID(), @CappuccinatorePropId, @brewMaster300Id, NULL, 1, NULL)

MERGE [dbo].[ProductPropertyValues] AS Target
	USING (SELECT * FROM @productPropertyValues) AS Source  
	ON (Target.Id = Source.Id
		AND Target.PropertyId = Source.PropertyId
		AND Target.ProductId = Source.ProductId)
WHEN MATCHED THEN
    UPDATE SET
		StringValue = Source.StringValue,
		NumericValue = Source.NumericValue,
		EnumValueId = Source.EnumValueId
WHEN NOT MATCHED THEN  
    INSERT (Id, PropertyId, ProductId, StringValue, NumericValue, EnumValueId)
    VALUES (Source.Id, Source.PropertyId, Source.ProductId, Source.StringValue, Source.NumericValue, Source.EnumValueId);