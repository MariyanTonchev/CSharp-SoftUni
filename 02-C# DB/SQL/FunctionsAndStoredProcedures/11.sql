CREATE FUNCTION ufn_CalculateFutureValue
(
	@initialSum MONEY,
	@interestRate FLOAT,
	@years INT
) RETURNS MONEY
AS
BEGIN
	RETURN @initialSum * POWER(1 + @interestRate, @years);
END;