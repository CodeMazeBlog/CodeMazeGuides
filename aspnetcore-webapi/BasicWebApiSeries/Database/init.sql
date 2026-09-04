/*
    AccountOwner sample database - ASP.NET Core Web API series, part 1.

    Creates the AccountOwner database, the Owner and Account tables, the foreign key
    between them, and the sample data the rest of the series calls its endpoints with.

    The script is re-runnable: it drops the tables before it creates them, so running
    it a second time rebuilds the schema instead of failing on names that already exist.

    LocalDB (Windows):
        sqlcmd -S "(localdb)\MSSQLLocalDB" -i init.sql

    Container (any OS), started with the docker-compose.yml beside this file:
        sqlcmd -S localhost -U sa -P "<YourStrong!Passw0rd>" -C -i init.sql
*/

IF DB_ID('AccountOwner') IS NULL
    CREATE DATABASE [AccountOwner];
GO

USE [AccountOwner];
GO

-- Account first: it holds the foreign key, so it has to go before its parent.
DROP TABLE IF EXISTS [dbo].[Account];
DROP TABLE IF EXISTS [dbo].[Owner];
GO

CREATE TABLE [dbo].[Owner]
(
    [OwnerId]     UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR(60)     NOT NULL,
    [DateOfBirth] DATE             NOT NULL,
    [Address]     NVARCHAR(100)    NOT NULL,
    CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED ([OwnerId])
);
GO

CREATE TABLE [dbo].[Account]
(
    [AccountId]   UNIQUEIDENTIFIER NOT NULL,
    [DateCreated] DATE             NOT NULL,
    [AccountType] NVARCHAR(45)     NOT NULL,
    [OwnerId]     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([AccountId]),
    CONSTRAINT [FK_Account_Owner] FOREIGN KEY ([OwnerId])
        REFERENCES [dbo].[Owner] ([OwnerId])
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Account_OwnerId] ON [dbo].[Account] ([OwnerId]);
GO

-- Owners first. Every Account row names an owner, and the foreign key rejects a row
-- whose owner does not exist yet.
INSERT INTO [dbo].[Owner] ([OwnerId], [Name], [DateOfBirth], [Address])
VALUES
    ('24fd81f8-d58a-4bcc-9f35-dc6cd5641906', N'John Keen',     '1980-12-05', N'61 Wellfield Road'),
    ('261e1685-cf26-494c-b17c-3546e65f5620', N'Anna Bosh',     '1974-11-14', N'27 Colored Row'),
    ('a3c1880c-674c-4d18-8f91-5d3608a2c937', N'Sam Query',     '1990-04-22', N'91 Western Roads'),
    ('f98e4d74-0f68-4aac-89fd-047f1aaca6b6', N'Martin Miller', '1983-05-21', N'3 Edgar Buildings');
GO

INSERT INTO [dbo].[Account] ([AccountId], [DateCreated], [AccountType], [OwnerId])
VALUES
    ('03e91478-5608-4132-a753-d494dafce00b', '2003-12-15', N'Domestic', 'f98e4d74-0f68-4aac-89fd-047f1aaca6b6'),
    ('356a5a9b-64bf-4de0-bc84-5395a1fdc9c4', '1996-02-15', N'Domestic', '261e1685-cf26-494c-b17c-3546e65f5620'),
    ('371b93f2-f8c5-4a32-894a-fc672741aa5b', '1999-05-04', N'Domestic', '24fd81f8-d58a-4bcc-9f35-dc6cd5641906'),
    ('670775db-ecc0-4b90-a9ab-37cd0d8e2801', '1999-12-21', N'Savings',  '24fd81f8-d58a-4bcc-9f35-dc6cd5641906'),
    ('a3fbad0b-7f48-4feb-8ac0-6d3bbc997bfc', '2010-05-28', N'Domestic', 'a3c1880c-674c-4d18-8f91-5d3608a2c937'),
    ('aa15f658-04bb-4f73-82af-82db49d0fbef', '1999-05-12', N'Foreign',  '24fd81f8-d58a-4bcc-9f35-dc6cd5641906'),
    ('c6066eb0-53ca-43e1-97aa-3c2169eec659', '1996-02-16', N'Foreign',  '261e1685-cf26-494c-b17c-3546e65f5620'),
    ('eccadf79-85fe-402f-893c-32d3f03ed9b1', '2010-06-20', N'Foreign',  'a3c1880c-674c-4d18-8f91-5d3608a2c937');
GO
