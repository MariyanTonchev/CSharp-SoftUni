SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepostiCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator ASC, DepositGroup ASC;