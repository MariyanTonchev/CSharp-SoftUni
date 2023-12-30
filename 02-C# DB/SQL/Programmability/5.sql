CREATE PROCEDURE usp_TransferMoney
(
	@SenderId INT,
	@ReceiverId INT, 
	@MoneyAmount DECIMAL(18,4)
) AS
BEGIN
	IF(@MoneyAmount < 0)
		BEGIN
			RAISERROR('Value is negative', 16, 1);
		END;
	ELSE
		BEGIN
			IF(@SenderId IS NULL OR @MoneyAmount IS NULL OR @ReceiverId IS NULL)
				BEGIN
					RAISERROR('Missing value', 16, 1)
				END;
		END;
	BEGIN TRANSACTION;
		UPDATE Accounts
		SET Balance = Balance - @MoneyAmount
		WHERE Id = @SenderId;
		IF(@@ROWCOUNT < 1)
			BEGIN
				ROLLBACK;
				RAISERROR('Account does not exists', 16, 1);
			END;

		UPDATE Accounts
		SET Balance = Balance + @MoneyAmount
		WHERE Id = @ReceiverId
		IF(@@ROWCOUNT < 1)
			BEGIN
				ROLLBACK;
				RAISERROR('Account does not exists', 16, 1);
			END;
	COMMIT;
END