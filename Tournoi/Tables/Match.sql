CREATE TABLE [dbo].[Match]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[TournamentId] INT NOT NULL REFERENCES [Tournament](Id),
	[Player1Id] INT NOT NULL REFERENCES [User](Id),
	[Player2Id] INT NOT NULL REFERENCES [User](Id),
	

)
