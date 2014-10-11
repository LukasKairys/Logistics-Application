CREATE TABLE [dbo].[SeaTypeOrder]
(
	[OrderId] INT NOT NULL PRIMARY KEY, 
    [Cargo] NCHAR(10) NOT NULL, 
    [TotalWeight] NCHAR(10) NOT NULL, 
    [Price] FLOAT NOT NULL, 
    [From] NVARCHAR(50) NOT NULL, 
    [To] NVARCHAR(50) NOT NULL, 
	[IsAdditionalFasteningNeeded] BIT NOT NULL, 
    [ShippingLine] NVARCHAR(50) NOT NULL, 
    [ClientId] INT NOT NULL, 
    CONSTRAINT [SeaOrderClientId] FOREIGN KEY ([ClientId]) REFERENCES [Client]([ClientId]) 
)
