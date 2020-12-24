USE [dbase1]
GO
/****** Object:  StoredProcedure [xpos].[getListDeps]    Script Date: 23.12.2020 10:03:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Description:	<Получение списка товаров>
-- =============================================

ALTER PROCEDURE [sendFrontol].[getListGoodsDbase1] 
	@isVOO bit = 0
AS
BEGIN


select 
	f.id_tovar,f.ntypeorg 
INTO 
	#ntypeorgTovar
from (
select  
	max(date) as date,
	id_tovar
from 
	[dbo].[goods_vs_firms]
where
	CAST(GETDATE() as date) >= date
	and 
	ntypeorg not in (6,17)									
group by
	id_tovar) as a inner join [dbo].[goods_vs_firms] f on f.id_tovar = a.id_tovar and f.date = a.date

select 
	ntypeorg ,id_departments
INTO 
	#ntypeorgDeps
from 
	[firms_vs_departments]
where
	DateStart < GETDATE() and DateEnd > GETDATE()
	and [default] = 1
order by id_departments

select 
	m.id_Post,
	m.nTypeOrg
INTO 
	#mainOrg
from  
	[dbo].[s_MainOrg] m
where 
	m.DateStart < GETDATE()
	and m.DateEnd > GETDATE()

select 
	tov.ean,
	tov.id_grp1,
	tov.id_otdel,
	tov.id as id_tovar,
	isnull(nTov.ntypeorg,nDeps.ntypeorg) as ntypeorg
INTO 
	#tableEAN
from dbo.s_tovar tov
	left join #ntypeorgTovar nTov on nTov.id_tovar = tov.id
	left join #ntypeorgDeps nDeps on nDeps.id_departments= tov.id_otdel
where 
	(@isVOO = 1 and id_otdel = 6) or (@isVOO = 0 and id_otdel <> 6  )  

select 
	t.ean,
	getdate() as r_time,
	''as name,	
	0.0 as price,
	0 as grp,
	0 as 'tax',
	case 
			when len(t.id_tovar) = 3 then '0'+cast(t.id_tovar as varchar(3))
			when len(t.id_tovar) = 2 then '00'+cast(t.id_tovar as varchar(2))
			else cast(t.id_tovar as varchar)
			end as id_tovar, 
	'' as kodVVO,
	p.cname as  firm,
	m.id_Post as id_post,	
	t.id_grp1
from 
	#tableEAN t 
		left join #mainOrg m on m.nTypeOrg = t.ntypeorg
		left join dbo.s_post p on p.id = m.id_Post

DROP TABLE #tableEAN, #ntypeorgTovar,#ntypeorgDeps,#mainOrg

END



