CREATE TABLE [dbo].[Prescription]
(
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[UserId] INT NOT NULL,
	[Name] VARCHAR(50) NOT NULL UNIQUE,
	[Description] NVARCHAR(MAX) NOT NULL,

    CONSTRAINT [FK_Prescription_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
