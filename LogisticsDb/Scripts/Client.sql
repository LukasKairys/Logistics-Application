CREATE TABLE [dbo].[Client]
(
	[ClientId] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Level] NCHAR(10) NOT NULL DEFAULT 'Standart'

)
