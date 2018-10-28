SELECT @@servername, @@version

Use Pubs
Go


select * from titles
--1. DateTime Function

--Get Date
select cast ('20121019' as datetime)
select cast ('7:51:00' as datetime)
select getdate()
--Returns name or integer value of specified datepart
select datename (month, getdate())
select datepart (day, getdate())
--Returns DateTime after adding specified value to datepart
select dateadd (day, 66, getdate())
--Returns difference of dateparts
select datediff (day, getdate(), '12/31/2018')

--2. String Function

--Selecting 5 characters from left in title
select LEFT(notes,5) from titles
--Counts the length of string including leading space but no trailing space
select LEN(' Hello World ')
--Changes the string into lower or upper case
select UPPER('hello world')
select LOWER('HELLO WORLD')
--Trims leading and trailing spaces
select TRIM(' hello world ')
--Returns the location of the keyword (% at the end for starting with and at the front for ending with)
select PATINDEX ('I am%', 'I am the king of the world')
--Replace the second argument with third argument in first argument (also note that it is not case sensitive)
select Replace('Hello World', 'world', 'Jinman')
--Reverses the string
select REVERSE('HELLOW WORLD')
--Substring from second argument position for third argument number of characters
select ('Hello World'), SUBSTRING ('Hello World', 1, 5)

--3. Math Function

--Selecting absolute value
select ABS(-13.0)
--Selecting random number
select RAND(1) AS Random_Number
--Selecting rounded value to second argument numberth digit
select ROUND(12.335, 2)


-- 4.Query from authors
SELECT *
FROM authors
WHERE au_lname LIKE 'A%' OR au_lname LIKE 'B%' or au_lname LIKE 'C%'
ORDER BY city DESC

-- 5.Query from publishers
SELECT TOP 3 *
FROM publishers
WHERE country = 'USA'

-- 6.Query from stores
SELECT DISTINCT state
FROM stores

-- 7.Query from discounts
SELECT TOP 1 *
FROM discounts
ORDER BY discount DESC

SELECT *
FROM discounts
WHERE discount > 5.5 AND discount < 8.0

-- 8.Query from sales
SELECT stor_id, avg_qty = avg(qty)
FROM sales
GROUP BY stor_id
ORDER BY stor_id DESC

SELECT title_id, sum_qty = SUM(qty)
FROM sales
GROUP BY title_id
HAVING SUM(qty) > 10
ORDER BY title_id ASC

SELECT DATEPART(year, ord_date) AS year, SUM(qty) AS sum
FROM sales
GROUP BY ord_date

SELECT DATEPART(year, ord_date) AS year, DATENAME(month, ord_date) AS month, SUM(qty) AS sum
FROM sales
GROUP BY ord_date

SELECT title_id, AVG(qty) AS avg_QTY
FROM sales
GROUP BY title_id
ORDER BY AVG(qty) ASC
OFFSET 0 ROWS
FETCH FIRST 1 ROW ONLY

SELECT title_id, AVG(qty) AS avg_QTY
FROM sales
GROUP BY title_id
ORDER BY AVG(qty) DESC
OFFSET 0 ROWS
FETCH FIRST 1 ROW ONLY