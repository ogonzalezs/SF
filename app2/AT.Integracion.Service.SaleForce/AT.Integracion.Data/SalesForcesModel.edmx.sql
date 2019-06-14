
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/13/2019 21:52:30
-- Generated from EDMX file: I:\Fuerza de Venta\trunk\AT.Integracion.Service.SaleForce\AT.Integracion.Data\SalesForcesModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SALESFORCES];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Cliente_Empresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_Customer] DROP CONSTRAINT [FK_Cliente_Empresa];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteDireccion_Cliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_CustomerAddress] DROP CONSTRAINT [FK_ClienteDireccion_Cliente];
GO
IF OBJECT_ID(N'[dbo].[FK_Empresa_Connection]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_Company] DROP CONSTRAINT [FK_Empresa_Connection];
GO
IF OBJECT_ID(N'[dbo].[FK_Orden_Empresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_Orders] DROP CONSTRAINT [FK_Orden_Empresa];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenDetalle_Orden]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_OrdersDetail] DROP CONSTRAINT [FK_OrdenDetalle_Orden];
GO
IF OBJECT_ID(N'[dbo].[FK_Producto_Empresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_Item] DROP CONSTRAINT [FK_Producto_Empresa];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductoPrecio_Producto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_ItemPrice] DROP CONSTRAINT [FK_ProductoPrecio_Producto];
GO
IF OBJECT_ID(N'[dbo].[FK_t_PurchaseRequest_t_PurchaseRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_PurchaseRequestDetail] DROP CONSTRAINT [FK_t_PurchaseRequest_t_PurchaseRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_Vendedor_Empresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[t_Seller] DROP CONSTRAINT [FK_Vendedor_Empresa];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[t_Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_Company];
GO
IF OBJECT_ID(N'[dbo].[t_Connection]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_Connection];
GO
IF OBJECT_ID(N'[dbo].[t_Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_Customer];
GO
IF OBJECT_ID(N'[dbo].[t_CustomerAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_CustomerAddress];
GO
IF OBJECT_ID(N'[dbo].[t_Item]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_Item];
GO
IF OBJECT_ID(N'[dbo].[t_ItemPrice]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_ItemPrice];
GO
IF OBJECT_ID(N'[dbo].[t_Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_Orders];
GO
IF OBJECT_ID(N'[dbo].[t_OrdersDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_OrdersDetail];
GO
IF OBJECT_ID(N'[dbo].[t_PurchaseRequest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_PurchaseRequest];
GO
IF OBJECT_ID(N'[dbo].[t_PurchaseRequestDetail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_PurchaseRequestDetail];
GO
IF OBJECT_ID(N'[dbo].[t_Seller]', 'U') IS NOT NULL
    DROP TABLE [dbo].[t_Seller];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 't_Company'
CREATE TABLE [dbo].[t_Company] (
    [IdCompany] bigint IDENTITY(1,1) NOT NULL,
    [Company] nvarchar(500)  NOT NULL,
    [IdConnection] tinyint  NOT NULL
);
GO

-- Creating table 't_Connection'
CREATE TABLE [dbo].[t_Connection] (
    [IdConnection] tinyint IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(250)  NOT NULL,
    [ConnectionString] nvarchar(max)  NOT NULL,
    [Proveedor] nvarchar(max)  NOT NULL,
    [FileName] nvarchar(max)  NULL
);
GO

-- Creating table 't_Customer'
CREATE TABLE [dbo].[t_Customer] (
    [CardCode] nvarchar(50)  NOT NULL,
    [IdCompany] bigint  NOT NULL,
    [CardCodeSAP] nvarchar(50)  NOT NULL,
    [CardName] nvarchar(100)  NULL,
    [CardType] nchar(1)  NULL,
    [Address] nvarchar(100)  NULL,
    [ZipCode] nvarchar(20)  NULL,
    [Phone1] nvarchar(20)  NULL,
    [Phone2] nvarchar(20)  NULL,
    [CntctPrsn] nvarchar(90)  NULL,
    [Balance] decimal(19,6)  NULL,
    [CreditLine] decimal(19,6)  NULL,
    [Identificacion] nvarchar(32)  NULL,
    [ListNum] nvarchar(32)  NULL,
    [Cellular] nvarchar(20)  NULL,
    [City] nvarchar(100)  NULL,
    [County] nvarchar(100)  NULL,
    [State] nvarchar(100)  NULL,
    [Country] nvarchar(100)  NULL,
    [E_Mail] nvarchar(100)  NULL,
    [sysCreateDate] datetime  NOT NULL,
    [sysUpdateDate] datetime  NULL,
    [validFor] nchar(1)  NULL,
    [DateUp] datetime  NULL,
    [DateDown] datetime  NULL,
    [sysIsDeleted] bit  NULL
);
GO

-- Creating table 't_CustomerAddress'
CREATE TABLE [dbo].[t_CustomerAddress] (
    [CustomerAddress] bigint  NOT NULL,
    [IdCompany] bigint  NOT NULL,
    [CardCode] nvarchar(50)  NOT NULL,
    [Tipo] nchar(2)  NULL,
    [Address] nvarchar(100)  NULL,
    [ZipCode] nvarchar(20)  NULL,
    [Phone1] nvarchar(20)  NULL,
    [City] nvarchar(100)  NULL,
    [County] nvarchar(100)  NULL,
    [State] nvarchar(100)  NULL,
    [Country] nvarchar(100)  NULL,
    [E_Mail] nvarchar(100)  NOT NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL,
    [validFor] nchar(1)  NULL
);
GO

-- Creating table 't_Item'
CREATE TABLE [dbo].[t_Item] (
    [ItemCode] nvarchar(50)  NOT NULL,
    [IdCompany] bigint  NOT NULL,
    [ItemName] nvarchar(500)  NULL,
    [OnHand] decimal(19,6)  NULL,
    [IsCommited] decimal(19,6)  NULL,
    [OnOrder] decimal(19,6)  NULL,
    [CardCode] nvarchar(50)  NULL,
    [SuppCatNum] nvarchar(50)  NULL,
    [BuyUnitMsr] nvarchar(50)  NULL,
    [NumInBuy] decimal(19,6)  NULL,
    [SalUnitMsr] nvarchar(50)  NULL,
    [NumInSale] decimal(19,6)  NULL,
    [SHeight1] decimal(19,6)  NULL,
    [SHght1Unit] int  NULL,
    [SHeight2] decimal(19,6)  NULL,
    [SHght2Unit] int  NULL,
    [SWidth1] decimal(19,6)  NULL,
    [SWdth1Unit] int  NULL,
    [SWidth2] decimal(19,6)  NULL,
    [SWdth2Unit] int  NULL,
    [SLength1] decimal(19,6)  NULL,
    [SLen1Unit] int  NULL,
    [Slength2] decimal(19,6)  NULL,
    [SLen2Unit] int  NULL,
    [SVolume] decimal(19,6)  NULL,
    [SVolUnit] int  NULL,
    [SWeight1] decimal(19,6)  NULL,
    [SWght1Unit] int  NULL,
    [SWeight2] decimal(19,6)  NULL,
    [SWght2Unit] int  NULL,
    [BHeight1] decimal(19,6)  NULL,
    [BHght1Unit] int  NULL,
    [BHeight2] decimal(19,6)  NULL,
    [BHght2Unit] int  NULL,
    [BWidth1] decimal(19,6)  NULL,
    [BWdth1Unit] int  NULL,
    [BWidth2] decimal(19,6)  NULL,
    [BWdth2Unit] int  NULL,
    [BLength1] decimal(19,6)  NULL,
    [BLen1Unit] int  NULL,
    [Blength2] decimal(19,6)  NULL,
    [BLen2Unit] int  NULL,
    [BVolume] decimal(19,6)  NULL,
    [BVolUnit] int  NULL,
    [BWeight1] decimal(19,6)  NULL,
    [BWght1Unit] int  NULL,
    [BWeight2] decimal(19,6)  NULL,
    [BWght2Unit] int  NULL,
    [FirmCode] int  NULL,
    [DateDown] datetime  NULL,
    [DateUp] datetime  NULL,
    [sysCreateDate] datetime  NOT NULL,
    [sysUpdateDate] datetime  NULL,
    [sysIsDeleted] bit  NULL
);
GO

-- Creating table 't_ItemPrice'
CREATE TABLE [dbo].[t_ItemPrice] (
    [ItemCode] nvarchar(50)  NOT NULL,
    [IdCompany] bigint  NOT NULL,
    [PriceList] int  NOT NULL,
    [Price] decimal(19,6)  NULL,
    [DateUp] datetime  NULL,
    [DateDown] datetime  NULL
);
GO

-- Creating table 't_Orders'
CREATE TABLE [dbo].[t_Orders] (
    [DocEntry] bigint IDENTITY(1,1) NOT NULL,
    [IdCompany] bigint  NOT NULL,
    [DocNum] int  NOT NULL,
    [DocDate] datetime  NOT NULL,
    [CardCode] nvarchar(50)  NOT NULL,
    [NumAtCard] nvarchar(50)  NULL,
    [VatSum] decimal(19,6)  NOT NULL,
    [DiscSum] decimal(19,6)  NOT NULL,
    [DocTotal] decimal(19,6)  NOT NULL,
    [Ref1] nvarchar(50)  NULL,
    [Ref2] nvarchar(50)  NULL,
    [Comments] nvarchar(max)  NULL,
    [SlpCode] int  NULL,
    [CntctCode] int  NULL,
    [DateUp] datetime  NULL,
    [DateDown] datetime  NULL
);
GO

-- Creating table 't_OrdersDetail'
CREATE TABLE [dbo].[t_OrdersDetail] (
    [DocEntry] bigint IDENTITY(1,1) NOT NULL,
    [LineNum] int  NOT NULL,
    [IdCompany] bigint  NOT NULL,
    [ItemCode] nvarchar(50)  NULL,
    [Dscription] nvarchar(500)  NULL,
    [Quantity] decimal(19,6)  NOT NULL,
    [ShipDate] datetime  NOT NULL,
    [Price] decimal(19,6)  NOT NULL,
    [DiscPrcnt] decimal(19,6)  NOT NULL,
    [LineTotal] decimal(19,6)  NOT NULL,
    [WhsCode] nchar(10)  NULL,
    [VatSum] decimal(19,6)  NOT NULL,
    [TaxCode] nchar(10)  NULL
);
GO

-- Creating table 't_PurchaseRequest'
CREATE TABLE [dbo].[t_PurchaseRequest] (
    [DocEntry] bigint IDENTITY(1,1) NOT NULL,
    [DocNum] int  NOT NULL,
    [Branch] int  NULL,
    [DocDate] datetime  NOT NULL,
    [DocDueDate] datetime  NULL,
    [CardCode] nvarchar(50)  NOT NULL,
    [CardName] nvarchar(150)  NULL,
    [NumAtCard] nvarchar(50)  NULL,
    [VatSum] decimal(18,6)  NOT NULL,
    [DocTotal] decimal(18,6)  NOT NULL,
    [DiscSum] decimal(18,6)  NOT NULL,
    [Comments] nvarchar(max)  NULL,
    [SlpCode] int  NULL,
    [Requester] nvarchar(50)  NULL,
    [ReqName] nvarchar(150)  NULL,
    [DocStatus] nchar(10)  NOT NULL
);
GO

-- Creating table 't_PurchaseRequestDetail'
CREATE TABLE [dbo].[t_PurchaseRequestDetail] (
    [DocEntry] bigint IDENTITY(1,1) NOT NULL,
    [LineNum] int  NOT NULL,
    [ItemCode] nvarchar(50)  NOT NULL,
    [Dscription] nvarchar(50)  NULL,
    [Quantity] decimal(18,6)  NOT NULL,
    [ShipDate] datetime  NULL,
    [ReqDate] nchar(10)  NULL,
    [Price] decimal(18,6)  NOT NULL,
    [PriceAfVAT] decimal(18,6)  NOT NULL,
    [PriceBefDi] decimal(18,6)  NOT NULL,
    [WhsCode] nchar(10)  NULL,
    [OpenQty] decimal(18,6)  NULL,
    [VatSum] decimal(18,6)  NOT NULL,
    [DiscPrcnt] decimal(18,6)  NOT NULL,
    [LineTotal] decimal(18,6)  NOT NULL
);
GO

-- Creating table 't_Seller'
CREATE TABLE [dbo].[t_Seller] (
    [SlpCode] int  NOT NULL,
    [IdCompany] bigint  NOT NULL,
    [SlpName] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [DateUp] datetime  NULL,
    [DateDown] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCompany] in table 't_Company'
ALTER TABLE [dbo].[t_Company]
ADD CONSTRAINT [PK_t_Company]
    PRIMARY KEY CLUSTERED ([IdCompany] ASC);
GO

-- Creating primary key on [IdConnection] in table 't_Connection'
ALTER TABLE [dbo].[t_Connection]
ADD CONSTRAINT [PK_t_Connection]
    PRIMARY KEY CLUSTERED ([IdConnection] ASC);
GO

-- Creating primary key on [CardCode], [IdCompany] in table 't_Customer'
ALTER TABLE [dbo].[t_Customer]
ADD CONSTRAINT [PK_t_Customer]
    PRIMARY KEY CLUSTERED ([CardCode], [IdCompany] ASC);
GO

-- Creating primary key on [CustomerAddress], [IdCompany], [CardCode] in table 't_CustomerAddress'
ALTER TABLE [dbo].[t_CustomerAddress]
ADD CONSTRAINT [PK_t_CustomerAddress]
    PRIMARY KEY CLUSTERED ([CustomerAddress], [IdCompany], [CardCode] ASC);
GO

-- Creating primary key on [ItemCode], [IdCompany] in table 't_Item'
ALTER TABLE [dbo].[t_Item]
ADD CONSTRAINT [PK_t_Item]
    PRIMARY KEY CLUSTERED ([ItemCode], [IdCompany] ASC);
GO

-- Creating primary key on [ItemCode], [IdCompany], [PriceList] in table 't_ItemPrice'
ALTER TABLE [dbo].[t_ItemPrice]
ADD CONSTRAINT [PK_t_ItemPrice]
    PRIMARY KEY CLUSTERED ([ItemCode], [IdCompany], [PriceList] ASC);
GO

-- Creating primary key on [DocEntry], [IdCompany] in table 't_Orders'
ALTER TABLE [dbo].[t_Orders]
ADD CONSTRAINT [PK_t_Orders]
    PRIMARY KEY CLUSTERED ([DocEntry], [IdCompany] ASC);
GO

-- Creating primary key on [DocEntry], [LineNum], [IdCompany] in table 't_OrdersDetail'
ALTER TABLE [dbo].[t_OrdersDetail]
ADD CONSTRAINT [PK_t_OrdersDetail]
    PRIMARY KEY CLUSTERED ([DocEntry], [LineNum], [IdCompany] ASC);
GO

-- Creating primary key on [DocEntry] in table 't_PurchaseRequest'
ALTER TABLE [dbo].[t_PurchaseRequest]
ADD CONSTRAINT [PK_t_PurchaseRequest]
    PRIMARY KEY CLUSTERED ([DocEntry] ASC);
GO

-- Creating primary key on [DocEntry], [LineNum] in table 't_PurchaseRequestDetail'
ALTER TABLE [dbo].[t_PurchaseRequestDetail]
ADD CONSTRAINT [PK_t_PurchaseRequestDetail]
    PRIMARY KEY CLUSTERED ([DocEntry], [LineNum] ASC);
GO

-- Creating primary key on [SlpCode] in table 't_Seller'
ALTER TABLE [dbo].[t_Seller]
ADD CONSTRAINT [PK_t_Seller]
    PRIMARY KEY CLUSTERED ([SlpCode] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCompany] in table 't_Customer'
ALTER TABLE [dbo].[t_Customer]
ADD CONSTRAINT [FK_Cliente_Empresa]
    FOREIGN KEY ([IdCompany])
    REFERENCES [dbo].[t_Company]
        ([IdCompany])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cliente_Empresa'
CREATE INDEX [IX_FK_Cliente_Empresa]
ON [dbo].[t_Customer]
    ([IdCompany]);
GO

-- Creating foreign key on [IdConnection] in table 't_Company'
ALTER TABLE [dbo].[t_Company]
ADD CONSTRAINT [FK_Empresa_Connection]
    FOREIGN KEY ([IdConnection])
    REFERENCES [dbo].[t_Connection]
        ([IdConnection])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Empresa_Connection'
CREATE INDEX [IX_FK_Empresa_Connection]
ON [dbo].[t_Company]
    ([IdConnection]);
GO

-- Creating foreign key on [IdCompany] in table 't_Orders'
ALTER TABLE [dbo].[t_Orders]
ADD CONSTRAINT [FK_Orden_Empresa]
    FOREIGN KEY ([IdCompany])
    REFERENCES [dbo].[t_Company]
        ([IdCompany])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Orden_Empresa'
CREATE INDEX [IX_FK_Orden_Empresa]
ON [dbo].[t_Orders]
    ([IdCompany]);
GO

-- Creating foreign key on [IdCompany] in table 't_Item'
ALTER TABLE [dbo].[t_Item]
ADD CONSTRAINT [FK_Producto_Empresa]
    FOREIGN KEY ([IdCompany])
    REFERENCES [dbo].[t_Company]
        ([IdCompany])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Producto_Empresa'
CREATE INDEX [IX_FK_Producto_Empresa]
ON [dbo].[t_Item]
    ([IdCompany]);
GO

-- Creating foreign key on [IdCompany] in table 't_Seller'
ALTER TABLE [dbo].[t_Seller]
ADD CONSTRAINT [FK_Vendedor_Empresa]
    FOREIGN KEY ([IdCompany])
    REFERENCES [dbo].[t_Company]
        ([IdCompany])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Vendedor_Empresa'
CREATE INDEX [IX_FK_Vendedor_Empresa]
ON [dbo].[t_Seller]
    ([IdCompany]);
GO

-- Creating foreign key on [CardCode], [IdCompany] in table 't_CustomerAddress'
ALTER TABLE [dbo].[t_CustomerAddress]
ADD CONSTRAINT [FK_ClienteDireccion_Cliente]
    FOREIGN KEY ([CardCode], [IdCompany])
    REFERENCES [dbo].[t_Customer]
        ([CardCode], [IdCompany])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteDireccion_Cliente'
CREATE INDEX [IX_FK_ClienteDireccion_Cliente]
ON [dbo].[t_CustomerAddress]
    ([CardCode], [IdCompany]);
GO

-- Creating foreign key on [ItemCode], [IdCompany] in table 't_ItemPrice'
ALTER TABLE [dbo].[t_ItemPrice]
ADD CONSTRAINT [FK_ProductoPrecio_Producto]
    FOREIGN KEY ([ItemCode], [IdCompany])
    REFERENCES [dbo].[t_Item]
        ([ItemCode], [IdCompany])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [DocEntry], [IdCompany] in table 't_OrdersDetail'
ALTER TABLE [dbo].[t_OrdersDetail]
ADD CONSTRAINT [FK_OrdenDetalle_Orden]
    FOREIGN KEY ([DocEntry], [IdCompany])
    REFERENCES [dbo].[t_Orders]
        ([DocEntry], [IdCompany])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenDetalle_Orden'
CREATE INDEX [IX_FK_OrdenDetalle_Orden]
ON [dbo].[t_OrdersDetail]
    ([DocEntry], [IdCompany]);
GO

-- Creating foreign key on [DocEntry] in table 't_PurchaseRequestDetail'
ALTER TABLE [dbo].[t_PurchaseRequestDetail]
ADD CONSTRAINT [FK_t_PurchaseRequest_t_PurchaseRequest]
    FOREIGN KEY ([DocEntry])
    REFERENCES [dbo].[t_PurchaseRequest]
        ([DocEntry])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------