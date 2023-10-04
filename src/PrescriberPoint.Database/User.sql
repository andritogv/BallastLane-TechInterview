CREATE TABLE [dbo].[User]
(
	[Id] INT PRIMARY KEY IDENTITY(1,1), 
    [Username] VARCHAR(50) NOT NULL UNIQUE, 
    [Password] TEXT NOT NULL
)
