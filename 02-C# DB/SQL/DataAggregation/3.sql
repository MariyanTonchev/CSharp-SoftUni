SELECT 
	DepositGroup, 
	MAX(MagicWandSize) AS LongestMegicWand 
FROM WizzardDeposits 
GROUP BY DepositGroup