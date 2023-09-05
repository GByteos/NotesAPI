CREATE PROCEDURE [dbo].[spNote_GetAll]
AS
BEGIN
	SELECT Id, Title, Owner, Content
	FROM dbo.Notes;
END
