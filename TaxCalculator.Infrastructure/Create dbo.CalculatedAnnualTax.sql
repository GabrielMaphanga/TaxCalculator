USE [TaxCalculator]
GO

/****** Object: Table [dbo].[CalculatedAnnualTax] Script Date: 14 May 2023 23:16:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalculatedAnnualTax] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [CalculatedTax] INT      NOT NULL,
    [NetPay]        INT      NOT NULL,
    [DateTime]      DATETIME NOT NULL
);


