SELECT 
	c.CountryCode, 
	COUNT(mc.MountainId) AS MountainRanges
FROM 
	Countries AS c
	JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
GROUP BY
	mc.CountryCode,
	c.CountryCode,
	c.CountryName
HAVING 
	c.CountryName IN('United States', 'Russia', 'Bulgaria');