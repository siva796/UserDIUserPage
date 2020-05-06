CREATE PROCEDURE [dbo].[SpInsertUsers]
   (@userName Nvarchar(200),@email Nvarchar(200),@isDeleted bit=0)
AS
	BEGIN
	INSERT INTO Users values(@userName,@email,@isDeleted)

END
exec SpInsertUsers 'siva','siva@gmail.com'

select * from Users





  
