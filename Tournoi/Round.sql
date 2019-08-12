﻿CREATE TABLE [dbo].[Round]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[WinnerId] INT NOT NULL REFERENCES [User](Id),
	[MatchId] INT NOT NULL REFERENCES [Match](Id),
	[Player1MoveId] INT NOT NULL REFERENCES [Move](Id),
	[Player2MoveId] INT NOT NULL REFERENCES [Move](Id),
	[NbRound] INT NOT NULL
)
