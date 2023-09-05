CREATE PROCEDURE [dbo].[spNote_GetAll]
AS
begin
	select Id, Title, Owner, Content
	from dbo.Notes
end
