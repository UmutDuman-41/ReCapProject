CREATE TABLE [dbo].[Table]
(
	[CarId] INT NOT NULL PRIMARY KEY, 
    [BrandId] INT NOT NULL, 
    [ColorId] INT NOT NULL, 
    [CarName] VARCHAR(50) NULL, 
    [ModelYear] VARCHAR(50) NOT NULL, 
    [DailyPrice] INT NOT NULL, 
    [Description] VARCHAR(50) NULL
)
