﻿USE [WOW]
GO

/****** Object:  Table [dbo].[IconData]    Script Date: 10/22/2014 11:33:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[IconData](
	[icon] [varchar](56) NOT NULL,
	[image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_IconData] PRIMARY KEY CLUSTERED 
(
	[icon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

