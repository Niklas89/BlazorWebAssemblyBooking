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

:setvar RoleTable Role	
INSERT INTO [Security].[$(RoleTable)]
           ([Id]
           ,[RoleName])
     VALUES
           (1,'admin'),
           (2,'user')

:setvar UserTable User	
INSERT INTO [Security].[$(UserTable)]
           ([Id]
           ,[FullName]
           ,[PasswordHash]
           ,[PasswordSalt]
           ,[Mail])
      VALUES
           ('114578E3-960F-4E00-9BB1-0CFD065A5B5F','Debra Stork', 0xF0B9E52455C046E1360395E416AA7EEB8355047CC0BFF03FCA943B55C6EFDF2C505978CE790A73130B5380835C50865E92F8280BAA40E7067C9D1DA863A17CC7, 0x67F29CD504481DE4B0183DC9ABBA7B95E082B64F829348AB172273DA4506CDCF6D067D0BEB21D410E2AE2D73B59E7CE0C4DCA327B95F0666EA07D7B85BE1F2307D37F211728479FEE1FFA24BB68B9EBB690A2CA184A3A50C9C870936BB08BF54793F4EB4653EDFD511F955A4DA8F089B711654EC9DF08630015315614E2D150E,'dstorkesf@opensource.org'), /* pass: BXEV9ix */
		   ('6013E510-BA3B-45A4-A13E-17C02BCCCDE1','Leonora Skegg', 0x78CCB47005BA28AB93F7F3FDEAA92F37BC9FFA987BCBDA10CA687F33EC11DE7FFAA7DF9379ED53CB07A54BD51AC9603EC53F64DD4AF865CF926793F77671CCC9, 0x062B62332E0156E1532C9C3218E3867958ED821A8D86970B64258E9B2005C25BF4FFF12737AC0944BAAE9380E7E39EC133608BF4F3DB082F2595B67E86C1CCF0946F7F1CDE42CAF24FF28A88186092EFFCF1679C5288E7F1C1F5F5972C1EFDB1BD183BB73426BE487703F70F9ED8950AAE92A4E78B064A6F5A6A4BBCF37805F4,'lskegg9@java.com') /* pass: zBKb7oU */

:setvar UserRoleTable UserRole	
INSERT INTO [Security].[$(UserRoleTable)]
           ([IdRole]
           ,[IdUser])
     VALUES
           ('1','114578E3-960F-4E00-9BB1-0CFD065A5B5F'),
           ('1','6013E510-BA3B-45A4-A13E-17C02BCCCDE1')