/*
Follwing assignment may be written in another file whose extension is sql such as "assignment.sql" so that it could be open in SSMS (SQL Server Management Studio) to execute it.

This file should be located somewhere in SQL folder and commit and push to student branch
*/

-- SQL DataType Confirm: https://www.promotic.eu/en/pmdoc/Subsystems/Db/MsSQL/DataTypes.htm

-- 0. Exercise query statement tested on classroom BEFRE "join" statement

-- SQL Function (System Function)
-- 1. Research SQL DateTime Function and Exercise (Copy and Paste is allowed)

  SELECT GETDATE();
  SELECT YEAR(GETDATE()), MONTH(GETDATE()), DAY(GETDATE());
  SELECT stor_id, ord_date, DATEDIFF(day,ord_date,GETDATE()) AS Diff_Days FROM sales;
  SELECT CONVERT(VARCHAR,GETDATE(),101);
  SELECT CONVERT(VARCHAR,GETDATE(),111);

-- 2. Research SQL String Function and Exercise (Copy and Paste is allowed)

  SELECT CONCAT('TEST', 100, 200);
  SELECT REPLACE('A-001', '-', '_') AS result;
  SELECT SUBSTRING('MSSQL SUBSTRING with position and length', 7, 9) AS result;
  SELECT LEFT('Introduction to MSSQL LEFT function', 12) AS result;

  -- 3. Research SQL Math Function and Exercise (Copy and Paste is allowed)
	SELECT COUNT(stor_id) As Store_Count FROM sales;
	SELECT SUM(qty) AS Total_QTY FROM sales;
	SELECT AVG(qty) AS Average_QTY FROM sales;
	SELECT MAX(qty) AS Max_QTY FROM sales;
	SELECT MIN(qty) AS MIN_QTY FROM sales;

-- Following Example is based on Database "Pubs". So you always make sure DB set to "pubs"
	Use Pubs
	Go

-- 4. Write query from authors
-- Lastname should be start 'A', or 'B' or 'C' (case-insensitive) and order by city descendingsele
  SELECT * FROM authors
   WHERE au_lname LIKE 'A%' or au_lname LIKE 'B%' or au_lname LIKE 'C%' 
   ORDER BY city desc;
	
-- 5. Write query from publishers
-- country should be only 'USA' and get record only 3
  SELECT * FROM publishers
   WHERE country = 'USA' and pub_id between 1000 AND 2000
   ORDER BY pub_name;

-- 6. Write query from stores
-- stores table, stores is located in several state. Get state information (no duplication)
  SELECT COUNT(state), state FROM stores
   GROUP BY state;

-- 7. Write query from discounts
-- 7-1  We have three discount options in discounts table
-- Which option has the highest discount rate and what is the discount value?

  SELECT discounttype, discount AS Rate FROM discounts
   WHERE discount =  (SELECT MAX(discount) AS Rate from discounts);

-- 7-2 Also write query discount is more than 5.5 and less than 8.0
 
  SELECT * FROM discounts
   where discount between 5.5 and 8.0;

-- 8. Write query from sales  (use group by)
  SELECT * FROM sales
  where qty > 0;
 
-- 8-1. average qty per store and average should be more than 20 and order by store id descending
  SELECT stor_id, AVG(qty)
    FROM sales
   GROUP BY stor_id 
  HAVING AVG(qty) > 20
   ORDER BY stor_id DESC;

-- 8-2. sum qty per title and qty should be more than 10 and order by title id ascending
  SELECT title_id, SUM(qty)
    FROM sales
   GROUP BY title_id 
  HAVING SUM(qty) > 10
   ORDER BY title_id;

-- 8-3. sum qty per year (may use date function as well)
  SELECT YEAR(ord_date) AS "YEAR",SUM(qty) AS TotalQTY
  FROM sales
  GROUP BY YEAR(ord_date);

-- 8-4. avg qty per year and month (may use date function as well)
  SELECT YEAR(ord_date) AS "YEAR", MONTH(ord_date) AS "MONTH",
 		AVG(qty) AS Average, SUM(qty) AS TotalQTY
    FROM sales
   GROUP BY YEAR(ord_date),MONTH(ord_date)
   ORDER BY YEAR(ord_date),MONTH(ord_date);

-- 8-5. which book is least sold out? showing title id and qty (one record)
  SELECT title_id, SUM(qty) AS total
    FROM sales
   GROUP BY title_id  
  HAVING Sum(qty) =  (SELECT MAX(total)
    from (SELECT SUM(qty) AS total from sales group by title_id)a);
 
 
-- 8-6. which book is most sold out? showing title id and qty (one record)
 
  SELECT title_id, SUM(qty) AS total
    FROM sales
   GROUP BY title_id  
  HAVING Sum(qty) =  (SELECT MIN(total) 
    from (SELECT SUM(qty) AS total from sales group by title_id)a);