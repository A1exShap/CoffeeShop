
-- Проверка ХП sp_listOfSoldGoods
declare @from datetime = cast('2022-04-11 10:53:14.2570000' as datetime2(7))
declare @to datetime = cast('2022-08-21 12:34:14.1320000' as datetime2(7))

exec [dbo].[sp_listOfSoldGoods] @from, @to, '0C57276D-022F-4983-A175-550E19B17318'


-- Проверка представления vw_ClientsActivity
select * from vw_ClientsActivity