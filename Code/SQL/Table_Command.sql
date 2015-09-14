USE [CSCloud]
GO

/****** Object:  Table [dbo].[Command]    Script Date: 09/13/2015 01:21:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Command](
	[id] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[Result] [varchar](10) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Command] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Command]  WITH CHECK ADD  CONSTRAINT [FK_Command_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([id])
GO

ALTER TABLE [dbo].[Command] CHECK CONSTRAINT [FK_Command_Client]
GO


