SELECT
	ranked.ContinentCode,
	ranked.CurrencyCode,
	ranked.CurrencyUsage
FROM 
(
	SELECT 
		usage.ContinentCode,
		usage.CurrencyCode,
		usage.CurrencyUsage,
		DENSE_RANK() OVER(PARTITION BY usage.ContinentCode ORDER BY usage.CurrencyUsage DESC) AS UsageRank
	FROM
	(
		SELECT 
			ContinentCode,
			CurrencyCode,
			COUNT(CurrencyCode) AS CurrencyUsage
		FROM 
			Countries
		GROUP BY 
			ContinentCode,
			CurrencyCode
		HAVING COUNT(CurrencyCode) > 1
	) AS usage
) AS ranked
WHERE ranked.UsageRank = 1
ORDER BY
	ranked.ContinentCode;