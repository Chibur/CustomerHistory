CREATE TABLE [dbo].[Account]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CustomerId] INT NOT NULL, 
    [Balance] MONEY NOT NULL, 
    [AccountNumber] VARCHAR(50) NOT NULL, 
    [DateCreated] TIMESTAMP NOT NULL, 
    [AccountType] VARCHAR(10) NOT NULL, 
    FOREIGN KEY ([CustomerId]) REFERENCES CUSTOMER_INFO([Id])
)
