USE [CoffeShop]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9/29/2019 12:18:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](100) NULL,
	[Contact] [varchar](12) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 9/29/2019 12:18:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 9/29/2019 12:18:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([ID], [Name], [Address], [Contact]) VALUES (1, N'Ariful Islam', N'Uttara', N'1773611681')
INSERT [dbo].[Customers] ([ID], [Name], [Address], [Contact]) VALUES (2, N'Arif', N'Uttara', N'1957884309')
INSERT [dbo].[Customers] ([ID], [Name], [Address], [Contact]) VALUES (3, N'Rakib', N'Uttara', N'1957884309')
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Items] ON 

INSERT [dbo].[Items] ([ID], [Name], [Price]) VALUES (1, N'Cold', 120)
INSERT [dbo].[Items] ([ID], [Name], [Price]) VALUES (2, N'Hot', 100)
INSERT [dbo].[Items] ([ID], [Name], [Price]) VALUES (3, N'Black', 90)
INSERT [dbo].[Items] ([ID], [Name], [Price]) VALUES (4, N'Regular', 80)
SET IDENTITY_INSERT [dbo].[Items] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID], [Name], [Qty]) VALUES (1, N'Hot', 4)
INSERT [dbo].[Orders] ([ID], [Name], [Qty]) VALUES (2, N'Cold', 2)
INSERT [dbo].[Orders] ([ID], [Name], [Qty]) VALUES (3, N'Regular', 6)
SET IDENTITY_INSERT [dbo].[Orders] OFF
