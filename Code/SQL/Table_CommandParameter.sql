USE [CSCloud]
GO

/****** Object:  Table [dbo].[CommandParameter]    Script Date: 09/13/2015 01:21:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CommandParameter](
	[id] [int] IDENTITY(1000,1) NOT NULL,
	[CommandID] [int] NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[Value] [varchar](max) NULL,
 CONSTRAINT [PK_CommandParameter] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CommandParameter]  WITH CHECK ADD  CONSTRAINT [FK_CommandParameter_Command] FOREIGN KEY([CommandID])
REFERENCES [dbo].[Command] ([id])
GO

ALTER TABLE [dbo].[CommandParameter] CHECK CONSTRAINT [FK_CommandParameter_Command]
GO


