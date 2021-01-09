USE [MMTShop]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 09/01/2021 15:11:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeaturedProductCodes]    Script Date: 09/01/2021 15:11:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeaturedProductCodes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SkuPrefix] [nvarchar](10) NULL,
 CONSTRAINT [PK_FeaturedProductCodes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 09/01/2021 15:11:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [decimal](18, 0) NULL,
	[StockKeepingUnit] [int] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCategories]    Script Date: 09/01/2021 15:11:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetAllCategories]
AS
BEGIN
Select id, name from categories
order by name desc
End
GO
/****** Object:  StoredProcedure [dbo].[GetFeaturedProducts]    Script Date: 09/01/2021 15:11:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[GetFeaturedProducts]
AS
BEGIN
Select Products.id,Products.name, Description, Price, StockKeepingUnit, CategoryId, Categories.Name as CategoryName from Products
inner join Categories on Products.CategoryId = Categories.Id
inner join FeaturedProductCodes on StockKeepingUnit Like FeaturedProductCodes.SkuPrefix + '%'
order by products.name desc
End
GO
/****** Object:  StoredProcedure [dbo].[GetProductsByCategoryId]    Script Date: 09/01/2021 15:11:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[GetProductsByCategoryId]
@categoryId int
AS
BEGIN
Select products.Id, products.Name, Description, Price, StockKeepingUnit, CategoryId, Categories.Name as CategoryName from products
inner join Categories on Products.CategoryId = Categories.Id where CategoryId = @categoryId
order by products.name desc
End
GO
