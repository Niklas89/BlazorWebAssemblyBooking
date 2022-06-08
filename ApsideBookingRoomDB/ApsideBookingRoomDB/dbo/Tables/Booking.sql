CREATE TABLE [dbo].[Booking] (
    [IdBooking]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Subject]            NVARCHAR(50)     NOT NULL,
    [StartDate]          DATETIME2 (7)    NOT NULL,
    [EndDate]            DATETIME2 (7)    NOT NULL,
    [Comment]            NVARCHAR(100)    NULL,
    [RowVersion]         ROWVERSION       NOT NULL,
    [CreationUserId]     UNIQUEIDENTIFIER NOT NULL,
    [ModificationUserId] UNIQUEIDENTIFIER NOT NULL,
    [CreationDate]       DATETIME2 (7)    NOT NULL,
    [ModificationDate]   DATETIME2 (7)    NOT NULL,
    [IdRoom]             UNIQUEIDENTIFIER NOT NULL,
    [IsAllDay]           BIT              NOT NULL,
    CONSTRAINT [Booking_PK] PRIMARY KEY CLUSTERED ([IdBooking] ASC),
    CONSTRAINT [Booking_Rooms_FK] FOREIGN KEY ([IdRoom]) REFERENCES [dbo].[Rooms] ([IdRoom])
);

