1. БД sqltestcasedb створюється автоматично, 
для її заповнення можна натиснути "Fill database with test data" (в футері)

2. Для тестування додатку можна використати такі SQL-запити:

```sql
CREATE TABLE Persons (
    PersonID int,
    LastName varchar(255),
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255)
);

DROP TABLE Persons;

select Name, Price from products where category=1;

select Top 3 * from customers 

SELECT * FROM Customers ORDER BY Country ASC;

SELECT MIN(Price) FROM Products

SELECT MIN(Price), Max(Price) FROM Products

INSERT INTO Products(Name, Price, Category) VALUES ('Test Device', 100.25, 2);

UPDATE Products SET Price=400 WHERE ID=2;

DELETE FROM Customers WHERE FullName = 'Ewa Duda';

TRUNCATE TABLE Products;
```