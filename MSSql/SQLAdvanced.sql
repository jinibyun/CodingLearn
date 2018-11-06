/* ----------------------------------------------------------------------------------
A: DCL : Data Control Language
1. CREATE	2. ALTER    3. DROP

VIEW, STORED PROCEDURE, FUNCTION
*-----------------------------------------------------------------------------------*/

/* --------------------------------------------------
A-1. VIEW
	가상의 테이블
--------------------------------------------------- */
CREATE VIEW vTitleAuthorPublisher
AS
SELECT titles.title, authors.au_lname, publishers.pub_name
FROM titles INNER JOIN titleauthor ON titles.title_id = titleauthor.title_id
INNER JOIN authors ON titleauthor.au_id = authors.au_id
INNER JOIN publishers ON titles.pub_id = publishers.pub_id
GO
DROP VIEW vTitleAuthorPublisher GO

select * from vTitleAuthorPublisher
sp_helptext vTitleAuthorPublisher 

/* --------------------------------------------------
A-2. STORED PROCEDURE
	Function과 비슷
	저장된 PROCEDURE 확인하려면 Object Explorer > DB > Programmability > Stored Procedures
--------------------------------------------------- */
-- PROC: Procedure. PROCEDURE 써도 가능
-- PROCEDURE가 VIEW가 하는 것 외에 다른 많은 것들도 할 수 있어서 보통 PROCEDURE 씀

CREATE PROC uspGetPricePerBook	
AS
SELECT pub_id, type, royalty, ytd_sales, AVG(price) 
FROM titlesGROUP BY pub_id, type, royalty, ytd_sales
GO

DROP PROC uspGetPricePerBook GO

-- EXEC: Execute. 물론 EXECUTE도 가능
EXEC uspGetPricePerBook


-- 1 create
DROP PROC uspGetTitleWithPrice

CREATE PROC uspGetTitleWithPrice
@v_price int-- all variables start with @ or @@
AS
SELECT * FROM titles 
WHERE price > @v_price 

EXEC uspGetTitleWithPrice 30 -- 30을 @v_price에 집어넣어 실행


CREATE PROC uspGetTitleWithPrice
@v_price int
AS
BEGIN	-- BEGIN, END는 프로그램에서 '{'와 '}'과도 같은 데 MSSql에선 생략 가능.. 다른 SQL에선 안될 수 있음
	SELECT * FROM titles 
	WHERE price > @v_price 
	
	-- EXEC uspGetTitleWithPrice 30 
END

-- 2. alter
ALTER PROC 
uspGetTitleWithPrice
@v_price int
AS
SELECT * FROM titles 
WHERE price <= @v_price

-- execution
EXEC uspGetTitleWithPrice 30 

-- 3. sp for insert	(Stored Procedure)
CREATE TABLE ForSP
(
	c1 int,
	c2 varchar(10)
) 
go

CREATE PROC uspSaveForSP
	@v_c1 int,
	@v_c2 varchar(10)
AS
BEGIN
	INSERT INTO ForSP(c1, c2) 
	VALUES(@v_c1, @v_c2)
END

-- execution
EXEC uspSaveForSP 1, 'Hi~'
EXEC uspSaveForSP 2, 'test'

-- confirmation
SELECT * FROM ForSP

-- 4. dynamic sql with stored proc
DROP PROC uspDynamicSP

CREATE PROC uspDynamicSP
	@v_tblname varchar(20), 
	@v_title_id varchar(20)
AS
	DECLARE @v_strSQL VARCHAR(200)-- declare variable
	SET @v_strSQL = 'SELECT * FROM ' + @v_tblname +
					' WHERE title_id = ''' + @v_title_id + ''''	-- SELECT * FROM  v1  WHERE title_id = '   v2    '    
										-- SQL이 특문을 문법처럼 인식 못하도록 '를 다른 프로그래밍의 /처럼 특문 앞에 써서 표현함.
	EXEC(@v_strSQL) --sp_sqlexec
					--SELECT @v_strSQL-- 
GO

-- execute	
EXEC uspDynamicSP 'titles', 'BU1032'
EXEC uspDynamicSP 'titles', 'BU1111'
EXEC uspDynamicSP 'titleauthor', 'BU1111'
EXEC uspDynamicSP 'titleauthor', 'BU1032'

--5. stored proc with output parameter
CREATE PROC uspSPwithOUTPUT
	@v_title_id varchar(10), 
	@v_output int OUTPUT		-- OUTPUT is used for Return 단일값 리턴하는 경우 사용됨. 아래 섹션과 같이 return도 있지만 OUTPUT이 더 많이 사용됨
AS
	UPDATE titles SET price = price * 2
	WHERE title_id = @v_title_id

SET @v_output = (SELECT @@ROWCOUNT)		-- @@ system variable

--execute 
DECLARE @v_effected_rows int
EXEC uspSPwithOUTPUT 'BU1032', @v_effected_rows OUTPUT	--OUTPUT 
SELECT @v_effected_rows

--execute
DECLARE @v_effected_rows int
EXEC uspSPwithOUTPUT 'BU103X', @v_effected_rows OUTPUT
SELECT @v_effected_rows


-- 6 store proc with return keyword
CREATE PROC uspReturnSP
@v_title_id varchar(10)
AS
UPDATE titles SET price = price * 2
WHERE title_id = @v_title_id
RETURN @@ROWCOUNT

-- execute
DECLARE @v_effected_rows int
EXEC @v_effected_rows = uspReturnSP 'BU1032'
SELECT @v_effected_rows

--execute
DECLARE @v_effected_rows int
EXEC @v_effected_rows = uspReturnSP 'BU103X'
SELECT @v_effected_rows 
 

/* --------------------------------------------------
A-3. FUNCTION

100이 가장 많이 쓰이는 거라면 99는 Stored Procedure 사용함.
그러나 FUNCTION은 그렇게 많이 쓰이지 않음.

Interview question ★★★
What is different between Sotred Procedure and Function?
A: 가장 아래 정리된 글 참고

--------------------------------------------------- */

CREATE FUNCTION whichContinent 
(@Country nvarchar(15))
RETURNS varchar(30)
AS
BEGIN
declare @Return varchar(30)
select @return = 
	case @Country		-- Switch의 case와 비슷. 이해만 하면 됨
		when 'Argentina' then 'South America'
		when 'Belgium' then 'Europe'
		when 'Brazil' then 'South America'
		when 'Canada' then 'North America'
		when 'Denmark' then 'Europe'
		when 'Finland' then 'Europe'
		when 'France' then 'Europe'
		else 'Unknown'
	end
return @return
end 
-- execute: Not like stored proc, function can be used wherever varchar(30) return value is used in sql statement
-- ex) select list item , where clause	->	SELECT * FROM FUNCTION 가능. SP는 안됨. 호출하는 방식, 어디에 쓰이느냐의 차이.
--NOTE: when executing, 'dbo' (schema name) should be used
print dbo.WhichContinent('USA')

select dbo.WhichContinent(Customers.Country), customers.* 
from customers

create table test 
(
	Country varchar(15),
	Continent as (dbo.WhichContinent(Country))
) 

insert into test (country) 
values ('USA') 

select * from test

-- 1. function returning inline table value
CREATE FUNCTION CustomersByContinent 
(@Continent varchar(30))
RETURNS TABLE 
AS
RETURN 
	-- Like sp calls another sp, function calls another function
	SELECT dbo.WhichContinent(Customers.Country) as continent,
	customers.*
	FROM customers
	WHERE dbo.WhichContinent(Customers.Country) = @Continent
	GO
-- execute: Calling function should be with "select" statement
SELECT * from CustomersbyContinent('North America')
SELECT * from CustomersByContinent('South America')
SELECT * from customersbyContinent('Unknown') 

-- 2. function returning multi statement table value

CREATE FUNCTION dbo.customersbycountry 
( @Country varchar(15) )
RETURNS 
	@CustomersbyCountryTab table 
	(
		[CustomerID] [nchar] (5), [CompanyName] [nvarchar] (40), 
		[ContactName] [nvarchar] (30), [ContactTitle] [nvarchar] (30), 
		[Address] [nvarchar] (60), [City] [nvarchar] (15),
		[PostalCode] [nvarchar] (10), [Country] [nvarchar] (15), 
		[Phone] [nvarchar] (24), [Fax] [nvarchar] (24)
	)
AS

BEGIN
INSERT INTO @CustomersByCountryTab 
	SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, PostalCode, Country, Phone, Fax
	FROM Customers
	WHERE country = @Country

DECLARE @cnt INT
SELECT @cnt = COUNT(*) FROM @customersbyCountryTab

IF @cnt = 0
	INSERT INTO @CustomersByCountryTab (
	CustomerID,CompanyName,
	ContactName,ContactTitle,
	Address,City,PostalCode, Country, Phone,Fax )
	VALUES ('','No Companies Found','','','','','','','','')

RETURN

END
GO 

-- execute
SELECT * FROM dbo.customersbycountry('USA') 
SELECT * FROM dbo.customersbycountry('CANADA') 
SELECT * FROM dbo.customersbycountry('ADF') 



/* Difference Between Function and Stored Procedure ★★★★★ */
/*
SP: Pre-Comipled				SP가 가장 많이 쓰이는 이유가 데이터 처리하는데 SP만큼 가장 빠른 게 없음. Pre-compiled라서. 단점: Debugging 힘듦.
Function: Not Pre-Compiled

SP: Can return more than one value
Function: only one at a time

SP: Cannot be called in DML, but can be executed independently
Function: Can be called in DML and it depends

SP: no limitation of return type
Function: cannot return image, text , timestamp

SP: mainly used for business logic
Function: mainly used for computation

SP: does not need to return value
Function: Must return

SP: parameters is either in or out
Function: always in, Out is Not possible


*/


