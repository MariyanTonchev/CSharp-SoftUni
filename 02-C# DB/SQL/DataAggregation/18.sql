SELECT DISTINCT
	DepartmentID,
	ThirdHighestSalary
FROM
(
	SELECT
		DepartmentID,
		Salary AS ThirdHighestSalary,
		DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
	FROM
		Employees
) AS RankedSalaries
WHERE RankedSalaries.SalaryRank = 3