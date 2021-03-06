USE [dbase1]
GO
/****** Object:  StoredProcedure [xpos].[getLastListTovar]    Script Date: 23.12.2020 10:07:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<AKU>
-- Create date: <2017-05-22>
-- Description:	<Создание списка товаров для xPOS>
-- Edited:      <Molotkova_IS>
-- Edit date:   <2019-03-28>
-- Description: <Добавлено поле id_post>
-- =============================================

CREATE PROCEDURE [sendFrontol].[getLastListTovar] 
 @last_id bigint ,
 @scope bit =0
AS

BEGIN


create table #tableEAN  (ean varchar(13),id_tovar int)

--declare @tableEANTime table (ean varchar(13),r_time datetime,name varchar(Max),price numeric(13,3),grp int,id_departments int,tax smallint)

insert into #tableEAN 
select ltrim(rtrim(ean)) as ean,id as id_tovar 
from dbo.s_tovar
where id_otdel<>6  	
--and id not in (
--				select id_tovar from [requests].[s_CatalogPromotionalTovars]
--				)

if @scope = 0
begin

	select distinct
			 a.ean
			,a.r_time
			,a.name
			,a.price
			,case when grp1.id is null  then 
					case when a.id_departments = 1 then 10
							when a.id_departments = 2 then 20
							when a.id_departments = 3 then 30
							when a.id_departments = 4 then 40
							when a.id_departments = 5 then 50
							when a.id_departments = 7 then 70
							when a.id_departments = 8 then 80
							when a.id_departments = 10 then 11
							when a.id_departments = 11 then 349
							end
				else a.grp
			end as grp
			,case when a.tax<>20 then a.tax else 18 end as 'tax'
			,case 
			when len(t.id_tovar) = 3 then '0'+cast(t.id_tovar as varchar(3))
			when len(t.id_tovar) = 2 then '00'+cast(t.id_tovar as varchar(2))
			else cast(t.id_tovar as varchar)
			end as id_tovar, '' as kodVVO 
			,isnull((select firm from dbo.goods_test where id = t.id_tovar)
			,(select cname from [s_post]
			  where id =
				(select id_Post from  [dbo].[s_MainOrg]
					where DateStart < GETDATE()
					and DateEnd > GETDATE()
					and nTypeOrg = (
					ISNULL(
					(  
									select top 1 ntypeorg
									from [dbo].[goods_vs_firms]
									where CAST(GETDATE() as date) >= date
									and ntypeorg not in (6,17)
									and id_tovar = t.id_tovar 
									order by date desc),
									--select top 1 ntypeorg
									--from [dbo].[goods_vs_firms]
									--where id_tovar = t.id_tovar 
									--order by date desc),
										(
											select ntypeorg from [firms_vs_departments]
											where DateStart < GETDATE() and DateEnd > GETDATE()
											and [default] = 1 and id_departments = 
											(select id_otdel from s_tovar where id = t.id_tovar ))
										)
									)
							
				)
			)
			) as firm
			,
			(select id_Post 
			from  [dbo].[s_MainOrg]
			where DateStart < GETDATE()
					and DateEnd > GETDATE()
					and nTypeOrg = (
			ISNULL((
							select top 1 ntypeorg
							from [dbo].[goods_vs_firms]
							where CAST(GETDATE() as date) >= date
							and ntypeorg not in (6,17)
							and id_tovar = t.id_tovar 
							order by date desc),
								(
									select ntypeorg from [firms_vs_departments]
									where DateStart < GETDATE() 
										and DateEnd > GETDATE()
										and [default] = 1 
										and id_departments = 
											(select id_otdel from s_tovar where id = t.id_tovar)
								)
					)
									)
				)
			as id_post
	from 
	
		(
		select ltrim(rtrim(ean)) as ean,id as id_tovar from dbo.s_tovar	where id_otdel<>6  
		--and id not in (
		--			select id_tovar from [requests].[s_CatalogPromotionalTovars]
		--			)
		
		) t
		inner join 
				(
				select distinct
				ltrim(rtrim(g.ean)) as ean,
				g.r_time,
					g.name,
				cast(g.price as numeric(13,3))/100 as price
				,g.grp
				,g.id_departments
				,case when g.tax<>20 then g.tax else 18 end  as tax
			from 
				(select top 1 ltrim(rtrim(ean)) as ean
				   , MAX(r_time) as r_time 
				 from KassRealiz.dbo.[goods_updates] g 
				 where	 id_departments <> 6
					 and g.id = @last_id
				 group by ltrim(rtrim(ean))) as a
				 inner join KassRealiz.dbo.[goods_updates] g 
				 on ltrim(rtrim(g.ean)) = ltrim(rtrim(a.ean)) and g.r_time = a.r_time
		
		) a on t.ean collate Cyrillic_General_CS_AI = a.ean	collate Cyrillic_General_CS_AI
		left join dbo.[s_grp1] grp1 on grp1.id = a.grp
	order by ean asc

	
end

if @scope = 1	
begin

	select distinct
			 a.ean
			,a.r_time
			,a.name
			,a.price
			,case when grp1.id is null  then 
					case when a.id_departments = 1 then 10
							when a.id_departments = 2 then 20
							when a.id_departments = 3 then 30
							when a.id_departments = 4 then 40
							when a.id_departments = 5 then 50
							when a.id_departments = 7 then 70
							when a.id_departments = 8 then 80
							when a.id_departments = 10 then 11
							when a.id_departments = 11 then 349
							end
				else a.grp
			end as grp
			,case when a.tax<>20 then a.tax else 18 end as 'tax'
			,case 
			when len(t.id_tovar) = 3 then '0'+cast(t.id_tovar as varchar(3))
			when len(t.id_tovar) = 2 then '00'+cast(t.id_tovar as varchar(2))
			else cast(t.id_tovar as varchar)
			end as id_tovar, '' as kodVVO 
			,(select cname from [s_post]
			  where id =
				(select id_Post from  [dbo].[s_MainOrg]
					where DateStart < GETDATE()
					and DateEnd > GETDATE()
					and nTypeOrg = (
					ISNULL(
					(  
									select top 1 ntypeorg
									from [dbo].[goods_vs_firms]
									where CAST(GETDATE() as date) >= date
									and ntypeorg not in (6,17)
									and id_tovar = t.id_tovar 
									order by date desc),

										(
											select ntypeorg from [firms_vs_departments]
											where DateStart < GETDATE() and DateEnd > GETDATE()
											and [default] = 1 and id_departments = 
											(select id_otdel from s_tovar where id = t.id_tovar ))
										)
									)
							
				)
			)
			 as firm
			,
			(select id_Post 
			from  [dbo].[s_MainOrg]
			where DateStart < GETDATE()
					and DateEnd > GETDATE()
					and nTypeOrg = (
			ISNULL((
							select top 1 ntypeorg
							from [dbo].[goods_vs_firms]
							where CAST(GETDATE() as date) >= date
							and ntypeorg not in (6,17)
							and id_tovar = t.id_tovar 
							order by date desc),
								(
									select ntypeorg from [firms_vs_departments]
									where DateStart < GETDATE() 
										and DateEnd > GETDATE()
										and [default] = 1 
										and id_departments = 
											(select id_otdel from s_tovar where id = t.id_tovar)
								)
					)
									)
				)
			as id_post
	from 
		(select [ean], [id_tovar] from #tableEAN ) t
		inner join 
		(
				select distinct
				ltrim(rtrim(g.ean)) as ean,
				g.r_time,
					g.name, 
				cast(g.price as numeric(13,3))/100  as price
				,g.grp
				,g.id_departments
				,case when g.tax<>20 then g.tax else 18 end  as tax
			from 
				(select  ltrim(rtrim(ean)) as ean
				   , MAX(r_time) as r_time 
				 from KassRealiz.dbo.[goods_updates] g 
				 where  id_departments <> 6
					and g.id > @last_id
				 group by ltrim(rtrim(ean))) as a
				 inner join KassRealiz.dbo.[goods_updates] g 
				 on ltrim(rtrim(g.ean)) = ltrim(rtrim(a.ean)) and g.r_time = a.r_time
		) a on t.ean collate Cyrillic_General_CS_AI = a.ean	collate Cyrillic_General_CS_AI
		left join dbo.[s_grp1] grp1 on grp1.id = a.grp
	order by ean asc
end

drop table #tableEAN 

END