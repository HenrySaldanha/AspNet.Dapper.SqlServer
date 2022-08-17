﻿CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(150) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [ISBN] NCHAR(13) NOT NULL, 
    [PublishedAt] DATETIME NOT NULL
)