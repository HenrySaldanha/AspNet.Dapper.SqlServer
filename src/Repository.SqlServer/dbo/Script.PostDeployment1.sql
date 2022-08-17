if not exists(select 1 from dbo.Book)
begin
 insert into dbo.Book 
	(Book.Name, Book.Description, Book.ISBN, Book.PublishedAt)
 values
	('Clean Code','A Handbook of Agile Software Craftsmanship','9780132350884','2008-08-11'),
	('Clean Architecture','A Craftsmans Guide to Software Structure and Design','9780134494166','2017-09-10'),
	('The Pragmatic Programmer','Your Journey to Mastery','9780135957059','2019-09-13');
end