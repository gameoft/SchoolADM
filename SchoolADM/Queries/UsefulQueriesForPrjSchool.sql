

--ALTER LOGIN sa ENABLE 
--ALTER LOGIN sa WITH PASSWORD = 'Armadillo1!'

Select * from sys.database_principals where name = 'Securables' and type = 'R'

USE [SchoolADM]

--2017-12-24


--2017-12-20
--select * from [dbo].[Customers]
--select * from [dbo].[WorkOrders]
--select * from [dbo].[Parts]
--select * from [dbo].[InventoryItems]
--select * from [dbo].[Categories]

select * from [dbo].[AspNetUsers]
--update [dbo].[AspNetUsers] set EmailConfirmed=1


select * from [dbo].[AspNetUserClaims]


select * from [dbo].[AspNetUserRoles]

select * from [dbo].[AspNetRoles]


select * from LogEntries

select DISTINCT(DateAdd(d, 0, Getdate())) from LogEntries
select * from LogEntries where EntityKeyValue = 6 and LogDate > DateAdd(d, -1, Getdate())

DELETE FROM LogEntries
FROM 
	EntityKeyValue = 13
	
	LogEntries.EntityKeyValue = 13

	LogEntries.LogDate < DateAdd(d, -10, Getdate())


SELECT * FROM 
	Logentries
FROM
	LogEntries.EntityKeyValue = 6

	

select * from [dbo].[WorkOrders]
update [dbo].[WorkOrders] set [Description] = 'prova 2 updated' where WorkOrderId = 4
select * from [dbo].[WorkOrders]