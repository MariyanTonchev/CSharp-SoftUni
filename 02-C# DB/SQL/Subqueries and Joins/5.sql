SELECT TOP 3 EmployeeID, FirstName
FROM Employees
WHERE NOT EXISTS (
    SELECT 1
    FROM EmployeesProjects
    WHERE EmployeesProjects.EmployeeID = Employees.EmployeeID
)
ORDER BY EmployeeID ASC;