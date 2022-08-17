CREATE PROCEDURE [dbo].[InsertBookSP]
	@Name nvarchar(150),
	@Description nvarchar(300),
	@ISBN nchar(13),
	@PublishedAt datetime
AS
begin
	insert into dbo.Book 
		(Name,Description,ISBN, PublishedAt)
	values
		(@Name,@Description,@ISBN, @PublishedAt)
end