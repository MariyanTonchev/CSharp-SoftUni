SELECT e.EmployeeID, e.FirstName, 
	CASE WHEN YEAR(p.StartDate) >= 2005 THEN NULL ELSE p.Name END AS "ProjectName"
FROM Employees e
JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE ep.EmployeeID = 24;
