﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[Email] NVARCHAR(255) NOT NULL,
	[Pseudo] NVARCHAR(50) NOT NULL,
	[Password] VARBINARY(MAX) NOT NULL
)
