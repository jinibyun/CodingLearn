/* ----------------------------------------------------------------------------------
A: DML : Data MANIPULATION Language
1. SELECT	2.INSERT	3.UPDATE	4.DELETE

	Table Records 관련
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



-- Join ★★★
-- Join by identical column (Physical and Logical)
-- Data Normalization and Denormalization with ERD
-- INNER JOIN / OUTER JOIN / CROSS JOIN/ SELF JOIN

-- if you wanna see a diagram, please see 'Database Diagrams' on Object Explorer, or view dependencies by right clicking on a table

SELECT * from authors
SELECT * FROM publishers


-- inner join
-- 테이블 두 개, ○와 ○가 있으면 서로 겹치는 부분만 가져옮.
-- ex) t1: 1, 2, 3, 4; t2: 3, 4, 5, 6 이면 3, 4 겹치는 부분만 가져옮.

SELECT *
FROM authors AS a INNER JOIN publishers AS p
ON a.city = p.city

--표준형식
-- ANSI Syntax
SELECT pub_name, title
FROM titles t1 INNER JOIN publishers t2
ON titles.pub_id = publishers.pub_id	-- On equality condition
WHERE t1.price > 20


--마이크로소프트가 뭔가 만든 건데 위에걸 추천
-- T-SQL Syntax
SELECT authors.au_lname, authors.state, publishers.*
FROM publishers, authors
WHERE publishers.city = authors.city



-- outer join
-- innerjoing + 칼럼값이 같지 않은 부분들까지 SELECT. 칼럼값 존재하지 않으면 null로 가져옴.
-- LEFT는 왼쪽에 쓰인 테이블의 모든 레코드를 가져옮. 오른쪽 테이블과 겹치든 안겹치든. RIGHT는 그 반대.
-- 근데 실제로는 사람들이 RIGHT 쓰기 귀찮아서 차라리 Table이름들 순서만 바꿔서 사용함.
-- ex) LEFT OUTER JOIN 하나도 안 팔린 책을 가져올 때 outer join 사용. 안팔린 책들은 팔린 history저장한 테이블에 기록이 없으니.
-- ex) RIGHT의 경우 사실 없는 책을 팔 순 없으니 null값이 안나옮.
SELECT title, stor_id, ord_num, qty, ord_date
FROM titles LEFT OUTER JOIN sales
ON titles.title_id = sales.title_id


-- 다음에 설명. written in 2018/10/31
-- cross join
SELECT au_fname, au_lname, pub_name
FROM authors CROSS JOIN publishers 

-- self join 
-- TODO
select t1.* from titleauthor t1 order by t1.title_id asc
-- same as the below. 테이블 하나를 두개로 나눠서 조인한 것처럼 보임. 아래는 두번씩 중복되는 데 위의 셀프조인은 중복은 안보여 주는 듯.
select t1.* from titleauthor t1 INNER JOIN titleauthor t2 ON t1.title_id = t2.title_id order by t1.title_id asc

-- Sub Query
SELECT * FROM titles
WHERE title_id IN (SELECT title_id FROM sales)
-- 아래와 같다고 보면 됨
	SELECT * FROM titles
	WHERE title_id IN ('BU1032', 'BU1111', 'BU2075', '.........')


-- 참고지식: =로 컨디션을 넣을 때 비교대상은 무조건 하나여야 함.
-- 두개 이상이 될 것 같으면 위나 그 아래의 예제처럼 IN (값1, 값2) 이렇게 넣어야함.
-- 아래 sub query는 그것의 결과값이 하나뿐이라 작동함.
SELECT * FROM titles
WHERE title_id = (SELECT title_id FROM sales WHERE title_id like 'PS2106')

SELECT title FROM titles
WHERE title_id IN -- IN Keyword
(SELECT DISTINCT title_id FROM sales)

-- related subquery : repalce it with join query
-- TODO


-- select into: create a table from another table
-- 실제로 sales2라는 테이블은 없는데 만들어서 SELECT 값을 모두 넣음
-- 실행 후 DB refresh하면 새로 생성된 sales2를 볼 수 있음.
SELECT * 
INTO sales2
FROM sales

Select * FROM sales2
DROP TABLE sales2
-- TODO




-- UNION
-- 두 테이블의 records를 모두 합침. Row 기준으로.
-- 조건: record의 column 수가 같아야함.


-- Interview question: What is different between UNION and UNION ALL? ★★
-- A: UNION은 UNIQUE일 경우 중복되는 애들은 추가 안하고 중복 안되는 애들만 포함해서 모두 합침.
--	  UNION ALL은 UNIQUE든 아니든 모두 합쳐서 결과를 냄. 중복 가능.
-- EX
Select * FROM sales t1
UNION ALL
Select * FROM sales2 t2
-- 둘의 stor_id가 Unique속성이라 중복되서 합쳐서 42줄이 아니라 21줄이 나옴.
-- UNION ALL을 사용하면 총 42줄이 됨.

-- Another Interview question:
--  최상위 2개만 select
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


-- TODO: Referential Integrity Test ★★★★★★
-- Interview Question: Referential Integrity 설명하라. 그럼 무조건 PK, FK가 답으로 나와야 함
-- 참조받는 PK를 갖고 있는 테이블이 부모 테이블이고 FK가 있는 테이블이 자식 테이블임.
-- Integrity란 무결성을 뜻함. 쓰레기 데이터가 있으면 안됨. 쓰레기데이터 입력 예방해야함. 
-- 1st Integrity: FK에 존재하지 PK키가 입력되면 제한함.
-- 2nd Integrity: 참조받는 PK를 지울 수 없음.
-- Relational Database 관련 문제가 나오면 이거 꼭 나옴.

CREATE TABLE Category(
	 id int PRIMARY KEY		-- Primary Key: not null, not duplicate
	,name nvarchar(50)
	-- varchar: varchar(1)이면 1바이트. 한 글자에 1바이트만 할당되기에 기본적으로 정해진 1바이트짜리 글자들밖에 못들어감.
	-- nvarchar: nvarchar(1)이면 2바이트 할당됨. 한 글자를 무조건 2바이트로 보고 할당함. 한글이나 한자 등 영어가 아닌 글도 저장하기에 좋음.
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

DELETE FROM Category	-- Interview Question ★★ Delete 하나만 있으면 Record를 지움.
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
-- DB의 Object 관련으로만.. DML (Data Manipulation Language) 위에 한 A파트는 DB의 Record 관련

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
--Error : Why?				 vchar(10)인데 10글자 넘어가서 truncated, 즉 잘려버림.
INSERT INTO testTable2 VALUES('Hi I am hungry')

--Error : Why?				 Identity 설정된 user_id를 직접 입력할 수 없음. 자동생성되기 때문에
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
