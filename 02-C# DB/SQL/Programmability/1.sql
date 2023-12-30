CREATE TABLE Logs
(
	LogId INT NOT NULL IDENTITY,
	AccountID INT NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL,
	CONSTRAINT PK_Logs PRIMARY KEY (LogId),
	CONSTRAINT FK_Logs_Account FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
);
GO

CREATE TRIGGER trg_AccountLogsAfterUpdate ON Accounts
FOR UPDATE
AS
	BEGIN
		INSERT INTO Logs
		VALUES
		(
		(
			SELECT Id
			FROM deleted
		),
		(
			SELECT Balance
			FROM deleted
		),
		(
			SELECT Balance
			FROM inserted
		)
		);
	END;