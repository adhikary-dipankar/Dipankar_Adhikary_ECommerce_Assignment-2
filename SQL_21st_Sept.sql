Exercise:
Check prime function
chkPrime(list_price) : returns even, odd, oddprime

chkPrime(@n int):
According to logic return either ‘even’ or ‘odd’ or ‘oddprime’

select chkPrime(8); --even
select chkPrime(13); --oddPrime
select chkPrime(9); --odd
select list_price, chkPrime(list_price) as ckPrime from ..products;
