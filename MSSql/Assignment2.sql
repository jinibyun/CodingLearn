USE PUBS
GO

-- 1.INNER JOIN  ??


-- 2.OUTER JOIN
SELECT *
FROM stores s LEFT OUTER JOIN discounts d
ON s.stor_id = d.stor_id AND d.discounttype != NULL

-- 3.sale count per store  ??
SELECT t1.stor_id, COUNT(*) salesCount 
FROM sales t1
GROUP BY t1.stor_id
ORDER BY salesCount DESC
OFFSET 1 ROWS
FETCH FIRST 2 ROWS ONLY

-- 4.Change Subquery into INNER JOIN
SELECT * FROM titles
WHERE title_id IN (SELECT title_id FROM sales)

SELECT DISTINCT t.*
FROM titles t INNER JOIN sales s
ON t.title_id = s.title_id

-- 5.SELF JOIN
-- Self Join of a table is used when the table itself is used to reference data
-- Most popular example is how the employees are related (employee vs supervisor/manager)
SELECT a.emp_id AS "Emp_ID",a.emp_name AS "Employee Name",
b.emp_id AS "Supervisor ID",b.emp_name AS "Supervisor Name"
FROM employee a, employee b
WHERE a.emp_supv = b.emp_id;

-- 6.CREATE TABLE USING SCRIPT
CREATE TABLE Customer(
	ID int PRIMARY KEY identity (1,1),
	UserName varchar(14) NOT NULL,
	Email varchar(30) NOT NULL,
	Password varchar(20) NOT NULL,
	FirstName varchar(20) NOT NULL,
	LastName varchar(20) NOT NULL,
	MiddleName varchar(20),
	Address1 varchar(30),
	Address2 varchar(20),
	City varchar(20),
	PostalCode varchar(20),
	Province varchar(20),
	Country varchar(20),
	HomePhone varchar(20),
	MobilePhone varchar(20),
	RegisterDate varchar(20) NOT NULL,
	FBAccount varchar(30),
	TwitterAccount varchar(30)
)

CREATE TABLE Request(
	ID int PRIMARY KEY identity(1,1),
	CustomerID int Foreign Key REFERENCES Customer(ID),
	RequestContent varchar(30) NOT NULL,
	RequestDate varchar(20),
	CompletedDate varchar(20),
	Status varchar(20) NOT NULL,
	Comment varchar(30),
	IsNotifiedToCustomer varchar(5) NOT NULL,
	ISNotifiedToTechnician varchar(5) NOT NULL
)

SELECT * FROM Customer

-- 7.INSERT DATA TO THE CUSTOMER TABLE
INSERT INTO Customer(UserName,Email,Password,FirstName,LastName,Address1,City,Province,Country,MobilePhone,RegisterDate)
VALUES ('JPAOLO','J.Paul@gmail.com','John1234','John','Paul', '123 Yonge Street', 'Toronto', 'Ontario', 'Canada', '6471112222', 'Nov-5-2018')

INSERT INTO Customer(UserName,Email,Password,FirstName,LastName,Address1,Address2,City,Province,Country,HomePhone,RegisterDate)
VALUES ('GPIERCE','GuyPIERCE@gmail.com','GP1234','Guy','Pierce', '3 St.Catherine Street', 'Unit 1803','Montreal', 'Quebec', 'Canada', '4161112222', 'Nov-1-2018')

SELECT * FROM Request

-- 8.INSERT DATA TO THE REQUEST TABLE
INSERT INTO Request(RequestContent, RequestDate, Status, Comment, IsNotifiedToCustomer,ISNotifiedToTechnician)
VALUES ('Refund from sale', 'Nov-1-2018', 'In Progress', 'Sale within 30 days', 'Yes', 'No')

UPDATE Request
SET CustomerID=4
WHERE ID = 1

INSERT INTO Request(RequestContent, CustomerID,RequestDate, Status, Comment, IsNotifiedToCustomer,ISNotifiedToTechnician)
VALUES ('Update Profile', 4, 'Nov-1-2018', 'In Progress', 'Update the address', 'Yes', 'Yes')

INSERT INTO Request(RequestContent, CustomerID,RequestDate, Status, Comment, IsNotifiedToCustomer,ISNotifiedToTechnician)
VALUES ('Unsubscription', 9, 'Nov-3-2018', 'Complete', 'Email unsubscribed', 'Yes', 'Yes')

UPDATE Request
SET CompletedDate = 'Nov-4-2018'
WHERE ID = 3

INSERT INTO Request(RequestContent, CustomerID,RequestDate,CompletedDate, Status, Comment, IsNotifiedToCustomer,ISNotifiedToTechnician)
VALUES ('Reset Password', 9, 'Nov-1-2018', 'Nov-5-2018', 'Complete', 'New password sent to the email', 'Yes', 'Yes')

-- 9.Referential Integrity

--Error
DELETE FROM Customer WHERE ID = 4 
--Error
INSERT INTO Request(RequestContent, CustomerID,RequestDate,CompletedDate, Status, Comment, IsNotifiedToCustomer,ISNotifiedToTechnician)
VALUES ('Reset Password', 99, 'Nov-1-2018', 'Nov-5-2018', 'Complete', 'New password sent to the email', 'Yes', 'Yes')

-- 10.Stored Procedure
CREATE PROCEDURE uspGetCustomer
@userID varchar(14)
AS
BEGIN
	SELECT * FROM Customer
	WHERE USERNAME = @userID
END

EXEC uspGetCustomer 'JPAOLO'

-- 11.Stored Procedure & Join
CREATE PROCEDURE uspGetCustomerRequest
@userID varchar(14)
AS
BEGIN
	SELECT c.Email, c.Address1, c.City, c.PostalCode, c.Province, r.RequestDate, r.RequestContent, r.Comment
	FROM Customer c JOIN Request r
	ON USERNAME = @userID
END

EXEC uspGetCustomerRequest 'GPIERCE'


-- 12.Stored Procedure & Insert
CREATE PROCEDURE uspAddCustomerRequest
@vCustomerID int,
@vUsername varchar(14), @vRequestContent varchar(30), @vRequestDate varchar(20), @vCompletedDate varchar(20),
@vStatus varchar(20), @vComment varchar(30), @vIsNotifiedToCustomer varchar(5), @vIsNotifiedtoTechnician varchar(5)
AS
BEGIN
	UPDATE Request 
	SET RequestContent = @vRequestContent,
		RequestDate = @vRequestDate,
		CompletedDate = @vCompletedDate,
		Status = @vStatus,
		Comment = @vComment,
		IsNotifiedToCustomer = @vIsNotifiedToCustomer,
		ISNotifiedToTechnician = @vIsNotifiedtoTechnician
	WHERE CustomerID = @vCustomerID
	RETURN @@ROWCOUNT
END

EXEC uspAddCustomerRequest 4,'JPAOLO', 'Email', 'Nov-1-2018', 'Nov-5-2018', 'In Progress', 'Email unsubscribe', 'Yes', 'Yes'