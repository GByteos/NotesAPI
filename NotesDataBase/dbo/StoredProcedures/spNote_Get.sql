CREATE PROCEDURE [dbo].[spNote_Get]
	@Id int
AS
BEGIN
	SELECT Id, Title, Owner, Content
	FROM dbo.Notes
	WHERE Id=@Id;
END
