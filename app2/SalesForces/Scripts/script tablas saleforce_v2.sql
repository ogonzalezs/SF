USE [SALESFORCES]
GO

ALTER TABLE [dbo].[t_Seller] DROP CONSTRAINT [FK_Vendedor_Empresa]
GO

ALTER TABLE [dbo].[t_ItemPrice] DROP CONSTRAINT [FK_ProductoPrecio_Producto]
GO

ALTER TABLE [dbo].[t_Item] DROP CONSTRAINT [FK_Producto_Empresa]
GO

ALTER TABLE [dbo].[t_OrdersDetail] DROP CONSTRAINT [FK_OrdenDetalle_Orden]
GO

ALTER TABLE [dbo].[t_Orders] DROP CONSTRAINT [FK_Orden_Empresa]
GO

ALTER TABLE [dbo].[t_Company] DROP CONSTRAINT [FK_Empresa_Connection]
GO

ALTER TABLE [dbo].[t_CustomerAddress] DROP CONSTRAINT [FK_ClienteDireccion_Cliente]
GO

ALTER TABLE [dbo].[t_Customer] DROP CONSTRAINT [FK_Cliente_Empresa]
GO

ALTER TABLE [dbo].[t_Item] DROP CONSTRAINT [DF_t_Item_sysCreateDate]
GO

ALTER TABLE [dbo].[t_OrdersDetail] DROP CONSTRAINT [DF_OrdenDetalle_VatSum]
GO

ALTER TABLE [dbo].[t_OrdersDetail] DROP CONSTRAINT [DF_OrdenDetalle_LineTotal]
GO

ALTER TABLE [dbo].[t_OrdersDetail] DROP CONSTRAINT [DF_OrdenDetalle_DiscPrcnt]
GO

ALTER TABLE [dbo].[t_OrdersDetail] DROP CONSTRAINT [DF_OrdenDetalle_Price]
GO

ALTER TABLE [dbo].[t_OrdersDetail] DROP CONSTRAINT [DF_OrdenDetalle_ShipDate]
GO

ALTER TABLE [dbo].[t_OrdersDetail] DROP CONSTRAINT [DF_OrdenDetalle_Quantity]
GO

ALTER TABLE [dbo].[t_Orders] DROP CONSTRAINT [DF_Orders_DocTotal]
GO

ALTER TABLE [dbo].[t_Orders] DROP CONSTRAINT [DF_Orders_DiscSum]
GO

ALTER TABLE [dbo].[t_Orders] DROP CONSTRAINT [DF_Orders_VatSum]
GO

ALTER TABLE [dbo].[t_Orders] DROP CONSTRAINT [DF_Orders_DocDate]
GO

ALTER TABLE [dbo].[t_CustomerAddress] DROP CONSTRAINT [DF_ClienteDireccion_CreateDate]
GO

ALTER TABLE [dbo].[t_Customer] DROP CONSTRAINT [DF_Cliente_CreateDate]
GO

/****** Object:  Table [dbo].[t_Seller]    Script Date: 10-06-2019 20:29:23 ******/
DROP TABLE [dbo].[t_Seller]
GO

/****** Object:  Table [dbo].[t_ItemPrice]    Script Date: 10-06-2019 20:29:23 ******/
DROP TABLE [dbo].[t_ItemPrice]
GO

/****** Object:  Table [dbo].[t_Item]    Script Date: 10-06-2019 20:29:23 ******/
DROP TABLE [dbo].[t_Item]
GO

/****** Object:  Table [dbo].[t_OrdersDetail]    Script Date: 10-06-2019 20:29:23 ******/
DROP TABLE [dbo].[t_OrdersDetail]
GO

/****** Object:  Table [dbo].[t_Orders]    Script Date: 10-06-2019 20:29:23 ******/
DROP TABLE [dbo].[t_Orders]
GO

/****** Object:  Table [dbo].[t_Company]    Script Date: 10-06-2019 20:29:23 ******/
DROP TABLE [dbo].[t_Company]
GO

/****** Object:  Table [dbo].[t_Connection]    Script Date: 10-06-2019 20:29:23 ******/
DROP TABLE [dbo].[t_Connection]
GO

/****** Object:  Table [dbo].[t_CustomerAddress]    Script Date: 10-06-2019 20:29:23 ******/
DROP TABLE [dbo].[t_CustomerAddress]
GO

/****** Object:  Table [dbo].[t_Customer]    Script Date: 10-06-2019 20:29:23 ******/
DROP TABLE [dbo].[t_Customer]
GO

/****** Object:  Table [dbo].[t_Customer]    Script Date: 10-06-2019 20:29:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[t_Customer](
	[CardCode] [nvarchar](50) NOT NULL,
	[IdCompany] [bigint] NOT NULL,
	[CardCodeSAP] [nvarchar](50) NOT NULL,
	[CardName] [nvarchar](100) NULL,
	[CardType] [nchar](1) NULL,
	[Address] [nvarchar](100) NULL,
	[ZipCode] [nvarchar](20) NULL,
	[Phone1] [nvarchar](20) NULL,
	[Phone2] [nvarchar](20) NULL,
	[CntctPrsn] [nvarchar](90) NULL,
	[Balance] [decimal](19, 6) NULL,
	[CreditLine] [decimal](19, 6) NULL,
	[Identificacion] [nvarchar](32) NULL,
	[ListNum] [nvarchar](32) NULL,
	[Cellular] [nvarchar](20) NULL,
	[City] [nvarchar](100) NULL,
	[County] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
	[E_Mail] [nvarchar](100) NULL,
	[sysCreateDate] [smalldatetime] NOT NULL,
	[sysUpdateDate] [smalldatetime] NULL,
	[validFor] [nchar](1) NULL,
	[FechaUp] [smalldatetime] NOT NULL,
	[sysIsDeleted] [bit] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[CardCode] ASC,
	[IdCompany] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[t_CustomerAddress]    Script Date: 10-06-2019 20:29:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[t_CustomerAddress](
	[CustomerAddress] [bigint] NOT NULL,
	[IdCompany] [bigint] NOT NULL,
	[CardCode] [nvarchar](50) NOT NULL,
	[Tipo] [nchar](2) NULL,
	[Address] [nvarchar](100) NULL,
	[ZipCode] [nvarchar](20) NULL,
	[Phone1] [nvarchar](20) NULL,
	[City] [nvarchar](100) NULL,
	[County] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
	[E_Mail] [nvarchar](100) NULL,
	[CreateDate] [smalldatetime] NULL,
	[UpdateDate] [smalldatetime] NULL,
	[validFor] [nchar](1) NULL,
 CONSTRAINT [PK_ClienteDireccion_1] PRIMARY KEY CLUSTERED 
(
	[CustomerAddress] ASC,
	[IdCompany] ASC,
	[CardCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[t_Connection]    Script Date: 10-06-2019 20:29:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[t_Connection](
	[IdConnection] [tinyint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](250) NOT NULL CONSTRAINT [DF_Connection_Descripcion]  DEFAULT (N'Estandar'),
	[ConnectionString] [nvarchar](max) NOT NULL CONSTRAINT [DF_Connection_ConnectionString]  DEFAULT (N'Data Source=.;Initial Catalog=Master;Integrated Security=True'),
	[Proveedor] [nvarchar](max) NOT NULL CONSTRAINT [DF_Connection_Proveedor]  DEFAULT (N'System.Data.SqlClient'),
	[FileName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Connection] PRIMARY KEY CLUSTERED 
(
	[IdConnection] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[t_Company]    Script Date: 10-06-2019 20:29:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[t_Company](
	[IdCompany] [bigint] IDENTITY(1,1) NOT NULL,
	[Company] [nvarchar](500) NOT NULL,
	[IdConnection] [tinyint] NOT NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[IdCompany] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[t_Orders]    Script Date: 10-06-2019 20:29:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[t_Orders](
	[DocEntry] [bigint] IDENTITY(1,1) NOT NULL,
	[IdCompany] [bigint] NOT NULL,
	[DocNum] [int] NOT NULL,
	[DocDate] [smalldatetime] NOT NULL,
	[CardCode] [bigint] NOT NULL,
	[NumAtCard] [nvarchar](50) NULL,
	[VatSum] [numeric](19, 6) NOT NULL,
	[DiscSum] [numeric](19, 6) NOT NULL,
	[DocTotal] [numeric](19, 6) NOT NULL,
	[Ref1] [nvarchar](50) NULL,
	[Ref2] [nvarchar](50) NULL,
	[Comments] [nvarchar](max) NULL,
	[SlpCode] [int] NULL,
	[CntctCode] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[DocEntry] ASC,
	[IdCompany] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[t_OrdersDetail]    Script Date: 10-06-2019 20:29:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[t_OrdersDetail](
	[DocEntry] [bigint] IDENTITY(1,1) NOT NULL,
	[LineNum] [int] NOT NULL,
	[IdCompany] [bigint] NOT NULL,
	[ItemCode] [nvarchar](50) NULL,
	[Dscription] [nvarchar](500) NULL,
	[Quantity] [numeric](19, 6) NOT NULL,
	[ShipDate] [smalldatetime] NOT NULL,
	[Price] [numeric](19, 6) NOT NULL,
	[DiscPrcnt] [numeric](19, 6) NOT NULL,
	[LineTotal] [numeric](19, 6) NOT NULL,
	[WhsCode] [nchar](10) NULL,
	[VatSum] [numeric](19, 6) NOT NULL,
	[TaxCode] [nchar](10) NULL,
 CONSTRAINT [PK_OrdenDetalle] PRIMARY KEY CLUSTERED 
(
	[DocEntry] ASC,
	[LineNum] ASC,
	[IdCompany] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[t_Item]    Script Date: 10-06-2019 20:29:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[t_Item](
	[ItemCode] [nvarchar](50) NOT NULL,
	[IdCompany] [bigint] NOT NULL,
	[ItemName] [nvarchar](500) NULL,
	[OnHand] [numeric](19, 6) NULL,
	[IsCommited] [numeric](19, 6) NULL,
	[OnOrder] [numeric](19, 6) NULL,
	[CardCode] [nvarchar](50) NULL,
	[SuppCatNum] [nvarchar](50) NULL,
	[BuyUnitMsr] [nvarchar](50) NULL,
	[NumInBuy] [numeric](19, 6) NULL,
	[SalUnitMsr] [nvarchar](50) NULL,
	[NumInSale] [numeric](19, 6) NULL,
	[SHeight1] [numeric](19, 6) NULL,
	[SHght1Unit] [int] NULL,
	[SHeight2] [numeric](19, 6) NULL,
	[SHght2Unit] [int] NULL,
	[SWidth1] [numeric](19, 6) NULL,
	[SWdth1Unit] [int] NULL,
	[SWidth2] [numeric](19, 6) NULL,
	[SWdth2Unit] [int] NULL,
	[SLength1] [numeric](19, 6) NULL,
	[SLen1Unit] [int] NULL,
	[Slength2] [numeric](19, 6) NULL,
	[SLen2Unit] [int] NULL,
	[SVolume] [numeric](19, 6) NULL,
	[SVolUnit] [int] NULL,
	[SWeight1] [numeric](19, 6) NULL,
	[SWght1Unit] [int] NULL,
	[SWeight2] [numeric](19, 6) NULL,
	[SWght2Unit] [int] NULL,
	[BHeight1] [numeric](19, 6) NULL,
	[BHght1Unit] [int] NULL,
	[BHeight2] [numeric](19, 6) NULL,
	[BHght2Unit] [int] NULL,
	[BWidth1] [numeric](19, 6) NULL,
	[BWdth1Unit] [int] NULL,
	[BWidth2] [numeric](19, 6) NULL,
	[BWdth2Unit] [int] NULL,
	[BLength1] [numeric](19, 6) NULL,
	[BLen1Unit] [int] NULL,
	[Blength2] [numeric](19, 6) NULL,
	[BLen2Unit] [int] NULL,
	[BVolume] [numeric](19, 6) NULL,
	[BVolUnit] [int] NULL,
	[BWeight1] [numeric](19, 6) NULL,
	[BWght1Unit] [int] NULL,
	[BWeight2] [numeric](19, 6) NULL,
	[BWght2Unit] [int] NULL,
	[FirmCode] [int] NULL,
	[FechaDown] [smalldatetime] NOT NULL,
	[FechaUp] [smalldatetime] NOT NULL,
	[sysCreateDate] [smalldatetime] NOT NULL,
	[sysUpdateDate] [smalldatetime] NULL,
	[sysIsDeleted] [bit] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[ItemCode] ASC,
	[IdCompany] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[t_ItemPrice]    Script Date: 10-06-2019 20:29:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[t_ItemPrice](
	[ItemCode] [nvarchar](50) NOT NULL,
	[IdCompany] [bigint] NOT NULL,
	[PriceList] [int] NOT NULL,
	[Price] [numeric](19, 6) NULL,
	[FechaUp] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_ProductoPrecio_1] PRIMARY KEY CLUSTERED 
(
	[ItemCode] ASC,
	[IdCompany] ASC,
	[PriceList] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[t_Seller]    Script Date: 10-06-2019 20:29:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[t_Seller](
	[SlpCode] [int] NOT NULL,
	[IdCompany] [bigint] NOT NULL,
	[SlpName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[FechaUp] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Vendedor] PRIMARY KEY CLUSTERED 
(
	[SlpCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[t_Customer] ADD  CONSTRAINT [DF_Cliente_CreateDate]  DEFAULT (getdate()) FOR [sysCreateDate]
GO

ALTER TABLE [dbo].[t_CustomerAddress] ADD  CONSTRAINT [DF_ClienteDireccion_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[t_Orders] ADD  CONSTRAINT [DF_Orders_DocDate]  DEFAULT (getdate()) FOR [DocDate]
GO

ALTER TABLE [dbo].[t_Orders] ADD  CONSTRAINT [DF_Orders_VatSum]  DEFAULT ((0)) FOR [VatSum]
GO

ALTER TABLE [dbo].[t_Orders] ADD  CONSTRAINT [DF_Orders_DiscSum]  DEFAULT ((0)) FOR [DiscSum]
GO

ALTER TABLE [dbo].[t_Orders] ADD  CONSTRAINT [DF_Orders_DocTotal]  DEFAULT ((0)) FOR [DocTotal]
GO

ALTER TABLE [dbo].[t_OrdersDetail] ADD  CONSTRAINT [DF_OrdenDetalle_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO

ALTER TABLE [dbo].[t_OrdersDetail] ADD  CONSTRAINT [DF_OrdenDetalle_ShipDate]  DEFAULT (getdate()) FOR [ShipDate]
GO

ALTER TABLE [dbo].[t_OrdersDetail] ADD  CONSTRAINT [DF_OrdenDetalle_Price]  DEFAULT ((0)) FOR [Price]
GO

ALTER TABLE [dbo].[t_OrdersDetail] ADD  CONSTRAINT [DF_OrdenDetalle_DiscPrcnt]  DEFAULT ((0)) FOR [DiscPrcnt]
GO

ALTER TABLE [dbo].[t_OrdersDetail] ADD  CONSTRAINT [DF_OrdenDetalle_LineTotal]  DEFAULT ((0)) FOR [LineTotal]
GO

ALTER TABLE [dbo].[t_OrdersDetail] ADD  CONSTRAINT [DF_OrdenDetalle_VatSum]  DEFAULT ((0)) FOR [VatSum]
GO

ALTER TABLE [dbo].[t_Item] ADD  CONSTRAINT [DF_t_Item_sysCreateDate]  DEFAULT (getdate()) FOR [sysCreateDate]
GO

ALTER TABLE [dbo].[t_Customer]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Empresa] FOREIGN KEY([IdCompany])
REFERENCES [dbo].[t_Company] ([IdCompany])
GO

ALTER TABLE [dbo].[t_Customer] CHECK CONSTRAINT [FK_Cliente_Empresa]
GO

ALTER TABLE [dbo].[t_CustomerAddress]  WITH CHECK ADD  CONSTRAINT [FK_ClienteDireccion_Cliente] FOREIGN KEY([CardCode], [IdCompany])
REFERENCES [dbo].[t_Customer] ([CardCode], [IdCompany])
GO

ALTER TABLE [dbo].[t_CustomerAddress] CHECK CONSTRAINT [FK_ClienteDireccion_Cliente]
GO

ALTER TABLE [dbo].[t_Company]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Connection] FOREIGN KEY([IdConnection])
REFERENCES [dbo].[t_Connection] ([IdConnection])
GO

ALTER TABLE [dbo].[t_Company] CHECK CONSTRAINT [FK_Empresa_Connection]
GO

ALTER TABLE [dbo].[t_Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Empresa] FOREIGN KEY([IdCompany])
REFERENCES [dbo].[t_Company] ([IdCompany])
GO

ALTER TABLE [dbo].[t_Orders] CHECK CONSTRAINT [FK_Orden_Empresa]
GO

ALTER TABLE [dbo].[t_OrdersDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrdenDetalle_Orden] FOREIGN KEY([DocEntry], [IdCompany])
REFERENCES [dbo].[t_Orders] ([DocEntry], [IdCompany])
GO

ALTER TABLE [dbo].[t_OrdersDetail] CHECK CONSTRAINT [FK_OrdenDetalle_Orden]
GO

ALTER TABLE [dbo].[t_Item]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Empresa] FOREIGN KEY([IdCompany])
REFERENCES [dbo].[t_Company] ([IdCompany])
GO

ALTER TABLE [dbo].[t_Item] CHECK CONSTRAINT [FK_Producto_Empresa]
GO

ALTER TABLE [dbo].[t_ItemPrice]  WITH CHECK ADD  CONSTRAINT [FK_ProductoPrecio_Producto] FOREIGN KEY([ItemCode], [IdCompany])
REFERENCES [dbo].[t_Item] ([ItemCode], [IdCompany])
GO

ALTER TABLE [dbo].[t_ItemPrice] CHECK CONSTRAINT [FK_ProductoPrecio_Producto]
GO

ALTER TABLE [dbo].[t_Seller]  WITH CHECK ADD  CONSTRAINT [FK_Vendedor_Empresa] FOREIGN KEY([IdCompany])
REFERENCES [dbo].[t_Company] ([IdCompany])
GO

ALTER TABLE [dbo].[t_Seller] CHECK CONSTRAINT [FK_Vendedor_Empresa]
GO


