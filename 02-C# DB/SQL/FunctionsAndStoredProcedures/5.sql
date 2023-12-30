CREATE FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4))
RETURNS NVARCHAR(50)
AS
BEGIN
	DECLARE @SalaryLevel NVARCHAR(50)

	IF @salary < 30000
		SET @SalaryLevel = 'Low'
	ELSE IF @salary BETWEEN 30000 AND 50000
		SET @SalaryLevel = 'Average'
	ELSE
		SET @SalaryLevel = 'High'

	RETURN @SalaryLevel
END;