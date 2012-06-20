USE [Dev.YouFood.Web]
GO
/****** Object:  Table [dbo].[Corporates]    Script Date: 06/19/2012 14:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corporates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Corporates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CartLines]    Script Date: 06/19/2012 14:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CartLines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DishId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_CartLine] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 06/19/2012 14:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SpecialtyId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06/19/2012 14:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[TableId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tables]    Script Date: 06/19/2012 14:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ZoneId] [int] NOT NULL,
 CONSTRAINT [PK_Tables] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specialties]    Script Date: 06/19/2012 14:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](400) NULL,
	[IsActive] [bit] NULL,
	[Image] [text] NULL,
 CONSTRAINT [PK_Specialties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurants]    Script Date: 06/19/2012 14:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CorporateId] [int] NOT NULL,
 CONSTRAINT [PK_Restaurants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 06/19/2012 14:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [float] NOT NULL,
	[TableId] [int] NOT NULL,
	[State] [int] NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dishes]    Script Date: 06/19/2012 14:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dishes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](40) NULL,
	[Price] [float] NOT NULL,
	[SpecialtyId] [int] NOT NULL,
	[Image] [nvarchar](max) NULL,
	[TimeToCook] [float] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_Dishes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zones]    Script Date: 06/19/2012 14:53:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Zones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Dishes_Specialties]    Script Date: 06/19/2012 14:53:16 ******/
ALTER TABLE [dbo].[Dishes]  WITH CHECK ADD  CONSTRAINT [FK_Dishes_Specialties] FOREIGN KEY([SpecialtyId])
REFERENCES [dbo].[Specialties] ([Id])
GO
ALTER TABLE [dbo].[Dishes] CHECK CONSTRAINT [FK_Dishes_Specialties]
GO
/****** Object:  ForeignKey [FK_Orders_Tables]    Script Date: 06/19/2012 14:53:16 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Tables] FOREIGN KEY([TableId])
REFERENCES [dbo].[Tables] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Tables]
GO
/****** Object:  ForeignKey [FK_Restaurants_Corporates]    Script Date: 06/19/2012 14:53:16 ******/
ALTER TABLE [dbo].[Restaurants]  WITH CHECK ADD  CONSTRAINT [FK_Restaurants_Corporates] FOREIGN KEY([CorporateId])
REFERENCES [dbo].[Corporates] ([Id])
GO
ALTER TABLE [dbo].[Restaurants] CHECK CONSTRAINT [FK_Restaurants_Corporates]
GO
/****** Object:  ForeignKey [FK_Zones_Restaurants]    Script Date: 06/19/2012 14:53:16 ******/
ALTER TABLE [dbo].[Zones]  WITH CHECK ADD  CONSTRAINT [FK_Zones_Restaurants] FOREIGN KEY([RestaurantId])
REFERENCES [dbo].[Restaurants] ([Id])
GO
ALTER TABLE [dbo].[Zones] CHECK CONSTRAINT [FK_Zones_Restaurants]
GO
