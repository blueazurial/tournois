CREATE TABLE [dbo].[Match]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[TournamentId] INT NOT NULL REFERENCES [Tournament](Id),
	[Playeur1Move] INT NOT NULL REFERENCES [User](Id),
	[Playeur2Move] INT NOT NULL REFERENCES [User](Id),
	

)
