-- Select specific columns from the Towns table and order alphabetically by name
SELECT Name FROM Towns
ORDER BY Name;

-- Select specific columns from the Departments table and order alphabetically by name
SELECT Name FROM Departments
ORDER BY Name;

-- Select specific columns from the Employees table and order descending by salary
SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC;