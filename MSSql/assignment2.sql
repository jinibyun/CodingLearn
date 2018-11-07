/*
Follwing assignment may be written in another file whose extension is sql such as "assignment.sql" so that it could be open in SSMS (SQL Server Management Studio) to execute it.

This file should be located somewhere in SQL folder and commit and push to student branch
*/

-- 1. Inner Join Statement
-- Scenario: we need following data. We need to join 5 tables. Research on google and exercise
-- title and type from titles table, pub_name from publishers, qty and paytersm from sales, name from stores, discounttype from discounts  table

SELECT t.title, t.[type], pb.pub_name, sls.qty, sls.payterms
FROM titles t
INNER JOIN publishers AS pb
ON t.pub_id = pb.pub_id
INNER JOIN sales AS sls
ON sls.title_id = t.title_id
INNER JOIN stores AS st
ON st.stor_id = SLS.stor_id
INNER JOIN discounts AS ds
ON ds.stor_id = st.stor_id;



-- 2. Outer Join Statement (Left Ourter Join)
-- Scenario: Between Stores and Discounts table
-- Not all stores have discount information. Select "only" stores which does "NOT" have discount

SELECT * FROM stores AS st LEFT OUTER JOIN discounts AS ds ON st.stor_id = ds.stor_id AND ds.discount = NULL;

-- 3. Run this, then you will get sale count per store.
-- difficulty: ¡Ú¡Ú¡Ú
 select t1.stor_id, count(*) salesCount from sales t1
 group by t1.stor_id

 -- display stor_id and saleRank
SELECT t1.stor_id, RANK() OVER (ORDER BY COUNT(*) DESC) as saleRank 
FROM sales t1 group by t1.stor_id
ORDER BY saleRank ASC

-- rank by qty
SELECT stor_id, qty, RANK() OVER (ORDER BY qty DESC) as qtyRank from sales

-- ANSWER:
-- note: when a SELECt query is used as a table, "ORDER BY" in the subquery cannot be used.
SELECt * FROM
(SELECT t1.stor_id, COUNT(*) as saleCount, RANK() OVER (ORDER BY COUNT(*) DESC) as saleRank 
FROM sales t1 group by t1.stor_id) t WHERE t.saleRank = 2



/* 
result would be
6380	2
7066	2
7067	4
7131	6
7896	3
8042	4
*/
-- Get only second top sale's store (from result, we know 7067 and 8042 )
-- TIP: use "top", "order by", and following hint: you can make it sub query in where clauses



-- 4. Change following sub query to inner join statement
-- no duplicate title in the following query
 SELECT * FROM titles
 WHERE title_id IN (SELECT title_id FROM sales)

 -- ANSWER:
 SELECT DISTINCT t1.* FROM titles t1 INNER JOIN sales t2 ON t1.title_id = t2.title_id




-- 5. self join : research on it and exercise (copy  & paste is allowed)

-- ref: https://www.w3schools.com/sql/sql_join_self.asp

SELECT * FROM stores a ORDER BY a.city

-- connections between stores in each same sate
-- I wanted to remove duplicates that their storeA and storeB orders are just opposite
-- but I don't know
SELECT a.stor_name as StoreA, b.stor_name as StoreB, a.[state]
FROM stores a, stores b 
WHERE a.stor_id <> b.stor_id AND a.[state] = b.[state]
ORDER BY a.[state]

-- 6. I know one of our classmate is working at ServiceDepot where user request service for repair. For that business, we need following two tables: Customer and Request tables. 
-- 6-1. For "Customer" table, please consider following:

--	1. use Script (Create table script)
--	2. define following columns. 
--		Id, UserName, Email,Password, FirstName, LastName, MiddleName, Address1,Address2, City, PostalCode, Province, Country, HomePhone, MobilePhone, RegisterDate, FBAccount, TwitterAccount		
--	3. Each column should have proper data type and null or not null constraints. Make Id as PK and Identity(1,1)

DROP TABLE CustomerQ6
CREATE TABLE CustomerQ6 
(
	Id int PRIMARY KEY Identity(1, 1),
	UserName VARCHAR(20) NOT NULL,
	Email VARCHAR(20) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	MiddleName VARCHAR(20) NULL,
	Address1 VARCHAR(20) NOT NULL,
	Address2 VARCHAR(20) NULL,
	City VARCHAR(20) NOT NULL,
	PostalCode VARCHAR(6) NOT NULL,
	Province VARCHAR(20) NOT NULL,
	Country VARCHAR(20) NOT NULL,
	HomePhone VARCHAR(15) NULL,
	MobilePhone VARCHAR(15) NOT NULL,
	RegisterDate Date NOT NULL
)




-- 6-2. For "Request" table, please consider following:
--	1. use Script (Create table script)
--	2. define following columns.
--		Id, CustomerId, RequestContent, RequestDate, CompletedDate, Status, Comment, IsNotifiedToCustomer, IsNotifiedToTechnician
--	3. Each column should have proper data type and null or not null constraints. Make Id as PK and Identity(1,1) and CustomerId as FK (CustomerId must refer to Request table's Id) . Do not use any UI menu. All should be done with "SQL Script"
	
drop table RequestQ6
CREATE TABLE RequestQ6 
(
	Id int PRIMARY KEY Identity(1, 1),
	CustomerId int FOREIGN KEY REFERENCES CustomerQ6(Id),
	RequestContent VARCHAR(500) NOT NULL,
	RequestDate Date NOT NULL,
	CompleteDate Date NULL,
	[Status] VARCHAR(20) NOT NULL,
	Comment VARCHAR(500) NOT NULL,
	IsNotifiedToCustomer bit,
	IsNotifiedToTechnician bit
)


-- 7. Insert two customers using insert statement
INSERT CustomerQ6 VALUES('MichaelJackson', 'mjcksn@gmail.com', '1q2w3e', 'James', 'Brown', NULL, 
'543 Markham Rd', NULL, 'Scarborough', 'M3P9F3', 'Ontario', 'Canada', 17864561234, 15684561234, CONVERT(datetime, '2016-05-12', 120));
INSERT CustomerQ6 VALUES('MarkDwain', 'dwain12@gmail.com', 'password', 'Dwain', 'Mark', NULL, 
'3343 Lawrence Rd', NULL, 'Scarborough', 'I9F7F3', 'Ontario', 'Canada', 18972511444, 18525468877, CONVERT(datetime, '2017-08-30', 120));

SELECT * FROM CustomerQ6;

-- 8. Insert four request (two request per one customer)

INSERT RequestQ6 VALUES(1, 'Laptop Repair', CONVERT(datetime, '2017-05-22', 120), CONVERT(datetime, '2017-05-27', 120), 'Complete', 'Please be careful about its fan module'
, 1, 1);

INSERT RequestQ6 VALUES(1, 'Desktop Repair', CONVERT(datetime, '2017-08-02', 120), CONVERT(datetime, '2017-08-15', 120), 'Complete', ''
, 1, 1);

INSERT RequestQ6 VALUES(2, 'Infected Laptop', CONVERT(datetime, '2017-06-22', 120), CONVERT(datetime, '2017-06-27', 120), 'Complete', 'The laptop has been formatted'
, 1, 1);

INSERT RequestQ6 VALUES(2, 'Complain services', CONVERT(datetime, '2018-11-07', 120), NULL, 'Progressing', 'Services Complain'
, 0, 0);

SELECT * FROM RequestQ6


-- 9. "Referential Integrity" confirmation
-- Confirm following: 
-- Delete from Customer should throw "error" (This is expected behavior)
-- Insert into request (with CustomerId as 99 which does not exist in Customer) should throw "error" (This is expected behavior)

DELETE CustomerQ6;

-- 10. Create Stored procedure for selecting information
-- name: uspGetCustomer
-- parameter: userName
-- logic: once username is passed, this should return All Customer information

DROP PROC uspGetCustomer
CREATE PROC uspGetCustomer
@v_userName VARCHAR(20)
AS
SELECT * FROM CustomerQ6 
WHERE UserName = @v_userName 

EXEC uspGetCustomer 'MichaelJackson'

-- 11. Create Stored procedure for selecting information
-- name: uspGetCustomerRequest
-- parameter: userName
-- logic: once username is passed, this should return Email, Address1, City, PostalCode, Province and RequestDate, RequestContent, Comment (you need to join Customer and Request inside stored proc)

DROP PROC uspGetCustomerRequest
CREATE PROC uspGetCustomerRequest
@v_userName VARCHAR(20)
AS
SELECT t1.Email, t1.Address1, t1.City, t1.PostalCode, t1.Province, t2.RequestDate, t2.RequestContent, t2.Comment 
FROM CustomerQ6 t1
INNER JOIN RequestQ6 t2
ON t1.Id = t2.CustomerId AND UserName = @v_userName

EXEC uspGetCustomerRequest 'MichaelJackson'

-- 12. Create Stored procedure for insert Request
-- name: uspAddCustomerRequest
-- parameter: userName, RequestContent, RequestDate, CompletedDate, Status, Comment, IsNotifiedToCustomer, IsNotifiedToTechnician, 
-- output parameter: rowAffected OUTPUT
-- logic: once username is passed, call "uspGetCustomer" (#10 assignment above) to get "customerId", then insert this "customerId" with other parameter (RequestContent, RequestDate...), insert into Request table. Once inserted, set @@rowcount to rowAffected output parameter

	
DROP PROC uspAddCustomerRequest
CREATE PROC uspAddCustomerRequest
@v_userName VARCHAR(20),
@v_RequestContent VARCHAR(500),
@v_RequestDate Date,
@v_CompleteDate Date,
@v_Status VARCHAR(20),
@v_Comment VARCHAR(500),
@v_IsNotifiedToCustomer bit,
@v_IsNotifiedToTechnician bit
AS
INSERT RequestQ6 VALUES(
(SELECT t1.Id FROM CustomerQ6 t1 WHERE t1.UserName = @v_userName),	-- user id
@v_RequestContent, @v_RequestDate, @v_CompleteDate, @v_Status, @v_Comment, @v_IsNotifiedToCustomer, @v_IsNotifiedToTechnician);

EXEC uspAddCustomerRequest 'MichaelJackson'





