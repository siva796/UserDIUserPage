CREATE PROCEDURE [dbo].[spSoftDelete]
@userId int,@isDeleted bit
AS
  BEGIN
     UPDATE Users set isDeleted=1 where userId=@userId
 END
 

 