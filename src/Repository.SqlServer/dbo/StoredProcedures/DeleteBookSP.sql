CREATE PROCEDURE [dbo].[DeleteBookSP]
	@Id int
AS
begin
	delete
	from 
		dbo.Book
	where 
		Id = @Id
end