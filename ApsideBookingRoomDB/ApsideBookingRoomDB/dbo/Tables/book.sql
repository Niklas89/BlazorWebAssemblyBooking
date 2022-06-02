CREATE TABLE [dbo].[book] (
    [IdBooking] UNIQUEIDENTIFIER NOT NULL,
    [IdUser]    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [book_PK] PRIMARY KEY CLUSTERED ([IdBooking] ASC, [IdUser] ASC),
    CONSTRAINT [book_Booking_FK] FOREIGN KEY ([IdBooking]) REFERENCES [dbo].[Booking] ([IdBooking]),
    CONSTRAINT [book_Users0_FK] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[Users] ([IdUser])
);

