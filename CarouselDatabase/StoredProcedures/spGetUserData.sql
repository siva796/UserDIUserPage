ALTER PROCEDURE [dbo].[spGetUserData]
(@skip int=0,@top int= 10)
AS
BEGIN
SET NOCOUNT ON
  select userId,userName,Email from Users where isDeleted=0
  order by userId
  OFFSET @skip ROWS FETCH NEXT @top ROWS ONLY
  END
  exec  spGetUserData

  select * from Users



  