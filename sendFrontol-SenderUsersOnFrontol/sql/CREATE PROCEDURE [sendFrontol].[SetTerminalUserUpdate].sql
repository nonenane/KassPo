USE [dbase1]
GO
/****** Object:  StoredProcedure [sendFrontol].[setDateSend]    Script Date: 23.12.2020 12:17:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		S.P.G.
-- Create date: 17.
-- Description:	Обновление данных по отправик на кассы
-- =============================================
CREATE PROCEDURE [sendFrontol].[SetTerminalUserUpdate]		
	@id_Ternimal int,
	@id_user int
AS
BEGIN
SET NOCOUNT ON

UPDATE	sendFrontol.s_Terminal
SET id_UserSender =@id_user,DateUserSend = GETDATE()
WHERE id = @id_Ternimal

	

END	
