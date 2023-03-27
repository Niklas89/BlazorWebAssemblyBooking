CREATE TABLE [BookingRoom].[Booking] (
    [Id]            UNIQUEIDENTIFIER CONSTRAINT [DF_BookingRoom_Booking_Id] DEFAULT (newsequentialid()) NOT NULL,
    [Subject]              NVARCHAR (50)    NOT NULL,
    [StartDate]            DATETIME2 (7)    NOT NULL,
    [EndDate]              DATETIME2 (7)    NOT NULL,
    [Comment]              NVARCHAR (150)   NULL,
    [RowVersion]           ROWVERSION       NOT NULL,
    [CreationUserId]       UNIQUEIDENTIFIER NOT NULL,
    [ModificationUserId]   UNIQUEIDENTIFIER NOT NULL,
    [CreationDate]         DATETIME2 (7)    NOT NULL,
    [ModificationDate]     DATETIME2 (7)    NOT NULL,
    [IsAllDay]             BIT CONSTRAINT [DF_BookingRoom_Booking_IsAllDay] DEFAULT ((0)) NOT NULL,
    [RecurrenceId]         UNIQUEIDENTIFIER NULL,
    [RecurrenceRule]       NVARCHAR (150)   NULL,
    [RecurrenceExceptions] NVARCHAR (250)   NULL,
    [IdRoom]               UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [Booking_PK] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Booking_Room_FK] FOREIGN KEY ([IdRoom]) REFERENCES [BookingRoom].[Room] ([Id]),
    CONSTRAINT [Booking_User_FK] FOREIGN KEY ([CreationUserId]) REFERENCES [Security].[User] ([Id])
);

