CREATE TABLE [dbo].[User_Tournament]
(
	[UserId] INT NOT NULL REFERENCES [User](Id),
	[TournamentId] INT NOT NULL REFERENCES [Tournament](Id)
)
