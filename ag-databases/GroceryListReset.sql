use GroceryList
go
delete OrderList where orderid = 2
delete Orders where orderid = 2
delete OrderList where orderid = 3
delete Orders where orderid = 3
delete OrderList where orderid = 4
delete Orders where orderid = 4
delete OrderList where orderid = 5
delete Orders where orderid = 5
delete OrderList where orderid = 6
delete Orders where orderid = 6
delete OrderList where orderid = 7
delete Orders where orderid = 7
delete OrderList where orderid = 8
delete Orders where orderid = 8
delete OrderList where orderid = 9
delete Orders where orderid = 9
go
set IDENTITY_INSERT  Orders on
insert into Orders (OrderID, OrderDate, StoreID, CustomerID, PickerID, PickedDate, Delivery, SubTotal, GST) Values(2, DATEADD(day,2,getdate()), 1, 1, null, null, 0,  0.0, 0.0)
insert into Orders (OrderID, OrderDate, StoreID, CustomerID, PickerID, PickedDate, Delivery, SubTotal, GST) Values(3, '2021-01-01', 1, 1, null, null, 0,  0.0, 0.0)
insert into Orders (OrderID, OrderDate, StoreID, CustomerID, PickerID, PickedDate, Delivery, SubTotal, GST) Values(4, GETDATE(), 1, 1, null, null, 0,  0.0, 0.0)
insert into Orders (OrderID, OrderDate, StoreID, CustomerID, PickerID, PickedDate, Delivery, SubTotal, GST) Values(5, GETDATE(), 1, 1, null, null, 0,  0.0, 0.0)
insert into Orders (OrderID, OrderDate, StoreID, CustomerID, PickerID, PickedDate, Delivery, SubTotal, GST) Values(6, GETDATE(), 1, 2, null, null, 0,  0.0, 0.0)
insert into Orders (OrderID, OrderDate, StoreID, CustomerID, PickerID, PickedDate, Delivery, SubTotal, GST) Values(7, GETDATE(), 1, 2, null, null, 0,  0.0, 0.0)
insert into Orders (OrderID, OrderDate, StoreID, CustomerID, PickerID, PickedDate, Delivery, SubTotal, GST) Values(8, GETDATE(), 1, 2, null, null, 0,  0.0, 0.0)
insert into Orders (OrderID, OrderDate, StoreID, CustomerID, PickerID, PickedDate, Delivery, SubTotal, GST) Values(9, GETDATE(), 1, 2, null, null, 0,  0.0, 0.0)
set IDENTITY_INSERT  Orders off
set IDENTITY_INSERT  OrderList on
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4000,2, 2, 2, 0, 0.0, 0.0, null, null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4001,2, 17, 1, 0, 0.0, 0.0, null, null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4002,3, 22, 1, 0, 0.0, 0.0, null, null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4003,3, 46, 1.5, 0, 0.0, 0.0, 'value package', null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4004,4, 49, 2, 0, 0.0, 0.0, null, null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4005,4, 69, 2, 0, 0.0, 0.0, null, null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4006,5, 76, 1, 0, 0.0, 0.0, null, null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4007,5, 127, 6, 0, 0.0, 0.0, null, null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4008,6, 2, 2, 0, 0.0, 0.0, null, null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4009,6, 17, 1, 0, 0.0, 0.0, null, null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4010,7, 22, 1, 0, 0.0, 0.0, null, null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4011,7, 46, 1.5, 0, 0.0, 0.0, 'value package', null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4012,8, 49, 2, 0, 0.0, 0.0, null, null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4013,8, 69, 2, 0, 0.0, 0.0, null, null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4014,9, 76, 1, 0, 0.0, 0.0, null, null)
insert into OrderList (OrderListID, OrderID, ProductID, QtyOrdered, QtyPicked, Price, Discount, CustomerComment, PickIssue) Values(4015,9, 127, 6, 0, 0.0, 0.0, null, null)
set IDENTITY_INSERT OrderList off
go



