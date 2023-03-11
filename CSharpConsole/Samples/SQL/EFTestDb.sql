USE [master]
GO
/****** Object:  Database [EFTestDb]     ******/
CREATE DATABASE [EFTestDb]
GO

GO
USE [EFTestDb]
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPermissions](
	[GroupId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
 CONSTRAINT [PK_GP_GroupId_PermissionId] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permissions]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[ID] [int] NOT NULL,
	[Permission] [nvarchar](40) NOT NULL,
	[Description] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserGroups]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserGroups](
	[Id] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (1, N'Administrator')
GO
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (2, N'Reader')
GO
INSERT [dbo].[Groups] ([Id], [Name]) VALUES (3, N'PowerUser')
GO
INSERT [dbo].[UserGroups] ([Id], [GroupId], [UserId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[UserGroups] ([Id], [GroupId], [UserId]) VALUES (2, 2, 1)
GO
INSERT [dbo].[UserGroups] ([Id], [GroupId], [UserId]) VALUES (3, 2, 2)
GO
INSERT [dbo].[UserGroups] ([Id], [GroupId], [UserId]) VALUES (4, 2, 3)
GO
INSERT [dbo].[UserGroups] ([Id], [GroupId], [UserId]) VALUES (5, 3, 3)
GO
INSERT [dbo].[UserGroups] ([Id], [GroupId], [UserId]) VALUES (6, 3, 4)
GO
INSERT [dbo].[UserGroups] ([Id], [GroupId], [UserId]) VALUES (7, 2, 5)
GO
INSERT [dbo].[UserGroups] ([Id], [GroupId], [UserId]) VALUES (8, 3, 6)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Name], [Password], [IsActive]) VALUES (1, N'John', N'Password', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [Password], [IsActive]) VALUES (2, N'Martin', N'qwerty', 0)
GO
INSERT [dbo].[Users] ([Id], [Name], [Password], [IsActive]) VALUES (3, N'Pawel', N'asdf', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [Password], [IsActive]) VALUES (4, N'Anna', N'pwd', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [Password], [IsActive]) VALUES (5, N'Joe', N'zxcVBNM', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [Password], [IsActive]) VALUES (6, N'Kimberly', N'secretPassword', 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[GroupPermissions] ADD  DEFAULT ((1)) FOR [GroupId]
GO
ALTER TABLE [dbo].[GroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_GP_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[GroupPermissions] CHECK CONSTRAINT [FK_GP_GroupId]
GO
ALTER TABLE [dbo].[GroupPermissions]  WITH CHECK ADD  CONSTRAINT [FK_GP_PermissionId] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permissions] ([ID])
GO
ALTER TABLE [dbo].[GroupPermissions] CHECK CONSTRAINT [FK_GP_PermissionId]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Groups] ([Id])
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_GroupId]
GO
ALTER TABLE [dbo].[UserGroups]  WITH CHECK ADD  CONSTRAINT [FK_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserGroups] CHECK CONSTRAINT [FK_UserId]
GO
/****** Object:  StoredProcedure [dbo].[pGetUsers]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pGetUsers]
@IsActive BIT
AS
BEGIN
	SELECT * FROM dbo.Users
	WHERE IsActive = @IsActive
END
GO
USE [master]
GO
CREATE PROCEDURE [dbo].[pDeleteUser]
@Id INT
AS
BEGIN
	DELETE  dbo.Users
	WHERE Id = @id
END
GO
ALTER DATABASE [EFTestDb] SET  READ_WRITE 
GO
