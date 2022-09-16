USE CoffeeStore

SET NOCOUNT ON;  

DECLARE @operationTypes TABLE (
	Id SMALLINT NOT NULL,
	Name NVARCHAR(20) NOT NULL
)

INSERT INTO @operationTypes (Id, Name) VALUES (1, 'Income')
INSERT INTO @operationTypes (Id, Name) VALUES (2, 'Outcome')

MERGE [dbo].[OperationTypes] AS Target
	USING (SELECT Id, Name FROM @operationTypes) AS Source  
	ON (Target.Id = Source.Id)
WHEN MATCHED THEN
    UPDATE SET Name = Source.Name  
WHEN NOT MATCHED THEN  
    INSERT (Id, Name)  
    VALUES (Source.Id, Source.Name);