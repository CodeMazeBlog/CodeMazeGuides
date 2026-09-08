-- SQL Server schema and seed data for the Advanced REST Concepts sample.
-- Run it against a database of your choice, then point sqlconnection:connectionString at it.
-- On Windows the default connection string uses LocalDB. Elsewhere, one line gets you a server:
--   docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Str0ng!Passw0rd" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

IF OBJECT_ID('dbo.account', 'U') IS NOT NULL DROP TABLE dbo.account;
IF OBJECT_ID('dbo.owner', 'U') IS NOT NULL DROP TABLE dbo.owner;

CREATE TABLE dbo.owner
(
    OwnerId     uniqueidentifier NOT NULL PRIMARY KEY,
    Name        nvarchar(60)     NOT NULL,
    DateOfBirth datetime2        NOT NULL,
    Address     nvarchar(100)    NOT NULL
);

CREATE TABLE dbo.account
(
    AccountId   uniqueidentifier NOT NULL PRIMARY KEY,
    DateCreated datetime2        NOT NULL,
    AccountType nvarchar(45)     NOT NULL,
    OwnerId     uniqueidentifier NOT NULL
        CONSTRAINT fk_account_owner REFERENCES dbo.owner (OwnerId) ON UPDATE CASCADE
);

CREATE INDEX ix_owner_name ON dbo.owner (Name);
CREATE INDEX ix_owner_dateofbirth ON dbo.owner (DateOfBirth);

INSERT INTO dbo.owner (OwnerId, Name, DateOfBirth, Address) VALUES
    ('24fd81f8-d58a-4bcc-9f35-dc6cd5641906', 'John Keen',     '1980-12-05', '61 Wellfield Road'),
    ('261e1685-cf26-494c-b17c-3546e65f5620', 'Anna Bosh',     '1974-11-14', '27 Colored Row'),
    ('66774006-2371-4d5b-8518-2177bcf3f73e', 'Nick Somion',   '1998-12-15', 'North sunny address 102'),
    ('a3c1880c-674c-4d18-8f91-5d3608a2c937', 'Sam Query',     '1990-04-22', '91 Western Roads'),
    ('f98e4d74-0f68-4aac-89fd-047f1aaca6b6', 'Martin Miller', '1983-05-21', '3 Edgar Buildings');

INSERT INTO dbo.account (AccountId, DateCreated, AccountType, OwnerId) VALUES
    ('03e91478-5608-4132-a753-d494dafce00b', '2003-12-15', 'Domestic', 'f98e4d74-0f68-4aac-89fd-047f1aaca6b6'),
    ('356a5a9b-64bf-4de0-bc84-5395a1fdc9c4', '1996-02-15', 'Domestic', '261e1685-cf26-494c-b17c-3546e65f5620'),
    ('371b93f2-f8c5-4a32-894a-fc672741aa5b', '1999-05-04', 'Domestic', '24fd81f8-d58a-4bcc-9f35-dc6cd5641906'),
    ('670775db-ecc0-4b90-a9ab-37cd0d8e2801', '1999-12-21', 'Savings',  '24fd81f8-d58a-4bcc-9f35-dc6cd5641906'),
    ('a3fbad0b-7f48-4feb-8ac0-6d3bbc997bfc', '2010-05-28', 'Domestic', 'a3c1880c-674c-4d18-8f91-5d3608a2c937'),
    ('aa15f658-04bb-4f73-82af-82db49d0fbef', '1999-05-12', 'Foreign',  '24fd81f8-d58a-4bcc-9f35-dc6cd5641906'),
    ('c6066eb0-53ca-43e1-97aa-3c2169eec659', '1996-02-16', 'Foreign',  '261e1685-cf26-494c-b17c-3546e65f5620'),
    ('eccadf79-85fe-402f-893c-32d3f03ed9b1', '2010-06-20', 'Foreign',  'a3c1880c-674c-4d18-8f91-5d3608a2c937');
