CREATE TABLE [dbo].[Player]
(
	[UserId] INT NOT NULL REFERENCES [User](Id),
	[TournamentId] INT NOT NULL REFERENCES [Tournament](Id)
)
