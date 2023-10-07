USE [Entities]
GO

DROP TABLE [dbo].Entities
GO

CREATE TABLE [dbo].[Entities] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Make] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](60) NOT NULL,
	[Year] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](50) NOT NULL
);

SET IDENTITY_INSERT [dbo].[Entities] ON
INSERT INTO [dbo].[Entities] ([Id], [Name], [Make], [Model], [Year], [Color]) VALUES (1, N'Mercedes Benz', N'GLC', N'2014', N'Black')
INSERT INTO [dbo].[Entities] ([Id], [Name], [Make], [Model], [Year], [Color]) VALUES (2, N'Nissan', N'Altima', N'2014', N'White')
SET IDENTITY_INSERT [dbo].[Entities] OFF