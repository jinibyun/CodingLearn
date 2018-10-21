/* --------------------------------------------------
1. Simple Select Statement

Basic use of queries and SQL functions
--------------------------------------------------- */

SELECT @@servername, @@version

USE pubs
GO

SELECT * FROM titles
GO
SELECT title_id, title, type FROM TITLES
GO
SELECT title_id AS bookID, title AS bookTitle, type AS bookType FROM TITLES
GO
-- 
SELECT bookID=title_id, bookTitke=title, bookType=type FROM TITLES

-- TIP: system stored procedure
EXEC sp_tables

select * from sysobjects where type = 'U'
-- system sp
sp_columns titles

select * from syscolumns where id = object_id('titles') 

-- Declare keyword
-- specific data type: table
DECLARE @T TABLE (id int, name varchar(8))
INSERT @T values(10,'Joe')
SELECT * FROM @T

-- set keyword, sql_variant type
DECLARE @T1 sql_variant, @T2 sql_variant
set @T1 = 12345
set @T2 = 'this is string'
select @T1
select @T2

/* sql built-in function
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
1. Select Statement

SELECT query with 

filtering, distinct, order by, group by, join, sub Query
---------------------------------------------------- */
USE pubs
GO

-- where filtering
SELECT * FROM sales where qty > 10

SELECT * FROM authors WHERE zip > 90000

-- string: not double quotation, but single one
SELECT * FROM authors WHERE state = 'CA'

-- NB: price = null 
SELECT title FROM titles WHERE price IS NULL

SELECT title_id, ytd_sales 
FROM titles 
WHERE ytd_sales > 4095 AND ytd_sales < 12000

SELECT title_id, ytd_sales 
FROM titles 
WHERE ytd_sales between 4095 AND 12000

SELECT title, type FROM titles 
WHERE type IN ('mod_cook', 'trad_cook')

SELECT title, type FROM titles 
WHERE type NOT IN ('mod_cook', 'trad_cook')

SELECT title, type FROM titles 
WHERE type = 'mod_cook' OR type = 'trad_cook'

-- Like pattern match
SELECT stor_name FROM stores 
WHERE stor_name LIKE '%Books%'

SELECT stor_name FROM stores
WHERE stor_name LIKE 'Bo%'

SELECT stor_name FROM stores
WHERE stor_name LIKE 'E_i%'

SELECT stor_name FROM stores
WHERE stor_name LIKE 'B[^a]%'

SELECT title_id, title, pub_id, price, pubdate
FROM titles
WHERE (title LIKE 'T%' OR pub_id = '0877') AND (price > $16.00)

SELECT title_id, title, pub_id, price, pubdate
FROM titles
WHERE (title LIKE 'T%') OR (pub_id = '0877' AND price > $16.00)

SELECT title_id, title, pub_id, price, pubdate
FROM titles
WHERE title LIKE 'T%' OR pub_id = '0877' AND (price > $16.00)

-- Distinct
-- compare
SELECT au_id FROM titleauthor
SELECT DISTINCT au_id FROM titleauthor

-- NOTE: text type column, image type column are not possible
SELECT DISTINCT * FROM titleauthor
SELECT * FROM titleauthor

-- Order By
/*
Column name or number
Asc is "by default".
NOTE: text type column, image type column are not possible
*/
-- compare
SELECT city, au_fname, au_lname FROM authors

SELECT city, au_fname, au_lname FROM authors
ORDER BY city

-- Same as above
SELECT city, au_fname, au_lname FROM authors
ORDER BY city ASC

SELECT city, au_fname, au_lname FROM authors
ORDER BY city DESC

SELECT city, au_fname, au_lname FROM authors
ORDER BY city ASC, au_fname ASC

-- group by
-- analytical data with aggregate function: sum, avg, count, min, max

--SELECT select_list
--FROM table_name
--[WHERE search_conditions] -- optional
--GROUP BY [ALL] aggregate_free_expression [, aggregate_free_expression…]]
--[HAVING search conditions] – optional

-- compare
select pub_id, type, royalty, ytd_sales 
from titles

select pub_id, type, royalty, ytd_sales, AVG(price)
from titles
GROUP BY pub_id, type, royalty, ytd_sales

select type, sum(price)
from titles
group by type

SELECT title_id, copies_sold = SUM(qty)
FROM sales
GROUP BY title_id
HAVING SUM(qty) > 20

SELECT title_id, copies_sold = SUM(qty)
FROM sales
WHERE ord_date BETWEEN '1/1/1994' AND '12/31/1994'
GROUP BY ALL title_id

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


-- Sub Query
SELECT * FROM titles
WHERE title_id IN (SELECT title_id FROM sales)

SELECT * FROM titles
WHERE title_id = (SELECT title_id FROM sales WHERE title_id like 'PS2106')

SELECT title FROM titles
WHERE title_id IN -- IN Keyword
(SELECT DISTINCT title_id FROM sales)
 
-- related subquery : repalce it with join query
SELECT ProductName
FROM Northwind.dbo.Products
WHERE UnitPrice =
(SELECT UnitPrice
FROM Northwind.dbo.Products
WHERE ProductName = 'Sir Rodney''s Scones')


SELECT Prd1.ProductName
FROM Northwind.dbo.Products AS Prd1
JOIN Northwind.dbo.Products AS Prd2
ON (Prd1.UnitPrice = Prd2.UnitPrice)
WHERE Prd2.ProductName = 'Sir Rodney''s Scones'

