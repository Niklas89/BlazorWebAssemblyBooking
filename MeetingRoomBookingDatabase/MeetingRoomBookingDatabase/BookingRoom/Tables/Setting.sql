CREATE TABLE [BookingRoom].[Setting]
(
	[Name]				NVARCHAR(64) NOT NULL PRIMARY KEY,
	[RowVersion]		ROWVERSION NOT NULL,
	[Value]				NVARCHAR (2048) NOT NULL,
	[Type]				TINYINT NOT NULL,
	[Description]		NVARCHAR (2048)
)
