CREATE TABLE [dbo].[Books] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Title]         NVARCHAR (MAX) NOT NULL,
    [Genre]         NVARCHAR (MAX) NOT NULL,
    [Nuber_of_Page] INT            NOT NULL,
    [AuthorId]      INT            NULL,
    CONSTRAINT [PK_dbo.Books] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Books_dbo.Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_AuthorId]
    ON [dbo].[Books]([AuthorId] ASC);

