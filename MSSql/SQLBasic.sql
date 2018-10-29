/* ----------------------------------------------------------------------------------
A: DML : Data MANIPULATION Language
1. SELECT	2.INSERT	3.UPDATE	4.DELETE
*-----------------------------------------------------------------------------------*/
--
/* --------------------------------------------------
A-1. Simple Select Statement

Basic use of queries and SQL functions
--------------------------------------------------- */

SELECT @@servername, @@version	-- 분홍색 글자는 내장되어있는 함수, 변수를 나타냄. @@는 전역변수.

USE pubs
GO		-- GO is ';' in programming. it can be skipped.

SELECT * FROM titles
GO
SELECT title_id, title, [type] FROM TITLES --type 테이블 글자가 파란색이었는데 헷갈릴 수 있으니 []안에 넣어 두었다. 해도 되고 안해도 되고.
GO
SELECT title_id AS bookID, title AS bookTitle, type AS bookType FROM TITLES		-- 보여지는 Column 이름을 바꿔서 보여줌.
GO
-- 
SELECT bookID=title_id, bookTitke=title, bookType=type FROM TITLES

-- TIP: system stored procedure
EXEC sp_tables		-- EXEC이라는 함수를 호출. 함수들은 pubs/Programmability/Functions에 저장되어 있다. Function들 잘 모르겠으면 여길 확인하거나 구글링

select * from sysobjects where type = 'U'
-- system sp
sp_columns titles		-- 이것도 함수.

select * from syscolumns where id = object_id('titles') 

-- Declare keyword
-- specific data type: table
DECLARE @T TABLE (id int, name varchar(8))	-- DCLARE는 변수 선언. 변수 앞에는 @를 붙이는 게 규칙.
							-- T라는 Table을 선언.
INSERT @T values(10,'Joe')	-- record 하나 저장
SELECT * FROM @T

-- set keyword, sql_variant type
DECLARE @T1 sql_variant, @T2 sql_variant
set @T1 = 12345				-- 값을 집어 넣을 때 set을 쓴다
set @T2 = 'this is string'
select @T1					-- 값을 가져올 때 select
select @T2

DECLARE @t1001 INT		-- example
SET @t1001 = 123456
select @t1001

/* sql built-in function
* 수가 중요도를 나타냄
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
SELECT * FROM sales where qty > 10		-- where는 if와 비슷함.

SELECT * FROM authors WHERE zip > 90000

-- string: not double quotation, but single one
SELECT * FROM authors WHERE state = 'CA'			-- string도 ''로 표현함. 사실 SQL에선 Char가 없고 모두 String임

-- NB: price = null 
-- price = null (wrong)
SELECT title FROM titles WHERE price IS NULL	-- price IS NOT NULL

SELECT title_id, ytd_sales 
FROM titles 
WHERE ytd_sales > 4095 AND ytd_sales < 12000

SELECT title_id, ytd_sales 
FROM titles 
WHERE ytd_sales between 4095 AND 12000


-- Interview Question ★★★
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
WHERE (title LIKE 'T%' OR pub_id = '0877') AND (price > $16.00)		-- 괄호부터 실행함. 여기서 OR 부분 괄호 없애면 AND 부터 실행됨. 왜냐하면 AND는 곱하기 개념이라. OR은 더하기 개념인 듯

SELECT title_id, title, pub_id, price, pubdate
FROM titles
WHERE (title LIKE 'T%') OR (pub_id = '0877' AND price > $16.00)

SELECT title_id, title, pub_id, price, pubdate
FROM titles
WHERE title LIKE 'T%' OR pub_id = '0877' AND (price > $16.00)		-- 위에 설명한대로 AND부터 실행함.

-- TOP
-- TODO
SELECT TOP 10 * FROM titles;		--보통 한국 사이트 게시판 보면 이런식으로 최상위 게시글들을 표시함

-- Distinct
-- compare
SELECT au_id FROM titleauthor
SELECT DISTINCT au_id FROM titleauthor		-- DISTINCT: 겹치는 내용을 없애고 가져옴

-- NOTE: text type column(over 8000 characters), image type column are not possible 왜냐하면 실제 데이터가 들어가 있는게 아니라 그걸 가리키는 어드레스가 저장되어 있어서.
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

SELECT city, au_fname, au_lname FROM authors  WHERE city like '%oak%'		-- where는 order by 앞에만 올 수 있다
ORDER BY city ASC

-- ★★★
-- group by
-- analytical data with aggregate function: sum, avg, count, min, max
-- group by는 자체적으로 distinct기능도 있다고 보면 됨. distinct안 써도 중복은 모두 제거하고 그룹지어서 보여주기 때문

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
GROUP BY pub_id, type, royalty, ytd_sales	-- GROUP BY에는 SELECT에 aggregate func빼고 모든 항목 이상이 들어가야 함. 안그러면 에러.

select type, sum(price)
from titles
group by type

SELECT title_id, copies_sold = SUM(qty)
FROM sales
GROUP BY title_id
HAVING SUM(qty) > 20			-- HAVING은 Group By를 통한 Return에 대한 결과값에 대한 조건.  Group By전용 WHERE이라고 보면 됨.

SELECT title_id, copies_sold = SUM(qty)
FROM sales
WHERE ord_date BETWEEN '1/1/1994' AND '12/31/1994'
GROUP BY ALL title_id			-- NULL값도 가져옮. ALL 없으면 NULL값들은 제외하고 수행함.

-- Discount가 가장 높은 DiscountTyp을 출력. SubSelect 사용함 ★
SELECT discounttype, discount 
FROM discounts 
WHERE discount = (SELECT MAX(discount) FROM discounts)

-- Normalization은 Entity들을 중복값을 없애 최적화 시키려고 최소한의 저장단위로 나누는 걸 말함.
-- Reciept Entity가 있고 물품 산 사람 정보랑 상품 모두 적혀있으면 물건 두개 사면 사람 정보가 두번이나 중복되니 사람 enity와 product entity로 쪼개는 것.
-- DeNomalization는 연구 목적으로 쪼개진 Entity들을 다시 합치는 것.
-- SSMS에서 ERD보고 싶으면 pubs/Database DIagrams에서 오른쪽 클릭, new DB diagram해서 보면 됨.

-- Join
-- Join by identical column (Physical and Logical)
-- Data Normalization and Denormalization with ERD
-- INNER JOIN / OUTER JOIN / CROSS JOIN/ SELF JOIN

SELECT * from authors
SELECT * FROM publishers

SELECT *
FROM authors AS a INNER JOIN publishers AS p
ON a.city = p.city

-- ANSI Syntax
SELECT pub_name, title
FROM titles INNER JOIN publishers
ON titles.pub_id = publishers.pub_id
-- T-SQL Syntax
SELECT authors.au_lname, authors.state, publishers.*
FROM publishers, authors
WHERE publishers.city = authors.city

-- outer join
SELECT title, stor_id, ord_num, qty, ord_date
FROM titles LEFT OUTER JOIN sales
ON titles.title_id = sales.title_id
-- cross join
SELECT au_fname, au_lname, pub_name
FROM authors CROSS JOIN publishers 

-- self join 
-- TODO

-- Sub Query
SELECT * FROM titles
WHERE title_id IN (SELECT title_id FROM sales)

SELECT * FROM titles
WHERE title_id = (SELECT title_id FROM sales WHERE title_id like 'PS2106')

SELECT title FROM titles
WHERE title_id IN -- IN Keyword
(SELECT DISTINCT title_id FROM sales)
?
-- related subquery : repalce it with join query
-- TODO


-- select into
-- TODO

-- UNION

/* ---------------------------------------------------
A-2. Insert Statement

SQL datatype in table, default value, null or not null, 
PK-FK: Referential Integrity
BEGIN TRAN and COMMIT TRAN
---------------------------------------------------- */
CREATE TABLE test1(
	 columnA varchar(10)
	,columnB int
)
GO
INSERT INTO test1 VALUES('John',1)
INSERT INTO test1 VALUES('Jane',2)
INSERT INTO test1 VALUES('Wilson',3)

-- TODO: Referential Integrity Test

-- Insert with select
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
	WHERE pub_name = 'New Moon Books') ?

/* ---------------------------------------------------
A-4. Delete Statement

SQL datatype in table, default value, null or not null, 
PK-FK: Referential Integrity
BEGIN TRAN and COMMIT TRAN

Referential Integrity
DELETE FROM and Trancate Table
---------------------------------------------------- */
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
-- SQL Object : Table,View, etc

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
INSERT INTO testTable2 VALUES('I am hungry')
--Error : Why?
INSERT INTO testTable2 VALUES('Hi I am hungry')

--Error : Why?
INSERT INTO testTable2 VALUES(3, 'Hi')
SELECT * FROM testTable2 

/* ---------------------------------------------------
B-2. Alter and Drop
---------------------------------------------------- */
ALTER TABLE testTable2 
ALTER COLUMN user_content VARCHAR(20) NOT NULL
GO

--Error : Why?
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
젨젨젨젨젨젨 Name VARCHAR(10) NOT NULL PRIMARY KEY 
젨젨젨젨젨젨 ,Age TINYINT NULL 
)

INSERT INTO testTable4(Name, Age) VALUES('aaa', 19) 
-- Error
INSERT INTO testTable4(Name, Age) VALUES('aaa', 20)젨젨젨?

--
CREATE TABLE Role( 
젨젨젨젨젨젨 RoleID INT NOT NULL PRIMARY KEY 
젨젨젨젨젨젨 ,RoleName VARCHAR(10) NOT NULL 
)
INSERT INTO Role(RoleID , RoleName ) VALUES(1, 'admin') 
INSERT INTO Role(RoleID, RoleName ) VALUES(2, 'guest') 
INSERT INTO Role(RoleID, RoleName ) VALUES(3, 'member')

CREATE TABLE Employee2( 
젨젨젨젨젨젨 EmpID VARCHAR(10) NOT NULL PRIMARY KEY 
젨젨젨젨젨젨 ,EmpName VARCHAR(10) NULL 
젨젨젨젨젨젨 ,RoleID INT NOT NULL 
젨젨젨젨젨젨 REFERENCES Role(RoleID ) 
?
)

INSERT INTO Employee2(EmpID, EmpName, RoleID) VALUES('00001', 'aaaa', 1) 
													
INSERT INTO Employee2(EmpID, EmpName, RoleID) VALUES('00002', 'bbbb', 1) 
													
INSERT INTO Employee2(EmpID, EmpName, RoleID) VALUES('00003', 'cccc', 2) 
													
INSERT INTO Employee2(EmpID, EmpName, RoleID) VALUES('00004', 'dddd', 3) 

--Error: Referential Integrity
INSERT INTO Employee2(EmpID, EmpName, RoleID) VALUES('00005', 'eeee', 4)?

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
