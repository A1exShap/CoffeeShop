USE CoffeeStore

SET NOCOUNT ON;  

DECLARE @productTypes TABLE (
	Id UNIQUEIDENTIFIER NOT NULL,
	Name NVARCHAR(50) NOT NULL
)

INSERT INTO @productTypes (Id, Name) VALUES (NEWID(), 'Coffee (ground)')
INSERT INTO @productTypes (Id, Name) VALUES (NEWID(), 'Coffee (beans)')
INSERT INTO @productTypes (Id, Name) VALUES (NEWID(), 'Coffee machine')

MERGE [dbo].[ProductTypes] AS Target  
	USING (SELECT Id, Name FROM @productTypes) AS Source  
	ON (Target.Id = Source.Id)
WHEN MATCHED THEN
    DELETE;