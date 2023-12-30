CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber
(
	@SalaryThreshold DECIMAL(18,4)
)
AS
	BEGIN
		SELECT
			FirstName AS "First Name",
			LastName AS "Last Name"
		FROM
			Employees
		WHERE
			Salary >= @SalaryThreshold
	END;