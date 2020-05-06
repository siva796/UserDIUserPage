


ALTER PROCEDURE [dbo].[spUpsertUserData]
(@userName Nvarchar(150),@email Nvarchar(200),@userId int,@isDeleted bit=0, @status bit)
AS
BEGIN
SET NOCOUNT ON
 BEGIN TRY  
IF @status=0
 BEGIN
  INSERT INTO Users (userName,Email,isDeleted) values(@userName,@email,@isDeleted)
  END
  IF @status=1
  BEGIN
  UPDATE Users set userName=@userName,Email=@email where userId=@userId
  END
  IF @status=2
  BEGIN
  UPDATE Users set isDeleted=1 where userId=@userId
  END
  END TRY
  BEGIN CATCH
        SELECT  
            ERROR_NUMBER() AS ErrorNumber  
            ,ERROR_SEVERITY() AS ErrorSeverity  
            ,ERROR_STATE() AS ErrorState  
            ,ERROR_PROCEDURE() AS ErrorProcedure  
            ,ERROR_LINE() AS ErrorLine  
            ,ERROR_MESSAGE() AS ErrorMessage;  
    END CATCH
  END
 
  
 























