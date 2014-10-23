USE [WOW]
GO

/****** Object:  Table [dbo].[AuctionData]    Script Date: 10/22/2014 11:32:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AuctionData](
	[time] [datetime] NOT NULL CONSTRAINT [DF_AuctionData_time]  DEFAULT (getdate()),
	[auc] [int] NOT NULL,
	[item] [int] NOT NULL,
	[owner] [varchar](50) NOT NULL,
	[ownerrealm] [varchar](50) NOT NULL,
	[bid] [bigint] NOT NULL,
	[buyout] [bigint] NOT NULL,
	[quantity] [int] NOT NULL,
	[timeleft] [varchar](9) NOT NULL,
 CONSTRAINT [UX_Table_time_auc] UNIQUE CLUSTERED 
(
	[time] ASC,
	[auc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

