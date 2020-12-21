USE [dbase1]
GO
/****** Object:  StoredProcedure [sendFrontol].[getTerminalType]    Script Date: 21.12.2020 12:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		АНС
-- Create date: 19.08.2020
-- Description:	Тип касс
-- =============================================
ALTER PROCEDURE [sendFrontol].[getTerminalType] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT	STT.id,
			STT.Type as NameTerminalType
	FROM sendFrontol.s_TerminalType STT
END
