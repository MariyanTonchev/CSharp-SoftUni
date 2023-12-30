CREATE PROCEDURE usp_CalculateFutureValueForAccount
(
	@accountId INT,
	@interest FLOAT
)
AS
BEGIN
	SELECT
		@accountId AS "Account Id",
		ah.FirstName AS "First Name",
		ah.LastName AS "Last Name",
		a.Balance AS "Current Balance",
		dbo.ufn_CalculateFutureValue(a.Balance, @interest, 5) AS "Balance in 5 years"
	FROM
		Accounts AS a
		JOIN AccountHolders AS ah ON ah.Id = a.AccountHolderId
	WHERE
		a.Id = @accountId
END