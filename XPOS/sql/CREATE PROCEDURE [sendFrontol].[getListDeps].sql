USE [dbase1]
GO
/****** Object:  StoredProcedure [xpos].[getListDeps]    Script Date: 23.12.2020 10:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Description:	<Получение списка отделов>
-- =============================================

CREATE PROCEDURE [sendFrontol].[getListDeps] 

AS
BEGIN

select 
	id,
	rtrim(name) as name 
from 
	[departments] 
where  
	if_comm =1 and ldeyst=1

END



