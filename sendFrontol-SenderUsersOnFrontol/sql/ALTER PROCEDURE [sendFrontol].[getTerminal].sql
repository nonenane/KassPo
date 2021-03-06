USE [dbase1]
GO
/****** Object:  StoredProcedure [sendFrontol].[getTerminal]    Script Date: 21.12.2020 12:50:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		S.P.G.
-- Create date: 17.
-- Description:	Получение настроек
-- =============================================
-- Изменил:		АНС
-- Дата:		19.08.2020
-- Описание:	Добавлено поле "тип кассы" из нового справчоника s_TerminalType
-- =============================================
ALTER PROCEDURE [sendFrontol].[getTerminal]		
AS
BEGIN
SET NOCOUNT ON

DECLARE @maxDate date
select @maxDate = max(DateEdit) from sendFrontol.s_Users

SELECT	ST.id,
		ST.Number,
		ST.IP,
		ST.Path,
		ST.id_TerminalType,
		STT.Type as NameTerminalType,
		ST.DateUserSend,
		cast(case when ST.DateUserSend is null or  ST.DateUserSend < @maxDate then 1 else 0 end as bit) as isError
FROM sendFrontol.s_Terminal ST
INNER JOIN sendFrontol.s_TerminalType STT ON STT.id = ST.id_TerminalType

END	
