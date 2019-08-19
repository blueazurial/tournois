--connection d un user 

CREATE PROCEDURE [dbo].[SP_Login]
	@email NVARCHAR(255),
	@password NVARCHAR(255)
AS
BEGIN
	SELECT Email,Id,Pseudo,'yolo' as [Password] FROM [User] WHERE Email = @email AND [Password] = dbo.Udf_Hash_Password (@password, @email)
END
