USE CoffeeStore

SET NOCOUNT ON;  

DECLARE @propertyValueTypes TABLE (
	Name NVARCHAR(50) NOT NULL
)

INSERT INTO @propertyValueTypes (Name) VALUES ('string')
INSERT INTO @propertyValueTypes (Name) VALUES ('number')
INSERT INTO @propertyValueTypes (Name) VALUES ('enum_value')

MERGE [dbo].[PropertyValueTypes] AS Target  
	USING (SELECT Name FROM @propertyValueTypes) AS Source  
	ON (Target.Name = Source.Name)
WHEN NOT MATCHED THEN
    INSERT (Name)
    VALUES (Source.Name);