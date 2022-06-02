CREATE TABLE [dbo].[userHasRole] (
    [IdRole] TINYINT          NOT NULL,
    [IdUser] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [userHasRole_PK] PRIMARY KEY CLUSTERED ([IdRole] ASC, [IdUser] ASC),
    CONSTRAINT [userHasRole_Role_FK] FOREIGN KEY ([IdRole]) REFERENCES [dbo].[Role] ([IdRole]),
    CONSTRAINT [userHasRole_Users0_FK] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[Users] ([IdUser])
);

