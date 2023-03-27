CREATE TABLE [Security].[Role] (
    [Id]     TINYINT       NOT NULL,
    [RoleName]   NVARCHAR (50) NOT NULL,
    [RowVersion] ROWVERSION    NOT NULL,
    CONSTRAINT [Role_PK] PRIMARY KEY CLUSTERED ([Id] ASC)
);

