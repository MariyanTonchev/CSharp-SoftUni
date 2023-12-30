SELECT
	hw.FirstName AS "Host Wizard",
	hw.DepositAmount AS "Host Wizard Deposit",
	gw.FirstName AS "Guest Wizard",
	gw.DepositAmount AS "Guest Deposit Aount",
	hw.DepositAmount - gw.DepositAmount AS "Difference"
FROM
	WizzardDeposits AS hw
JOIN
	WizzardDeposits AS gw ON hw.Id + 1 = gw.Id;

--SOLUTION

SELECT
	SUM(hw.DepositAmount - gw.DepositAmount) AS "Difference"
FROM 
	WizzardDeposits AS hw
JOIN
	WizzardDeposits AS gw ON hw.Id + 1 = gw.Id;