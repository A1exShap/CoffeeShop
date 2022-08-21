insert into [dbo].[Orders] (Id ,ClientId, OrderStatus, CreatedDate, ModifiedDate)
values (newid(), '5B91CA37-6ED0-4972-8737-9A45E6636E04', 2, cast('2022-08-20 19:12:56.1110000' as datetime2(7)), cast('2022-08-20 19:12:56.1110000' as datetime2(7)))

insert into [dbo].[OrderDetails] (Id ,OrderId, ProductId, Amount, Sum)

values (newid(), '20AF8597-0195-4A5F-9EE2-26E8561852D9', 'E95A73F6-F94C-4DBC-B52A-F2ED370553B0', 5, 6000.00),
	   (newid(), 'C9CA7921-229A-4945-9111-5C74B264859C', '88A11753-DC9D-4899-A7E9-BD0EA580F25A', 1, 1200.00)