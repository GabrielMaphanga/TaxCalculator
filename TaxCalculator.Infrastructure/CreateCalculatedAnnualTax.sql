USE [TaxCalculator]
GO

/****** Object:  Table [dbo].[CalculatedAnnualTax]    Script Date: 13 May 2023 21:10:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalculatedAnnualTax](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CalculatedTax] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
