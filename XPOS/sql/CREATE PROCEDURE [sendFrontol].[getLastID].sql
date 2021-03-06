USE [dbase1]
GO
/****** Object:  StoredProcedure [xpos].[getLastID]    Script Date: 23.12.2020 10:10:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alekseev KU>
-- Create date: <22.03.2017>
-- Description:	<Получает последний id из таблицы goods_updates>
-- =============================================
ALTER PROCEDURE [sendFrontol].[getLastID]
AS
BEGIN
	select 
		t.id, 
		t.DateCreate,
		t.DateEdit,
		t.DateGoodsSend,
		t.DateUserSend,
		t.id_Creator,
		t.id_Editor,
		t.id_GoodsSender,
		isnull(t.id_gu,0) as id_gu,
		t.id_TerminalType,
		t.id_UserSender,
		t.IP,
		t.isActive,
		isnull(t.last_id_gu,0) as lastID,
		t.Number as number,
		t.Path as path

	from sendFrontol.s_Terminal t
END
