USE [dbase1]
GO
/****** Object:  StoredProcedure [xpos].[setLastID]    Script Date: 23.12.2020 10:13:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alekseev KU>
-- Create date: <22.03.2017>
-- Description:	<Получает последний id из таблицы goods_updates>
-- =============================================
CREATE PROCEDURE [sendFrontol].[setLastID]
  @number int,  
  @lastID bigint
AS
BEGIN
	update sendFrontol.s_Terminal
	set last_id_gu = @lastID
	where Number = @number
	
END
