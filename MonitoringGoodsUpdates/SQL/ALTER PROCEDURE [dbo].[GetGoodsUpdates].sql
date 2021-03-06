USE [KassRealiz]
GO
/****** Object:  StoredProcedure [dbo].[GetGoodsUpdates]    Script Date: 21.12.2020 15:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Korshkova N.>
-- Create date: <28.03.2017>
-- Description:	<Получает товары с переоценкой на дату.>
-- Editor:		Molotkova_IS
-- Edit date:	27.07.2020
-- Description: Исключена первая касса
-- =============================================
ALTER PROCEDURE [dbo].[GetGoodsUpdates]
	@date datetime
AS
BEGIN
	SET NOCOUNT ON;
	
	--------------------------------------------------------------------
    declare @date_start datetime = dateadd(hour, 4, @date)
	declare @date_end datetime = dateadd(HOUR, 3, dateadd(day, 1, @date))

	declare @minute int = 30

	--select
	--		@minute = value
	--from
	--		dbo.prog_config
	--where
	--		id_prog = 294 and id_value = 'wait'
			
	--if @minute is null
	--	set @minute = 15
	print 1
	--------------------------------------------------------------------
		select
				gu.id as id_goods_updates,
				ean as ean,
				rtrim(ltrim(gu.name)) as name,
				convert(numeric(14,2), (convert(numeric(14,2), price)/100)) as price,
				rtrim(ltrim(d.name)) as dep_name,
				r_time as time_send,
				gu.id_departments,
				(select top 1 Number from dbase1.sendFrontol.s_Terminal k left join dbase1.sendFrontol.sprav_updates su on k.Number = su.terminal and su.id_goods_updates = gu.id where su.terminal is null and k.Number != 0 and k.Number != 1) as not_sent_kass
	INTO #goods_updates
		from 
				dbo.goods_updates gu left join dbo.departments d on gu.dpt = d.id
		where
				r_time >= @date_start and r_time <= @date_end
	--------------------------------------------------------------------

		print 2	
	select
				gu.id,
				gu.ean,
				convert(numeric(14,2), (convert(numeric(14,2), gu.price)/100)) as price,
				gu.r_time
INTO #all_prices
		from
				dbo.goods_updates gu join #goods_updates upd on gu.ean = upd.ean

	--------------------------------------------------------------------
		print 3	
	select
			t.id_goods_updates,
			t.Number as terminal
INTO #errors
	from
			(select gu.id_goods_updates, gu.time_send, k.Number from #goods_updates gu, dbase1.sendFrontol.s_Terminal k where k.Number != 0 and k.Number != 1) t left join
			                   (
								select
										s.id_goods_updates, terminal, MAX(time_update) as time_update
								from
										dbase1.sendFrontol.sprav_updates s join #goods_updates g on s.id_goods_updates = g.id_goods_updates
								group by
										s.id_goods_updates, terminal
			                   ) su on su.terminal = t.Number and su.id_goods_updates = t.id_goods_updates
	where
			su.time_update is null and DATEDIFF(minute, t.time_send, GETDATE()) > @minute
	--------------------------------------------------------------------	
	print 4	
	SELECT
			e.id_goods_updates, 
			(SELECT rtrim(ltrim(str(t.terminal))) + ', ' 
			 FROM #errors t
			 WHERE t.id_goods_updates = e.id_goods_updates
			 order by t.terminal
			 FOR XML PATH('')) as term_names into #not_sent
			FROM #goods_updates e

	select
			gu.id_goods_updates,
			ean,
			name,
			price,
		    isnull((select top 1 a.price from #all_prices a where a.ean = gu.ean and a.id != gu.id_goods_updates order by r_time desc), 0.00) as old_price,
			dep_name,
			time_send,
			substring(isnull(ns.term_names, ''), 1, LEN(ns.term_names) - 1) as not_sent_terminals,
			case when not_sent_kass is null then 2 else
				 case when DATEDIFF(minute, time_send, GETDATE()) <= @minute then 1 else 3 end end as id_status
				 ,gu.id_departments
	from
			#goods_updates gu left join #not_sent ns on gu.id_goods_updates = ns.id_goods_updates
	order by
			time_send
			
	drop table #goods_updates
	drop table #all_prices
	drop table #errors
	
END
