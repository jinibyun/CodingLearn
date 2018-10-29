/*
Follwing assignment may be written in another file whose extension is sql such as "assignment.sql" so that it could be open in SSMS (SQL Server Management Studio) to execute it.

This file should be located somewhere in SQL folder and commit and push to student branch
*/

-- SQL DataType Confirm: https://www.promotic.eu/en/pmdoc/Subsystems/Db/MsSQL/DataTypes.htm

-- 0. Exercise query statement tested on classroom BEFORE "join" statement

-- SQL Function (System Function)
-- 1. Research SQL DateTime Function and Exercise (Copy and Paste is allowed)
-- Date function

/*
datetime:
length: 8
Data type representing date and time from 1.1.1753 to 31.12.9999 with precision about 3ms.
 Values are rounded to .000, .003 and .007.

 ref: https://docs.microsoft.com/en-us/sql/t-sql/functions/date-and-time-data-types-and-functions-transact-sql?view=sql-server-2017
*/

-- Get current DateTime
SELECT GETDATE()
SELECT CURRENT_TIMESTAMP
SELECT GETUTCDATE()

-- Display Year, Month, Day separately
SELECT YEAR(pubdate), MONTH(pubdate), DAY(pubdate) FROM titles;


-- current DateTime's month number
SELECT DATEPART(month, GETDATE()) AS 'Month Number'	
SELECT DATEPART(Year, pubdate) FROM titles

-- display DateName
SELECT DATENAME(YEAR, pubdate), DATENAME(MONTH, pubdate), DATENAME(DAY, pubdate), DATENAME(WEEKDAY, pubdate),
 DATENAME(HOUR, pubdate), DATENAME(MINUTE, pubdate) FROM titles

-- display values with Date format
SELECT DATEFROMPARTS(2000, 12, 25)
SELECT DATETIME2FROMPARTS(2000, 12, 25, 8, 56, 12, 34, 3)	-- the last part is precision for miliseconds
SELECT DATETIMEFROMPARTS(2000, 12, 25, 8, 56, 12, 345)
SELECT DATETIMEOFFSETFROMPARTS(2000, 12, 25, 8, 56, 12, 50, 5, 20, 3)
SELECT SMALLDATETIMEFROMPARTS(2000, 12, 25, 8, 56)
SELECT TIMEFROMPARTS(8, 56, 12, 34, 3)


-- display the gap days between pubdate and current date
SELECT DATEDIFF(day, pubdate, getdate()) AS no_of_days FROM titles	
SELECT DATEDIFF(YEAR, pubdate, getdate()) AS no_of_days FROM titles		-- gap of years
SELECT DATEDIFF_BIG(day, pubdate, getdate()) AS no_of_days FROM titles	-- return data type is 'bigint' while the DATEDIFF returns just 'int'

-- Display date with adding time
SELECT DATEADD(day, 1, pubdate) AS timeframe FROM titles	-- add 1 day in pubdate and display them
SELECT DATEADD(HOUR, 10, pubdate) AS timeframe FROM titles	-- add 10 hours in pubdate and display them
SELECT DATEADD(MONTH, 1, pubdate) AS timeframe FROM titles	-- add 1 month in pubdate and display them
SELECT DATEADD(YEAR, 50, pubdate) AS timeframe FROM titles	-- add 50 years in pubdate and display them

--Returns the last day of the month containing the specified date, with an optional offset.
SELECT EOMONTH(pubdate, 4) FROM titles	-- same as DATEADD(MONTH, 4, pubdate)

-- SwitchTimeOffSet
DECLARE @temp_timeoffset datetimeoffset
SET @temp_timeoffset = '1998-09-20 7:45:50.71345 -5:00'
SELECT @temp_timeoffset							 --Returns: 1998-09-20 04:45:50.7134500 -08:00  
SELECT SWITCHOFFSET (@temp_timeoffset, '-08:00') --Returns: 1998-09-20 07:45:50.7134500 -05:00  

SELECT TODATETIMEOFFSET(pubdate, '-11:00') FROM titles

SELECT ISDATE(pubdate) FROM titles	-- all pubdate is DATE
SELECT ISDATE('2555-10-332') 	-- It is not DATE



-- 2. Research SQL String Function and Exercise (Copy and Paste is allowed)

-- String
/*
functions ref: 
https://docs.microsoft.com/en-us/sql/t-sql/functions/string-functions-transact-sql?view=sql-server-2017
https://www.itprotoday.com/sql-server/8-t-sql-string-functions
char	n	Char string of fixed length and max. length of 8000 chars.
varchar	n	Char string of variable length and max. length of 8000 chars.
text	n	Char string of variable length and max. length of 2^31-1 (2 147 483 647) chars.
nchar	2*n	Unicode char string of fixed length and max. length of 4000 chars.
nvarchar	2*n	Unicode char string of variable length and max. length of 4000 chars.
ntext	2*n	Unicode char string of variable length and max. length of 2^30-1 (1 073 741 823) chars.
*/
SELECT title FROM titles
SELECT LEFT(title, 5) FROM titles
SELECT RIGHT(title, 10) FROM titles
SELECT LEN(title) FROM titles	-- length
SELECT LOWER(title) AS LowerCase FROM titles
SELECT UPPER(title) AS UpperCase FROM titles
-- LTRIM(string) removes leading blanks from a string
DECLARE @myLTRIM varchar(40)= '     Get rid of five leading blanks'
SELECT 'The new string: ' + LTRIM(@myLTRIM) As Example

-- RTRIM(string) removes trailing blanks from a string
DECLARE @myRTRIM varchar(40) ='Get rid of five trailing blanks         '
SELECT 'The new string: '+ RTRIM (@myRTRIM) As Example

-- SUBSTRING: at the below example, it returns 5 letters since the 10th place
SELECT SUBSTRING(title, 10, 5) FROM titles

-- Replace
SELECT REPLACE('SQL Server 2005','2005','2008') As Example

-- Stuff: in the example, replace 8 letters starting from 5th with another string
SELECT STUFF('SQL Services',5, 8, 'Server') As [Stuff Example]




-- 3. Research SQL Math Function and Exercise (Copy and Paste is allowed)
-- Math function
/*
ABS()	This SQL ABS() returns the absolute value of a number passed as an argument.
FLOOR()	The SQL FLOOR() rounded up any positive or negative decimal value down to the next least integer value.
EXP()	The SQL EXP() returns e raised to the n-th power(n is the numeric expression), where e is the base of natural algorithm and the value of e is approximately 2.71828183.
POWER()	This SQL POWER() function returns the value of a number raised to another, where both of the numbers are passed as arguments.
SQRT()	The SQL SQRT() returns the square root of given value in the argument.
*/
-- absolute value
SELECT ABS(-1.0), ABS(0.0), ABS(1.0)
-- generate a random number with a seed number. if the seed number is same, results are same
SELECT RAND(15359) AS Random_Number
-- Round number with a percision number
SELECT ROUND(123.9994, 3), ROUND(123.9995, 3), ROUND(123.9995, 0), ROUND(123.9995, -1)
SELECT FLOOR(123.9994), FLOOR(123.9995), FLOOR(-123.00001), FLOOR(-125.9995)
SELECT POWER(12, 3), POWER(12, 3), POWER(12, 0), POWER(12, -1)
SELECT SQRT(12), SQRT(2), SQRT(0)




-- Following Example is based on Database "Pubs". So you always make sure DB set to "pubs"
Use Pubs
Go

-- 4. Write query from authors
-- Lastname should be start 'A', or 'B' or 'C' (case-insensitive) and order by city descending

SELECT * from authors WHERE LEFT(au_lname, 1) = 'A' 
OR LEFT(au_lname, 1) = 'B' OR LEFT(au_lname, 1) = 'C' ORDER BY city DESC


-- 5. Write query from publishers
-- country should be only 'USA' and get record only 3

SELECT TOP 3 * from publishers WHERE country = 'USA'

-- 6. Write query from stores
-- stores table, stores is located in several state. Get state information (no duplication)

SELECT DISTINCT state FROM stores

-- 7. Write query from discounts
-- 7-1  We have three discount options in discounts table
-- Which option has the highest discount rate and what is the discount value?

SELECT discounttype, discount FROM discounts WHERE discount = (SELECT MAX(discount) FROM discounts)

-- 7-2 Also write query discount is more than 5.5 and less than 8.0

SELECT * FROM discounts WHERE discount > 5.5 AND discount < 8.0


SELECT * FROM sales
-- 8. Write query from sales  (use group by)
-- 8-1. average qty per store and average should be more than 20 and order by store id descending

SELECT stor_id, AVG(qty) AS qty_avg FROM sales GROUP BY stor_id HAVING AVG(qty) > 20

-- 8-2. sum qty per title and qty should be more than 10 and order by title id ascending

SELECT title_id, SUM(qty) AS qty_sum FROM sales GROUP BY title_id HAVING SUM(qty) > 10 ORDER BY title_id ASC

-- 8-3. sum qty per year (may use date function as well)

SELECT DATEPART(YEAR, ord_date) AS yr, SUM(qty) AS qty_sum FROM sales GROUP BY DATEPART(YEAR, ord_date)

-- 8-4. avg qty per year and month (may use date function as well)

SELECT DATEPART(YEAR, ord_date) AS yr, DATEPART(MONTH, ord_date) AS mo, SUM(qty) AS qty_sum 
FROM sales GROUP BY DATEPART(YEAR, ord_date), DATEPART(MONTH, ord_date) ORDER BY yr, mo

-- 8-5. which book is least sold out? showing title id and qty (one record)

SELECT * FROM titles WHERE ytd_sales = (SELECT MIN(ytd_sales) FROM titles)

-- 8-6. which book is most sold out? showing title id and qty (one record)

SELECT * FROM titles WHERE ytd_sales = (SELECT MAX(ytd_sales) FROM titles)