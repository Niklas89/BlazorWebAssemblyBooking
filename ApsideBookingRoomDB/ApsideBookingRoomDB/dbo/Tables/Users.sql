CREATE TABLE [dbo].[Users] (
    [IdUser]     UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [FullName]   NVARCHAR(100)    NOT NULL,
    [Password]   NVARCHAR(100)    NOT NULL,
    [Mail]       NVARCHAR(100)    NOT NULL,
    [RowVersion] ROWVERSION       NOT NULL,
    CONSTRAINT [Users_PK] PRIMARY KEY CLUSTERED ([IdUser] ASC)
);

