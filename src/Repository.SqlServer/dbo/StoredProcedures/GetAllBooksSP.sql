CREATE PROCEDURE [dbo].[GetAllBooksSP]
AS
begin
	select 
		book.Id, 
		book.Description, 
		book.Name, 
		book.PublishedAt, 
		book.ISBN 
	from 
		dbo.Book as book;
end