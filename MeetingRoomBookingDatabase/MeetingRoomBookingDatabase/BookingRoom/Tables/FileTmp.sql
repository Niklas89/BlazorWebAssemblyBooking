CREATE TABLE [BookingRoom].[FileTmp]
(
	[Id]            UNIQUEIDENTIFIER CONSTRAINT [DF_BookingRoom_FileTmp_Id] DEFAULT (newsequentialid()) NOT NULL,
	[Type]				   NVARCHAR (100)    NOT NULL,
	[Name]				   NVARCHAR (255)    NOT NULL,
	[Content]              VARBINARY (MAX)    NOT NULL,
	[Extension]            NVARCHAR (10)    NOT NULL,
	[CreationDate]		   DATETIME2 (7)    NOT NULL,
	[RowVersion]           ROWVERSION       NOT NULL,
	CONSTRAINT [FileTmp_PK] PRIMARY KEY CLUSTERED ([Id] ASC)
)
