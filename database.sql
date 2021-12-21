USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='GuildCars')
DROP DATABASE GuildCars
GO

CREATE DATABASE GuildCars
GO

USE GuildCars
GO


ALTER LOGIN sa ENABLE ;
GO
ALTER LOGIN sa WITH PASSWORD = 'sqlserver';
GO
