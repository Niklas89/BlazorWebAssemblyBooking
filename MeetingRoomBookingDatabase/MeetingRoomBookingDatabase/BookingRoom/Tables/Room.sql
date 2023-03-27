CREATE TABLE [BookingRoom].[Room] (
    [Id]             UNIQUEIDENTIFIER CONSTRAINT [DF_BookingRoom_Room_Id] DEFAULT (newsequentialid()) NOT NULL,
    [Name]               NVARCHAR (50)    NOT NULL,
    [Capacity]           INT              NOT NULL,
    [Availability]       BIT              NOT NULL,
    [RowVersion]         ROWVERSION       NOT NULL,
    [CreationUserId]     UNIQUEIDENTIFIER NOT NULL,
    [ModificationUserId] UNIQUEIDENTIFIER NOT NULL,
    [CreationDate]       DATETIME2 (7)    NOT NULL,
    [ModificationDate]   DATETIME2 (7)    NOT NULL,
    [IdFile]             UNIQUEIDENTIFIER,
    CONSTRAINT [Room_PK] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [Room_FileTmp_FK] FOREIGN KEY ([IdFile]) REFERENCES [BookingRoom].[FileTmp] ([Id])
);

