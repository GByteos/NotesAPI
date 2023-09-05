CREATE PROCEDURE [dbo].[spNote_Update]
	@Id INT,
	@Title NVARCHAR(50),
	@Owner NVARCHAR(100),
	@Content NVARCHAR(MAX)
AS
BEGIN
	UPDATE dbo.Notes
	SET Title=@Title, Owner=@Owner, Content=@Content
	WHERE Id=@Id;
	
	SELECT Id, Title, Owner, Content
	FROM dbo.Notes
	WHERE Id=@Id;
END
