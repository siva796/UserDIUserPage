CREATE TABLE [dbo].[Users]
(
  userId int identity(1,1) Primary Key,
  userName Nvarchar(150),
  Email Nvarchar(200),
  isDeleted bit

	
)
            select * from Users     
			    
drop table Users
use [Carousel.Database]