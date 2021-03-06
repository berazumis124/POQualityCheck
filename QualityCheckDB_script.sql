USE [QualityCheckDB]
GO
/****** Object:  Table [dbo].[tbl_Supplier]    Script Date: 06/26/2017 14:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Supplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Supplier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Defect]    Script Date: 06/26/2017 14:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Defect](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Defect] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_OrderHeader]    Script Date: 06/26/2017 14:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_OrderHeader](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [nvarchar](20) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[DeliveryS] [nchar](10) NULL,
	[DeliveryP] [nchar](10) NULL,
	[isChecked] [smallint] NOT NULL,
 CONSTRAINT [PK_tbl_OrderHeader] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_OrderLine]    Script Date: 06/26/2017 14:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_OrderLine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OrderHeaderID] [int] NOT NULL,
	[ItemNumber] [nchar](10) NULL,
	[Name] [nvarchar](80) NULL,
	[OrderQty] [decimal](7, 2) NULL,
	[UnitOfMeasure] [nchar](10) NULL,
	[Description] [nvarchar](250) NULL,
	[QtyChecked] [decimal](7, 2) NULL,
	[isChecked] [smallint] NOT NULL,
 CONSTRAINT [PK_tbl_OrderLine] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_DefectLog]    Script Date: 06/26/2017 14:00:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DefectLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OrderLineID] [int] NOT NULL,
	[DefectID] [int] NOT NULL,
	[EntryDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_DefectLog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_tbl_OrderHeader_isChecked]    Script Date: 06/26/2017 14:00:35 ******/
ALTER TABLE [dbo].[tbl_OrderHeader] ADD  CONSTRAINT [DF_tbl_OrderHeader_isChecked]  DEFAULT ((0)) FOR [isChecked]
GO
/****** Object:  Default [DF_tbl_OrderLine_isChecked]    Script Date: 06/26/2017 14:00:35 ******/
ALTER TABLE [dbo].[tbl_OrderLine] ADD  CONSTRAINT [DF_tbl_OrderLine_isChecked]  DEFAULT ((0)) FOR [isChecked]
GO
/****** Object:  ForeignKey [FK_tbl_DefectLog_tbl_Defect]    Script Date: 06/26/2017 14:00:35 ******/
ALTER TABLE [dbo].[tbl_DefectLog]  WITH CHECK ADD  CONSTRAINT [FK_tbl_DefectLog_tbl_Defect] FOREIGN KEY([DefectID])
REFERENCES [dbo].[tbl_Defect] ([id])
GO
ALTER TABLE [dbo].[tbl_DefectLog] CHECK CONSTRAINT [FK_tbl_DefectLog_tbl_Defect]
GO
/****** Object:  ForeignKey [FK_tbl_DefectLog_tbl_OrderLine]    Script Date: 06/26/2017 14:00:35 ******/
ALTER TABLE [dbo].[tbl_DefectLog]  WITH CHECK ADD  CONSTRAINT [FK_tbl_DefectLog_tbl_OrderLine] FOREIGN KEY([OrderLineID])
REFERENCES [dbo].[tbl_OrderLine] ([id])
GO
ALTER TABLE [dbo].[tbl_DefectLog] CHECK CONSTRAINT [FK_tbl_DefectLog_tbl_OrderLine]
GO
/****** Object:  ForeignKey [FK_tbl_OrderHeader_tbl_Supplier]    Script Date: 06/26/2017 14:00:35 ******/
ALTER TABLE [dbo].[tbl_OrderHeader]  WITH CHECK ADD  CONSTRAINT [FK_tbl_OrderHeader_tbl_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[tbl_Supplier] ([id])
GO
ALTER TABLE [dbo].[tbl_OrderHeader] CHECK CONSTRAINT [FK_tbl_OrderHeader_tbl_Supplier]
GO
/****** Object:  ForeignKey [FK_tbl_OrderLine_tbl_OrderHeader]    Script Date: 06/26/2017 14:00:35 ******/
ALTER TABLE [dbo].[tbl_OrderLine]  WITH CHECK ADD  CONSTRAINT [FK_tbl_OrderLine_tbl_OrderHeader] FOREIGN KEY([OrderHeaderID])
REFERENCES [dbo].[tbl_OrderHeader] ([id])
GO
ALTER TABLE [dbo].[tbl_OrderLine] CHECK CONSTRAINT [FK_tbl_OrderLine_tbl_OrderHeader]
GO
