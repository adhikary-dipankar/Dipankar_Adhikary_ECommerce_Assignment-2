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
RETURNS VARCHAR(20)
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
        RETURN 'oddprime';
    ELSE IF @n % 2 = 0
        RETURN 'even';
    ELSE
        RETURN 'odd';
END;


-- Example usage
SELECT chkPrime(8); -- Returns 'even'
SELECT chkPrime(13); -- Returns 'oddprime'
SELECT chkPrime(9); -- Returns 'odd'
SELECT list_price, chkPrime(list_price) AS ckPrime FROM products;
