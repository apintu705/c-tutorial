use AdventureWorks2012;

SELECT 'ABHISHEK','KUMAR';
SELECT 7*4;
SELECT (7-4)*8;
SELECT 'BREWSTER''S SQL TRAINING CLASS';
SELECT 'DAY 1 OF TRAINING ',5*3;

SELECT COUNT(*) FROM PERSON.PERSON;
SELECT FIRSTNAME,MIDDLENAME,LASTNAME FROM PERSON.PERSON;

SELECT TOP 10 FirstName+' '+MiddleName+' '+LastName AS 'CUSTOMER NAME' FROM PERSON.PERSON
WHERE MiddleName != 'NULL';

SELECT * FROM PERSON.PERSON;

SELECT TOP 100 * FROM Production.PRODUCT;




SELECT * FROM HumanResources.vEmployee;
SELECT * FROM HumanResources.Employee;

SELECT TOP 12 FIRSTNAME,LASTNAME,EMAILADDRESS,PHONENUMBER FROM SALES.vIndividualCustomer;



SELECT NationalIDNumber FROM HumanResources.Employee;

SELECT NationalIDNumber,JobTitle FROM HumanResources.Employee;

SELECT TOP 20 PERCENT NationalIDNumber,JobTitle,BirthDate FROM HumanResources.Employee;

SELECT TOP 20 PERCENT NationalIDNumber AS 'SSN',JobTitle AS ' JOB TITILE',BirthDate FROM HumanResources.Employee;

SELECT * FROM Sales.SalesOrderHeader;

SELECT TOP 50 PERCENT * FROM Sales.Customer;

SELECT Name AS 'PRODUCT''S NAME' FROM Production.vProductAndDescription;

SELECT TOP 400 * FROM HumanResources.Department;

SELECT * FROM Production.BillOfMaterials;

SELECT TOP 1500 * FROM Sales.vPersonDemographics;



SELECT * FROM Production.Product
WHERE ListPrice > 10;

SELECT * FROM HumanResources.vEmployee
WHERE FirstName = 'CHRIS';

SELECT * FROM HumanResources.vEmployee
WHERE FirstName <> 'CHRIS';

SELECT * FROM HumanResources.Employee
WHERE BirthDate < '1-1-1980';

SELECT * FROM HumanResources.Employee
WHERE BirthDate >= '1/1/1980' AND Gender = 'F';

SELECT * FROM HumanResources.Employee
WHERE MaritalStatus = 'S' AND Gender = 'M';

SELECT * FROM HumanResources.Employee
WHERE MaritalStatus = 'S' OR Gender = 'M';

SELECT * FROM HumanResources.Employee
WHERE (MaritalStatus = 'S' AND Gender = 'M') OR OrganizationLevel = 4;

SELECT * FROM HumanResources.Employee
WHERE MaritalStatus='S' AND (Gender = 'M' OR OrganizationLevel =4);

SELECT * FROM HumanResources.vEmployeeDepartment
WHERE Department = 'RESEARCH AND DEVELOPMENT' OR(StartDate < '1/1/2005'
AND Department = 'EXECUTIVE');

SELECT * FROM Sales.vStoreWithDemographics
WHERE (AnnualSales > 1000000 AND BusinessType = 'OS') OR
(YearOpened < 1990 AND SquareFeet > 40000 AND NumberEmployees >10);

SELECT * FROM HumanResources.vEmployee
WHERE FirstName = 'CHRIS' OR FirstName = 'STEVE'
OR FirstName='MICHAEL' OR FirstName='THOMAS';

SELECT * FROM HumanResources.vEmployee
WHERE FirstName IN ('CHRIS', 'STEVE', 'MICHAEL' ,'THOMAS');

SELECT * FROM Sales.vStoreWithDemographics
WHERE AnnualRevenue BETWEEN 100000 AND 200000;

SELECT * FROM HumanResources.vEmployee
WHERE FirstName LIKE 'MI_'

SELECT * FROM HumanResources.vEmployee
WHERE FirstName LIKE 'D[A-F,R-Z]N';

SELECT * FROM Person.Person
WHERE MiddleName IS NOT NULL;

SELECT FIRSTNAME,LASTNAME FROM PERSON.PERSON
WHERE FirstName = 'MARK';

SELECT TOP 100 * FROM Production.Product
WHERE ListPrice <> 0.00;

SELECT * FROM Person.StateProvince
WHERE CountryRegionCode = 'CA';

SELECT FirstName AS 'Customer first name', LastName AS 'Customer last name' FROM Sales.vIndividualCustomer
WHERE LastName='SMITH';

SELECT * FROM SALES.vIndividualCustomer
WHERE CountryRegionName='AUSTRALIA' OR (PhoneNumberType='CELL' AND EmailPromotion=0);

SELECT * FROM HumanResources.vEmployeeDepartment
WHERE Department IN ('EXECUTIVE','TOOL DESIGN','ENGINEERING');

SELECT * FROM HumanResources.vEmployeeDepartment
WHERE StartDate BETWEEN '7/1/2000' AND '6/30/2002';

SELECT * FROM Sales.vIndividualCustomer
WHERE LastName LIKE 'R%';

SELECT * FROM Sales.vIndividualCustomer
WHERE LastName LIKE '%R';

SELECT * FROM Sales.vIndividualCustomer
WHERE LastName IN ('LOPEZ','MARTIN','WOOD') AND FirstName LIKE '[C-L]%';

SELECT * FROM Sales.SalesOrderHeader
WHERE SalesPersonID IS NOT NULL;

SELECT SalesPersonID,TotalDue FROM Sales.SalesOrderHeader
WHERE SalesPersonID IS NOT NULL AND TotalDue >70000;

SELECT FIRSTNAME,LASTNAME FROM Sales.vIndividualCustomer
ORDER BY 2;

SELECT FIRSTNAME,LASTNAME FROM Sales.vIndividualCustomer
WHERE LastName='ZIMMERMAN' ORDER BY FirstName;

SELECT FIRSTNAME,LASTNAME FROM Sales.vIndividualCustomer
ORDER BY LastName,FirstName DESC;

SELECT LASTNAME,FIRSTNAME,SALESQUOTA FROM Sales.vSalesPerson
WHERE SALESQUOTA >= 25000
ORDER BY SALESQUOTA DESC, LASTNAME ASC;

SELECT FIRSTNAME,LASTNAME,JobTitle FROM HumanResources.vEmployeeDepartment
ORDER BY FirstName ASC;

SELECT FIRSTNAME,LASTNAME,JobTitle FROM HumanResources.vEmployeeDepartment
ORDER BY FirstName ASC, LastName DESC;

SELECT FirstName,LastName,CountryRegionName FROM Sales.vIndividualCustomer
ORDER BY 3;

SELECT FirstName,LastName,CountryRegionName FROM Sales.vIndividualCustomer
WHERE CountryRegionName IN ('UNITED STATES','FRANCE')
ORDER BY 3 ASC;

SELECT Name,AnnualSales,YearOpened,SquareFeet AS [Store Size], NumberEmployees AS [Total Employees] FROM SALES.vStoreWithDemographics
where ANNUALSALES > 1000000 AND NUMBEREMPLOYEES >=45
ORDER BY [Store size] DESC, [Total Employees] DESC;

SELECT P.Name,P.ProductNumber,P.ProductSubcategoryID,PS.Name AS [PRODUCRSUBCATEGORY NAME] FROM Production.Product P
INNER JOIN Production.ProductSubcategory PS
ON P.ProductSubcategoryID = PS.ProductSubcategoryID

SELECT PS.Name AS [PRODUCTSUBCATE NAME],PC.Name AS [PRODUCTCATE NAME] FROM Production.ProductSubcategory PS
INNER JOIN PRODUCTION.ProductCategory PC
ON PS.ProductCategoryID = PC.ProductCategoryID

SELECT P.FirstName,P.LastName,PE.EmailAddress,PP.PhoneNumber FROM Person.Person P
INNER JOIN Person.EmailAddress PE
ON P.BusinessEntityID = PE.BusinessEntityID
INNER JOIN Person.PersonPhone PP
ON PP.BusinessEntityID = P.BusinessEntityID;

SELECT P.FirstName,P.LastName,PS.PasswordHash FROM Person.Person P
INNER JOIN Person.Password PS
ON PS.BusinessEntityID = P.BusinessEntityID;

SELECT HE.BusinessEntityID,HE.NationalIDNumber,HE.JobTitle,HED.BusinessEntityID,HED.StartDate,HED.EndDate FROM HumanResources.Employee HE
INNER JOIN HumanResources.EmployeeDepartmentHistory HED
ON HE.BusinessEntityID = HED.BusinessEntityID;

SELECT P.FirstName,P.LastName,PS.PasswordHash,PE.EmailAddress FROM Person.Person P
INNER JOIN Person.Password PS
ON PS.BusinessEntityID = P.BusinessEntityID
INNER JOIN Person.EmailAddress PE
ON P.BusinessEntityID=PE.BusinessEntityID

SELECT B.TITLE,B,ISBN,A.NAME,P.PUBLISHERNAME FROM BOOKAUTHOR BA
INNER JOIN BOOK B
ON BA.BOOKID = B.BOOKID
INNER JOIN AUTOR A
ON BA.AUTHORID = A.AUTHORID;
INNER JOIN PUBLISHER P
ON P.PUBLISHERID = B.PUBLISHERID

SELECT P.Name,P.ProductNumber,P.ProductSubcategoryID,PS.Name AS [PRODUCRSUBCATEGORY NAME] FROM Production.Product P
LEFT OUTER JOIN Production.ProductSubcategory PS
ON P.ProductSubcategoryID = PS.ProductSubcategoryID

SELECT P.FirstName,P.LastName,SH.SalesOrderNumber,SH.TotalDue,ST.Name FROM Sales.SalesOrderHeader SH
LEFT OUTER JOIN Sales.SalesPerson SP
ON SP.BusinessEntityID = SH.SalesOrderID
LEFT OUTER JOIN HumanResources.Employee E
ON E.BusinessEntityID = SP.BusinessEntityID
LEFT OUTER JOIN PERSON.Person P
ON P.BusinessEntityID = E.BusinessEntityID
LEFT OUTER JOIN Sales.SalesTerritory ST
ON ST.TerritoryID = SH.TerritoryID
WHERE ST.Name = 'CANADA'
ORDER BY 4 DESC;

SELECT SP.BusinessEntityID,SP.SalesYTD,ST.Name AS [TERITORY NAME] FROM Sales.SalesPerson SP
LEFT OUTER JOIN Sales.SalesTerritory ST
ON ST.TerritoryID = SP.TerritoryID

SELECT P.FirstName,P.LastName,SP.BusinessEntityID,SP.SalesYTD,ST.Name AS [TERITORY NAME] FROM Sales.SalesPerson SP
LEFT OUTER JOIN Sales.SalesTerritory ST
ON ST.TerritoryID = SP.TerritoryID
LEFT OUTER JOIN Person.Person P
ON P.BusinessEntityID = SP.BusinessEntityID
WHERE ST.NAME IN ('NORTHEAST','CENTRAL')

SELECT 
P.Name AS [PRODUCT NAME],
P.ListPrice,
PSC.Name AS [PRODUCTSUBCATEGORY NAME],
PC.Name AS [PRODUCTCATEGORY NAME]
FROM Production.Product P
LEFT OUTER JOIN Production.ProductSubcategory PSC
ON P.ProductSubcategoryID = PSC.ProductSubcategoryID
LEFT OUTER JOIN Production.ProductCategory PC
ON PC.ProductCategoryID = PSC.ProductCategoryID
ORDER BY 4 DESC,3 ASC;

SELECT MAX(TOTALDUE) FROM Sales.SalesOrderHeader
SELECT TotalDue FROM Sales.SalesOrderHeader
ORDER BY 1 DESC;

SELECT MIN(TOTALDUE) FROM Sales.SalesOrderHeader
SELECT TotalDue FROM Sales.SalesOrderHeader
ORDER BY 1;

SELECT COUNT(*) FROM Sales.SalesOrderHeader
SELECT COUNT(SalesPersonID) FROM Sales.SalesOrderHeader

SELECT COUNT(DISTINCT FirstName) FROM PERSON.PERSON

SELECT AVG(TotalDue) FROM Sales.SalesOrderHeader

SELECT SUM(TotalDue) FROM Sales.SalesOrderHeader

SELECT SUM(TotalDue) FROM Sales.SalesOrderHeader
WHERE OrderDate BETWEEN '1/1/2006' AND '12/31/2006'

SELECT COUNT(*) FROM PERSON.PERSON;
SELECT COUNT(MIDDLENAME) FROM PERSON.PERSON;
SELECT AVG(StandardCost) FROM Production.Product

SELECT AVG(Freight) FROM Sales.SalesOrderHeader
WHERE TerritoryID=4;
SELECT MAX(ListPrice) FROM Production.Product

SELECT SUM(PP.ListPrice*PPI.Quantity) FROM Production.Product PP
INNER JOIN Production.ProductInventory PPI
ON PPI.ProductID = PP.ProductID
WHERE PP.ListPrice>0;

SELECT SalesPersonID,SUM(TOTALDUE) AS [TOTAL SALES] FROM SALES.SalesOrderHeader
GROUP BY SalesPersonID HAVING SalesPersonID IS NOT NULL;

SELECT ProductID, SUM(Quantity) AS [QUANTITY],COUNT(*)AS[TOTAL LOACTION] FROM Production.ProductInventory
GROUP BY ProductID

SELECT 
ST.Name AS [TERRITORY NAME],
P.FirstName+' '+P.LastName,
SUM(TOTALDUE) AS [TOTAL SALES]
FROM SALES.SalesOrderHeader SOH
INNER JOIN SALES.SalesPerson SP
ON SOH.SalesPersonID= SP.BusinessEntityID
INNER JOIN PERSON.PERSON P
ON P.BusinessEntityID = SP.BusinessEntityID
INNER JOIN Sales.SalesTerritory ST
ON ST.TerritoryID = SOH.TerritoryID
WHERE OrderDate BETWEEN '1/1/2006' AND '12/31/2006'
GROUP BY ST.NAME,P.FirstName,P.LastName
ORDER BY 1,2

SELECT 
PersonType,
COUNT(*)
FROM Person.Person
GROUP BY PersonType

SELECT Color,COUNT(*)
FROM Production.Product
WHERE Color IN ('RED','BLACK')
GROUP BY COLOR;

SELECT 
ST.Name,COUNT(*)
FROM Sales.SalesOrderHeader SOH
LEFT OUTER JOIN Sales.SalesTerritory ST
ON ST.TerritoryID = SOH.TerritoryID
WHERE OrderDate BETWEEN '1/7/2005' AND '12/31/2006'
GROUP BY ST.Name
ORDER BY 2 DESC;

CREATE PROCEDURE SPGETEMPLOYEE
AS 
BEGIN
SELECT FIRSTNAME,LASTNAME FROM PERSON.PERSON;
END

EXECUTE SPGETEMPLOYEE

CREATE PROCEDURE SPGETEMPLOYEEBYGENDER
@GENDER CHAR(1)='F',
@JOBTITLE NVARCHAR(50)
WITH ENCRYPTION
AS 
BEGIN
SELECT GENDER,JobTitle FROM HumanResources.Employee
WHERE GENDER = @GENDER AND JobTitle=@JOBTITLE
ORDER BY JobTitle
END

EXECUTE SPGETEMPLOYEEBYGENDER @GENDER = 'F',@JOBTITLE = 'Production Technician - WC60';
EXECUTE SP_HELPTEXT SPGETEMPLOYEEBYGENDER;

SELECT * FROM HumanResources.Employee

CREATE PROCEDURE SPGetEmployeeCounntByGender
@GENDER CHAR(1) ='F' ,
@EMPLOYEECOUNT INT OUTPUT
AS
BEGIN
SELECT COUNT(NationalIDNumber) FROM HumanResources.Employee
WHERE Gender = @GENDER
END

DECLARE @TOTALCOUNT INT;
EXECUTE SPGetEmployeeCounntByGender  @EMPLOYEECOUNT = 30;
PRINT @TOTALCOUNT;

SELECT * FROM PERSON.Address

CREATE INDEX IX_PersonAddress
ON PERSON.ADDRESS (STATEPROVINCEID ASC)

execute sp_helpindex 'Person.address';




