CREATE TABLE Deleted_Employees(
	EmployeeId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(255) NOT NULL,
	LastName NVARCHAR(255) NOT NULL,
	MiddleName NVARCHAR(255) NOT NULL,
	JobTitle NVARCHAR(255) NOT NULL,
	DepartmentId INT NOT NULL,
	Salary MONEY NOT NULL
)

CREATE TRIGGER trg_LogDeletedEmployees
ON Employees
AFTER DELETE
AS
	BEGIN
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT d.FirstName, d.LastName, d.MiddleName, d.JobTitle, d.DepartmentID, d.Salary
	FROM deleted d
END

DELETE FROM EmployeesProjects WHERE EmployeeID = 10
DELETE FROM Employees WHERE EmployeeID = 10

SELECT * FROM Deleted_Employees