CREATE PROCEDURE [dbo].[GetBookByIdSP]
	@Id int
AS
begin
	select 
		book.Id, 
		book.Description, 
		book.Name, 
		book.PublishedAt, 
		book.ISBN 
	from 
		dbo.Book as book
	where 
		book.Id = @Id
end