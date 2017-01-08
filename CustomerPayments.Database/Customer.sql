CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [BirthDate] DATE NULL, 
    [PhoneNumer] VARCHAR(20) NULL, 
    [EmailAddress] VARCHAR(50) NULL, 
    [LastModified] TIMESTAMP NOT NULL
)
