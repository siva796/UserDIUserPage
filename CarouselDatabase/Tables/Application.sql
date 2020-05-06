

CREATE TABLE [dbo].[Application]
(
	applicationId int identity(1,1) Primary key,
	applicationName nvarchar(150),
	applicationDescription nvarchar(max),
	isDeleted  bit

)
drop table Application

select * from Application
use [Carousel.Database]