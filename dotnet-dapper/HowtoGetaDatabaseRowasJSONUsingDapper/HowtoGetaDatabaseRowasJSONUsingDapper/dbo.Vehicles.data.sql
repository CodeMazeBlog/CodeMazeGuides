USE [VehicleDatabase]
GO

DROP TABLE [dbo].[Vehicles]
GO

CREATE TABLE [dbo].[Vehicles] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[City] [nvarchar](60) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
);

SET IDENTITY_INSERT [dbo].[Vehicles] ON
INSERT INTO [dbo].[Vehicles] ([Id], [Name], [Country], [City]) VALUES (1, N'Nissan', N'Japan', N'Tokyo')
INSERT INTO [dbo].[Vehicles] ([Id], [Name], [Country], [City]) VALUES (2, N'Mazda', N'Japan', N'Tokyo')
INSERT INTO [dbo].[Vehicles] ([Id], [Name], [Country], [City]) VALUES (3, N'BMW', N'Germany', N'Munich')
SET IDENTITY_INSERT [dbo].[Vehicles] OFF