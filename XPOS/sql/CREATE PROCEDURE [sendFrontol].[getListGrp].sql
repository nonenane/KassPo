USE [dbase1]
GO
/****** Object:  StoredProcedure [xpos].[getListGrp]    Script Date: 23.12.2020 10:08:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<SGU>
-- Create date: <2016-06-28>
-- Description:	<Получение групп не по ЕГАИС>
-- =============================================

CREATE PROCEDURE [sendFrontol].[getListGrp] 

AS
BEGIN

select 
	id,
	ltrim(rtrim(cname)) as cname,
	id_otdel 
from 
	dbase1.dbo.s_grp1 
where 
	id_otdel<>6

END



