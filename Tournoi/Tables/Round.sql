CREATE TABLE [dbo].[Round]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY,
	[WinnerId] INT NULL REFERENCES [User](Id),
	[MatchId] INT NOT NULL REFERENCES [Match](Id),
	[Player1MoveId] INT NULL REFERENCES [Move](Id),
	[Player2MoveId] INT NULL REFERENCES [Move](Id),
	[NbRound] INT NOT NULL
)



GO

CREATE TRIGGER [dbo].[Trigger_Round]
    ON [dbo].[Round]
    AFTER UPDATE
    AS
    BEGIN
        SET NoCount ON
		--VERIFIER si les 2 playeurmoveId ne sont pas null
		------------------------------------------------------------------------------------------------------------------------------------------------------------
		if (SELECT Player1MoveId FROM inserted) is NOT NULL and (SELECT Player2MoveId FROM inserted) is NOT NULL 
		BEGIN
			--si ils ne le sont pas : ces qu il on jouer tt les deux donc 
			-- il faux decider le quels des deux a gagner --comment ? : 
			------------------------------------------------------------------------------------------------------------------------------------------------------------
			IF ((SELECT Player1MoveId FROM inserted) = (SELECT Weakness FROM Move WHERE Id = (SELECT Player2MoveId FROM inserted)))
			--SI  dans la table qui est en mise a jour (inserted) le playeur1move a la faiblesse du move2 alors :
			BEGIN
				UPDATE Round --MISE A JOUR  du Round pour remplacer la valeur du winnerId
				SET 
				--winnerid = on vas chercher dans la table Match l'id du player1 si Id du Match = du matchId de la table en modification 
 					WinnerId = (SELECT Player1Id FROM Match WHERE Id = (SELECT MatchId FROM inserted))        --il faux recuperer id du bon jouer dans la table Match 
					--quand l id = l id de la table en modification 
					WHERE Id = (SELECT Id FROM inserted)
					
			END 
			------------------------------------------------------------------------------------------------------------------------------------------------------------
			ELSE 
			BEGIN
				------------------------------------------------------------------------------------------------------------------------------------------------------------
				IF ((SELECT Player2MoveId FROM inserted) = (SELECT Weakness FROM Move WHERE Id = (SELECT Player1MoveId FROM inserted)))
			--SI  dans la table qui est en mise a jour (inserted) le playeur1move a la faiblesse du move1 alors :
				BEGIN
				UPDATE Round --MISE A JOUR  du Round pour remplacer la valeur du winnerId
				SET 
				--winnerid = on vas chercher dans la table Match l'id du player2 si Id du Match = du matchId de la table en modification 
 					WinnerId = (SELECT Player2Id FROM Match WHERE Id = (SELECT MatchId FROM inserted))        --il faux recuperer id du bon jouer dans la table Match 
					--quand l id = l id de la table en modification 
					WHERE Id = (SELECT Id FROM inserted) 
				END
				------------------------------------------------------------------------------------------------------------------------------------------------------------	
				ELSE
				--sinon : c est egaliter
				BEGIN
					UPDATE Round 
					--la meme chose misa a jour 
					SET 
					--winnerid = 0 pour que dans le code si il est a 0 c est egaliter 
					WinnerId = 0
				END
			------------------------------------------------------------------------------------------------------------------------------------------------------------
			END
		------------------------------------------------------------------------------------------------------------------------------------------------------------
		END
	END