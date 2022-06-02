/*
Script de déploiement pour ApsideBookingRoomDB

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ApsideBookingRoomDB"
:setvar DefaultFilePrefix "ApsideBookingRoomDB"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
PRINT N'Modification de Table [dbo].[Booking]...';


GO
ALTER TABLE [dbo].[Booking] ALTER COLUMN [Comment] NVARCHAR (100) NULL;

ALTER TABLE [dbo].[Booking] ALTER COLUMN [Subject] NVARCHAR (50) NOT NULL;


GO
PRINT N'Modification de Table [dbo].[Role]...';


GO
ALTER TABLE [dbo].[Role] ALTER COLUMN [RoleName] NVARCHAR (50) NOT NULL;


GO
PRINT N'Modification de Table [dbo].[Rooms]...';


GO
ALTER TABLE [dbo].[Rooms] ALTER COLUMN [Image] NVARCHAR (50) NULL;

ALTER TABLE [dbo].[Rooms] ALTER COLUMN [Name] NVARCHAR (50) NOT NULL;


GO
PRINT N'Modification de Table [dbo].[Users]...';


GO
ALTER TABLE [dbo].[Users] ALTER COLUMN [FullName] NVARCHAR (100) NOT NULL;

ALTER TABLE [dbo].[Users] ALTER COLUMN [Mail] NVARCHAR (100) NOT NULL;

ALTER TABLE [dbo].[Users] ALTER COLUMN [Password] NVARCHAR (100) NOT NULL;


GO
PRINT N'Mise à jour terminée.';


GO
