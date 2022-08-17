CREATE PROCEDURE [dbo].[UpdateBookSP]
	@Id int,
	@Name nvarchar(150),
	@Description nvarchar(300),
	@ISBN nchar(13),
	@PublishedAt datetime
AS
begin
	update dbo.Book 
		set Name = @Name,
			Description = @Description,
			ISBN = @ISBN,
			PublishedAt = @PublishedAt
	where 
		Id = @Id
end