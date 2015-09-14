USE [CSCloud]
GO

/****** Object:  View [dbo].[vwCommand]    Script Date: 09/13/2015 01:31:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwCommand]
AS
SELECT     dbo.Client.Name AS ClientName, dbo.Command.Result AS CommandResult, dbo.Command.Code AS CommandCode, dbo.Command.Date AS CommandDate, 
                      dbo.CommandParameter.Name AS ParameterName, dbo.CommandParameter.Value AS ParameterValue
FROM         dbo.CommandParameter RIGHT OUTER JOIN
                      dbo.Command ON dbo.CommandParameter.CommandID = dbo.Command.id RIGHT OUTER JOIN
                      dbo.Client ON dbo.Command.ClientID = dbo.Client.id

GO
