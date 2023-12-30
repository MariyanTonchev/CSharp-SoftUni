CREATE PROCEDURE usp_WithdrawMoney
(
	@AccountId INT,
	@MoneyAmount DECIMAL(18,4)
) AS
BEGIN
	IF(@MoneyAmount < 0)
		BEGIN
			RAISERROR('Value is negative', 16, 1);
		END;
	ELSE
		BEGIN
			IF(@AccountId IS NULL OR @MoneyAmount IS NULL)
				BEGIN
					RAISERROR('Missing value', 16, 1)
				END;
		END;
	BEGIN TRANSACTION;
		UPDATE Accounts
		SET Balance = Balance - @MoneyAmount
		WHERE Id = @AccountId;
		IF(@@ROWCOUNT < 1)
			BEGIN
				ROLLBACK;
				RAISERROR('Account does not exists', 16, 1);
			END;
	COMMIT;
END

EXEC usp_WithdrawMoney 1, 10