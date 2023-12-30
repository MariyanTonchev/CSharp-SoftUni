SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS "DeptName" 
FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate > '1.1.1999'
AND (d.Name = 'Sales' OR d.Name = 'Finance')
ORDER BY HireDate ASC;