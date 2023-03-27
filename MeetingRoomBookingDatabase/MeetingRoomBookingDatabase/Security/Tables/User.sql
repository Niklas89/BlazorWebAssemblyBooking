CREATE TABLE [Security].[User] (
    [Id]     UNIQUEIDENTIFIER CONSTRAINT [DF_Security_User_Id] DEFAULT (newsequentialid()) NOT NULL,
    [FullName]   NVARCHAR (100)   NOT NULL,
    [PasswordHash]   VARBINARY(MAX)   NOT NULL,
    [PasswordSalt]   VARBINARY(MAX)   NOT NULL,
    [Mail]       NVARCHAR (100)   NOT NULL,
    [RowVersion] ROWVERSION       NOT NULL,
    CONSTRAINT [User_PK] PRIMARY KEY CLUSTERED ([Id] ASC)
);

