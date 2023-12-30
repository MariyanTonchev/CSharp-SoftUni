SELECT CONCAT_WS(' ', FirstName, COALESCE(MiddleName, ''), LastName) AS "Full Name"
FROM Employees 
WHERE Salary IN (25000, 14000, 12500, 25000)