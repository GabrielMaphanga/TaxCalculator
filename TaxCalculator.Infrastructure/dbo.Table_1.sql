CREATE TABLE [dbo].[CalculatedAnnualTax]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[CalculatedTax] [int] NOT NULL,
	[NetPay] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL
)
