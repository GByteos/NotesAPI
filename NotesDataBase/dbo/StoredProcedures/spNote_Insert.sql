CREATE PROCEDURE [dbo].[spNote_Insert]
	@Title NVARCHAR(50),
	@Owner NVARCHAR(100),
	@Content NVARCHAR(MAX)
AS
BEGIN
	DECLARE @InsertedEntry table(	Id INT,
									Title NVARCHAR(50),
									[Owner] NVARCHAR(100),
									Content NVARCHAR(MAX));

	INSERT INTO dbo.Notes (Title, [Owner], Content)
	OUTPUT inserted.Id, inserted.Title, inserted.[Owner], inserted.Content INTO @InsertedEntry
	VALUES (@Title, @Owner, @Content);
	
	SELECT Id, Title, Owner, Content FROM @InsertedEntry;
END
