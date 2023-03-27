/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:setvar SettingTable Setting
INSERT INTO [BookingRoom].[$(SettingTable)]
           ([Name]
           ,[Value]
           ,[Type]
           ,[Description])
     VALUES
           ('Rooms'
           ,'1'
           ,0
           ,'Show the rooms page in the administration area'),
		   ('Statistics'
           ,'1'
           ,0
           ,'Show the statistics page in the administration area')