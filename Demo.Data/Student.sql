CREATE TABLE [dbo].[Student] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [LastName]       NVARCHAR (50) NULL,
    [FirstName]      NVARCHAR (50) NULL, 
    CONSTRAINT [PK_Student] PRIMARY KEY ([Id]),
)