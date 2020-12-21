USE [KassRealiz]
GO
/****** Object:  StoredProcedure [dbo].[GetGoodsUpdatesTerminals]    Script Date: 21.12.2020 15:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Korshkova N.>
-- Create date: <28.03.2017>
-- Description:	<Получает информацию по отправке цен на кассы.>
-- =============================================
ALTER PROCEDURE [dbo].[GetGoodsUpdatesTerminals]
	@id_goods_updates int,
	@time_send datetime
AS
BEGIN
	SET NOCOUNT ON;
	
	declare @minute int = 10

	--select
	--		@minute = value
	--from
	--		dbo.prog_config
	--where
	--		id_prog = 294 and id_value = 'wait'
			
	--if @minute is null
	--	set @minute = 15

    select
			k.Number as terminal,
			su.time_update,
			case when su.time_update is not null then 2 else
				 case when DATEDIFF(minute, @time_send, GETDATE()) <= @minute then 1 else 3 end end as id_status,
			t.Type as NameType
    from
			dbase1.sendFrontol.s_Terminal k left join 
								(select 
										terminal, max(time_update) as time_update
								 from
										dbase1.xpos.sprav_updates
								 where
										id_goods_updates = @id_goods_updates
								 group by
										terminal
								) su on k.Number = su.terminal
								left join dbase1.sendFrontol.s_TerminalType t on t.id = k.id_TerminalType
	where
			k.Number != 0 and k.Number != 1  --исключается строка с значением максимального ид_товаров (0) и (1) касса, которая торгует онлайн
	
			
END
