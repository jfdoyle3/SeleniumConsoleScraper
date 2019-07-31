CREATE TABLE [dbo].[StockTable] (
    [ID]         INT           NOT NULL IDENTITY,
    [DateStamp]  DateTime.Now  NULL,
    [Symbol]     NVARCHAR (50) NULL,
    [LastPrice]  NVARCHAR (50) NULL,
    [Change]     NVARCHAR (50) NULL,
    [ChgPc]      NVARCHAR (50) NULL,
    [Currency]   NVARCHAR (50) NULL,
    [MarketTime] NVARCHAR (50) NULL,
    [Volume]     NVARCHAR (50) NULL,
    [AvgVol3m]   NVARCHAR (50) NULL,
    [MarketCap]  NVARCHAR (50) NULL,

    CONSTRAINT [PK_StockTable] PRIMARY KEY CLUSTERED ([ID] ASC)
);