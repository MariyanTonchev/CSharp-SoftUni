CREATE PROCEDURE usp_AssignProject(
	@employeeId INT,
	@projectId INT
) 
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @projectCoount INT;

		SELECT  @projectCoount = COUNT(*)
		FROM EmployeesProjects
		WHERE EmployeeID = @employeeId
		
		IF @projectCoount >= 3
		BEGIN
			RAISERROR('The employee has too many projects!', 16, 1);
			ROLLBACK
			RETURN
		END

	INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
	VALUES (@employeeId, @projectId);
		
	COMMIT
END
