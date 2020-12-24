USE [dbase1]
GO
/****** Object:  StoredProcedure [sendFrontol].[getTerminal]    Script Date: 21.12.2020 12:50:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Sporykhi  G.Y.
-- Create date: 22.12.2020
-- Description:	Получение списка касс для справочника 
-- =============================================
ALTER PROCEDURE [sendFrontol].[GetSpravTerminal]		
AS
BEGIN
SET NOCOUNT ON

select 
	t.id,
	t.Number,
	tt.Type as NameTerminalType,
	t.id_TerminalType,
	isnull(t.id_gu,0) as id_gu,
	isnull(t.last_id_gu,0) as last_id_gu,
	t.DateGoodsSend,
	cast(0 as bit) as isSelect,
	t.IP,
	t.Path
from 
	sendFrontol.s_Terminal t
	inner join sendFrontol.s_TerminalType tt on tt.id =  t.id_TerminalType

END	
