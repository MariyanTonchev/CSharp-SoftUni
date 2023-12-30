CREATE PROCEDURE usp_EmployeesBySalaryLevel(@LevelOfSalary NVARCHAR(7))
AS
BEGIN
	SELECT 
		FirstName AS "First Name",
		LastName AS "Last Name"
    FROM 
		Employees
    WHERE 
		dbo.ufn_GetSalaryLevel(Salary) = @LevelOfSalary
END;