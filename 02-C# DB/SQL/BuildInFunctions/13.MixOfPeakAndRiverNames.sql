SELECT
    p.PeakName AS "Peak Name",
    r.RiverName AS "River Name",
    LOWER(CONCAT(SUBSTRING(p.PeakName, 1, LEN(p.PeakName) - 1), r.RiverName)) AS "Mix"
FROM Peaks p, Rivers r
WHERE LOWER(RIGHT(p.PeakName, 1)) = LOWER(LEFT(r.RiverName, 1))
ORDER BY "Mix";