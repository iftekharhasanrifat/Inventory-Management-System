USE [master]
GO
/****** Object:  Database [InventoryManagementSystemDB]    Script Date: 28/02/2022 00:05:23 ******/
CREATE DATABASE [InventoryManagementSystemDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventoryManagementSystemDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\InventoryManagementSystemDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'InventoryManagementSystemDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\InventoryManagementSystemDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [InventoryManagementSystemDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventoryManagementSystemDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InventoryManagementSystemDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET  MULTI_USER 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InventoryManagementSystemDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InventoryManagementSystemDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [InventoryManagementSystemDB]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 28/02/2022 00:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 28/02/2022 00:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Items]    Script Date: 28/02/2022 00:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Items](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[CategoryId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ReorderLevel] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StockOut]    Script Date: 28/02/2022 00:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockOut](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemId] [int] NULL,
	[Date] [date] NULL,
	[Quantity] [int] NULL,
	[Type] [nchar](10) NULL,
 CONSTRAINT [PK_StockOut] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 28/02/2022 00:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[GetSalesView]    Script Date: 28/02/2022 00:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GetSalesView]
AS
SELECT s.ItemId, i.Name AS Item,c.Name AS Company,s.Date,s.Quantity AS SaleQuantity FROM 
StockOut AS s 
INNER JOIN Items AS i ON s.ItemId=i.Id 
INNER JOIN Companies AS c ON i.CompanyId=c.Id
WHERE s.Type ='Sold'
GO
/****** Object:  View [dbo].[GetSearchView]    Script Date: 28/02/2022 00:05:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GetSearchView]
AS
SELECT i.Name AS Item,c.Name AS Company,i.Quantity AS AvailableQuantity,i.ReorderLevel,i.CategoryId,i.CompanyId
FROM Items AS i 
INNER JOIN Companies AS c ON i.CompanyId=c.Id 
INNER JOIN Categories AS cg ON i.CategoryId=cg.Id
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (4, N'Beverage')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (8, N'Beverageas')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (6, N'Chips')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (7, N'Drink')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Electrical')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Grocery')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Hasan')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (5, N'Snacks')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([Id], [Name]) VALUES (3, N'Shezan')
INSERT [dbo].[Companies] ([Id], [Name]) VALUES (1, N'Pran')
INSERT [dbo].[Companies] ([Id], [Name]) VALUES (2, N'Milk Vita')
SET IDENTITY_INSERT [dbo].[Companies] OFF
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([Id], [Name], [CategoryId], [CompanyId], [ReorderLevel], [Quantity]) VALUES (1, N'Pran Potato Chips', 6, 1, 2, 17)
INSERT [dbo].[Items] ([Id], [Name], [CategoryId], [CompanyId], [ReorderLevel], [Quantity]) VALUES (2, N'Shezan Mango Juice', 7, 3, 0, 3)
INSERT [dbo].[Items] ([Id], [Name], [CategoryId], [CompanyId], [ReorderLevel], [Quantity]) VALUES (3, N'Tom Tom', 5, 1, 3, 0)
INSERT [dbo].[Items] ([Id], [Name], [CategoryId], [CompanyId], [ReorderLevel], [Quantity]) VALUES (4, N'Hot Potato Crackers', 6, 1, 0, 0)
INSERT [dbo].[Items] ([Id], [Name], [CategoryId], [CompanyId], [ReorderLevel], [Quantity]) VALUES (5, N'Tom Tom', 4, 3, 0, 0)
INSERT [dbo].[Items] ([Id], [Name], [CategoryId], [CompanyId], [ReorderLevel], [Quantity]) VALUES (6, N'123A', 6, 1, 0, 0)
SET IDENTITY_INSERT [dbo].[Items] OFF
SET IDENTITY_INSERT [dbo].[StockOut] ON 

INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Quantity], [Type]) VALUES (3, 2, CAST(0xA1430B00 AS Date), 7, N'Sold      ')
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Quantity], [Type]) VALUES (4, 1, CAST(0xA0430B00 AS Date), 14, N'Sold      ')
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Quantity], [Type]) VALUES (5, 2, CAST(0xA1430B00 AS Date), 4, N'Damaged   ')
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Quantity], [Type]) VALUES (6, 1, CAST(0xA1430B00 AS Date), 19, N'Damaged   ')
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Quantity], [Type]) VALUES (7, 2, CAST(0xA1430B00 AS Date), 1, N'Lost      ')
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Quantity], [Type]) VALUES (8, 1, CAST(0xA1430B00 AS Date), 6, N'Sold      ')
INSERT [dbo].[StockOut] ([Id], [ItemId], [Date], [Quantity], [Type]) VALUES (9, 2, CAST(0xA2430B00 AS Date), 19, N'Sold      ')
SET IDENTITY_INSERT [dbo].[StockOut] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [Password]) VALUES (1, N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Category]    Script Date: 28/02/2022 00:05:24 ******/
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [IX_Category] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Companies]    Script Date: 28/02/2022 00:05:24 ******/
ALTER TABLE [dbo].[Companies] ADD  CONSTRAINT [IX_Companies] UNIQUE NONCLUSTERED 
(
	[Name] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Users]    Script Date: 28/02/2022 00:05:24 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Categories]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Companies] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Companies]
GO
ALTER TABLE [dbo].[StockOut]  WITH CHECK ADD  CONSTRAINT [FK_StockOut_Items] FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([Id])
GO
ALTER TABLE [dbo].[StockOut] CHECK CONSTRAINT [FK_StockOut_Items]
GO
USE [master]
GO
ALTER DATABASE [InventoryManagementSystemDB] SET  READ_WRITE 
GO
