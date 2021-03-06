USE [dbase1]
GO
/****** Object:  StoredProcedure [sendFrontol].[setTerminal]    Script Date: 21.12.2020 15:12:03 ******/
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
-- Описание:	Добавлена работа с полем "тип кассы"
-- =============================================
ALTER PROCEDURE [sendFrontol].[setTerminal]		
	@id int,
	@Number int,
	@IP varchar(17),
	@Path varchar(max),
	@type int,	
	@idUser int,
	@idTerminalType int

AS
BEGIN
SET NOCOUNT ON

IF EXISTS ( SELECT * FROM sendFrontol.s_Terminal WHERE id<>@id AND (IP = @IP OR Number=@Number))
	BEGIN
		SELECT -2 as id
		return;
	END

BEGIN TRY
IF @id=-1
	BEGIN
		INSERT INTO sendFrontol.s_Terminal (IP,Number,Path,DateCreate,DateEdit,id_Creator,id_Editor,id_TerminalType)
			 VALUES (@IP,@Number,@Path,GETDATE(),GETDATE(),@idUser,@idUser, @idTerminalType)
		SELECT SCOPE_IDENTITY() as id
	END
ELSE IF @id<> -1
	BEGIN
		IF @type = 1
			BEGIN
				UPDATE sendFrontol.s_Terminal SET IP = @IP,Number=@Number,Path=@Path, DateEdit=GETDATE(),id_Editor=@idUser,id_TerminalType=@idTerminalType
					WHERE id = @id
				SELECT @id as id
			END
		ELSE IF @type=2
			BEGIN			
			--IF EXISTS(select * from sendFrontol.s_Terminal where id = @id)
			--	BEGIN
			--		UPDATE 
			--			sendFrontol.s_Terminal 
			--		SET 
			--			isActive=case When isActive=1 then 0 else 1 end
			--		WHERE 
			--			id = @id
			--		SELECT -3 as id
			--	END
			--	ELSE
				--BEGIN		
					DELETE FROM sendFrontol.s_Terminal WHERE id = @id
					SELECT @id as id
				--END
			END
	END
END TRY
BEGIN CATCH	
	SELECT -1 as id
END CATCH


END	
