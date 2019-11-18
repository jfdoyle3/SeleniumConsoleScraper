CREATE TABLE [dbo].[SeleniumStocks] (
    [ID]         INT           NOT NULL IDENTITY,
    [DateStamp]  DateTime.Now  NULL,
    [Symbol]     NVARCHAR (50) NULL,
    [LastPrice]  NVARCHAR (50) NULL,
    [Change]     NVARCHAR (50) NULL,
    [ChgPc]      NVARCHAR (50) NULL,
    [MarketTime] NVARCHAR (50) NULL,
    [Volume]     NVARCHAR (50) NULL,
    [AvgVol3m]   NVARCHAR (50) NULL,
    [MarketCap]  NVARCHAR (50) NULL,
	[Method]     NVARCHAR (50) NULL,

    CONSTRAINT [PK_SeleniumStocks] PRIMARY KEY CLUSTERED ([ID] ASC)
);