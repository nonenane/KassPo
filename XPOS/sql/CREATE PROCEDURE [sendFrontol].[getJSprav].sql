USE [dbase1]
GO
/****** Object:  StoredProcedure [xpos].[getJSprav]    Script Date: 23.12.2020 10:21:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alekseev KU>
-- Create date: <23-03-2017>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [sendFrontol].[getJSprav]
	@terminal int
AS
BEGIN

select top 1 id_goods_updates
from [sendFrontol].[sprav_updates]
where terminal =  @terminal
order by time_update desc
	
END
