/* ----------------------------------------------------------------------------------
A: DML : Data MANIPULATION Language
1. SELECT	2.INSERT	3.UPDATE	4.DELETE

	Table Records ����
*-----------------------------------------------------------------------------------*/
--
/* --------------------------------------------------
A-1. Simple Select Statement

Basic use of queries and SQL functions
--------------------------------------------------- */

SELECT @@servername, @@version	-- ��ȫ�� ���ڴ� ����Ǿ��ִ� �Լ�, ������ ��Ÿ��. @@�� ��������.

USE pubs
GO		-- GO is ';' in programming. it can be skipped.

SELECT * FROM titles
GO
SELECT title_id, title, [type] FROM TITLES --type ���̺� ���ڰ� �Ķ����̾��µ� �򰥸� �� ������ []�ȿ� �־� �ξ���. �ص� �ǰ� ���ص� �ǰ�.
GO
SELECT title_id AS bookID, title AS bookTitle, type AS bookType FROM TITLES		-- �������� Column �̸��� �ٲ㼭 ������.
GO
-- 
SELECT bookID=title_id, bookTitke=title, bookType=type FROM TITLES

-- TIP: system stored procedure
EXEC sp_tables		-- EXEC�̶�� �Լ��� ȣ��. �Լ����� pubs/Programmability/Functions�� ����Ǿ� �ִ�. Function�� �� �𸣰����� ���� Ȯ���ϰų� ���۸�

select * from sysobjects where type = 'U'
-- system sp
sp_columns titles		-- �̰͵� �Լ�.

select * from syscolumns where id = object_id('titles') 

-- Declare keyword
-- specific data type: table
DECLARE @T TABLE (id int, name varchar(8))	-- DCLARE�� ���� ����. ���� �տ��� @�� ���̴� �� ��Ģ.
							-- T��� Table�� ����.
INSERT @T values(10,'Joe')	-- record �ϳ� ����
SELECT * FROM @T

-- set keyword, sql_variant type
DECLARE @T1 sql_variant, @T2 sql_variant
set @T1 = 12345				-- ���� ���� ���� �� set�� ����
set @T2 = 'this is string'
select @T1					-- ���� ������ �� select
select @T2

DECLARE @t1001 INT		-- example
SET @t1001 = 123456
select @t1001

/* sql built-in function
* ���� �߿䵵�� ��Ÿ��
** Aggregate Functions 
Configuration Functions
Cursor Functions
** Date and Time Functions
** Mathematical Functions
Metadata Functions
Security Functions
** String Functions
System Functions
System Statistical Functions
Text and Image Functions
** : Often Used
*/ 

-- example of using function 
-- NOTE: When using "functions", use it with "SELECT"

SELECT AVG(advance) FROM titles
SELECT SUM(price), SUM(advance) FROM titles
SELECT COUNT(*) FROM titles -- == SELECT COUNT(title) FROM titles
SELECT MAX(ytd_sales) FROM titles
SELECT min(ytd_sales) FROM titles 

-- Date function
SELECT GETDATE()
SELECT DATEADD(day, 21, pubdate) AS timeframe FROM titles
SELECT DATEDIFF(day, pubdate, getdate()) AS no_of_days FROM titles
SELECT DATEPART(month, GETDATE()) AS 'Month Number'

-- Math function
SELECT ABS(-1.0), ABS(0.0), ABS(1.0)
SELECT RAND(1) AS Random_Number
SELECT ROUND(123.9994, 3), ROUND(123.9995, 3) 
SELECT ROUND(123.9994, 3), ROUND(123.9995, 3) 

-- String
SELECT LEFT(title, 5) FROM titles
SELECT LEN(title) FROM titles
SELECT LOWER(title) AS LowerCase FROM titles
SELECT UPPER(au_lname) AS UpperCase FROM authors


DECLARE @temp_string varchar(100)
SET @temp_string = ' abcdefg'
SELECT LTRIM(@temp_string)

SELECT PATINDEX('%the%', title) as firstPlaceOfString FROM titles

SELECT REPLACE('Here is Canada','Canada','Korea')

SELECT REVERSE(au_fname) FROM authors

SELECT RIGHT(au_fname, 5) FROM authors

SELECT au_fname, SUBSTRING(au_fname, 3, 2) FROM authors

/* ---------------------------------------------------
A-1. Select Statement

SELECT query with 

filtering, distinct, order by, group by, join, sub Query,
union, select into
---------------------------------------------------- */
USE pubs
GO

-- where filtering
SELECT * FROM sales where qty > 10		-- where�� if�� �����.

SELECT * FROM authors WHERE zip > 90000

-- string: not double quotation, but single one
SELECT * FROM authors WHERE state = 'CA'			-- string�� ''�� ǥ����. ��� SQL���� Char�� ���� ��� String��

-- NB: price = null 
-- price = null (wrong)
SELECT title FROM titles WHERE price IS NULL	-- price IS NOT NULL

SELECT title_id, ytd_sales 
FROM titles 
WHERE ytd_sales > 4095 AND ytd_sales < 12000

SELECT title_id, ytd_sales 
FROM titles 
WHERE ytd_sales between 4095 AND 12000


-- Interview Question �ڡڡ�
-- When a stupid guy put a space in a column, then how will you handle it?  like this "Home Address"  (HomeAddress is correct)
-- In this case, changing the name is very dangerous. do not change it, just put [ ] beside it.
-- [Home Address]
-- [type]
SELECT title, type FROM titles 
WHERE type IN ('mod_cook', 'trad_cook')


SELECT title, type FROM titles 
WHERE type NOT IN ('mod_cook', 'trad_cook')

-- same as the first above one
SELECT title, type FROM titles 
WHERE type = 'mod_cook' OR type = 'trad_cook'

-- Like pattern match
SELECT stor_name FROM stores 
WHERE stor_name LIKE '%Books%'		-- % is any character

SELECT stor_name FROM stores
WHERE stor_name LIKE 'Bo%'

SELECT stor_name FROM stores
WHERE stor_name LIKE 'E_i%'

SELECT stor_name FROM stores
WHERE stor_name LIKE 'B[^a]%'

SELECT title_id, title, pub_id, price, pubdate
FROM titles
WHERE (title LIKE 'T%' OR pub_id = '0877') AND (price > $16.00)		-- ��ȣ���� ������. ���⼭ OR �κ� ��ȣ ���ָ� AND ���� �����. �ֳ��ϸ� AND�� ���ϱ� �����̶�. OR�� ���ϱ� ������ ��

SELECT title_id, title, pub_id, price, pubdate
FROM titles
WHERE (title LIKE 'T%') OR (pub_id = '0877' AND price > $16.00)

SELECT title_id, title, pub_id, price, pubdate
FROM titles
WHERE title LIKE 'T%' OR pub_id = '0877' AND (price > $16.00)		-- ���� �����Ѵ�� AND���� ������.

-- TOP
-- TODO
SELECT TOP 10 * FROM titles;		--���� �ѱ� ����Ʈ �Խ��� ���� �̷������� �ֻ��� �Խñ۵��� ǥ����

-- Distinct
-- compare
SELECT au_id FROM titleauthor
SELECT DISTINCT au_id FROM titleauthor		-- DISTINCT: ��ġ�� ������ ���ְ� ������

-- NOTE: text type column(over 8000 characters), image type column are not possible �ֳ��ϸ� ���� �����Ͱ� �� �ִ°� �ƴ϶� �װ� ����Ű�� ��巹���� ����Ǿ� �־.
SELECT DISTINCT * FROM titleauthor
SELECT * FROM titleauthor

-- Order By
/*
Column name or number
Asc is "by default".
NOTE: text type column, image type column are not possible
*/
-- compare
SELECT city, au_fname, au_lname FROM authors		-- default order is ascending

SELECT city, au_fname, au_lname FROM authors
ORDER BY city

-- Same as above
SELECT city, au_fname, au_lname FROM authors		--  ex) 1, 2, 3, 4 ..
ORDER BY city ASC

SELECT city, au_fname, au_lname FROM authors		--  ex) 4, 3, 2, 1
ORDER BY city DESC

SELECT city, au_fname, au_lname FROM authors			
ORDER BY city ASC, au_fname ASC

SELECT city, au_fname, au_lname FROM authors  WHERE city like '%oak%'		-- where�� order by �տ��� �� �� �ִ�
ORDER BY city ASC

-- �ڡڡ�
-- group by
-- analytical data with aggregate function: sum, avg, count, min, max
-- group by�� ��ü������ distinct��ɵ� �ִٰ� ���� ��. distinct�� �ᵵ �ߺ��� ��� �����ϰ� �׷���� �����ֱ� ����

--SELECT select_list
--FROM table_name
--[WHERE search_conditions] -- optional
--GROUP BY [ALL] aggregate_free_expression [, aggregate_free_expression?]
--[HAVING search conditions] ?optional

-- compare
select pub_id, type, royalty, ytd_sales 
from titles

select pub_id, type, royalty, ytd_sales, AVG(price)
from titles
GROUP BY pub_id, type, royalty, ytd_sales	-- GROUP BY���� SELECT�� aggregate func���� ��� �׸� �̻��� ���� ��. �ȱ׷��� ����.

select type, sum(price)
from titles
group by type

SELECT title_id, copies_sold = SUM(qty)
FROM sales
GROUP BY title_id
HAVING SUM(qty) > 20			-- HAVING�� Group By�� ���� Return�� ���� ������� ���� ����.  Group By���� WHERE�̶�� ���� ��.

SELECT title_id, copies_sold = SUM(qty)
FROM sales
WHERE ord_date BETWEEN '1/1/1994' AND '12/31/1994'
GROUP BY ALL title_id			-- NULL���� ������. ALL ������ NULL������ �����ϰ� ������.

-- Discount�� ���� ���� DiscountTyp�� ���. SubSelect ����� ��
SELECT discounttype, discount 
FROM discounts 
WHERE discount = (SELECT MAX(discount) FROM discounts)

-- Normalization�� Entity���� �ߺ����� ���� ����ȭ ��Ű���� �ּ����� ��������� ������ �� ����.
-- Reciept Entity�� �ְ� ��ǰ �� ��� ������ ��ǰ ��� ���������� ���� �ΰ� ��� ��� ������ �ι��̳� �ߺ��Ǵ� ��� enity�� product entity�� �ɰ��� ��.
-- DeNomalization�� ���� �������� �ɰ��� Entity���� �ٽ� ��ġ�� ��.
-- SSMS���� ERD���� ������ pubs/Database DIagrams���� ������ Ŭ��, new DB diagram�ؼ� ���� ��.



-- Join �ڡڡ�
-- Join by identical column (Physical and Logical)
-- Data Normalization and Denormalization with ERD
-- INNER JOIN / OUTER JOIN / CROSS JOIN/ SELF JOIN

-- if you wanna see a diagram, please see 'Database Diagrams' on Object Explorer, or view dependencies by right clicking on a table

SELECT * from authors
SELECT * FROM publishers


-- inner join
-- ���̺� �� ��, �ۿ� �۰� ������ ���� ��ġ�� �κи� ������.
-- ex) t1: 1, 2, 3, 4; t2: 3, 4, 5, 6 �̸� 3, 4 ��ġ�� �κи� ������.

SELECT *
FROM authors AS a INNER JOIN publishers AS p
ON a.city = p.city

--ǥ������
-- ANSI Syntax
SELECT pub_name, title
FROM titles t1 INNER JOIN publishers t2
ON titles.pub_id = publishers.pub_id	-- On equality condition
WHERE t1.price > 20


--����ũ�μ���Ʈ�� ���� ���� �ǵ� ������ ��õ
-- T-SQL Syntax
SELECT authors.au_lname, authors.state, publishers.*
FROM publishers, authors
WHERE publishers.city = authors.city



-- outer join
-- innerjoing + Į������ ���� ���� �κе���� SELECT. Į���� �������� ������ null�� ������.
-- LEFT�� ���ʿ� ���� ���̺��� ��� ���ڵ带 ������. ������ ���̺�� ��ġ�� �Ȱ�ġ��. RIGHT�� �� �ݴ�.
-- �ٵ� �����δ� ������� RIGHT ���� �����Ƽ� ���� Table�̸��� ������ �ٲ㼭 �����.
-- ex) LEFT OUTER JOIN �ϳ��� �� �ȸ� å�� ������ �� outer join ���. ���ȸ� å���� �ȸ� history������ ���̺� ����� ������.
-- ex) RIGHT�� ��� ��� ���� å�� �� �� ������ null���� �ȳ���.
SELECT title, stor_id, ord_num, qty, ord_date
FROM titles LEFT OUTER JOIN sales
ON titles.title_id = sales.title_id


-- ������ ����. written in 2018/10/31
-- cross join
SELECT au_fname, au_lname, pub_name
FROM authors CROSS JOIN publishers 

-- self join 
-- TODO
select t1.* from titleauthor t1 order by t1.title_id asc
-- same as the below. ���̺� �ϳ��� �ΰ��� ������ ������ ��ó�� ����. �Ʒ��� �ι��� �ߺ��Ǵ� �� ���� ���������� �ߺ��� �Ⱥ��� �ִ� ��.
select t1.* from titleauthor t1 INNER JOIN titleauthor t2 ON t1.title_id = t2.title_id order by t1.title_id asc

-- Sub Query
SELECT * FROM titles
WHERE title_id IN (SELECT title_id FROM sales)
-- �Ʒ��� ���ٰ� ���� ��
	SELECT * FROM titles
	WHERE title_id IN ('BU1032', 'BU1111', 'BU2075', '.........')


-- ��������: =�� ������� ���� �� �񱳴���� ������ �ϳ����� ��.
-- �ΰ� �̻��� �� �� ������ ���� �� �Ʒ��� ����ó�� IN (��1, ��2) �̷��� �־����.
-- �Ʒ� sub query�� �װ��� ������� �ϳ����̶� �۵���.
SELECT * FROM titles
WHERE title_id = (SELECT title_id FROM sales WHERE title_id like 'PS2106')

SELECT title FROM titles
WHERE title_id IN -- IN Keyword
(SELECT DISTINCT title_id FROM sales)

-- related subquery : repalce it with join query
-- TODO


-- select into: create a table from another table
-- ������ sales2��� ���̺��� ���µ� ���� SELECT ���� ��� ����
-- ���� �� DB refresh�ϸ� ���� ������ sales2�� �� �� ����.
SELECT * 
INTO sales2
FROM sales

Select * FROM sales2
DROP TABLE sales2
-- TODO




-- UNION
-- �� ���̺��� records�� ��� ��ħ. Row ��������.
-- ����: record�� column ���� ���ƾ���.


-- Interview question: What is different between UNION and UNION ALL? �ڡ�
-- A: UNION�� UNIQUE�� ��� �ߺ��Ǵ� �ֵ��� �߰� ���ϰ� �ߺ� �ȵǴ� �ֵ鸸 �����ؼ� ��� ��ħ.
--	  UNION ALL�� UNIQUE�� �ƴϵ� ��� ���ļ� ����� ��. �ߺ� ����.
-- EX
Select * FROM sales t1
UNION ALL
Select * FROM sales2 t2
-- ���� stor_id�� Unique�Ӽ��̶� �ߺ��Ǽ� ���ļ� 42���� �ƴ϶� 21���� ����.
-- UNION ALL�� ����ϸ� �� 42���� ��.

-- Another Interview question:
--  �ֻ��� 2���� select
SELECT TOP 2 * FROM sales t1 order by t1.qty 

/* ---------------------------------------------------
A-2. Insert Statement

SQL datatype in table, default value, null or not null, 
PK-FK: Referential Integrity
BEGIN TRAN and COMMIT TRAN
---------------------------------------------------- */
CREATE TABLE test1(
	 columnA varchar(10)	-- column name, type
	,columnB int
)
GO

INSERT INTO test1 VALUES('John',1)
INSERT INTO test1 VALUES('Jane',2)
INSERT INTO test1 VALUES('Wilson',3)
DROP TABLE test1;


-- TODO: Referential Integrity Test �ڡڡڡڡڡ�
-- Interview Question: Referential Integrity �����϶�. �׷� ������ PK, FK�� ������ ���;� ��
-- �����޴� PK�� ���� �ִ� ���̺��� �θ� ���̺��̰� FK�� �ִ� ���̺��� �ڽ� ���̺���.
-- Integrity�� ���Ἲ�� ����. ������ �����Ͱ� ������ �ȵ�. �����ⵥ���� �Է� �����ؾ���. 
-- 1st Integrity: FK�� �������� PKŰ�� �ԷµǸ� ������.
-- 2nd Integrity: �����޴� PK�� ���� �� ����.
-- Relational Database ���� ������ ������ �̰� �� ����.

CREATE TABLE Category(
	 id int PRIMARY KEY		-- Primary Key: not null, not duplicate
	,name nvarchar(50)
	-- varchar: varchar(1)�̸� 1����Ʈ. �� ���ڿ� 1����Ʈ�� �Ҵ�Ǳ⿡ �⺻������ ������ 1����Ʈ¥�� ���ڵ�ۿ� ����.
	-- nvarchar: nvarchar(1)�̸� 2����Ʈ �Ҵ��. �� ���ڸ� ������ 2����Ʈ�� ���� �Ҵ���. �ѱ��̳� ���� �� ��� �ƴ� �۵� �����ϱ⿡ ����.
)
GO

CREATE TABLE Product(
	CategoryId int
	, id int PRIMARY KEY		-- Primary Key: not null, not duplicate
	,name nvarchar(50)
)
GO

INSERT INTO Category(id, name) VALUES (1, 'Electronic' );
INSERT INTO Category(id, name) VALUES (2, 'Home');
INSERT INTO Product(CategoryID, id, name) VALUES (1, 1, 'Smartphone' );
INSERT INTO Product(CategoryId, id, name) VALUES (2, 2, 'Humidifier');
INSERT INTO Product(CategoryId, id, name) VALUES (1, 3, 'Laptop');
-- PK, FK relationship through using GUI: Table Designer tab > Relationship Icon button

SELECT t1.name as 'category', t2.name as 'product' from Category t1 inner join Product t2 on t1.id = t2.CategoryId;

INSERT INTO Product(CategoryId, id, name) VALUES (3, 4, 'Laptop');


SELECT * FROM Category
GO
SELECT * FROM Product
GO

DROP TABLE Category, Product;






-- Insert with select
-- Insert records into a table from Select records from another table.
INSERT INTO test1
SELECT * FROM test1

SELECT * FROM test1
/* ---------------------------------------------------
A-3. Update Statement

SQL datatype in table, default value, null or not null, 
PK-FK: Referential Integrity
BEGIN TRAN and COMMIT TRAN
---------------------------------------------------- */

-- Before
SELECT title_id, price, title 
FROM titles WHERE title_id like 'BU1032'

UPDATE titles
SET price = price * 2
WHERE title_id like 'BU1032'

-- After
SELECT title_id, price, title 
FROM titles WHERE title_id like 'BU1032'

-- Update with Select
UPDATE titles
SET price = price * 2
WHERE pub_id IN
	(SELECT pub_id
	FROM publishers
	WHERE pub_name = 'New Moon Books')

/* ---------------------------------------------------
A-4. Delete Statement

SQL datatype in table, default value, null or not null, 
PK-FK: Referential Integrity
BEGIN TRAN and COMMIT TRAN

Referential Integrity
DELETE FROM and Trancate Table
---------------------------------------------------- */
SELECT * FROM Category 
SELECT * FROM Product 

DELETE FROM Category	-- Interview Question �ڡ� Delete �ϳ��� ������ Record�� ����.
WHERE id = 1



SELECT * FROM authors

-- NOTE: PK, FK
DELETE FROM authors
WHERE au_lname = 'McBadden'

DELETE FROM titleauthor 
WHERE title_id IN 
(SELECT title_id 
FROM titles
WHERE title LIKE '%computers%')

/* ----------------------------------------------------------------------------------
B: DDL : Data Definition Language
1.CREATE  	2.DROP		3.ALTER	
---------------------------------------------------------------------------------- */
-- Data Type Confirmation
-- SQL Object : Table, View, etc
-- DB�� Object �������θ�.. DML (Data Manipulation Language) ���� �� A��Ʈ�� DB�� Record ����

/* ---------------------------------------------------
B-1. Create 
---------------------------------------------------- */
CREATE TABLE testTable(user_id int)

INSERT INTO testTable VALUES(1)INSERT INTO testTable VALUES(2)

SELECT * FROM testTable

CREATE TABLE testTable2(
	user_id int identity(1,1)
	,user_content varchar(10)
)
INSERT INTO testTable2 VALUES('Hi')
--Error : Why?				 vchar(10)�ε� 10���� �Ѿ�� truncated, �� �߷�����.
INSERT INTO testTable2 VALUES('Hi I am hungry')

--Error : Why?				 Identity ������ user_id�� ���� �Է��� �� ����. �ڵ������Ǳ� ������
INSERT INTO testTable2 VALUES(3, 'Hi')
SELECT * FROM testTable2	

/* ---------------------------------------------------
B-2. Alter and Drop
---------------------------------------------------- */
ALTER TABLE testTable2 
ALTER COLUMN user_content VARCHAR(20) NOT NULL
GO

--Error : Why work?		Solved after Alter the data type VARCHAR(10) to VARCHAR(20)
INSERT INTO testTable2 VALUES('Hi I am hungry')

SELECT * FROM testTable2

ALTER TABLE testTable2 
ADD gender bit NULL
GO
-- see table info
EXEC sp_help testTable2 
GO

ALTER TABLE testTable2 
DROP COLUMN gender GO

EXEC sp_help testTable2 GO

/* ----------------------------------------------------------------------------------
C: Data Integrity and Consistency
*-----------------------------------------------------------------------------------*/

-- Domain Integrity: per table 
	-- column constraint
-- Referential Integrity: between tables
	-- PK, FK
CREATE TABLE testTable4( 
       Name VARCHAR(10) NOT NULL PRIMARY KEY 
       ,Age TINYINT NULL 
)

INSERT INTO testTable4(Name, Age) VALUES('aaa', 19) 
-- Error
INSERT INTO testTable4(Name, Age) VALUES('aaa', 20)

--
CREATE TABLE Role( 
       RoleID INT NOT NULL PRIMARY KEY 
       ,RoleName VARCHAR(10) NOT NULL 
)
INSERT INTO Role(RoleID , RoleName ) VALUES(1, 'admin') 
INSERT INTO Role(RoleID, RoleName ) VALUES(2, 'guest') 
INSERT INTO Role(RoleID, RoleName ) VALUES(3, 'member')

CREATE TABLE Employee2( 
       EmpID VARCHAR(10) NOT NULL PRIMARY KEY 
       ,EmpName VARCHAR(10) NULL 
       ,RoleID INT NOT NULL 
       REFERENCES Role(RoleID ) 
)

INSERT INTO Employee2(EmpID, EmpName, RoleID) VALUES('00001', 'aaaa', 1) 
													
INSERT INTO Employee2(EmpID, EmpName, RoleID) VALUES('00002', 'bbbb', 1) 
													
INSERT INTO Employee2(EmpID, EmpName, RoleID) VALUES('00003', 'cccc', 2) 
													
INSERT INTO Employee2(EmpID, EmpName, RoleID) VALUES('00004', 'dddd', 3) 

--Error: Referential Integrity
INSERT INTO Employee2(EmpID, EmpName, RoleID) VALUES('00005', 'eeee', 4)

-- Join
SELECT e.EmpName, r.RoleName 
FROM employee2 e INNER JOIN Role r
ON e.RoleID = r.RoleID


/* ----------------------------------------------------------------------------------
D: PIVOT
*-----------------------------------------------------------------------------------*/
CREATE TABLE TestMember (userID char(02) PRIMARY KEY,userName varchar(20)) 
GO

CREATE TABLE TestProduct (productID char(02) PRIMARY KEY,productName varchar(20))

CREATE TABLE TestOrder(orderID int PRIMARY KEY,userID char(02),productID char(02),sellCount int)

INSERT INTO TestMember VALUES ('M1', 'jini')
INSERT INTO TestMember VALUES ('M2', 'jason')
INSERT INTO TestMember VALUES ('M3', 'boyd')
INSERT INTO TestMember VALUES ('M4', 'Phill')
INSERT INTO TestMember VALUES ('M5', 'Nick')
INSERT INTO TestProduct VALUES ('P1', 'bycycle')
INSERT INTO TestProduct VALUES ('P2', 'camera')
INSERT INTO TestProduct VALUES ('P3', 'notebook')
INSERT INTO TestOrder VALUES (1, 'M1', 'P1', 1)
INSERT INTO TestOrder VALUES (2, 'M2', 'P2', 2)
INSERT INTO TestOrder VALUES (3, 'M3', 'P1', 1)
INSERT INTO TestOrder VALUES (4, 'M3', 'P1', 1)
INSERT INTO TestOrder VALUES (5, 'M2', 'P3', 1)
INSERT INTO TestOrder VALUES (6, 'M1', 'P2', 3)
INSERT INTO TestOrder VALUES (7, 'M3', 'P1', 1)
INSERT INTO TestOrder VALUES (8, 'M1', 'P1', 2)
INSERT INTO TestOrder VALUES (9, 'M2', 'P3', 1)
INSERT INTO TestOrder VALUES (10, 'M1', 'P2', 1)

-- Order Count per customer
SELECT T2.userName, T3.productName, SUM(sellCount ) Total
FROM TestOrder T1 INNER JOIN TestMember T2 
ON T1.userID = T2.userIDINNER JOIN TestProduct T3 
ON T1. productID = T3. productID 
GROUP BY T2. userName , T3. productName 

-- what if we need "product column" as column and order count
SELECT * FROM
(
SELECT T2. userName , T3. productName , SUM(sellCount ) Total
FROM TestOrder T1 INNER JOIN TestMember T2 ON T1.userID = T2.userIDINNER JOIN TestProduct T3 
ON T1. productID = T3. productID 
GROUP BY T2. userName , T3. productName
) TPIVOT (SUM(Total) FOR productName IN (bycycle, camera, notebook) ) 
AS PVT

/* ----------------------------------------------------------------------------------
D: Ranking Function
Rank
Dens Rank
Row Number
Ntile
*-----------------------------------------------------------------------------------*/
CREATE TABLE Customer (
CustID int,
Name varchar(10),
Gender char(1),
Score int
)
GO

INSERT INTO Customer VALUES(1, 'Gilyong', 'M', 70)
INSERT INTO Customer VALUES(2, 'Deoken', 'M', 80)
INSERT INTO Customer VALUES(3, 'Juyeon', 'F', 60)
INSERT INTO Customer VALUES(4, 'Hodong', 'M', 70)
INSERT INTO Customer VALUES(5, 'Hyori', 'F', 90)
INSERT INTO Customer VALUES(6, 'Hani', 'F', 70)
INSERT INTO Customer VALUES(7, 'Minsoo', 'M', 50)
INSERT INTO Customer VALUES(8, 'MiJa', 'F', 90)
INSERT INTO Customer VALUES(9, 'ChoiGuk', 'M', 75)
INSERT INTO Customer VALUES(10, 'Kobong', 'M', 80)
GO

SELECT Name, Gender, Score 
FROM Customer
ORDER BY Score DESC
GO

SELECT Name, Gender, Score, 
RANK() OVER(ORDER BY Score DESC) AS ScoreRank
FROM Customer
GO

SELECT Name, Gender, Score, 
RANK() OVER(PARTITION BY Gender ORDER BY Score DESC) AS ScoreRank
FROM Customer
GO

SELECT Name, Gender, Score, 
DENSE_RANK() OVER(ORDER BY Score DESC) AS ScoreRank
FROM Customer
GO

SELECT Name, Gender, Score, 
DENSE_RANK() OVER(PARTITION BY Gender ORDER BY Score DESC) AS ScoreRank
FROM Customer
GO

SELECT ROW_NUMBER() OVER(ORDER BY Score DESC) AS RowNum, Name, Gender, Score
FROM Customer
GO

SELECT ROW_NUMBER() OVER(PARTITION BY Gender ORDER BY Score DESC) AS RowNum, Name, Gender, Score
FROM Customer
GO

SELECT NTILE(3) OVER(ORDER BY Score DESC) AS ScoreBand, Name, Gender, Score
FROM Customer
GO

SELECT NTILE(3) OVER(PARTITION BY Gender ORDER BY Score DESC) AS ScoreBand, Name, Gender, Score
FROM Customer
GO
