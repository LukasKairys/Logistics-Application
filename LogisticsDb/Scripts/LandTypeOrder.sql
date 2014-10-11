CREATE TABLE [dbo].[LandTypeOrder]
(
	[OrderId] INT NOT NULL PRIMARY KEY, 
    [Cargo] NCHAR(10) NOT NULL, 
    [TotalWeight] NCHAR(10) NOT NULL, 
    [Price] FLOAT NOT NULL, 
    [From] NVARCHAR(50) NOT NULL, 
    [To] NVARCHAR(50) NOT NULL, 
	[IsOpenStorage] BIT NOT NULL, 
    [TransportLine] NVARCHAR(50) NOT NULL, 
    [ClientId] INT NOT NULL, 
    CONSTRAINT [LandOrderClientId] FOREIGN KEY ([ClientId]) REFERENCES [Client]([ClientId]) 
)
