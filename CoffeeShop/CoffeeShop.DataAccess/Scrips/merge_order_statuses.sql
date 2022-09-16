USE CoffeeStore

SET NOCOUNT ON;  

DECLARE @orderStatuses TABLE (
	Id SMALLINT NOT NULL,
	Name NVARCHAR(30) NOT NULL
)

INSERT INTO @orderStatuses (Id, Name) VALUES (1, 'New')
INSERT INTO @orderStatuses (Id, Name) VALUES (2, 'In progress')
INSERT INTO @orderStatuses (Id, Name) VALUES (3, 'Finished')
INSERT INTO @orderStatuses (Id, Name) VALUES (4, 'Canceled')
INSERT INTO @orderStatuses (Id, Name) VALUES (5, 'Error')

MERGE [dbo].[OrderStatuses] AS Target
	USING (SELECT Id, Name FROM @orderStatuses) AS Source  
	ON (Target.Id = Source.Id)
WHEN MATCHED THEN
    UPDATE SET Name = Source.Name  
WHEN NOT MATCHED THEN  
    INSERT (Id, Name)  
    VALUES (Source.Id, Source.Name);