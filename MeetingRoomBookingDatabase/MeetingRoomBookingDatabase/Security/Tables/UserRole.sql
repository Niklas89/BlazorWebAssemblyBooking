CREATE TABLE [Security].[UserRole] (
    [Id] UNIQUEIDENTIFIER CONSTRAINT [DF_Security_UserRole_Id] DEFAULT (newsequentialid()) NOT NULL, 
    [IdRole] TINYINT          NOT NULL,
    [IdUser] UNIQUEIDENTIFIER NOT NULL,
    [RowVersion] ROWVERSION NOT NULL, 
    CONSTRAINT [UserRole_PK] PRIMARY KEY CLUSTERED  ([Id] ASC),
    CONSTRAINT [UserRole_Role_FK] FOREIGN KEY ([IdRole]) REFERENCES [Security].[Role] ([Id]),
    CONSTRAINT [UserRole_User_FK] FOREIGN KEY ([IdUser]) REFERENCES [Security].[User] ([Id]),
    CONSTRAINT [UserRole_Unique] UNIQUE ([IdRole],[IdUser])
); 

