﻿CREATE TABLE [dbo].[Tournament]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[LimitDate] DATETIME2 NOT NULL,
	[NbPlayer] INT NOT NULL,
	[AdminId] INT NOT NULL REFERENCES [User](Id)
)
