USE [dbase1]
GO
/****** Object:  StoredProcedure [xpos].[getLastIdSprav]    Script Date: 23.12.2020 10:09:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [sendFrontol].[getLastIdSprav] 
AS
BEGIN
	select top 1 
		id 
	from 
		KassRealiz.dbo.goods_updates
	order by 
		id desc
END