USE [MMTShop]
INSERT [dbo].[Categories] ([Name]) VALUES ('Home')
INSERT [dbo].[Categories] ([Name]) VALUES ('Garden')
INSERT [dbo].[Categories] ([Name]) VALUES ('Electronics')
INSERT [dbo].[Categories] ([Name]) VALUES ('Fitness')
INSERT [dbo].[Categories] ([Name]) VALUES ('Toys')

INSERT [dbo].[Products] ([Name], [Description], [Price],[StockKeepingUnit],[CategoryId]) VALUES ('Sofa','Living room sofa',199.99,11245,1)
INSERT [dbo].[Products] ([Name], [Description], [Price],[StockKeepingUnit],[CategoryId]) VALUES ('DiningTable','Dining room table',599.99,13345,1)

INSERT [dbo].[Products] ([Name], [Description], [Price],[StockKeepingUnit],[CategoryId]) VALUES ('Gnome','Garden gnome',4.99,21289,2)
INSERT [dbo].[Products] ([Name], [Description], [Price],[StockKeepingUnit],[CategoryId]) VALUES ('SwingSet','Swing set',199.99,21249,2)

INSERT [dbo].[Products] ([Name], [Description], [Price],[StockKeepingUnit],[CategoryId]) VALUES ('PlasmaTv','Plasma TV for wall mounting',400.00,33345,3)
INSERT [dbo].[Products] ([Name], [Description], [Price],[StockKeepingUnit],[CategoryId]) VALUES ('NintendoSwitch','Handheld games console',199.99,31235,3)

INSERT [dbo].[Products] ([Name], [Description], [Price],[StockKeepingUnit],[CategoryId]) VALUES ('WeightBench','Adjustable bench for weight lifting',99.99,41455,4)
INSERT [dbo].[Products] ([Name], [Description], [Price],[StockKeepingUnit],[CategoryId]) VALUES ('FootballBootsFg','Firm ground football boots',79.99,41245,4)

INSERT [dbo].[Products] ([Name], [Description], [Price],[StockKeepingUnit],[CategoryId]) VALUES ('StarWarsLego','Lego death star model ',399.99,55545,5)
INSERT [dbo].[Products] ([Name], [Description], [Price],[StockKeepingUnit],[CategoryId]) VALUES ('BarbieHouse','Mansion for your Barbie to live in',25.00,51541,5)

INSERT [dbo].[FeaturedProductCodes] ([SkuPrefix]) VALUES (1)