Exercise:
Check prime function
chkPrime(list_price) : returns even, odd, oddprime

chkPrime(@n int):
According to logic return either ‘even’ or ‘odd’ or ‘oddprime’

select chkPrime(8); --even
select chkPrime(13); --oddPrime
select chkPrime(9); --odd
select list_price, chkPrime(list_price) as ckPrime from ..products;



CREATE FUNCTION chkPrime(@n INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
    DECLARE @isPrime BIT = 1;
    
    IF @n <= 1
        SET @isPrime = 0;
		
    ELSE
    BEGIN
        DECLARE @i INT = 2;
        WHILE @i <= SQRT(@n)
        BEGIN
            IF @n % @i = 0
            BEGIN
                SET @isPrime = 0;
                BREAK;
            END
            SET @i = @i + 1;
        END
    END
    
    IF @isPrime = 1
        RETURN 'Odd_prime';
    ELSE IF @n % 2 = 0
        RETURN 'Even';
    ELSE
        RETURN 'Odd';
return 'NaN';
END;


SELECT dbo.chkPrime(8); 
SELECT dbo.chkPrime(13);
SELECT dbo.chkPrime(9); 
SELECT salary, dbo.chkPrime(salary) AS Check_Prime FROM customers;

select list_price ,dbo.chkPrime(list_price) as Check_Prime from bikestores.production.products;



drop table if exists customers;
select* into customers from BikeStores.sales.customers;
select* from customers;

Define a table variable function which has same number of rows as customers with columns as:
Customer_id : same as table
Zip_code : same as table
Eligible4Gift: calculated as (yes/no) according to whether the zip_code is prime or not. (use the scalar function chkPrime() and case..when..then or if..else to insert the value into the table variable).
The function returns the table to be displayed later.
