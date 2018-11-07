

/*
Follwing assignment may be written in another file whose extension is sql such as "assignment.sql" so that it could be open in SSMS (SQL Server Management Studio) to execute it.

This file should be located somewhere in SQL folder and commit and push to student branch
*/
SELECT @@servername, @@version

USE pubs;

-- 1. Inner Join Statement
-- Scenario: we need following data. We need to join 5 tables. Research on google and exercise
-- title and type from titles table, pub_name from publishers, qty and paytersm from sales, name from stores, discounttype from discounts  table

	SELECT title,type,pub_name,qty,payterms,stor_name,discounttype
  	  FROM titles t1 
	INNER JOIN publishers t2 ON t1.pub_id = t2.pub_id 
	INNER JOIN sales  t3 ON t1.title_id = t3.title_id 
	INNER JOIN stores t4 ON t3.stor_id = t4.stor_id
	INNER JOIN discounts t5 ON t4.stor_id = t5.stor_id;

-- 2. Outer Join Statement (Left Ourter Join)
-- Scenario: Between Stores and Discounts table
-- Not all stores have discount information. Select "only" stores which does "NOT" ave discount
   SELECT stor_name, discount, discounttype
	 FROM stores t1 LEFT OUTER JOIN discounts t2
	   ON t1.stor_id = t2.stor_id 

-- 3. Run this, then you will get sale count per store.
-- select t1.stor_id, count(*) salesCount from sales t1
-- group by t1.stor_id
   
   SELECT stor_id, count(*) as salesCount
    from sales t1
	group by t1.stor_id

	
/*
result would be
6380	2
7066	2
7067	4
7131	6SELECT TOP(2) * from (SELECT stor_id, count(*) as salesCount
    from sales 
	group by stor_id ) tb1
    order by salesCount desc
7896	3
8042	4

*/
-- Get only second top sale's store (from result, we know 7067 and 8042 )
-- TIP: use "top", "order by", and following hint: you can make it sub query in where clauses
	SELECT TOP(2) * from (SELECT stor_id, count(*) as salesCount
		from sales 
		group by stor_id ) tb1
		order by salesCount desc


-- 4. Change following sub query to inner join statement
-- SELECT * FROM titles
-- WHERE title_id IN (SELECT title_id FROM sales);

	SELECT DISTINCT t1.*
	  FROM titles t1  INNER JOIN sales t2 
	    ON t1.title_id = t2.title_id

-- 5. self join : research on it and exercise (copy  & paste is allowed)

    SELECT t1.title_id
	  FROM sales t1 INNER JOIN sales t2 ON t1.title_id = t2.title_id
  GROUP BY t1.title_id
	HAVING COUNT(t2.title_id) > 1

-- 6. I know one of our classmate is working at ServiceDepot where user request service for repair. For that business, we need following two tables: Customer and Request tables. 

-- 6-1. For "Customer" table, please consider following:
--  1. use Script (Create table script)
--  2. define following columns. 
--     Id, UserName, Email,Password, FirstName, LastName, MiddleName, Address1,Address2, City, PostalCode, Province, Country, HomePhone, MobilePhone, RegisterDate, FBAccount, TwitterAccount		
--  3. Each column should have proper data type and null or not null constraints. Make Id as PK and Identity(1,1)
		
	CREATE TABLE Customer(
	  Id int NOT NULL IDENTITY(1,1)
     ,UserName nvarchar(50) NOT NULL
	 ,Email varchar(20) NULL
	 ,Password varchar(10) NOT NULL
	 ,FirstName varchar(20) NULL
	 ,LastName varchar(20) NULL
	 ,MiddleName varchar(20) NULL
	 ,Address1 varchar(40) NULL
	 ,Address2 varchar(40) NULL
	 ,City varchar(20) NULL
	 ,PostalCode char(6) NULL
	 ,Province varchar(20) NULL
	 ,Country varchar(20) NULL
	 ,HomePhone char(12) NULL
	 ,MobilePhone char(20) NULL
	 ,RegisterDate datetime NOT NULL
	 ,FBAccount char(20) NULL
	 ,TwitterAccount char(20) NULL
	 ,CONSTRAINT PK_Customer PRIMARY KEY (ID)
	 )
	GO
	--drop table Customer
	
-- 6-2. For "Request" table, please consider following:
--	1. use Script (Create table script)
--	2. define following columns.
--		Id, CustomerId, RequestContent, RequestDate, CompletedDate, Status, Comment, IsNotifiedToCustomer, IsNotifiedToTechnician
--	3. Each column should have proper data type and null or not null constraints. Make Id as PK and Identity(1,1) and CustomerId as FK (CustomerId must refer to Request table's Id) . Do not use any UI menu. All should be done with "SQL Script"
	
	CREATE TABLE Request(
		Id int NOT NULL IDENTITY(1,1)
  	   ,CustomerId int  NOT NULL
	   ,RequestContent nvarchar(50) NOT NULL
	   ,RequestDate datetime NOT NULL
	   ,CompleteDate datetime NULL
	   ,Status varchar(10) NOT NULL
	   ,Comment varchar(50) NULL
	   ,IsNotifiedToCustomer char(10) NULL
	   ,IsNotifiedToCTechnitian char(10)
	   ,CONSTRAINT PK_Request PRIMARY KEY (Id)
	   ,CONSTRAINT FK_Request FOREIGN KEY (CustomerId) REFERENCES Customer(Id)
)
	GO

	SELECT * FROM Customer

	SELECT * FROM Request

-- 7. Insert two customers using insert statement
 SET IDENTITY_INSERT Customer OFF
 INSERT INTO Customer(Id,UserName,Email,Password,FirstName,LastName,MiddleName,Address1,Address2,City,PostalCode,Province,Country,HomePhone,MobilePhone,RegisterDate,FBAccount,TwitterAccount)
 VALUES   (1,'StarPower','star@gmail.com','star123','Anne','Kim','JJ','25 Yonge st','East ','Thornhill','l2b0a2','Ontario','Canada','416-234-3232','647-236-1321',GETDATE(),'ABB ','ABC ');

 INSERT INTO Customer(Id,UserName,Email,Password,FirstName,LastName,MiddleName,Address1,Address2,City,PostalCode,Province,Country,HomePhone,MobilePhone,RegisterDate,FBAccount,TwitterAccount)
 VALUES   (2,'CodingAcademy','coding@gmail.com','coding777','Jeff','Lee','je','87 jane st','west ','NotthYork','L3b0a2','Ontario','Canada','905-234-3179','647526-1381',GETDATE(),'Abo ','qwC ');

-- 8. Insert four request (two request per one customer)

 SET IDENTITY_INSERT Request ON
 INSERT INTO Request(Id,CustomerId,RequestContent,RequestDate,CompleteDate,Status,Comment,IsNotifiedToCustomer,IsNotifiedToCTechnitian)
 VALUES (11,1,'Late delevery',GETDATE(),GETDATE(),'Processing','Urgent','Yes','No')

 INSERT INTO Request(Id,CustomerId,RequestContent,RequestDate,CompleteDate,Status,Comment,IsNotifiedToCustomer,IsNotifiedToCTechnitian)
 VALUES (12,1,'Not match',GETDATE(),null,'Stop','Urgent','Yes','No');

 INSERT INTO Request(Id,CustomerId,RequestContent,RequestDate,CompleteDate,Status,Comment,IsNotifiedToCustomer,IsNotifiedToCTechnitian)
 VALUES (13,2,'Size Error',GETDATE(),null,'Processing','Normal','No','No');

 INSERT INTO Request(Id,CustomerId,RequestContent,RequestDate,CompleteDate,Status,Comment,IsNotifiedToCustomer,IsNotifiedToCTechnitian)
 VALUES (14,2,'Change',GETDATE(),null,'Notice','Normal','Yes','Ye');


-- 9. "Referential Integrity" confirmation
-- Confirm following: 
-- Delete from Customer should throw "error" (This is expected behavior)
-- Insert into request (with CustomerId as 99 which does not exist in Customer) should throw "error" (This is expected behavior)
	DELETE FROM Customer
	WHERE Id = 99 and UserName = 'Angel';

	INSERT INTO Request(Id,CustomerId,RequestContent,RequestDate,CompleteDate,Status,Comment,IsNotifiedToCustomer,IsNotifiedToCTechnitian)
	VALUES (15,99,'Error',GETDATE(),null,'Processing','Normal','Yes','Yes');

-- 10. Create Stored procedure for selecting information
-- name: uspGetCustomer
-- parameter: userName
-- logic: once username is passed, this should return All Customer information
	CREATE PROC uspGetCustomer
	@v_userName nvarchar(50)
	AS
	SELECT * FROM Customer 
	WHERE UserName = @v_userName 

	Go

	EXEC uspGetCustomer 'StarPower'
	
-- 11. Create Stored procedure for selecting information
-- name: uspGetCustomerRequest
-- parameter: userName
-- logic: once username is passed, this should return Email, Address1, City, PostalCode, Province and RequestDate, RequestContent, Comment (you need to join Customer and Request inside stored proc)
	CREATE PROC uspGetCustomerRequest
	@v_userName nvarchar(50)
	ASSELECT * FROM Request t1
		WHERE t1.CustomerId = (SELECT t2.Id FROM Customer t2 WHERE t2.UserName = @v_userName)

	EXEC uspGetCustomerRequest 'StarPower';


-- 12. Create Stored procedure for insert Request
-- name: uspAddCustomerRequest
-- parameter: userName, RequestContent, RequestDate, CompletedDate, Status, Comment, IsNotifiedToCustomer, IsNotifiedToTechnician, 
-- output parameter: rowAffected OUTPUT

	CREATE PROC uspAddCustomerRequest
	@v_Id int, @v_userName nvarchar(50), @v_RContent nvarchar(50), @v_RDate datetime, @v_CDate datetime,
	@v_Status varchar(10), @v_Comment varchar(50), @v_IsNotifiedToCustomer char(10), @v_IsNotifiedToTechnition char(10),
	@v_output int OUTPUT

	AS
	DECLARE @v_cusId int
    SELECT Id=@v_cusId  FROM Customer 
	WHERE UserName = @v_userName
	
	INSERT INTO Request(Id, CustomerId,RequestContent,RequestDate,CompleteDate,Status,Comment,IsNotifiedToCustomer,IsNotifiedToCTechnitian) 
	VALUES(5, 1, 'Size Error', GETDATE(), GETDATE(),@v_Status, @v_Comment, @v_IsNotifiedToCustomer,@v_IsNotifiedToTechnition)

	SET @v_output = (SELECT @@ROWCOUNT)

	-- execution
	DECLARE @v_effected_rows int
	EXEC uspAddCustomerRequest 5, 'CodingAcademy','Size Error',GETDATE,GETDATE,'Processing','Normal','Yes','No'
   ,@v_effected_rows OUTPUT
	SELECT @v_effected_rows

	
