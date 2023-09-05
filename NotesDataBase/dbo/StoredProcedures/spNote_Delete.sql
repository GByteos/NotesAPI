CREATE PROCEDURE [dbo].[spNote_Delete]
	@Id INT
AS
BEGIN
	DECLARE @InsertedEntry table(	Id INT,
									Title NVARCHAR(50),
									[Owner] NVARCHAR(100),
									Content NVARCHAR(MAX));

	INSERT INTO @InsertedEntry
	SELECT Id, Title, Owner, Content
	FROM dbo.Notes
	WHERE Id=@Id;

	DELETE
	FROM dbo.Notes
	WHERE Id=@Id;
	
	SELECT Id, Title, Owner, Content FROM @InsertedEntry;
END
