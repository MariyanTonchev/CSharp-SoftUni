SELECT TOP (5)
	r.CountryName AS Country,
	ISNULL(r.PeakName, '(no highest peak)') AS HighestPeakName,
	ISNULL(r.Elevation, 0) AS HighestPeakElevation,
	ISNULL(r.MountainRange, '(no mountain)') AS Mountain
FROM
(
	SELECT
		c.CountryName,
		DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRank,
		p.PeakName,
		p.Elevation,
		m.MountainRange
	FROM 
		Countries AS c
		LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
		LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
		LEFT JOIN Peaks AS p ON m.Id = p.MountainId
) AS r
WHERE 
	r.PeakRank = 1
ORDER BY
	r.CountryName,
	r.PeakName