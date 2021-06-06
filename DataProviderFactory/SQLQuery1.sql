
CREATE PROCEDURE GetPetName
	@carId int,
	@petName char(10) output

AS
BEGIN
	
	SELECT @petName = PetName From Inventory where CarId = @carId
END
GO
CREATE TABLE [dbo].[Customers]
(
[CustID] INT IDENTITY(1, 1) NOT NULL ,
[FirstName] NVARCHAR(50) NULL ,
[LastName] NVARCHAR(50) NULL ,
PRIMARY KEY CLUSTERED ( [CustID] ASC )
);

CREATE TABLE [dbo].[Orders]
(
[OrderId] INT NOT NULL PRIMARY KEY IDENTITY,
[CustId] INT NOT NULL,
[CarId] INT NOT NULL
);