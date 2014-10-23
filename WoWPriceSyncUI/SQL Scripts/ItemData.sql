USE [WOW]
GO

/****** Object:  Table [dbo].[ItemData]    Script Date: 10/22/2014 11:33:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ItemData](
	[id] [int] NOT NULL,
	[name] [varchar](75) NOT NULL,
	[description] [varchar](512) NOT NULL,
	[icon] [varchar](75) NOT NULL,
	[sellprice] [bigint] NOT NULL,
	[stackable] [int] NOT NULL,
	[itemclass] [int] NOT NULL,
	[itemlevel] [int] NOT NULL,
	[isauctionable] [bit] NOT NULL,
	[itembind] [int] NOT NULL,
	[isfavorite] [bit] NOT NULL CONSTRAINT [DF_ItemData_isfavorite]  DEFAULT ((0)),
	[buyoutcutoff] [float] NOT NULL CONSTRAINT [DF_ItemData_buyoutcutoff]  DEFAULT ((9999999999.)),
	[maxincreasepercent] [float] NOT NULL CONSTRAINT [DF_ItemData_maxincreasepercent]  DEFAULT ((300)),
 CONSTRAINT [PK_ItemData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

