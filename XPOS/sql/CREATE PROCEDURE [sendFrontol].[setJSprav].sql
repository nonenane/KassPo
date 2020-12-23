USE [dbase1]
GO
/****** Object:  StoredProcedure [xpos].[setJSprav]    Script Date: 23.12.2020 10:13:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alekseev KU>
-- Create date: <23-03-2017>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [sendFrontol].[setJSprav]
	@terminal int
	,@id bigint
AS
BEGIN
--insert into [dbase1].[xpos].[sprav_updates]
--(id_goods_updates,[terminal],[time_update])
--values
--  (@id, @terminal,getdate()) 


if not EXISTS (select 1 from [sendFrontol].[sprav_updates] where terminal = @terminal and id_goods_updates = @id)

	insert into [sendFrontol].[sprav_updates](id_goods_updates,[terminal],[time_update])
	values (@id, @terminal,getdate()) 

END
