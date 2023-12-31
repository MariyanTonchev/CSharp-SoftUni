CREATE PROCEDURE usp_DeleteEmployeesFromDepartment
(
	@departmentId INT
)
AS
	BEGIN
		ALTER TABLE Employees ALTER COLUMN DepartmentID INT;

		UPDATE Employees SET DepartmentID = NULL
		WHERE EmployeeID IN (
		(
			SELECT EmployeeID
			FROM Employees
			WHERE DepartmentID = @departmentId
		));

		UPDATE Employees SET ManagerID = NULL
		WHERE ManagerID IN (
		(
			SELECT EmployeeID
			FROM Employees
			WHERE DepartmentID = @departmentId
		));

		ALTER TABLE Departments ALTER COLUMN ManagerID INT;

		UPDATE Departments SET ManagerID = NULL
		WHERE DepartmentID = @departmentId;

		DELETE FROM Employees
		WHERE DepartmentID = @departmentId;

		DELETE FROM Departments
		WHERE DepartmentID = @departmentId;

		SELECT COUNT(*) AS EmployeeCount
		FROM Employees
		WHERE DepartmentID = @departmentId
	END;

EXEC usp_DeleteEmployeesFromDepartment 1