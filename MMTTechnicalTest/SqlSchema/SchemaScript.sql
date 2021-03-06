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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
	[Price] [decimal](18, 2) NULL,
	[StockKeepingUnit] [int] NULL,
	[CategoryId] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
SELECT id, name FROM categories
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
SELECT Products.id,Products.name, Description, Price, StockKeepingUnit, CategoryId, Categories.Name AS CategoryName FROM Products
INNER JOIN Categories ON Products.CategoryId = Categories.Id
INNER JOIN FeaturedProductCodes ON StockKeepingUnit LIKE FeaturedProductCodes.SkuPrefix + '%'
ORDER BY products.name DESC
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
SELECT products.Id, products.Name, Description, Price, StockKeepingUnit, CategoryId, Categories.Name AS CategoryName FROM products
INNER JOIN Categories ON Products.CategoryId = Categories.Id WHERE CategoryId = @categoryId
ORDER BY products.Name DESC
End
GO
