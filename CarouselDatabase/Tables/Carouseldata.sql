CREATE TABLE [dbo].[carouseldata]
(
  CarouselId int identity(1,1) Primary Key,

   carouselData Nvarchar(max),
   validFrom DateTime,
   validTo DateTime,
   isDeleted  Bit,
   applicationId int,
   userId int,
  CONSTRAINT FK_carouseldata_applicationId FOREIGN KEY(applicationId) REFERENCES [Application](applicationId),
  CONSTRAINT FK_carouseldata_userId FOREIGN KEY(userId) REFERENCES [Users](userId)
)

use [Carousel.Database]
Truncate Table Carouseldata
drop Table carouseldata

