
--Crée le user 
CREATE PROCEDURE [dbo].[SP_Register]
	@email NVARCHAR(255),
	@password NVARCHAR(255),
	@pseudo NVARCHAR(100),
	@id INT 

AS
BEGIN
	INSERT INTO [User] (Email, [Password], Pseudo) 
						VALUES (@email, dbo.Udf_hash_Password(@password, @email), @pseudo)

END