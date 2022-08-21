
declare @order1 uniqueidentifier = newid()
declare @order2 uniqueidentifier = newid()

insert into [dbo].[Orders] (Id ,ClientId, OrderStatus, CreatedDate, ModifiedDate)
values (@order1, 'F4610161-8779-4E99-A26F-8EC30EEAB712', 2, cast('2022-08-10 19:12:56.1110000' as datetime2(7)), cast('2022-08-10 19:12:56.1110000' as datetime2(7))),
	   (@order2, '5B91CA37-6ED0-4972-8737-9A45E6636E04', 2, cast('2022-08-20 19:12:56.1110000' as datetime2(7)), cast('2022-08-20 19:12:56.1110000' as datetime2(7)))

insert into [dbo].[OrderDetails] (Id ,OrderId, ProductId, Amount, Sum)

values (newid(), @order1, 'E95A73F6-F94C-4DBC-B52A-F2ED370553B0', 5, 6000.00),
	   (newid(), @order2, '88A11753-DC9D-4899-A7E9-BD0EA580F25A', 1, 1200.00)