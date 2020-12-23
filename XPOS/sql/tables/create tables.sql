USE [dbase1]
GO

/****** Object:  Table [xpos].[checksUnloadError]    Script Date: 23.12.2020 10:18:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [sendFrontol].[checksUnloadError](
	[terminal] [int] NOT NULL,
	[error] [bit] NOT NULL,
	[time] [datetime] NULL
) ON [PRIMARY]
GO


CREATE TABLE [sendFrontol].[j_sprav](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NULL,
	[terminal] [int] NULL,
	[message] [varchar](200) NULL,
	[timeId] [int] NULL
) ON [PRIMARY]
GO


CREATE TABLE [sendFrontol].[j_spravErrors](
	[ean] [varchar](13) NULL,
	[name] [varchar](40) NULL,
	[price] [int] NULL,
	[t1] [time](7) NULL,
	[t2] [time](7) NULL,
	[dpt] [smallint] NULL,
	[grp] [smallint] NULL,
	[tax] [smallint] NULL,
	[action] [smallint] NULL,
	[acount] [smallint] NULL,
	[aean] [varchar](13) NULL,
	[aprice] [int] NULL,
	[r_time] [datetime] NULL,
	[s_time] [datetime] NULL,
	[sender] [varchar](10) NULL,
	[s] [char](1) NULL,
	[id] [int] NULL,
	[id_departments] [int] NULL
) ON [PRIMARY]
GO

CREATE TABLE [sendFrontol].[j_transactions](
	[number] [int] NOT NULL,
	[lastRecID] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [sendFrontol].[MainSprav](
	[id] [int] NOT NULL,
	[ean] [varchar](13) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[price] [int] NOT NULL,
	[dpt] [smallint] NOT NULL,
	[r_time] [datetime] NOT NULL,
	[isNew] [bit] NULL,
	[comment] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


CREATE TABLE [sendFrontol].[s_ntovar](
	[id] [int] NULL,
	[id_tovar] [int] NULL,
	[ean] [char](13) NULL,
	[tdate_n] [datetime] NULL,
	[cname] [char](45) NULL,
	[kass_name] [char](20) NULL,
	[ntypetovar] [int] NULL,
	[short_name] [char](45) NULL
) ON [PRIMARY]
GO


CREATE TABLE [sendFrontol].[sprav_updates](
	[id_goods_updates] [int] NULL,
	[terminal] [int] NULL,
	[time_update] [datetime] NULL
) ON [PRIMARY]
GO


