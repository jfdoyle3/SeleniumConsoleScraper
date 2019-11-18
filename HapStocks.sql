CREATE TABLE [dbo].[HapStocks] (
    [ID]         INT           NOT NULL IDENTITY,
    [DateStamp]  DateTime  NULL,
    [Symbol]     NVARCHAR (50) NULL,
    [LastPrice]  NVARCHAR (50) NULL,
    [Change]     NVARCHAR (50) NULL,
    [ChgPc]      NVARCHAR (50) NULL,
    [MarketTime] NVARCHAR (50) NULL,
    [Volume]     NVARCHAR (50) NULL,
    [AvgVol3m]   NVARCHAR (50) NULL,
    [MarketCap]  NVARCHAR (50) NULL,
	[Method]     NVARCHAR (50) NULL,

    CONSTRAINT [PK_HapStocks] PRIMARY KEY CLUSTERED ([ID] ASC)
);