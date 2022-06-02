CREATE TABLE [dbo].[Rooms] (
    [IdRoom]             UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Name]               NVARCHAR(50)     NOT NULL,
    [Capacity]           INT              NOT NULL,
    [Image]              NVARCHAR(50)     NULL,
    [Availability]       BIT              NOT NULL,
    [RowVersion]         ROWVERSION       NOT NULL,
    [CreationUserId]     UNIQUEIDENTIFIER NOT NULL,
    [ModificationUserId] UNIQUEIDENTIFIER NOT NULL,
    [CreationDate]       DATETIME2 (7)    NOT NULL,
    [ModificationDate]   DATETIME2 (7)    NOT NULL,
    CONSTRAINT [Rooms_PK] PRIMARY KEY CLUSTERED ([IdRoom] ASC)
);

