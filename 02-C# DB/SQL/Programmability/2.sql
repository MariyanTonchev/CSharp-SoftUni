CREATE TABLE NotificationEmails
(
	Id INT NOT NULL IDENTITY,
	Recipient INT NOT NULL,
	Subject NVARCHAR(50) NOT NULL,
	Body NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_NotificationEmails PRIMARY KEY(Id)
);
GO

CREATE TRIGGER trg_LogsNotificationEmails ON Logs
FOR INSERT
AS
BEGIN
    INSERT INTO NotificationEmails (Recipient, Subject, Body)
    SELECT
        i.AccountId,
        CONCAT('Balance change for account: ', i.AccountId),
        CONCAT('On ', FORMAT(GETDATE(), 'dd-MM-yyyy HH:mm'), ' your balance was changed from ', l.OldSum, ' to ', l.NewSum, '.')
    FROM
        inserted i
    JOIN
        Logs l ON i.LogId = l.LogId;
END;