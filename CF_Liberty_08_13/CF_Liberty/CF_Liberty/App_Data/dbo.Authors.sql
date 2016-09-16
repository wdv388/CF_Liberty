CREATE TABLE [dbo].[Authors] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NOT NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    [Birthdate] DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.Authors] PRIMARY KEY CLUSTERED ([ID] ASC)
);

