CREATE PROCEDURE [dbo].[SpUpdateUsers]
	(@userName Nvarchar(200) ,@email Nvarchar(200) ,@userId int)
AS
   BEGIN
   IF(@UserName IS Not NULL)  UPDATE Users set userName=@userName where userId=@userId
 IF(@email IS Not NULL) UPDATE Users set email=@email where userId=@userId
End





