SELECT TOP 5 e.EmployeeID, e.FirstName, e.Salary, d.Name
FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID 
WHERE e.Salary > 1500
ORDER BY d.DepartmentID ASC;